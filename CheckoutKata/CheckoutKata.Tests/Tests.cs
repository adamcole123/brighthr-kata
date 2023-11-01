using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void EnsureItemIsScanned()
        {
            ICheckout checkout = new Checkout(new List<Product> { new Product("A", 50, null)});
            var basketItems = checkout.Scan("A");

            Assert.AreEqual(1, basketItems.Count());
        }

        [TestMethod]
        public void EnsureCheckoutPriceReturnsZero()
        {
            List<Product> products = new List<Product>
            {
                new Product("A", 50, null)
            };

            ICheckout checkout = new Checkout(products);

            Assert.AreEqual(0, checkout.GetTotalPrice());
        }

        [TestMethod]
        public void EnsureScanFailsWithNoProduct()
        {
            ICheckout checkout = new Checkout(null);

            try
            {
                checkout.Scan("A");
                Assert.Fail("Exception of type {0} expected; got none exception", typeof(Exception).Name);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No product with that SKU.", ex.Message);
            }

        }

        [TestMethod]
        public void EnsureScanIncrementsBasketItemQuantity()
        {
            List<Product> products = new List<Product>
            {
                new Product("A", 50, null)
            };

            ICheckout checkout = new Checkout(products);

            checkout.Scan("A");
            var basket = checkout.Scan("A");

            Assert.AreEqual(1, basket.Count());
            Assert.AreEqual(2, basket.FirstOrDefault(ba => ba.Product.Sku == "A").Quantity);
        }

        [TestMethod]
        public void EnsureCheckoutPriceReturnsSpecialPrice()
        {
            List<Product> products = new List<Product>
            {
                new Product("A", 50, (3, 70))
            };

            ICheckout checkout = new Checkout(products);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.AreEqual(70, checkout.GetTotalPrice());
        }

        [TestMethod]
        public void EnsureCheckoutPriceReturnsSpecialPriceWithRemainder()
        {
            List<Product> products = new List<Product>
            {
                new Product("A", 50, (3, 70))
            };

            ICheckout checkout = new Checkout(products);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.AreEqual(120, checkout.GetTotalPrice());
        }
    }
}