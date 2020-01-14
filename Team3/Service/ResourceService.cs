using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;
 

namespace Team3
{
    public class ResourceService
    {
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        public List<CompanyVO> GetCompanyAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetCompanyAll();
        }
        /// <summary>
        ///  Machine 설비 모든컬럼 select
        /// </summary>
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
    }
}
