using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class PriceManage
    {
        public static TotalPrice totalPrice = new TotalPrice() { totalPrice = 0 };

        public static TotalPrice GetTotalPrice()
        {
            return totalPrice;
        }

        public static void SetTotalPrice(decimal price)
        {
            totalPrice.totalPrice = price;
        }
    }
}
