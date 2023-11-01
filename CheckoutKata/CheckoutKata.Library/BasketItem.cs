using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get { return Product.UnitPrice * Quantity; } }
        public BasketItem(Product product, int quantity) 
        { 
            Product = product;
            Quantity = quantity;
        }

        internal int GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
