using CloudTracking.Messages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;
using System.Collections.Generic;

namespace CloudTraking.CarSimulator
{
    class Program
    {
        static List<PingMessage> pingMessages = new List<PingMessage>();
        static List<Simulator> simulators = new List<Simulator>();
       
        static void Main(string[] args)
        {
            fillDummyData();

            IConfiguration config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
            CloudTracking.Storage.AzureTableStorage azureTableStorage = new CloudTracking.Storage.AzureTableStorage(config["AzureTableConnectionString"]);
             var stauts = azureTableStorage.GetStatusAsync(null,null).GetAwaiter().GetResult();
            foreach (var msg in pingMessages) {
                simulators.Add(new Simulator(msg, config["PingUrl"]));
            }
        
            Console.ReadLine();
        }

        private static void fillDummyData()
        {
            Random rnd = new Random();
            pingMessages.Add(new PingMessage() { CustomerId = "cust1", CarId = "c1", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust1", CarId = "c2", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust1", CarId = "c3", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust1", CarId = "c4", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust2", CarId = "c5", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust2", CarId = "c6", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust2", CarId = "c7", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust2", CarId = "c8", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust2", CarId = "c9", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust3", CarId = "c10", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust3", CarId = "c11", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust3", CarId = "c12", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust3", CarId = "c13", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust4", CarId = "c14", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust4", CarId = "c15", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
            pingMessages.Add(new PingMessage() { CustomerId = "cust4", CarId = "c16", CarStatus = CarStatus.Working, OilLevel = rnd.Next(1,100), ErrorMessage = "", Speed = rnd.Next(1,100), Time = DateTime.Now });
        }

       
    }
}
