using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team3VO;

namespace Team3WebAPI.Controllers
{
    public class ResourceController : ApiController
    {
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        // GET: api/Resource
        public List<CompanyVO> GetCompanyAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetCompanyAll();
        }

        /// <summary>
        ///  Machine 설비 모든컬럼 select
        /// </summary>
        // GET: api/Resource/5
        public List<MachineVO> GetMachineAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetMachineAll();
        }

        /// <summary>
        /// MachineGreade 설비군 모든컬럼 select
        /// </summary>
        public List<MachineGradeVO> GetMachineGrpAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetMachineGrpAll();
        }

        public List<BORDB_VO> GetBORAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetBORAll();
        }
        public List<FactoryDB_VO> GetFactoryAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetFactoryAll();
        }

        // POST: api/Resource
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Resource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Resource/5
        public void Delete(int id)
        {
        }
    }
}
