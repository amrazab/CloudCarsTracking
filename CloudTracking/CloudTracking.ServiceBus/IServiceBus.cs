using System;

namespace CloudTracking.ServiceBus
{
    public interface IServiceBus<T>
    {
        
        string QueueName { get; set; }
        bool Send(T message);
        event EventHandler<T> OnRecieve;

    }
}
