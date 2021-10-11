using System.Collections;
using System.Collections.Generic;
using Moq;
using StoreDiscountCalculator.Clients;
using StoreDiscountCalculator.Components;
using Xunit;

namespace StoreDiscountCalculator.Tests
{
    public class CalculatorTest
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TestGetTotalPrice(string[] request, Dictionary<string, float> response, float result)
        {
            var basket = new Basket();

            basket.AddProduct(new Product("1", "a", 100));
            basket.AddProduct(new Product("2", "b", 100));
            basket.AddProduct(new Product("3", "c", 100));
            basket.AddProduct(new Product("4", "d", 100));
            basket.AddProduct(new Product("5", "e", 100));

            var discountClientMock = new Mock<IDiscountClient>();
            discountClientMock.Setup(d => d.GetDiscountByCodes(request)).Returns(response).Verifiable();

            var calculator = new Calculator(discountClientMock.Object);

            Assert.Equal(result, calculator.GetTotalPrice(basket));

            discountClientMock.Verify();
        }
    }

    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new [] {"1", "2", "3", "4", "5"},
                new Dictionary<string, float>(),
                500,
            },
            new object[]
            {
                new [] {"1", "2", "3", "4", "5"},
                new Dictionary<string, float>()
                {
                    {"1", 5},
                    {"2", 10},
                    {"3", 15},
                    {"4", 20},
                    {"5", 25},
                },
                425,
            },
            new object[]
            {
                new [] {"1", "2", "3", "4", "5"},
                new Dictionary<string, float>()
                {
                    {"1", 5},
                    {"2", 10},
                    {"4", 20},
                    {"5", 0},
                },
                465,
            },
            new object[]
            {
                new [] {"1", "2", "3", "4", "5"},
                new Dictionary<string, float>()
                {
                    {"1", 100},
                },
                400,
            },
            new object[]
            {
                new [] {"1", "2", "3", "4", "5"},
                new Dictionary<string, float>()
                {
                    {"1", 5},
                    {"2", 10},
                    {"4", -135},
                    {"5", 0},
                },
                485,
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}