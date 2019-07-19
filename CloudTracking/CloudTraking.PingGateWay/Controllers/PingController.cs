using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Messages;
using Microsoft.AspNetCore.Mvc;

namespace CloudTraking.PingGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ping GateWay";
        }

      
        [HttpPost]
        public ActionResult<string> Post([FromBody]PingMessage pingMessage)
        {
            return "value";
        }

    }
}
