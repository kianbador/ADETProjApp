using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADETProjApp
{
    internal class MySqlQuerries
    {

        public static string checkUser(string username)
        {
            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "Select count(*) from user_tbl where username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    try
                    {
                        int count = Convert.ToInt16(cmd.ExecuteScalar());
                        if (count != 0)
                        {
                            conn.Close();
                            return "user";
                        }
                    }catch(Exception ex)
                    {
                        conn.Close();
                        return Convert.ToString(ex);
                    }
                }

            }catch (Exception ex)
            {
                conn.Close();
                return Convert.ToString(ex);
            }

            conn.Close();
            return "";
        }

        public static string checkUpdateUser(string username, string username1)
        {
            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "Select count(*) from user_tbl where username = @username and username <> @username1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@username1", username1);
                    try
                    {
                        int count = Convert.ToInt16(cmd.ExecuteScalar());
                        if (count != 0)
                        {
                            conn.Close();
                            return "user";
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return Convert.ToString(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return Convert.ToString(ex);
            }

            conn.Close();
            return "";
        }

        public static bool UpdateUserDetails(string originalUsername, string newUsername, string name, string address, string contactNo, string email, string password)
        {

            using (MySqlConnection conn = DBConnection.connectDB())
            {
                try
                {

                    string query = "UPDATE user_tbl SET username = @newUsername, name = @name, full_address = @address, contact_no = @contactNo, email = @email, password = @password "
                                 + "WHERE username = @originalUsername";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@newUsername", newUsername);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@contactNo", contactNo);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@originalUsername", originalUsername);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating user details: " + ex.Message);
                    return false;
                }
            }
        }

        public static string login(string username, string password)
        {
            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "Select count(*) from user_tbl where username = @username and password = @pw";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pw", password);
                    try
                    {
                        int count = Convert.ToInt16(cmd.ExecuteScalar());
                        if ( count == 1)
                        {
                            return "success";
                        }
                        else
                        {
                            conn.Close();
                            return "Wrong password.";
                        }
                    }catch( Exception ex)
                    {
                        conn.Close();
                        return Convert.ToString(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return Convert.ToString(ex);
            }
        }

        public static string addUser(string username, string name, string address, string contactNum, string email, string password)
        {
            int points = 0;
            MySqlConnection conn = DBConnection.connectDB();
            try
            {
                string query = "INSERT INTO user_tbl (username, name, full_address, contact_no, email, password, points) VALUES (@username, @name, @address, @contactNum, @email, @password, @points)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@contactNum", contactNum);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@points", points);

                cmd.ExecuteNonQuery();
   
                conn.Close();
            }catch(Exception ex)
            {
                conn.Close();
                return Convert.ToString(ex);
            }

            return "";
        }
    }
}
