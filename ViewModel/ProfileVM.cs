using ADETProjApp.Commands;
using ADETProjApp.Model;
using ADETProjApp.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ADETProjApp.ViewModel
{
    public class ProfileVM : INotifyPropertyChanged
    {
        private User _user;
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

        public ICommand UpdateUserDetails { get; }

        public ProfileVM()
        {
            User = UserManage.GetUser();
            UpdateUserDetails = new RelayCommand(ExecuteUpdateUserDetails, CanExecuteUserDetails);
        }

        private bool CanExecuteUserDetails(object obj)
        {
            return true;
        }

        private void ExecuteUpdateUserDetails(object obj)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
