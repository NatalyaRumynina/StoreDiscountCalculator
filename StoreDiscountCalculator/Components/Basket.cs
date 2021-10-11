using System.Collections.Generic;

namespace StoreDiscountCalculator.Components
{
    public class Basket
    {
        private List<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.RemoveAll(p => p.GetCode() == product.GetCode());
        }
    }
}