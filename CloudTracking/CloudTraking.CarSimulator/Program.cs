using CloudTracking.Messages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;

namespace CloudTraking.CarSimulator
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string pingUrl = "";
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
             pingUrl = config["PingUrl"];
            Timer t = new Timer(ping,null,0,6000);
            Console.ReadLine();
        }
      
        private static void ping(object state)
        {
          
            try
            {
                Console.WriteLine("ping started");
                PingMessage pingMessage = new PingMessage() {
                    Time = DateTime.Now,
                CarId = "tst id",
                CarStatus = CarStatus.Working,
                CustomerId = "c Id",
                ErrorMessage = "",
                OilLevel = 10,
                Speed=100
                };
                var jsonn = JsonConvert.SerializeObject(pingMessage);
                client.PostAsync(pingUrl, new StringContent(jsonn, Encoding.UTF8, "application/json"));
                Console.WriteLine("sent....");
            }
            catch (Exception ex)
            {
                Console.Write("error while pingin the service : " + ex.Message);
            }
        }
    }
}
