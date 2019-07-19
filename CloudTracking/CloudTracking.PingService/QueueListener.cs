using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using CloudTracking.Storage;
using System;

namespace CloudTracking.PingService
{
    internal class QueueListener
    {
        private IServiceBus<PingMessage> serviceBus;
        IStorage storage;
        internal  void Start(IServiceProvider serviceProvider)
        {
            this.storage =  (IStorage)serviceProvider.GetService(typeof(IStorage)); ;
             serviceBus =(IServiceBus<PingMessage>) serviceProvider.GetService(typeof( IServiceBus<PingMessage>));
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