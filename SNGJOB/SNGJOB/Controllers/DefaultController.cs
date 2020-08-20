using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SNGJOB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        // GET: api/Default
        [HttpGet]
        public string Get()
        {
            return "You get value";
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "you get " + id;
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT: api/Default/5
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
