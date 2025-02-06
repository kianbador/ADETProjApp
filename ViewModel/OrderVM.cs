using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using ADETProjApp.Commands;
using ADETProjApp.Model;
using MySql.Data.MySqlClient;



namespace ADETProjApp.ViewModel
{
    public class OrderVM : INotifyPropertyChanged
    {
        public ObservableCollection<Orders> AllOrders { get; set; }
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand DeleteOrder { get; }
        public ICommand ReceiveOrder { get; }
        public OrderVM()
        {
            AllOrders = OrderManage.GetOrders();

            DeleteOrder = new RelayCommand(ExecuteDeleteOrder, CanExecuteDeleteOrder);
            ReceiveOrder = new RelayCommand(ExecuteReceiveOrder, CanExecuteReceiveOrder);
        }

        private bool CanExecuteReceiveOrder(object obj)
        {
            return true;
        }

        private void ExecuteReceiveOrder(object obj)
        {
            if (obj is Orders order)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you received your order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                string order_id = order.order_id;
                string description = order.description.Replace("\n", " ");
                string username = order.username;
                string status = "Order Received";
                string price = order.price;
                double tempPoints = (Convert.ToDouble(price))/50;
                int points= Convert.ToInt32(tempPoints);
                User = UserManage.GetUser();
                UserManage.UpdateAddPoints(points);
                OnPropertyChanged(nameof(User));
                OnPropertyChanged(nameof(points));
                MySqlConnection conn = DBConnection.connectDB();
                try
                {
                    string query = "Insert into history_tbl (username, order_id, status, description, price) Values (@username, @order_id, @status, @description, @price)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    if (points != 0)
                    {
                        query = "UPDATE user_tbl SET points = points + @points WHERE username = @username";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@points", points.ToString());
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{points.ToString()} points added successfully to @{username}.");
                        }
                        else
                        {
                            MessageBox.Show($"No rows updated for {username}.");
                        }
                    }

                    conn.Close();
                }
                catch (Exception)
                {
                    conn.Close();
                }

                OrderManage.RemoveOrder(order_id);
            }
            OnPropertyChanged(nameof(AllOrders));
        }

        private bool CanExecuteDeleteOrder(object obj)
        {
            return true;
        }

        private void ExecuteDeleteOrder(object obj)
        {
            if (obj is Orders order)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel your order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                string order_id = order.order_id;
                string description = order.description.Replace("\n", " ");
                string username = order.username;
                string status = "Order Cancelled";
                string price = order.price;

                MySqlConnection conn = DBConnection.connectDB();
                try
                {
                    if(conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    string query = "Insert into history_tbl (username, order_id, status, description, price) Values (@username, @order_id, @status, @description, @price)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();


                    OrderManage.RemoveOrder(order_id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn?.Close();
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
