using ADETProjApp.Model;
using ADETProjApp.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Paymongo.Sharp;
using Paymongo.Sharp.Checkouts.Entities;
using Paymongo.Sharp.Core.Entities;
using Paymongo.Sharp.Core.Enums;
using Paymongo.Sharp.Links.Entities;
using Paymongo.Sharp.Sources.Entities;
using Paymongo.Sharp.Utilities;
using System.Security.Cryptography;

namespace ADETProjApp.View
{
    public partial class PaymentOption : INotifyPropertyChanged
    {
        public PaymentOption()
        {
            InitializeComponent();
        }
        public TotalPrice totalPrice { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Cart> CartItems { get; set; }
        private User User { get; set; }

        private async void proceedBtn_Click(object sender, RoutedEventArgs e)
        {
            string description = "";
            if (codRB.IsChecked == true)
            {
                User = UserManage.GetUser();
                CartItems = CartManage.GetCart();
                totalPrice = PriceManage.GetTotalPrice();                       
                string price = Convert.ToString(totalPrice.totalPrice);
                string payment1 = "Pay in Cash";
                string description1 = "";
                foreach (Cart cart in CartItems)
                {
                    description += $"{Convert.ToString(cart.Quantity)} x {cart.foodName}-";
                }
                foreach (Cart cart in CartItems)
                {
                    description1 += $"{Convert.ToString(cart.Quantity)} x {cart.foodName} \n";
                }
                MySqlConnection conn = DBConnection.connectDB();
                string username = Convert.ToString(User.username);

                DateTime now = DateTime.Now;

                string datetimeString = now.ToString();

                string md5Hash = GetMd5Hash(datetimeString);

                string order_id = md5Hash.Substring(0, 10);

                Orders order = new Orders()
                {
                    order_id = order_id,
                    username = username,
                    description = description1,
                    price = price,
                    payment = payment1,
                    date_ordered = DateTime.Now
                };

                OrderManage.AddOrder(order);

                try
                {
                    string query = "INSERT INTO order_tbl (order_id, username, description, price, payment) VALUES (@order_id, @username, @description, @price, @payment)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@payment", payment1);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    conn.Close();
                }

                CartManage.ClearCart();
                OnPropertyChanged(nameof(CartItems));
                this.Close();
                MessageBox.Show("Ordered Successfully.");
            }
            else if (onlineRB.IsChecked == true)
            {
                User = UserManage.GetUser();
                CartItems = CartManage.GetCart();
                totalPrice = PriceManage.GetTotalPrice();
                string text = totalPrice.totalPrice.ToString();
                var isDouble = decimal.TryParse(text, out decimal doubleAmount);

                if (!isDouble)
                {
                    return;
                }

                if (doubleAmount <= 0)
                {
                    MessageBox.Show("Cart is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (doubleAmount < 100)
                {
                    MessageBox.Show("Payment should be higher than Php 100.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int roundedValue = (int)Math.Round(doubleAmount);

                var secretKey = "sk_test_T2DhtFPfi7zD2UFtFeEwcinj";
                var client = new PaymongoClient(secretKey);

                var link = new Link
                {
                    Description = "Payment for an order.",
                    Amount = roundedValue,
                    Currency = Currency.Php
                };

                var linkResult = await client.Links.CreateLinkAsync(link);

                var paymentWindow = new PaymentWindow(linkResult.CheckoutUrl);
                paymentWindow.ShowDialog();

                while (true)
                {
                    var paymentStatus = await client.Links.RetrieveLinkAsync(linkResult.Id);

                    if (paymentStatus.Payments == null || !paymentStatus.Payments.Any())
                    {
                        continue;
                    }

                    var payment = paymentStatus.Payments.First();

                    if (payment != null && payment.Status != PaymentStatus.Paid)
                    {
                        continue;
                    }

                    paymentWindow.Close();
                    break;
                }
                string price = Convert.ToString(totalPrice.totalPrice);
                string description1 = "";
                string payment1 = "paid";
                foreach (Cart cart in CartItems)
                {
                    description += $"{Convert.ToString(cart.Quantity)} x {cart.foodName}-";
                }
                foreach (Cart cart in CartItems)
                {
                    description1 += $"{Convert.ToString(cart.Quantity)} x {cart.foodName} \n";
                }
                MySqlConnection conn = DBConnection.connectDB();
                string username = Convert.ToString(User.username);

                DateTime now = DateTime.Now;

                string datetimeString = now.ToString();

                string md5Hash = GetMd5Hash(datetimeString);

                string order_id = md5Hash.Substring(0, 10);

                Orders order = new Orders()
                {
                    order_id = order_id,
                    username = username,
                    description = description1,
                    price = price,
                    payment = payment1,
                    date_ordered = DateTime.Now
                };

                OrderManage.AddOrder(order);

                try
                {
                    string query = "INSERT INTO order_tbl (order_id, username, description, price, payment) VALUES (@order_id, @username, @description, @price, @payment)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@payment", payment1);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    conn.Close();
                }

                CartManage.ClearCart();
                OnPropertyChanged(nameof(CartItems));
                this.Close();
                MessageBox.Show("Payment Successful");
                MessageBox.Show("Ordered Successfully.");
            }
        }
        private static string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); 
                }
                return sb.ToString();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
