using System.Collections.Generic;

namespace StoreDiscountCalculator.Clients
{
    public interface IDiscountClient
    {
        public Dictionary<string, float> GetDiscountByCodes(string[] codes);
    }
}