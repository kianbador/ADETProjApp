using ADETProjApp.Commands;
using ADETProjApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ADETProjApp.ViewModel
{
    public class VoucherVM : INotifyPropertyChanged
    {
        public ObservableCollection<UserVoucher> userVouchers { get; set; }

        private TotalPrice _totalPrice;

        public TotalPrice totalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(totalPrice));
                }
            }
        }

        public ICommand UseVoucher { get; }

        public VoucherVM()
        {
            userVouchers = VoucherManage.GetUserVouchers();
            totalPrice = PriceManage.GetTotalPrice();
            UseVoucher = new RelayCommand(ExecuteUseVoucher, CanExecuteUseVoucher);
        }

        private bool CanExecuteUseVoucher(object obj)
        {
            return true;
        }

        private void ExecuteUseVoucher(object obj)
        {
            if (obj is UserVoucher voucher)
            {
                decimal percent = (decimal)voucher.percent;
                DiscountedPrice(percent);
                VoucherManage.RemoveVoucher(voucher.voucher_id);
            }
            OnPropertyChanged(nameof(userVouchers));
        }

        private void DiscountedPrice(decimal percent)
        {
            totalPrice.totalPrice -= totalPrice.totalPrice * percent;
            PriceManage.SetTotalPrice(totalPrice.totalPrice);
            OnPropertyChanged(nameof(totalPrice));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
