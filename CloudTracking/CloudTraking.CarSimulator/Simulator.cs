using CloudTracking.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace CloudTraking.CarSimulator
{
    class Simulator
    {
        static HttpClient client = new HttpClient();
        static string pingUrl = "";
        PingMessage msg;
        Timer t ;
        public Simulator(PingMessage msg, string url)
        {
            this.msg = msg;
            pingUrl = url;
            t = new Timer(ping, null, 0, 60000);
        }
        private  void ping(object state)
        {

            try
            {
                Console.WriteLine("ping started");
                msg.Time = DateTime.Now;
                msg.OilLevel -= 5;
                if(msg.OilLevel<10)
                {
                    if (msg.OilLevel <= 0)
                    {
                        msg.OilLevel = 100;
                        msg.CarStatus = CarStatus.Working;

                        msg.ErrorMessage = "";
                    }
                    else
                    {
                        msg.CarStatus = CarStatus.Error;
                        msg.OilLevel = 0;
                        msg.ErrorMessage = "out of oil";
                    }
                   
                }
                msg.Speed++;
                var jsonn = JsonConvert.SerializeObject(msg);
                client.PostAsync(pingUrl, new StringContent(jsonn, Encoding.UTF8, "application/json")).GetAwaiter().GetResult(); ;
                Console.WriteLine("sent....");
            }
            catch (Exception ex)
            {
                Console.Write("error while pingin the service : " + ex.Message);
            }
        }
    }
}
