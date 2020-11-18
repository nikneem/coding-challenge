using System.Linq;
using GEP.CodingChallenge.Ship.Enums;
using GEP.CodingChallenge.Ship.Tests.Helpers;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ship.Tests
{
    [TestFixture]
    public class ShipmentDurationCalculationsTests
    {

        [TestCase("PostNL", 12, 1)]
        [TestCase("PostNL", 2, 1)]
        [TestCase("BelgioPosto", 2, 2)]
        [TestCase("BelgioPosto", 12, 2)]
        [TestCase("DHL", 2, 4)]
        [TestCase("DHL", 12, 8)]
        public void WhenOperatorIsSelected_DurationCanBeCalculated(string operatorName, decimal payloadWeight, int expectedDuration)
        {
            var order = new OrderBuilder().WithWeight(payloadWeight).Build();
            var shipmentOperator = ShipmentOperator.All.FirstOrDefault(x => x.Operator == operatorName);
            var duration = shipmentOperator.GetShipmentDuration(order);
            Assert.AreEqual(expectedDuration, duration);
        }

    }
}