using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class User : INotifyPropertyChanged
    {
        public string username {  get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string contact_no { get; set; }
        public string password { get; set; }
        private int _points { get; set; }

        public int points
        {
            get { return _points; }
            set
            {
                if (_points != value)
                {
                    _points = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
