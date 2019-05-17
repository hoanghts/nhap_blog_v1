using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;

namespace nhap_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEasyCachingProvider _provider;
        public ValuesController(IEasyCachingProvider provider)
        {
            this._provider = provider;
        }
        // GET api/values
        [HttpGet]
        public void Set()
        {
            //Remove
            _provider.Remove("demo");

            //Set
            _provider.Set("demo", "123", TimeSpan.FromSeconds(10));
        }

        // GET api/values/
        [HttpGet("test/{id}")]
        public string Get_1(int id)
        {
            var res = _provider.Get<string>("demo");
            return res.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
