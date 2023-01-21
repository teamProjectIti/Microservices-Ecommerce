using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Basket.order
{
    public class ShoppingCart
    {
        public string _UserName { get; set; }

        public List<ShoppingCartItems> Items { get; set; } = new List<ShoppingCartItems>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string UserName)
        {
            _UserName = UserName;
        }

        public decimal TotalPrice
        {
            get { 
            decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Price * item.Qountity;
                }
                return total;
            }
        }
        


    }
}
