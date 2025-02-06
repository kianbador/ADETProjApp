using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace ADETProjApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindowNavigation.Navigate(new RegisterPage());
        }

        private void loginBttn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameEntry.Text;
            SecureString userPW = pwEntry.SecurePassword;
            string pw = PasswordString.ConvertToUnsecureString(userPW);

            string result = MySqlQuerries.checkUser(username);
            if (result == "user")
            {
                result = MySqlQuerries.login(username, pw);
                if (result == "success")
                {
                    Window.GetWindow(this).Close();

                    OrderWindow orderWindow = new OrderWindow(username);
                    orderWindow.Show();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (result == "")
            {
                MessageBox.Show("Username doesn't exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Something went wrong: " + result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void xBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
