using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GEP.CodingChallenge.Ship.Services;

namespace GEP.CodingChallenge.Shipping
{
    class Program
    {
        private static string defaultAddress = "https://www.henrybeen.nl/wp-content/uploads/2020/11/003-experts-inputs.csv";

        static async Task Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hi! This is a very awesome tic tac toe game status analyzer");
            var url = GetUrlFromUserInput();
            var importLines = await DownloadStatusFileAsync(url);

            var service = new OrderProcessingService();
            var shipmentLines = service.Process(importLines);
            Console.WriteLine("CustomerId,Name,Shipper,Duration,ShippingCost");
            foreach (var shipmentLine in shipmentLines)
            {
                Console.WriteLine($"{shipmentLine.CustomerId},{shipmentLine.Name},{shipmentLine.Shipper},{shipmentLine.Duration},{shipmentLine.ShippingCost}");
            }

            Console.WriteLine();

            Console.ReadKey();
        }

        private static string GetUrlFromUserInput()
        {

            Console.WriteLine($"Just press enter to accept the default which is ({defaultAddress})");
            Console.WriteLine("Where would you like me to download a status file from?");
            var address = Console.ReadLine();
            if (address.Length == 0)
            {
                address = defaultAddress;
            }

            return address;
        }

        private static async Task<List<string>> DownloadStatusFileAsync(string url)
        {
            var orderLines = new List<string>();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var responseStream = await response.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(responseStream);
            string line = await streamReader.ReadLineAsync();
            do
            {
                line = await streamReader.ReadLineAsync();
                if (!string.IsNullOrEmpty(line))
                {
                    orderLines.Add(line);
                }
            } while (!string.IsNullOrEmpty(line));

            return orderLines;
        }
    }
}
