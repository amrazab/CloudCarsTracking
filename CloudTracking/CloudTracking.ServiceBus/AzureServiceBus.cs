using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTracking.ServiceBus
{
    public class AzureServiceBus<T> : IServiceBus<T>
    {
        private static IQueueClient queueClient;
        private const string ServiceBusConnectionString = "Endpoint=sb://azabsrvcbus.servicebus.windows.net/;SharedAccessKeyName=ReadWrite;SharedAccessKey=B8r+a5yMzJ1BWa1ecOo+vAk7a/RFukJqLnYZfyMprlI=";

        public AzureServiceBus()
        {
           
        }
        private string _queueName = null;
        public string QueueName {
            get
            {
                return _queueName;
            }
            set
            {
                if (_queueName == null || !(_queueName == value))
                {
                    _queueName = value;
                    queueClient = new QueueClient(ServiceBusConnectionString, _queueName, ReceiveMode.PeekLock);
                   
                }

            }
        }

        public  void startListen()
        {
          queueClient.RegisterMessageHandler(
                    async (message, token) =>
                    {
                        var messageJson = Encoding.UTF8.GetString(message.Body);
                        var messageObject = JsonConvert.DeserializeObject<T>(messageJson);

                        if (OnRecieve != null)
                            OnRecieve(this, messageObject);

                        await queueClient.CompleteAsync(message.SystemProperties.LockToken);
                    },
                    new MessageHandlerOptions(async args => Console.WriteLine(args.Exception))
                    { MaxConcurrentCalls = 1, AutoComplete = false });
        }

        public event EventHandler<T> OnRecieve;

        public bool Send(T message)
        {
            byte[] data = convertMessageToBytes(message);
            
            queueClient.SendAsync(new Message(data));
            return true;
        }

        private byte[] convertMessageToBytes(T message)
        {
            var json  = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
