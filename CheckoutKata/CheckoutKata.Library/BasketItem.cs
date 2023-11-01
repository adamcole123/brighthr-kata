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
        public int Price { get { return GetPrice(); } }
        public BasketItem(Product product, int quantity) 
        { 
            Product = product;
            Quantity = quantity;
        }

        internal int GetPrice()
        {
            if (Product.SpecialPrice != null) 
            {
                (int quantity, int price) = Product.SpecialPrice.Value;

                if(Quantity < quantity)
                {
                    return Quantity * Product.UnitPrice;
                }

                int dealAmount = (Quantity / quantity) * price;

                int regularAmount = (Quantity % quantity) * Product.UnitPrice;

                return dealAmount + regularAmount;
            }

            return Quantity * Product.UnitPrice;
        }
    }
}
