namespace CheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        private List<BasketItem> Basket = new List<BasketItem>();
        private List<Product> Products = new List<Product>();
        public Checkout(List<Product> products)
        {
            if(products != null)
            {
                Products.AddRange(products);
            }
        }
        public int GetTotalPrice()
        {
            return Basket != null ? Basket.Aggregate(0, (acc, ba) => acc + ba.Price ) : 0;
        }

        public IEnumerable<BasketItem> Scan(string item)
        {
            if(Products == null)
            {
                throw new Exception("No product with that SKU.");
            }

            var product = Products.FirstOrDefault(prod => prod.Sku == item);

            if(product == null)
            {
                throw new Exception("No product with that SKU.");
            }

            var basketItem = Basket.FirstOrDefault(b => b.Product.Sku == item);

            if(basketItem == null)
            {
                Basket.Add(new BasketItem(product, 1));
            } else
            {
                basketItem.Quantity++;
            }

            return Basket;
        }
    }
}