using GEP.CodingChallenge.Ship.Contracts;

namespace GEP.CodingChallenge.Ship.Models
{
    public class Order : IOrder
    {
        public int CustomerId{ get;  set; }
        public string Name { get;  set; }
        public string Product { get;  set; }
        public decimal Price { get;  set; }
        public decimal Weight { get;  set; }
        public string Country { get;  set; }


        public static bool TryParse(string importLine, out Order order)
        {
            order = null;
            var fields = importLine.Split(',');
            if (fields.Length == 6)
            {
                order = new Order
                {
                    CustomerId = int.Parse(fields[0]),
                    Name = fields[1],
                    Product = fields[2],
                    Price = decimal.Parse(fields[3]),
                    Weight = decimal.Parse(fields[4]),
                    Country = fields[5]
                };
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{CustomerId},{Name},{Product},{Price},{Weight},{Country}";
        }
    }
}
