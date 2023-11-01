namespace CheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        public int GetTotalPrice()
        {
            return 50;
        }

        public void Scan(string item)
        { 
        }
    }
}