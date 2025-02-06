using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADETProjApp.Model
{
    public class OrderManage : INotifyPropertyChanged
    {
        public static ObservableCollection<Orders> Ordered = new ObservableCollection<Orders>();

        static OrderManage()
        {
            PopulateOrdersByDB();
        }

        private static void PopulateOrdersByDB()
        {
            User user = new User();
            user = UserManage.GetUser();
            string username = Convert.ToString(user.username);

            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "Select * from order_tbl where username=@username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            while (reader.Read())
                            {
                                string order_id = Convert.ToString(reader["order_id"]);
                                string orderUsername = Convert.ToString(reader["username"]);
                                string description = Convert.ToString(reader["description"]);
                                string[] descriptions = description.Split('-');
                                description = "";
                                foreach (string desc in descriptions)
                                {
                                    if (desc == "" || desc == " ")
                                    {
                                        continue;
                                    }
                                    description += desc;
                                    if (desc != descriptions.Last())
                                    {
                                        description += "\n";  
                                    }
                                }
                                string price = Convert.ToString(reader["price"]);
                                string payment = Convert.ToString(reader["payment"]);
                                DateTime date_ordered = Convert.ToDateTime(reader["date_ordered"]);

                                Orders orders = new Orders()
                                {
                                    order_id = order_id,
                                    username = orderUsername,
                                    description = description,
                                    price = price,
                                    payment = payment,
                                    date_ordered = date_ordered
                                };

                                Ordered.Add(orders);
                            }
                        }
                    }

                }
            }
            catch (Exception) { }
        }

        public static void RemoveOrder(string itemId)
        {
            var itemToRemove = Ordered.FirstOrDefault(item => item.order_id == itemId);
            if (itemToRemove != null)
            {
                MySqlConnection conn = DBConnection.connectDB();
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    string query = "Delete from order_tbl where order_id =@order_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_id", itemId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Ordered.Remove(itemToRemove);
                    }

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
        public static void AddOrder(Orders order)
        {
            Ordered.Add(order);
        } 

        public static ObservableCollection<Orders> GetOrders() { return Ordered; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
