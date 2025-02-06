using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using ADETProjApp.Commands;
using ADETProjApp.Model;
using MySql.Data.MySqlClient;

namespace ADETProjApp.ViewModel
{
    public class PointsVM : INotifyPropertyChanged
    {
        public ObservableCollection<Discount> AllDiscount { get; set; }
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddDiscountToUser { get; }
        
        public int points
        {
            get { return User.points; }
            set
            {
                if (User.points != value)
                {
                    User.points = value;
                    OnPropertyChanged(); 
                }
            }
        }

        public PointsVM()
        {
            AllDiscount = DiscountDetails.GetDiscounts();
            User = UserManage.GetUser();

            AddDiscountToUser = new RelayCommand(ExecuteAddDiscontToUser, CanExecuteAddDiscontToUser);
        }

        private bool CanExecuteAddDiscontToUser(object obj)
        {
            return true;
        }

        private void ExecuteAddDiscontToUser(object obj)
        {
            if (obj is Discount discount)
            {
                int costPoints = 0;
                if (discount.percent == 0.1)
                {
                    costPoints = 50;
                }
                else if (discount.percent == 0.25)
                {
                    costPoints = 1000;
                }
                else if (discount.percent == 0.5)
                {
                    costPoints = 2000;
                }
                MessageBoxResult result = MessageBox.Show($"Are you sure? It will cost {costPoints} pts.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }

                if (User.points <  costPoints)
                {
                    MessageBox.Show("Insufficient Points", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string md5Hash = GetMd5Hash(DateTime.Now.ToString());

                string voucher_id = md5Hash.Substring(0, 10);
                string imagePath = "";
                if (discount.percent == 0.1)
                {
                    imagePath = "..\\img\\discount\\10-percent.png";
                }
                else if (discount.percent == 0.25)
                {
                    imagePath = "..\\img\\discount\\25-percent.png";
                }
                else if (discount.percent == 0.5)
                {
                    imagePath = "..\\img\\discount\\50-percent.png";
                }

                MySqlConnection conn = DBConnection.connectDB();
                try
                {
                    string query = "Insert into voucher_tbl (username, voucher_id, percent, description) values (@username, @voucher_id, @percent, @description)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", User.username);
                    cmd.Parameters.AddWithValue("@voucher_id", voucher_id);
                    cmd.Parameters.AddWithValue("@percent", discount.percent);
                    cmd.Parameters.AddWithValue("@description", discount.desc);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    query = $"UPDATE user_tbl SET points = points - {costPoints} WHERE username = @username";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", User.username);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        UserVoucher voucher = new UserVoucher() 
                        {
                            username = User.username, 
                            voucher_id = voucher_id,
                            percent = discount.percent,
                            desc = discount.desc,
                            imagePath = imagePath
                        };
                        VoucherManage.AddVoucher(voucher);
                        MessageBox.Show("Voucher obtained.");
                        MessageBox.Show($"{costPoints.ToString()} points deducted successfully to @{User.username}.");
                    }
                    else
                    {
                        MessageBox.Show($"No rows updated for {User.username}.");
                    }

                    conn.Close();
                }
                catch (Exception)
                {
                    conn.Close();
                }
                finally
                {
                    conn?.Close();
                }
                UserManage.UpdateSubtractPoints(costPoints);
            }
            OnPropertyChanged(nameof(points));
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
