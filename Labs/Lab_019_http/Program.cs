using System;
using System.Net;
using System.Diagnostics;

namespace Lab_019_http
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://www.bbc.co.uk/weather");

            Console.WriteLine($"Host is {uri.Host}, Port is {uri.Port}, Path is {uri.AbsolutePath}");

            // Get Page
            var webClient = new WebClient { Proxy = null };

            webClient.DownloadFile(uri, "localpage.html");

            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");

        }
        
    }
}
