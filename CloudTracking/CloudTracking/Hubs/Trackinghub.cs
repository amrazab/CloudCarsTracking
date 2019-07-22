using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Messages;
using Microsoft.AspNetCore.SignalR;


namespace CloudTracking.Hubs
{
    public class Trackinghub : Hub
    {
        public Trackinghub()
        {

        }

        public void getStatus()
        {
           // Clients.All.SendAsync("statusUpdated",null);
        }
        
       
    }
}
