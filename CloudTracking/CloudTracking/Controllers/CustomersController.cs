using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudTracking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return new Customer[] { new Customer() { Id = "tst", Name = "Customer 1", Address = "Cairo" },
                new Customer() { Id = "tst2", Name = "Customer 2", Address = "Alex" }};
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
