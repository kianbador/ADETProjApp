using ADETProjApp.Commands;
using ADETProjApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ADETProjApp.ViewModel
{
    public class CartVM : INotifyPropertyChanged
    {
        public ObservableCollection<Cart> CartItems { get; set; }

        private TotalPrice _totalPrice;

        public TotalPrice totalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(totalPrice));
                }
            }
        }

        public ICommand DeleteItemToCart {  get; }

        public CartVM()
        {
            CartItems = CartManage.GetCart();
            totalPrice = PriceManage.GetTotalPrice();
            CartItems.CollectionChanged += CartItems_CollectionChanged;

            foreach (var item in CartItems)
            {
                item.PropertyChanged += CartItem_PropertyChanged;
            }

            DeleteItemToCart = new RelayCommand(ExecuteDeleteItemToCart, CanExecuteDelteItemToCart);
            CalculateTotalPrice();
        }

        private void CartItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Cart item in e.NewItems)
                {
                    item.PropertyChanged += CartItem_PropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Cart item in e.OldItems)
                {
                    item.PropertyChanged -= CartItem_PropertyChanged;
                }
            }

            CalculateTotalPrice();
        }

        private void CartItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Cart.Quantity))
            {
                CalculateTotalPrice();
            }
        }

        private void CalculateTotalPrice()
        {
            totalPrice.totalPrice = CartItems.Sum(item => Convert.ToDecimal(item.price) * item.Quantity);
            PriceManage.SetTotalPrice(totalPrice.totalPrice);
            OnPropertyChanged(nameof(totalPrice));
        }


        private bool CanExecuteDelteItemToCart(object parameter)
        {
            return true;
        }

        private void ExecuteDeleteItemToCart(object parameter)
        {
            if (parameter is Cart cart)
            {
                string Id = cart.Id;
                CartManage.RemoveItemFromCart(Id);
            }
            OnPropertyChanged(nameof(CartItems));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
