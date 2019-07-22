using CloudTracking.Hubs;
using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CloudTracking
{
    public class QueueListener
    {
        public EventHandler<PingMessage> OnRecieve;
        private IServiceBus<PingMessage> serviceBus;
        private string connectoinString;
        private IServiceProvider serviceProvider;
        internal void Start(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
          
            serviceBus = (IServiceBus<PingMessage>)serviceProvider.GetService(typeof(IServiceBus<PingMessage>));
            serviceBus.ConnectionString = connectoinString = configuration["BusConnectionString"];
            serviceBus.QueueName = "statusqeue";
            serviceBus.OnRecieve += ServiceBuse_OnRecieve;
            serviceBus.startListen();
        }

        private void ServiceBuse_OnRecieve(object sender, PingMessage message)
        {

          //  IHubContext<Trackinghub> hubContext = Startup.hubContext;//  (IHubContext<Trackinghub>)serviceProvider.GetRequiredService(typeof(IHubContext<Trackinghub>));
          //  hubContext.Clients.All.SendAsync("statusUpdated", message);
            if (OnRecieve != null)
                OnRecieve(null, message);
        }
    }
}

