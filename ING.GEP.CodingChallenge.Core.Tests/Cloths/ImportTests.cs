using System.IO;
using System.Threading.Tasks;
using ING.GEP.CodingChallenge.Core.Clothing;
using NUnit.Framework;

namespace ING.GEP.CodingChallenge.Core.Tests.Cloths
{
    public class ImportTests
    {

        [Test]
        public async Task WhenImportingCsvFileWithHeader_ThenImportedClothesAreReturned()
        {
            var memStream = WithValidClothsStream(true);
            var service = new ClothsService();
            var cloths = await service.ImportFromCsv(memStream);
            Assert.AreEqual(cloths.Count, 3);
        }
        [Test]
        public async Task WhenImportingCsvFileWithoutHeader_ThenImportedClothesAreReturned()
        {
            var memStream = WithValidClothsStream(false);
            var service = new ClothsService();
            var cloths = await service.ImportFromCsv(memStream, false);
            Assert.AreEqual(cloths.Count, 3);
        }

        private static MemoryStream WithValidClothsStream(bool inclueHeader)
        {
            var memStream = new MemoryStream();
            var sw = new StreamWriter(memStream);
            if (inclueHeader)
            {
                sw.WriteLine("ProductId,Name,Description,PriceInDollars,Category");
            }

            sw.WriteLine("1234,Denim Extrema,Extremely nice pair of jeans,80,jeans");
            sw.WriteLine("1235,Kaki Plus,Extra high quality kaki pants,94,pants");
            sw.WriteLine("1236,Say Yes,One size fits all wedding dress,3540,dress");
            sw.Flush();
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }
    }
}
