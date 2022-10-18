using Microsoft.VisualBasic;
using System.Net;
using System.Runtime.CompilerServices;

namespace NetStartProject
{
    internal class Program
    {
        static async Task MyRequestAsync()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://top-academy.ru");
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            request.Credentials = new NetworkCredential("login", "password");

            using(StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                //Console.WriteLine(sr.ReadToEnd());
            }

            WebHeaderCollection webHeader = response.Headers;
            for(int i = 0; i < webHeader.Count; i++)
                Console.WriteLine($"{webHeader.GetKey(i)} - {webHeader[i]}");
        }
        static async Task Main(string[] args)
        {
            //WebClientExample.Run();
            await MyRequestAsync();
        }
    }
}