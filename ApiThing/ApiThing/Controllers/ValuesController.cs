using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiThing.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiThing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // really, we'd use a database
        public static List<Temperature> Data = new List<Temperature>();
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Temperature>> Get()
        {
            return Data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Temperature> Get(int id)
        {
            var ret = Data.FirstOrDefault(x => x.TempId == id);
            if (ret == null)
            {
                NotFound();
            }
            return ret;
        }

        // POST api/values
        // inserting a new resource
        [HttpPost]
        public void Post([FromBody] Temperature value)
        {
            Data.Add(value);
        }

        // PUT api/values/5
        // replace existing resource
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temperature value)
        {
            var existing = Data.FirstOrDefault(x => x.TempId == id);
            if (existing != null)
            {
                Data.Remove(existing);

            }
            Data.Add(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existing = Data.FirstOrDefault(x => x.TempId == id);
            if (existing != null)
            {
                Data.Remove(existing);

            }
            return Ok();
        }
    }
}
