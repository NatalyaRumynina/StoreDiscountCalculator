namespace StoreDiscountCalculator.Components
{
    //todo. properties ???
    public class Product
    {
        private string _code;
        private string _name;
        private float _price;

        public Product(string code, string name, float price)
        {
            _code = code;
            _name = name;
            _price = price;
        }

        public string GetCode()
        {
            return _code;
        }

        public string GetName()
        {
            return _name;
        }

        public float GetPrice()
        {
            return _price;
        }
    }
}