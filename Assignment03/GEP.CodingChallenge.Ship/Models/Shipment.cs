namespace GEP.CodingChallenge.Ship.Models
{
    public class Shipment
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Shipper { get; set; }
        public int Duration { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
