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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paymongo.Sharp;
using Paymongo.Sharp.Checkouts.Entities;
using Paymongo.Sharp.Core.Entities;
using Paymongo.Sharp.Core.Enums;
using Paymongo.Sharp.Links.Entities;
using Paymongo.Sharp.Sources.Entities;
using Paymongo.Sharp.Utilities;
using ADETProjApp;
using ADETProjApp.View;
using ADETProjApp.ViewModel;
using System.Xml.Schema;
using ADETProjApp.Model;

namespace ADETProjApp
{
    /// <summary>
    /// Interaction logic for CartContent.xaml
    /// </summary>
    public partial class CartContent : UserControl
    {
        public TotalPrice totalPrice {  get; set; }
        public CartContent()
        {
            InitializeComponent();
        }

        private void checkOut_btn_Click(object sender, RoutedEventArgs e)
        {
            totalPrice = PriceManage.GetTotalPrice();
            decimal doubleAmount = totalPrice.totalPrice;

            if (doubleAmount <= 0)
            {
                MessageBox.Show("Cart is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PaymentOption paymentOption = new PaymentOption();
            paymentOption.ShowDialog();
        }
    }
}
