using ING.GEP.CodingChallenge.Core.Clothing.Models;
using ING.GEP.CodingChallenge.Core.Exceptions;
using NUnit.Framework;

namespace ING.GEP.CodingChallenge.Core.Tests.Importing
{
    public class ImportLineTests
    {

        [Test]
        [TestCase("1234,name,description,80,pants", 1234, "name", "description", 80.00, "pants")]
        [TestCase("1234,    name,    description,80,pants", 1234, "name", "description", 80.00, "pants")]
        public void WhenImportLineIsCorrect_ThenItReturnsClothObject(string line, int id, string name, string description, decimal priceInDollars, string category)
        {
            var cloth = ClothsFactory.FromCsvString(line);
            Assert.AreEqual(cloth.ProductId, id);
            Assert.AreEqual(cloth.Name, name);
            Assert.AreEqual(cloth.Description, description);
            Assert.AreEqual(cloth.Price.Amount, priceInDollars);
            Assert.AreEqual(cloth.Category, category);
        }


        [Test]
        [TestCase("1234,description,80,pants")]
        [TestCase("1234,    name,    description,80,pants,bananarama")]
        [TestCase(null)]
        public void WhenImportLineContainsUnexpectedFieldCount_ThenItThrowsLineImportException(string line)
        {
            var act = new TestDelegate(()=> ClothsFactory.FromCsvString(line));
            var exception = Assert.Throws<LineImportException>(act);
            Assert.IsTrue(exception.InnerException.Message.Contains("Failed to import CSV line as Cloth"));
        }

        [Test]
        [TestCase("abc,name,description,80,pants")]
        [TestCase(",name,description,80,pants")]
        public void WhenProductIdIsInvalid_ThenItThrowsLineImportException(string line)
        {
            var act = new TestDelegate(() => ClothsFactory.FromCsvString(line));
            var exception = Assert.Throws<LineImportException>(act);
            Assert.IsTrue(exception.InnerException.Message.Contains("Product ID could not be converted to a long"));
        }

        [Test]
        [TestCase("123,name,description,x80,pants")]
        [TestCase("123,name,description,,pants")]
        public void WhenPriceIsInvalid_ThenItThrowsLineImportException(string line)
        {
            var act = new TestDelegate(() => ClothsFactory.FromCsvString(line));
            var exception = Assert.Throws<LineImportException>(act);
            Assert.IsTrue(exception.InnerException.Message.Contains("The import price could not be parsed to a valid decimal"));
        }


        [Test]
        [TestCase("1234,name,description,80,pants", 1234, "name", "description", 80.00, "pants")]
        [TestCase(" 1234 ,    name,    description, 80 ,pants", 1234, "    name", "    description", 80.00, "pants")]
        public void WhenImportingLineUntrimmed_ThenPropertiesKeepWhitespace(string line, int id, string name, string description, decimal priceInDollars, string category)
        {
            var cloth = ClothsFactory.FromCsvString(line, false);
            Assert.AreEqual(cloth.ProductId, id);
            Assert.AreEqual(cloth.Name, name);
            Assert.AreEqual(cloth.Description, description);
            Assert.AreEqual(cloth.Price.Amount, priceInDollars);
            Assert.AreEqual(cloth.Category, category);
        }


    }
}