using ING.GEP.CodingChallenge.Core.Enums;
using ING.GEP.CodingChallenge.Core.ValueObjects;
using NUnit.Framework;

namespace ING.GEP.CodingChallenge.Core.Tests.CurrencyConverter
{
    public class CurrencyConversionTests
    {

        [TestCase(0, 0)]
        [TestCase(1, 0.85)]
        [TestCase(2, 1.70)]
        [TestCase(5, 4.25)]
        [TestCase(10, 8.50)]
        [TestCase(10.18, 8.65)]
        [TestCase(-1, -0.85)]
        [TestCase(-85.14, -72.37)]
        public void WhenDollarIsConvertedToEuro_ThenAllExpectedAmountsAreEqual(decimal dollarAmount, decimal expectedAmount)
        {
            var targetCurrency = Currency.Euro;
            var convertedAmount = targetCurrency.ConvertAmountFrom(dollarAmount, Currency.Dollar);
            Assert.IsTrue( decimal.Equals(convertedAmount, expectedAmount));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1.18)]
        [TestCase(2, 2.35)]
        [TestCase(5, 5.88)]
        [TestCase(10, 11.76)]
        [TestCase(10.18, 11.98)]
        [TestCase(-1, -1.18)]
        [TestCase(-85.14, -100.16)]
        public void WhenEuroIsConvertedToDollar_ThenAllExpectedAmountsAreEqual(decimal euroAmount, decimal expectedAmount)
        {
            var targetCurrency = Currency.Dollar;
            var convertedAmount = targetCurrency.ConvertAmountFrom(euroAmount, Currency.Euro);
            Assert.IsTrue(decimal.Equals(convertedAmount, expectedAmount));
        }

        [TestCase(0, 0)]
        [TestCase(1, 0.85)]
        [TestCase(2, 1.70)]
        [TestCase(5, 4.25)]
        [TestCase(10, 8.50)]
        [TestCase(10.18, 8.65)]
        [TestCase(-1, -0.85)]
        [TestCase(-85.14, -72.37)]
        public void WhenPriceIsConvertedFromDollarToEuro_ThenTheAmountIsChanged(decimal dollarAmount, decimal expectedAmount)
        {
            var price = new Price(dollarAmount, Currency.Dollar);
            price.ConvertTo(Currency.Euro);
            Assert.IsTrue(decimal.Equals(price.Amount, expectedAmount));
        }



    }
}