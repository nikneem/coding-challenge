using GEP.CodingChallenge.Ship.Enums;
using GEP.CodingChallenge.Ship.Tests.Helpers;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ship.Tests
{
    [TestFixture]
    public class ShippingOperatorSelectionTests
    {


        [TestCase("Netherlands", 5, "PostNL")]
        [TestCase("Netherlands", 9.9, "PostNL")]
        [TestCase("Netherlands", 10, "DHL")]
        [TestCase("Belgium", 5, "BelgioPosto")]
        [TestCase("Belgium", 9.9, "BelgioPosto")]
        [TestCase("Belgium", 11, "BelgioPosto")]
        [TestCase("France", 5, "DHL")]
        [TestCase("Brazil", 5, "DHL")]
        public void WhenOperatorCriteriaAreMet_ThenShippingOperatorIsSelected(string targetCountry, decimal weight, string expectedOperator)
        {
            var order = new OrderBuilder()
                .WithCountry(targetCountry)
                .WithWeight(weight)
                .Build();

            var shipmentOperator = ShipmentOperator.Parse(order);
            Assert.AreEqual(expectedOperator, shipmentOperator.Operator);
        }



    }
}
