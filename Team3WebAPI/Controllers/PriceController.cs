using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team3VO;

namespace Team3WebAPI.Controllers
{
    public class PriceController : ApiController
    {
        // GET: api/Price
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Price/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Price
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Price/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Price/5
        public void Delete(int id)
        {
        }
    }
}
