using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ING.GEP.CodingChallenge.Core.Clothing;
using ING.GEP.CodingChallenge.Core.Enums;
using ING.GEP.CodingChallenge.Core.Exceptions;

namespace ING.GEP.CodingChallenge
{
    class Program
    {

        private const string DefaultSourceFileUrl =
            "https://henrybeen.nl/wp-content/uploads/2020/10/001-experts-inputs.csv";


        static async Task Main()
        {
            Console.Clear();
            var sourceFileUrl = GetSourceFileUrl();
            var targetFilePath = GetTargetFilePath();

            var downloadedStream = await Download(sourceFileUrl);

            var clothsService = new ClothsService();

            try
            {
                var importedCloths = await clothsService.ImportFromCsv(downloadedStream);
                var exportSubjects = importedCloths.Where(cloth => cloth.Price.Amount >= 10);
                await clothsService.ExportClothesToCsvFile(targetFilePath, exportSubjects, Currency.Euro);
            }
            catch (LineImportException importException)
            {
                await Console.Error.WriteLineAsync(importException.Message);
                await Console.Error.WriteLineAsync(importException.InnerException?.ToString());
            }
            catch (Exception unhandled)
            {
                await Console.Error.WriteLineAsync(unhandled.Message);
            }

#if debug
            Console.WriteLine("All completed, press a key to close");
            Console.ReadKey();
#endif
        }

        private static string GetSourceFileUrl()
        {
            Console.WriteLine(
                $"Enter a source file URL, or just hit enter to use the default ({DefaultSourceFileUrl})");
            var sourceFileUrl = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sourceFileUrl))
            {
                sourceFileUrl = DefaultSourceFileUrl;
            }

            return sourceFileUrl;
        }

        private static string GetTargetFilePath()
        {
            var defaultTargetUrl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ING GEP CodingChallenge\\output.csv");
            Console.WriteLine($"Enter a target file path, or just hit enter to use the default ({defaultTargetUrl})");
            var targetFilePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(targetFilePath))
            {
                targetFilePath = defaultTargetUrl;
            }

            return targetFilePath;
        }

        private static async Task<Stream> Download(string url)
        {
            Console.Write($"Downloading {url}...");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.SendAsync(httpRequest);
            Console.WriteLine(httpResponse.IsSuccessStatusCode ? "OK" : "FAILED");
            return await httpResponse.Content.ReadAsStreamAsync();
        }


    }
}