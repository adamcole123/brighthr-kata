namespace CheckoutKata.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void EnsureCheckoutReturnsPrice()
        {
            // Arrange
            ICheckout checkout = new Checkout();

            // Act
            int price = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(50, price);
        }

        [TestMethod]
        public void EnsureItemIsScanned()
        {
            ICheckout checkout = new Checkout();
            var basketItems = checkout.Scan("A");

            Assert.AreEqual(1, basketItems.Count());
        }
    }
}