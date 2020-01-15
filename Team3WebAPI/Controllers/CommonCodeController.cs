using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team3VO;

namespace Team3WebAPI.Controllers
{
    public class CommonCodeController : ApiController
    {
        /// <summary>
        /// CommonCode 컬럼 모두 select
        /// </summary>
        // GET: api/CommonCode
        public List<CommonVO> GetCommonCodeAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetCommonCodeAll();
        }

        // GET: api/CommonCode/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CommonCode
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CommonCode/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CommonCode/5
        public void Delete(int id)
        {
        }
    }
}
