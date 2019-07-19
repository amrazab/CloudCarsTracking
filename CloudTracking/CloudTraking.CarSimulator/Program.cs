using CloudTracking.Messages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace CloudTraking.CarSimulator
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
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
                client.PostAsync("http://localhost:59426/api/Ping", new StringContent(jsonn, Encoding.UTF8, "application/json"));
                Console.WriteLine("sent....");
            }
            catch (Exception ex)
            {
                Console.Write("error while pingin the service : " + ex.Message);
            }
        }
    }
}
