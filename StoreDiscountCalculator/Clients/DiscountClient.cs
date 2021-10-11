using System.Collections.Generic;

namespace StoreDiscountCalculator.Clients
{
    public class DiscountClient : IDiscountClient
    {
        public Dictionary<string, float> GetDiscountByCodes(string[] codes)
        {
            return new Dictionary<string, float>()
            {
                {"1", 5},
                {"2", 10},
                {"4", 20},
                {"5", 0},
            };
        }
    }
}