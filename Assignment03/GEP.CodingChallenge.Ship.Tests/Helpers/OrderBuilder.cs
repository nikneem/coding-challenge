using System;
using GEP.CodingChallenge.Ship.Models;

namespace GEP.CodingChallenge.Ship.Tests.Helpers
{
    public class OrderBuilder
    {


        

        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Product { get; private set; }
        public decimal Price { get; private set; }
        public decimal Weight { get; private set; }
        public string Country { get; private set; }

        public OrderBuilder WithCustomerId(int value)
        {
            CustomerId = value;
            return this;
        }
        public OrderBuilder WithName(string value)
        {
            Name = value;
            return this;
        }
        public OrderBuilder WithProduct(string value)
        {
            Product = value;
            return this;
        }
        public OrderBuilder WithCountry(string value)
        {
            Country = value;
            return this;
        }
        public OrderBuilder WithPrice(decimal value)
        {
            Price = value;
            return this;
        }
        public OrderBuilder WithWeight(decimal value)
        {
            Weight = value;
            return this;
        }

        public Order Build()
        {
            return new Order
            {
                CustomerId = CustomerId,
                Name = Name,
                Product = Product,
                Price = Price,
                Weight = Weight,
                Country = Country
            };
        }


        public OrderBuilder()
        {
            var random = new Random();
            CustomerId = random.Next(1, 100);
            Price = decimal.Parse(random.Next(1, 10000).ToString()) / 100;
            Weight = decimal.Parse(random.Next(1, 10000).ToString()) / 100;
            Product = $"Product {DateTime.Now.Ticks}";
            Name = $"Name {DateTime.Now.Ticks}";
            Country = $"Country {DateTime.Now.Ticks}";
        }
    }
}
