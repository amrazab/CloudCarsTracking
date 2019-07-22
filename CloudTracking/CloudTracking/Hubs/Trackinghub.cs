using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Messages;
using CloudTracking.Storage;
using Microsoft.AspNetCore.SignalR;


namespace CloudTracking.Hubs
{
    public class Trackinghub : Hub
    {
        private IStorage storage;
        public Trackinghub(IStorage storage)
        {
            this.storage = storage;
        }

        public void getStatus()
        {
           var status =  storage.GetStatusAsync(null, null).GetAwaiter().GetResult();
            Clients.Caller.SendAsync("statusLoaded", status);
        }
        
       
    }
}
