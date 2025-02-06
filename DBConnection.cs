using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ADETProjApp
{
    internal class DBConnection
    {
        public static MySqlConnection connectDB()
        {
            string connstring = "server=localhost;userid=root;password=kisi;database=food_order_db";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            return conn;
        }
    }
}
