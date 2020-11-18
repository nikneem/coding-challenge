using System.Collections.Generic;
using GEP.CodingChallenge.Ship.Contracts;
using GEP.CodingChallenge.Ship.Enums;
using GEP.CodingChallenge.Ship.Models;

namespace GEP.CodingChallenge.Ship.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {

        public IEnumerable<Shipment> Process(List<string> importLines)
        {
            var validOrders = ProcessOrderLines(importLines);
            return ProcessOrders(validOrders);
        }

        private IEnumerable<Order> ProcessOrderLines(List<string> importLines)
        {
            foreach (var line in importLines)
            {
                if (Order.TryParse(line, out Order order))
                {
                    yield return order;
                }
            }
        }

        private IEnumerable<Shipment> ProcessOrders(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                var shipmentOperator = ShipmentOperator.Parse(order);
                yield return new Shipment
                {
                    CustomerId = order.CustomerId,
                    Name = order.Name,
                    Shipper = shipmentOperator.Operator,
                    Duration = shipmentOperator.GetShipmentDuration(order),
                    ShippingCost = shipmentOperator.GetShipmentPrice(order)
                };
            }
        }

    }
}
