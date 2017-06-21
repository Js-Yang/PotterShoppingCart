using System.Collections.Generic;
using NUnit.Framework;

namespace PotterShoppingCart.Tests
{
    [TestFixture]
    public class CashierTest
    {
        [Test]
        public void CalculateFee_Buy_A_First_Episode_Should_Be_100()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 100;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_Should_Be_190()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 190;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_Should_Be_270()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 270;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.ThirdEpisode, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_Should_Be_320()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 320;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.ThirdEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.FourthEpisode, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_A_ThirdEpisode_A_FourEpisode_A_FifthEpisode_Should_Be_375()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 375;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.ThirdEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.FourthEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.FifthEpisode, 1);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_A_Second_Episode_TWO_ThirdEpisode_Should_Be_370()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 370;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.ThirdEpisode, 2);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        [Test]
        public void CalculateFee_Buy_A_First_Episode_TWO_Second_Episode_TWO_ThirdEpisode_Should_Be_460()
        {
            //Arrange
            var cashier = new Cashier(GetDicountDefinition());
            var shoppingCart = new ShoppingCart();
            var expected = 460;

            shoppingCart.AddProduct((int)HarryPotterBooks.FirstEpisode, 1);
            shoppingCart.AddProduct((int)HarryPotterBooks.SecondEpisode, 2);
            shoppingCart.AddProduct((int)HarryPotterBooks.ThirdEpisode, 2);

            //Act
            var actaul = cashier.CalculateFee(shoppingCart.GetContent());

            //Assert
            Assert.AreEqual(expected, actaul);
        }

        private Dictionary<int, double> GetDicountDefinition()
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
}
