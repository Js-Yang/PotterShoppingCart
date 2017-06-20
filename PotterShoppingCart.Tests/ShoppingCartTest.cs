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
            var actaul = shoppingCart.CalculateFee(1, 0, 0, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_Should_Be_190()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1, 0, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_Should_Be_270()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 270;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1, 1, 0);

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_Should_Be_320()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 320;

            //Act
            var actaul = shoppingCart.CalculateFee(1, 1, 1, 1);

            //Assert
            Assert.AreEqual(expected, actaul);
        }
    }

    public class ShoppingCart
    {
        public double CalculateFee(int firstEpisodeCount, int secondEpisodeCount, int thirdEpisodeCount, int fourEpisodeCount)
        {
            var discount = GetDiscount(firstEpisodeCount, secondEpisodeCount, thirdEpisodeCount, fourEpisodeCount);

            var basePrize = 100;
            var totalFee = (firstEpisodeCount * basePrize + secondEpisodeCount * basePrize + thirdEpisodeCount * basePrize + fourEpisodeCount * basePrize) * discount;

            return totalFee;
        }

        private static double GetDiscount(int firstEpisodeCount, int secondEpisodeCount, int thirdEpisodeCount, int fourEpisodeCount)
        {
            var discount = 0d;
            if (firstEpisodeCount == 1 && secondEpisodeCount == 1 && thirdEpisodeCount == 1 && fourEpisodeCount == 1)
            {
                discount = 0.8;
            }
            else if (firstEpisodeCount == 1 && secondEpisodeCount == 1 && thirdEpisodeCount == 1 && fourEpisodeCount == 0)
            {
                discount = 0.9;
            }
            else if (firstEpisodeCount == 1 && secondEpisodeCount == 1 && thirdEpisodeCount == 0 && fourEpisodeCount == 0)
            {
                discount = 0.95;
            }
            else if (firstEpisodeCount == 1 && secondEpisodeCount == 0 && thirdEpisodeCount == 0 && fourEpisodeCount == 0)
            {
                discount = 1;
            }
            return discount;
        }
    }
}
