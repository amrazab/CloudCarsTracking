using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Messages;
using CloudTracking.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace CloudTraking.PingGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private IServiceBus<PingMessage> _serviceBus;
        public PingController(IServiceBus<PingMessage> serviceBus)
        {
            _serviceBus = serviceBus;
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
                return "Done";
            }catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

    }
}
