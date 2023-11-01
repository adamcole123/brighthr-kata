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
    }
}