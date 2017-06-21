using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart
{
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
}
