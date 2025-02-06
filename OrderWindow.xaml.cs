using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ADETProjApp.Model;
using ADETProjApp.View;
using ADETProjApp.ViewModel;

namespace ADETProjApp
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public string username;
        public OrderWindow(string username)
        {
            InitializeComponent();
            this.username = username;
            UserVM userVM = new UserVM();
            userVM.userDB(this.username);
            ContentArea.Content = new FoodContent();
        }

        private void foodBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(foodBtn.IsChecked == true)
            {
                ContentArea.Content = new FoodContent();
                cartBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void cartBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (cartBtn.IsChecked == true)
            {
                ContentArea.Content = new CartContent();
                foodBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void orderBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (orderBtn.IsChecked == true)
            {
                ContentArea.Content = new OrderContent();
                cartBtn.IsChecked = false;
                foodBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void historyBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (historyBtn.IsChecked == true)
            {
                ContentArea.Content = new HistoryContent();
                cartBtn.IsChecked = false;
                foodBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void profileBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (profileBtn.IsChecked == true)
            {
                ContentArea.Content = new ProfileContent();
                cartBtn.IsChecked = false;
                foodBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void pointsBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (pointsBtn.IsChecked == true)
            {
                ContentArea.Content = new PointsContent();
                cartBtn.IsChecked = false;
                foodBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                gamesBtn.IsChecked = false;
            }
        }

        private void gamesBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (gamesBtn.IsChecked == true)
            {
                ContentArea.Content = new GamesContent();
                cartBtn.IsChecked = false;
                foodBtn.IsChecked = false;
                orderBtn.IsChecked = false;
                historyBtn.IsChecked = false;
                profileBtn.IsChecked = false;
                pointsBtn.IsChecked = false;
            }
        }

        private void toggleBtns_Unchecked(object sender, RoutedEventArgs e)
        {
            if(foodBtn.IsChecked == false && gamesBtn.IsChecked == false && pointsBtn.IsChecked == false && profileBtn.IsChecked == false && historyBtn.IsChecked == false && orderBtn.IsChecked == false && cartBtn.IsChecked == false && historyBtn.IsChecked == false )
            {
                ContentArea.Content = new FoodContent();
            }
        }

        private void outBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
