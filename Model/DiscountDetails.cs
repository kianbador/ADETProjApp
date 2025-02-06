using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class DiscountDetails
    {
        public static ObservableCollection<Discount> discounts = new ObservableCollection<Discount>()
        {
            new Discount(){desc = "10% off discount.", percent = 0.1, imagePath = "..\\img\\discount\\10-percent.png", cost = 500},
            new Discount(){desc = "25% off discount.", percent = 0.25, imagePath = "..\\img\\discount\\25-percent.png", cost = 1000},
            new Discount(){desc = "50% off discount.", percent = 0.5, imagePath = "..\\img\\discount\\50-percent.png", cost = 2000}
        };

        public static ObservableCollection <Discount> GetDiscounts()
        {
            return discounts; 
        }
    }
}
