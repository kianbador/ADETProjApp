using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ADETProjApp.Model
{
    public class UserManage : INotifyPropertyChanged
    {
        public static User user;

        public User User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged();
                }
            }
        }

        public static void UpdateAddPoints(int points)
        {
            user.points += points;
        }
        public static void UpdateSubtractPoints(int points)
        {
            user.points -= points;
        }


        public static void UpdateUser(string username, string name, string address, string email, string contact_no, string password)
        {
            user.username = username;
            user.name = name;
            user.address = address;
            user.email = email;
            user.contact_no = contact_no;
            user.password = password;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UserManage(string username)
        {
            LoadUserFromDatabase(username);
        }

        private void LoadUserFromDatabase(string username)
        {
            MySqlConnection conn = null;

            try
            {
                conn = DBConnection.connectDB(); 

                string query = "SELECT * FROM user_tbl WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User = new User
                            {
                                username = reader["username"].ToString(),
                                name = reader["name"].ToString(),
                                address = reader["full_address"].ToString(),
                                email = reader["email"].ToString(),
                                contact_no = reader["contact_no"].ToString(),
                                password = reader["password"].ToString(),
                                points = Convert.ToInt32(reader["points"])
                            };
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user: {ex.Message}");
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static User GetUser()
        {
            return user;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
