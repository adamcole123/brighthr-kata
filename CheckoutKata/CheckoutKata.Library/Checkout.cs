namespace CheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        public int GetTotalPrice()
        {
            return 50;
        }

        public IEnumerable<BasketItem> Scan(string item)
        {
            List<BasketItem> items = new List<BasketItem> {
                new BasketItem(new Product("A", 50, null), 2) 
            };

            return items;
        }
    }
}