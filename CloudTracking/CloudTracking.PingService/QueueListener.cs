using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using CloudTracking.Storage;
using Microsoft.Extensions.Configuration;
using System;

namespace CloudTracking.PingService
{
    internal class QueueListener
    {
        private IServiceBus<PingMessage> serviceBus;
        IStorage storage;
        internal  void Start(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            this.storage =  (IStorage)serviceProvider.GetService(typeof(IStorage)); ;
             serviceBus =(IServiceBus<PingMessage>) serviceProvider.GetService(typeof( IServiceBus<PingMessage>));
            serviceBus.ConnectionString = configuration["BusConnectionString"];
            serviceBus.QueueName = "pingqueue";
            serviceBus.OnRecieve += ServiceBuse_OnRecieve;
            serviceBus.startListen();
        }

        private  void ServiceBuse_OnRecieve(object sender, PingMessage message)
        {
            storage.UpdateStatusAsync(message);
            storage.LogStatus(message);
        }
    }
}