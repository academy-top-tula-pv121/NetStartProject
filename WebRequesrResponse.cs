using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetStartProject
{
    internal class WebRequesrResponse
    {
        public static void Run()
        {
            string downFile = "https://fs.top-academy.ru/api/v1/files/VgQukFUE7nnTYhruAArk-OB8LyscNgIV?inline=true";
            WebRequest request = WebRequest.Create("https://top-academy.ru");
            WebResponse response = request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                //string text = reader.ReadToEnd();
                //Console.WriteLine(text);
                Console.WriteLine($"Response");
                Console.WriteLine($"ContentType: {response.ContentType}");
                WebHeaderCollection webHeader = response.Headers;
                var headers = Enumerable.Range(0, webHeader.Count)
                                        .Select(h =>
                                        {
                                            return new
                                            {
                                                Key = webHeader.GetKey(h),
                                                Names = webHeader.GetValues(h)
                                            };
                                        });
                foreach (var item in headers)
                {
                    Console.WriteLine($"- {item.Key}");
                    foreach (var v in item.Names)
                        Console.WriteLine($"\t{v}");
                }


                Console.WriteLine($"\nRequest");
                Console.WriteLine($"URL: {request.RequestUri}");
                Console.WriteLine($"Method: {request.Method}");
                webHeader = request.Headers;

                headers = Enumerable.Range(0, webHeader.Count)
                                        .Select(h =>
                                        {
                                            return new
                                            {
                                                Key = webHeader.GetKey(h),
                                                Names = webHeader.GetValues(h)
                                            };
                                        });
                foreach (var item in headers)
                {
                    Console.WriteLine($"- {item.Key}");
                    foreach (var v in item.Names)
                        Console.WriteLine($"\t{v}");
                }
            }
        }
    }
}
