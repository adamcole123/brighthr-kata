using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class BasketItem
    {
        private Product Product { get; set; }
        private int Quantity { get; set; }
        public BasketItem(Product product, int quantity) 
        { 
            Product = product;
            Quantity = quantity;
        }
    }
}
