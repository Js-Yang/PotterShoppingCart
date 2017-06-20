using System.Collections.Generic;
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
            var actaul = shoppingCart.CalculateFee(1, 0, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_And_A_Second_Episode_Should_Be_190()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_And_A_Second_Episode_And_A_ThirdEpisode_Should_Be_270()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 270;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1, 1);

            //Assert
            Assert.AreEqual(expected, actaul);
        }
    }

    public class ShoppingCart
    {
        public double CalculateFee(int firstEpisodeCount, int secondEpisodeCount, int thirdEpisodeCount)
        {
            var discount = 1d;

            if (firstEpisodeCount == 1 && secondEpisodeCount == 1 && thirdEpisodeCount == 1)
            {
                discount = 0.9;
            }
            else if (firstEpisodeCount == 1 && secondEpisodeCount == 1 && thirdEpisodeCount == 0)
            {
                discount = 0.95;
            }
            else if (firstEpisodeCount == 1 && secondEpisodeCount == 0 && thirdEpisodeCount == 0)
            {
                discount = 1;
            }

            var totalFee = (firstEpisodeCount * 100 + secondEpisodeCount * 100 + thirdEpisodeCount * 100) * discount;

            return totalFee;
        }
    }
}
