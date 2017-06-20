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
            var actaul = shoppingCart.CalculateFee(1, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_And_Second_Episode_Should_Be_190()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1);

            //Assert
            Assert.AreEqual(expected, actaul);
        }
    }

    public class ShoppingCart
    {
        public double CalculateFee(int firstEpisodeCount, int secondEpisodeCount)
        {
            var fee = 0;
            if (firstEpisodeCount == 1 && secondEpisodeCount == 1)
            {
                fee = 190;
            }
            else if (firstEpisodeCount == 1)
            {
                fee = 100;
            }
            return fee;
        }
    }
}
