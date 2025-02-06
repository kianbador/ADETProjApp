using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADETProjApp.Model
{
    public class CartManage
    {
        public static ObservableCollection<Cart> CartItems = new ObservableCollection<Cart>();

        public static ObservableCollection<Cart> GetCart()
        {
            return CartItems;
        }

        public static void AddItemToCart(Cart cart)
        {
            if(cart != null)
            {
                var existingItem = CartItems.FirstOrDefault(item => item.Id == cart.Id);
                if (existingItem != null)
                {
                    existingItem.Quantity += cart.Quantity;
                }
                else
                {
                    CartItems.Add(cart);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");
            }
        }

        public static void RemoveItemFromCart(string itemId)
        {
            var itemToRemove = CartItems.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                CartItems.Remove(itemToRemove);
            }

        }

        public static void ClearCart()
        {
            CartItems.Clear();
        }

    }
}
