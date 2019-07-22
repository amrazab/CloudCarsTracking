using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using CloudTracking.Storage;
using Microsoft.Extensions.Configuration;
using System;

namespace CloudTracking.PingService
{
    internal class QueueListener
    {
        IServiceBus<PingMessage> serviceBus;
         IStorage storage;
        private string connectoinString;
        private IServiceProvider serviceProvider;
        internal  void Start(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.storage =  (IStorage)serviceProvider.GetService(typeof(IStorage)); ;
             serviceBus =(IServiceBus<PingMessage>) serviceProvider.GetService(typeof( IServiceBus<PingMessage>));
            serviceBus.ConnectionString =connectoinString= configuration["BusConnectionString"];
            serviceBus.QueueName = "pingqueue";
            serviceBus.OnRecieve += ServiceBuse_OnRecieve;
            serviceBus.startListen();
        }

        private  void ServiceBuse_OnRecieve(object sender, PingMessage message)
        {
            storage.UpdateStatusAsync(message);
            new QueueSender(connectoinString, "eventsourcingqueue", serviceProvider).send(message);
            new QueueSender(connectoinString, "statusqeue", serviceProvider).send(message);
        }
    }
}