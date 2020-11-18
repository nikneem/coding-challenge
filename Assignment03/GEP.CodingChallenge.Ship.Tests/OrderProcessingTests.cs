using System.Collections.Generic;
using System.Linq;
using GEP.CodingChallenge.Ship.Models;
using GEP.CodingChallenge.Ship.Services;
using GEP.CodingChallenge.Ship.Tests.Helpers;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ship.Tests
{
    [TestFixture]public class OrderProcessingTests
    {


        [Test]
        public void WhenOrderIsProcessed_IsReturnsShipmentInformation()
        {
            var order = new OrderBuilder()
                .WithCountry("Netherlands")
                .WithWeight(6)
                .Build();

            var orderProcessor = new OrderProcessingService();
            var shipmentInfo = orderProcessor.Process(new List<string>
            {
                order.ToString()
            });
            Assert.AreEqual(1, shipmentInfo.Count());

            var shipment = shipmentInfo.FirstOrDefault();

            Assert.AreEqual(order.CustomerId, shipment.CustomerId);
            Assert.AreEqual(order.Name, shipment.Name);
            Assert.AreEqual("PostNL", shipment.Shipper);
            Assert.AreEqual(1, shipment.Duration);
            Assert.AreEqual(6.95M, shipment.ShippingCost);

        }

        [Test]
        public void WhenImportLineIsInvalid_ThenTheImportLineIsIgnored()
        {
            var importLine = "21,Pietje de Boer,Monitor,466,19,2.5,Belgium";
            var result = Order.TryParse(importLine, out _);
            Assert.AreEqual(false, result);
        }
    }
}
