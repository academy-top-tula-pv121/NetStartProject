using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetStartProject
{
    internal class WebClientExample
    {
        public static void Run()
        {
            IPAddress ip = IPAddress.Loopback;

            IPAddress[] ipsYandex = Dns.GetHostAddresses("yandex.ru");
            foreach (var ipOne in ipsYandex)
                Console.WriteLine($"{ipOne.ToString()}");
            Console.WriteLine(new String('-', 20));


            IPHostEntry host = Dns.GetHostEntry("yandex.ru");
            Console.WriteLine($"-- {host.HostName} --");
            foreach (var ipOne in host.AddressList)
                Console.WriteLine($"{ipOne.ToString()}");


            // WebClient
            WebClient client = new();
            string downFile = "https://fs.top-academy.ru/api/v1/files/VgQukFUE7nnTYhruAArk-OB8LyscNgIV?inline=true";
            string saveFile = "myfile.pdf";

            client.DownloadFile(downFile, saveFile);

            using (MemoryStream stream = new(client.DownloadData(downFile)))
            {

                Console.WriteLine($"{stream.Length}");
                byte[] buffer = new byte[stream.Length];
                using (BinaryReader file = new(stream))
                {
                    file.Read(buffer, 0, buffer.Length);
                };
                using (BinaryWriter file = new(File.OpenWrite("myfile2.pdf")))
                {
                    file.Write(buffer);
                };
            }

            using (Stream stream = client.OpenRead("https://top-academy.ru"))
            {
                using (StreamReader reader = new(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        Console.WriteLine(line);
                }

            }
        }
    }
}
