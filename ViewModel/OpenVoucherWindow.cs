using ADETProjApp.Commands;
using ADETProjApp.Model;
using ADETProjApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ADETProjApp.ViewModel
{
    public class OpenVoucherWindow 
    {
        public TotalPrice totalPrice {  get; set; }
        public ICommand UseVoucherCommand { get; }
        public OpenVoucherWindow()
        {
            UseVoucherCommand = new RelayCommand(ExecuteUseVoucherCommand, CanExecuteUseVoucherCommand);
        }

        private bool CanExecuteUseVoucherCommand(object obj)
        {
            return true;
        }

        private void ExecuteUseVoucherCommand(object obj)
        {
            totalPrice = PriceManage.GetTotalPrice();
            decimal doubleAmount = totalPrice.totalPrice;

            if (doubleAmount <= 0)
            {
                MessageBox.Show("Cart is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            VoucherWindow voucherWindow = new VoucherWindow();
            voucherWindow.ShowDialog();
        }

    }
}
