using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.RightsManagement;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindowNavigation.Navigate(new LoginPage());
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            SecureString securePw = pwEntry.SecurePassword;
            SecureString secureCpw = cpwEntry.SecurePassword;
            string username = uNameEntry.Text;
            string name = nameEntry.Text;
            string address = addressEntry.Text;
            string contactNo = numEntry.Text;
            string email = emailEntry.Text;
            string pw = PasswordString.ConvertToUnsecureString(securePw);
            string cpw = PasswordString.ConvertToUnsecureString(secureCpw);

            string result = MySqlQuerries.checkUser(username);
            if(result == "")
            {
                UserDataEntryValidation validation = new UserDataEntryValidation(username, name, address, contactNo, email, pw, cpw);
                string validationError = validation.Validate();

                if (validationError == "")
                {
                    result = MySqlQuerries.addUser(username, name, address, contactNo, email, pw);
                    if (result == "")
                    {
                        MessageBox.Show("User Successfully Recorded.");
                        MainWindowNavigation.Navigate(new LoginPage());
                    }
                    else
                    {
                        MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show(validationError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (result == "user")
            {
                MessageBox.Show("Username already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);     
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
