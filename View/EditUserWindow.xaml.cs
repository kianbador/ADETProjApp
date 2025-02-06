using ADETProjApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADETProjApp.View
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : INotifyPropertyChanged
    {
        private User _user;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public EditUserWindow()
        {
            InitializeComponent();
            User = UserManage.GetUser();

            usernameEntry.Text = User.username;
            nameEntry.Text = User.name;
            addressEntry.Text = User.address;
            emailEntry.Text = User.email;
            numEntry.Text = User.contact_no;
            passwordEntry.Password = User.password;
            confPasswordEntry.Password = User.password;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string username1 = User.username;
            string username = usernameEntry.Text;
            string name = nameEntry.Text;
            string address = addressEntry.Text;
            string email = emailEntry.Text;
            string contact_no = numEntry.Text;
            string password = passwordEntry.Password;
            string confPassword = confPasswordEntry.Password;
            string result = MySqlQuerries.checkUpdateUser(username, username1);
            if (result == "")
            {
                UserDataEntryValidation validation = new UserDataEntryValidation(username, name, address, contact_no, email, password, confPassword);
                string validationError = validation.Validate();

                if (validationError == "")
                {
                    bool updateSuccess = MySqlQuerries.UpdateUserDetails(username1, username, name, address, contact_no, email, password);
                    if (updateSuccess)
                    {
                        MessageBox.Show("User details updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        UserManage.UpdateUser(username, name, address, email, contact_no, password);
                        OnPropertyChanged(nameof(User));
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
