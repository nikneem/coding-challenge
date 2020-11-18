using System.Linq;
using GEP.CodingChallenge.Ship.Enums;
using GEP.CodingChallenge.Ship.Tests.Helpers;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ship.Tests
{
    [TestFixture]
    public class ShipmentPriceCalculationsTests
    {

        [TestCase("PostNL", 12, 6.95)]
        [TestCase("PostNL", 2, 6.95)]
        [TestCase("BelgioPosto", 2, (2 + 1.95))]
        [TestCase("BelgioPosto", 12, (12+1.95))]
        [TestCase("DHL", 2, 15.95)]
        [TestCase("DHL", 12, 30.95)]
        public void WhenOperatorIsSelected_DurationCanBeCalculated(string operatorName, decimal payloadWeight,
            decimal expectedPrice)
        {
            var order = new OrderBuilder().WithWeight(payloadWeight).Build();
            var shipmentOperator = ShipmentOperator.All.FirstOrDefault(x => x.Operator == operatorName);
            var price = shipmentOperator.GetShipmentPrice(order);
            Assert.AreEqual(expectedPrice, price);
        }

    }
}