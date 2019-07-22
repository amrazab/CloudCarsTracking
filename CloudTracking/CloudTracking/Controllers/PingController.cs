using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Hubs;
using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace CloudTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private IServiceBus<PingMessage> _serviceBus;
        IHubContext<Trackinghub> hub;
        public PingController(IServiceBus<PingMessage> serviceBus,IConfiguration configuration, IHubContext<Trackinghub> hub)
        {
            this.hub = hub;
            _serviceBus = serviceBus;
            _serviceBus.ConnectionString = configuration["BusConnectionString"];
            _serviceBus.QueueName = "pingqueue";
        }
       
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ping GateWay";
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="pingMessage"></param>
      /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody]PingMessage pingMessage)
        {
            try
            {
                _serviceBus.Send(pingMessage);
                hub.Clients.All.SendAsync("statusUpdated", pingMessage);
                return "Done";
            }catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

    }
}
