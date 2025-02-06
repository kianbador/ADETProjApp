using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using ADETProjApp.Model;

namespace ADETProjApp.View
{
    /// <summary>
    /// Interaction logic for HistoryContent.xaml
    /// </summary>
    public partial class HistoryContent : UserControl
    {
        public HistoryContent()
        {
            InitializeComponent();
            showHistory();
        }

        private void showHistory()
        {
            User user = UserManage.GetUser();
            MySqlConnection conn = DBConnection.connectDB();
            string query = "SELECT order_id as 'Order ID', date as 'Date', description as 'Description', status As 'Status', concat('Php ',price) as Price FROM history_tbl where username=@username";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@username", user.username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

 
                            while (dataTable.Columns.Count > 5)
                            {
                                dataTable.Columns.RemoveAt(5);
                            }

                            dataGrid.ItemsSource = dataTable.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("No records found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
