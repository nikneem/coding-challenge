using System.Globalization;
using ING.GEP.CodingChallenge.Core.Clothing.Models;
using NUnit.Framework;

namespace ING.GEP.CodingChallenge.Core.Tests.Exporting
{
    public class ExportLineTests
    {
        [Test]
        public void WhenClothLineIsExported_ThenLineIsFormatted()
        {
            var decimalSeperator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            var importCsvString = "1234,name,description,80,pants";
            var expectedOutputString = $"1234,name,description,80{decimalSeperator}00,pants";
            var cloth = ClothsFactory.FromCsvString(importCsvString);
            var actualOutputString = cloth.ToCsvString();
            Assert.AreEqual(expectedOutputString, actualOutputString);
        }
    }
}
