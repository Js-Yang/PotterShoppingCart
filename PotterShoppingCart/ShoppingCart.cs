using System.Collections.Generic;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        private Dictionary<int, int> products = new Dictionary<int, int>();

        public void AddProduct(int productNumber, int count)
        {
            products.Add(productNumber, count);
        }

        public Dictionary<int, int> GetContent()
        {
            return products;
        }
    }
}
