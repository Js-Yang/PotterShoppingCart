using NUnit.Framework;

namespace PotterShoppingCart.Tests
{
    [TestFixture]
    public class ShoppingCartTest
    {
        [Test]
        public void CalculateFee_Buy_A_First_Episode_Should_Be_100()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 100;

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }
    }

    public class ShoppingCart
    {
        public double CalculateFee()
        {
            return 100;
        }
    }
}
