using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_21_AwaitAsync
{
    internal class Program
    {

        static Uri uri = new Uri("https://www.bbc.co.uk/weather");

        private static void Main(string[] args)
        {
            //main method here
            //setup - create data file
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1, 'john', 21");
            File.AppendAllText("data.csv", "\n2, 'paul', 24");
            File.AppendAllText("data.csv", "\n3, 'ringo', 22");
            File.AppendAllText("data.csv", "\n4, 'george  ', 23");

            //sync method : wait for it
            ReadDataSync();
            //async method : don't wait for it
            ReadDataAsync();

            GetWebPageSync();
            GetWebPageAsync();
            Console.WriteLine("\nCode complete.\n");
        }

        private static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
        }

        private async static void ReadDataAsync()
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
        }

        private static void GetWebPageSync()
        {
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "7page01.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page01.html");
        }

        private async static void GetWebPageAsync()
        {
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFileAsync(uri, "page02.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page02.html");
        }
    }
}