using System.Collections.Generic;
using System.Linq;
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

            shoppingCart.AddProduct(1, 1);

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_Should_Be_190()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_Should_Be_270()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 270;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_Should_Be_320()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 320;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);
            shoppingCart.AddProduct(4, 1);

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }


        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_A_FifthEpisode_Should_Be_375()
        {
            //Arrange
            var shoppingCart = new ShoppingCart();
            var expected = 375;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);
            shoppingCart.AddProduct(4, 1);
            shoppingCart.AddProduct(5, 1);

            //Act
            var actaul = shoppingCart.CalculateFee();

            //Assert
            Assert.AreEqual(expected, actaul);
        }
    }

    public class ShoppingCart
    {
        Dictionary<int, int> products = new Dictionary<int, int>();

        public void AddProduct(int episode, int count)
        {
            products.Add(episode, count);
        }

        public double CalculateFee()
        {
            var basePrize = 100;

            var totalFee = products.Sum(x => x.Value * basePrize) * GetDiscount();

            return totalFee;
        }

        private double GetDiscount()
        {
            var discount = 0d;
            var totalCount = products.Count(product => product.Value == 1);

            if (totalCount == 1)
            {
                discount = 1;
            }
            else if (totalCount == 2)
            {
                discount = 0.95;
            }
            else if (totalCount == 3)
            {
                discount = 0.9;
            }
            else if (totalCount == 4)
            {
                discount = 0.8;
            }
            else if (totalCount == 5)
            {
                discount = 0.75;
            }
            return discount;
        }
    }
}
