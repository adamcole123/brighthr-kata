namespace CheckoutKata.Library
{
    public class Product
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public Tuple<int, int> SpecialPrice { get; set; }
        public Product(string sku, int unitPrice, Tuple<int, int>? specialPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            SpecialPrice = specialPrice;
        }
    }
}