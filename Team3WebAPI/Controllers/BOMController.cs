using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team3VO;

namespace Team3WebAPI.Controllers
{
    public class BOMController : ApiController
    {
        /// <summary>
        /// 모든 Bom 조회
        /// </summary>
        /// <returns></returns>
        // GET: api/BOM
        public List<BomVO> GetBomAll()
        {
            BomDac dac = new BomDac();
            return dac.GetBomAll();
        }

        // GET: api/BOM/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Bom 신규 추가
        /// </summary>
        /// <returns></returns>
        // POST: api/BOM
        public bool AddBom(BomVO vo)
        {
            BomDac dac = new BomDac();
            return dac.AddBom(vo);
        }

        // PUT: api/BOM/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BOM/5
        public void Delete(int id)
        {
        }
    }
}
