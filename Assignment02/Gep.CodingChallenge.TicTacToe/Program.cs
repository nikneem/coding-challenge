using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GEP.CodingChallenge.Ttt.Base;
using GEP.CodingChallenge.Ttt.Domain;
using GEP.CodingChallenge.Ttt.Persistence;

namespace Gep.CodingChallenge.TicTacToe
{
    class Program
    {

        private static string defaultAddress = "https://www.henrybeen.nl/wp-content/uploads/2020/10/002-experts.txt";

        static async Task Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hi! This is a very awesome tic tac toe game status analyzer");
            var url = GetUrlFromUserInput();
            var downloadStatusFileContent = await DownloadStatusFileAsync(url);

            var game = new Game();
            game.Initialize(PlainTextInterpreter.OccupationsFromString(downloadStatusFileContent, game));

            Console.WriteLine();
            Console.WriteLine(game.GetStatusText());
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

        private static async Task<string> DownloadStatusFileAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
