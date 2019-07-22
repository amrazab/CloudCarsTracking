using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTracking.PingService
{
    public class QueueSender
    {
        private IServiceBus<PingMessage> serviceBus;
        public QueueSender(string connectoinString, string queueName, IServiceProvider serviceProvider)
        {
            serviceBus = (IServiceBus<PingMessage>)serviceProvider.GetService(typeof(IServiceBus<PingMessage>));
            serviceBus.ConnectionString = connectoinString;
            serviceBus.QueueName = queueName;
        }
        public void send(PingMessage message)
        {
            serviceBus.Send(message);
        }
    }
}
