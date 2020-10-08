using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ING.GEP.CodingChallenge.Core.Clothing;
using ING.GEP.CodingChallenge.Core.Clothing.Models;
using ING.GEP.CodingChallenge.Core.Enums;
using ING.GEP.CodingChallenge.Core.ValueObjects;
using NUnit.Framework;

namespace ING.GEP.CodingChallenge.Core.Tests.Cloths
{
    public class ExportTests
    {

        private string _filename;

        [Test]
        public async Task WhenClothLinesAreExported_ThenAFileIsCreated()
        {
            var cloths = new List<Cloth>()
            {
                new Cloth(123, "Some name", "Some Description", new Price(5, Currency.Euro), "pants")
            };
            var service = new ClothsService();
            await service.ExportClothesToCsvFile(_filename, cloths, Currency.Dollar);
            Assert.IsTrue(File.Exists(_filename));
        }

        [SetUp]
        public void Setup()
        {
            _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "GEPUnitTests\\Outout.csv");
        }

        [TearDown]
        public void Teardown()
        {
            var folderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "GEPUnitTests");
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true);
            }
        }

    }
}
