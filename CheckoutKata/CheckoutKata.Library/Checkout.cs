namespace CheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        private List<BasketItem> Basket = new List<BasketItem>();
        private List<Product> Products { get; set; }
        public Checkout(List<Product> products = null)
        {
            Products = products;
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

            var product = Products.First(prod => prod.Sku == item);

            if(product == null)
            {
                throw new Exception("No product with that SKU.");
            }

            Basket.Add(new BasketItem(product, 1));

            return Basket;
        }
    }
}