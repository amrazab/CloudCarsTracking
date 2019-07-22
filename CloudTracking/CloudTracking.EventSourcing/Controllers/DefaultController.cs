using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CloudTracking.EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET api/Default
        [HttpGet]
        public string Get()
        {
            return "evnet sourcing service";
        }

        
    }
}
