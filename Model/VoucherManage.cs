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

namespace ADETProjApp.Model
{
    public class VoucherManage : INotifyPropertyChanged
    {
        public static ObservableCollection<UserVoucher> userVouchers = new ObservableCollection<UserVoucher>();

        public event PropertyChangedEventHandler PropertyChanged;
        static VoucherManage()
        {
            PopulateUserVoucher();
        }

        public static void PopulateUserVoucher()
        {
            User user = new User();
            user = UserManage.GetUser();
            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "Select * from voucher_tbl where username=@username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.username);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string voucher_id = reader["voucher_id"].ToString();
                            string voucherUsername = reader["username"].ToString();
                            string description = reader["description"].ToString();
                            double percent = Convert.ToDouble(reader["percent"]);
                            string imagePath = "";
                            if (percent == 0.1)
                            {
                                imagePath = "..\\img\\discount\\10-percent.png";
                            }
                            else if (percent == 0.25)
                            {
                                imagePath = "..\\img\\discount\\25-percent.png";
                            }
                            else if (percent == 0.5)
                            {
                                imagePath = "..\\img\\discount\\50-percent.png";
                            }

                            UserVoucher userVoucher = new UserVoucher()
                            {
                                voucher_id = voucher_id,
                                username = voucherUsername,
                                desc = description,
                                percent = percent,
                                imagePath = imagePath
                            };
                            userVouchers.Add(userVoucher);
                        }
                    }
                }

            }
            catch (Exception)
            {
                conn.Close();
            }
            finally { conn.Close(); }
        }

        public static void RemoveVoucher(string itemId)
        {
            var itemToRemove = userVouchers.FirstOrDefault(item => item.voucher_id == itemId);
            if (itemToRemove != null)
            {
                MySqlConnection conn = DBConnection.connectDB();
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    string query = "Delete from voucher_tbl where voucher_id =@voucher_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@voucher_id", itemId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        userVouchers.Remove(itemToRemove);
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

        public static void AddVoucher(UserVoucher voucher)
        {
            userVouchers.Add(voucher);
        }

        public static ObservableCollection<UserVoucher> GetUserVouchers()
        {
            return userVouchers;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
