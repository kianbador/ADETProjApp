using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ADETProjApp.Commands;
using ADETProjApp.Model;

namespace ADETProjApp.ViewModel
{
    public class FoodVM : INotifyPropertyChanged
    {
        public ObservableCollection<Food> AlaCarte { get; }
        public ObservableCollection<Food> Sides { get; }
        public ObservableCollection<Food> SoloValue { get; }
        public ObservableCollection<Food> MatchyCombo { get; }
        public ObservableCollection<Food> Pizza { get; }
        public ObservableCollection<Food> Drinks { get; }

        public ObservableCollection<Food> Desserts { get; }
        public ObservableCollection<Cart> CartItems { get; set; }

        public ICommand AddToCartCommand { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public FoodVM()
        {
            AlaCarte = FoodDetails.GetAlaCarte();
            Sides = FoodDetails.GetSides();
            SoloValue = FoodDetails.GetSoloValue();
            MatchyCombo = FoodDetails.GetMatchyCombo();
            Pizza = FoodDetails.GetPizza();
            Drinks = FoodDetails.GetDrinks();
            Desserts = FoodDetails.GetDesserts();
            AddToCartCommand = new RelayCommand(ExecuteAddToCartCommand, CanExecuteAddToCartCommand);
            IncrementCommand = new RelayCommand(ExecuteIncrementCommand, CanExecuteIncrementCommand);
            DecrementCommand = new RelayCommand(ExecuteDecrementCommand, CanExecuteDecrementCommand);
        }

        private bool CanExecuteAddToCartCommand(object parameter)
        {
            return true;
        }

        private void ExecuteAddToCartCommand(object parameter)
        {
            if (parameter is Food food1)
            {
                if (food1.Quantity == 0)
                {
                    MessageBox.Show("Quantity is zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Cart cart = new Cart()
                    {
                        Id = food1.Id,
                        Quantity = food1.Quantity,
                        foodName = food1.foodName,
                        price = food1.price,
                        imagePath = food1.imagePath
                    };
                    CartManage.AddItemToCart(cart);
                }
            }
            CartItems = new ObservableCollection<Cart>(
                AlaCarte.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                Sides.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                SoloValue.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                MatchyCombo.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                Pizza.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                Drinks.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            CartItems = new ObservableCollection<Cart>(
                Desserts.Where(f => f.Quantity > 0).Select(f => new Cart { Id = f.Id, foodName = f.foodName, price = f.price })
            );
            foreach (var food in AlaCarte)
            {
                food.Quantity = 0;
            }
            foreach (var food in Sides)
            {
                food.Quantity = 0;
            }
            foreach (var food in SoloValue)
            {
                food.Quantity = 0;
            }
            foreach (var food in MatchyCombo)
            {
                food.Quantity = 0;
            }
            foreach (var food in Pizza)
            {
                food.Quantity = 0;
            }
            foreach (var food in Drinks)
            {
                food.Quantity = 0;
            }
            foreach (var food in Desserts)
            {
                food.Quantity = 0;
            }
            OnPropertyChanged(nameof(AlaCarte));
            OnPropertyChanged(nameof(Sides));
            OnPropertyChanged(nameof(SoloValue));
            OnPropertyChanged(nameof(MatchyCombo));
            OnPropertyChanged(nameof(Pizza));
            OnPropertyChanged(nameof(Drinks));
            OnPropertyChanged(nameof(Desserts));
        }

        private bool CanExecuteIncrementCommand(object parameter)
        {
            return true; 
        }

        private void ExecuteIncrementCommand(object parameter)
        {
            if (parameter is Food food)
            {
                food.Quantity++;
                OnPropertyChanged(nameof(AlaCarte));
                OnPropertyChanged(nameof(Sides));
                OnPropertyChanged(nameof(SoloValue));
                OnPropertyChanged(nameof(MatchyCombo));
                OnPropertyChanged(nameof(Pizza));
                OnPropertyChanged(nameof(Drinks));
                OnPropertyChanged(nameof(Desserts));
            }
        }

        private bool CanExecuteDecrementCommand(object parameter)
        {
            if (parameter is Food food)
            {
                return food.Quantity >= 0;
            }
            return false;
        }

        private void ExecuteDecrementCommand(object parameter)
        {
            if (parameter is Food food)
            {
                if (food.Quantity > 0)
                {
                    food.Quantity--;
                    OnPropertyChanged(nameof(AlaCarte));
                    OnPropertyChanged(nameof(Sides));
                    OnPropertyChanged(nameof(SoloValue));
                    OnPropertyChanged(nameof(MatchyCombo));
                    OnPropertyChanged(nameof(Pizza));
                    OnPropertyChanged(nameof(Drinks));
                    OnPropertyChanged(nameof(Desserts));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
