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
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 100;

            shoppingCart.AddProduct(1, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_Should_Be_190()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_Should_Be_270()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 270;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_Should_Be_320()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 320;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);
            shoppingCart.AddProduct(4, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_A_FifthEpisode_Should_Be_375()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 375;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 1);
            shoppingCart.AddProduct(4, 1);
            shoppingCart.AddProduct(5, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_TWO_ThirdEpisode_Should_Be_370()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 370;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 1);
            shoppingCart.AddProduct(3, 2);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_TWO_Second_Episode_TWO_ThirdEpisode_Should_Be_460()
        {
            //Arrange
            var cashier = new Cashier(SetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 460;

            shoppingCart.AddProduct(1, 1);
            shoppingCart.AddProduct(2, 2);
            shoppingCart.AddProduct(3, 2);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        private Dictionary<int, double> SetDicountDefinition()
        {
            return new Dictionary<int, double>
            {
                {1, 1},
                {2, 0.95},
                {3, 0.9},
                {4, 0.8},
                {5, 0.75},
            };
        }
    }

    public class Cashier
    {
        private Dictionary<int, double> discountRule;

        public Cashier(Dictionary<int, double> dicountRule)
        {
            this.discountRule = dicountRule;
        }

        public double CalculateFee(Dictionary<int, int> products)
        {
            var basePrize = 100;
            var totalFee = 0d;
            for (int i = 1; i <= products.Keys.Max(); i++)
            {
                var setsCount = products.Count(product => product.Value >= i);
                if (setsCount == 0)
                    break;
                totalFee += setsCount * basePrize * discountRule[setsCount];
            }
            return totalFee;
        }
    }

    public class ShoppingCart
    {
        private Dictionary<int, int> products = new Dictionary<int, int>();

        public void AddProduct(int episode, int count)
        {
            products.Add(episode, count);
        }

        public Dictionary<int, int> GetContent()
        {
            return products;
        }
    }
}
