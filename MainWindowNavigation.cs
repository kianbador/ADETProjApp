using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ADETProjApp
{
    public static class MainWindowNavigation
    {
        public static Frame MainFrame { get; set; }

        public static void Navigate(Page page)
        {
            MainFrame?.Navigate(page);
        }
    }
}
