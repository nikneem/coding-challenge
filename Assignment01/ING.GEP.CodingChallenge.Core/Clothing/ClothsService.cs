using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ING.GEP.CodingChallenge.Core.Clothing.Models;
using ING.GEP.CodingChallenge.Core.Enums;

namespace ING.GEP.CodingChallenge.Core.Clothing
{
    public class ClothsService
    {
        public async Task<List<Cloth>> ImportFromCsv(Stream csv, bool skipFirstLine = true)
        {
            var cloths = new List<Cloth>();
            using (var sr = new StreamReader(csv))
            {
                bool endOfFile;
                bool firstLine = true;
                do
                {
                    var line = await sr.ReadLineAsync();
                    if (!firstLine || !skipFirstLine)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            cloths.Add(ClothsFactory.FromCsvString(line));
                        }
                    }

                    endOfFile = string.IsNullOrWhiteSpace(line);
                    firstLine = false;
                } while (!endOfFile);
            }

            return cloths;
        }

        public async Task ExportClothesToCsvFile(
            string targetFilePath,
            IEnumerable<Cloth> exportSubjects,
            Currency desiredCurrency)
        {

            var fileInfo = new FileInfo(targetFilePath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            await using var outputFile = File.OpenWrite(targetFilePath);
            await using var sw = new StreamWriter(outputFile);
            await sw.WriteLineAsync("productId,name,description,price,category");
            foreach (var exportObject in exportSubjects)
            {
                exportObject.Price.ConvertTo(desiredCurrency);
                var csvString = exportObject.ToCsvString();
                await sw.WriteLineAsync(csvString);
            }
        }


    }
}
