using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using System;

namespace CloudTracking.PingService
{
    internal class QueueListener
    {
        private IServiceBus<PingMessage> serviceBus;
        internal static void Start(IServiceProvider serviceProvider)
        {
            var serviceBuse =(IServiceBus<PingMessage>) serviceProvider.GetService(typeof( IServiceBus<PingMessage>));
            serviceBuse.QueueName = "pingqueue";
            serviceBuse.OnRecieve += ServiceBuse_OnRecieve;
        }

        private static void ServiceBuse_OnRecieve(object sender, PingMessage e)
        {
            
        }
    }
}