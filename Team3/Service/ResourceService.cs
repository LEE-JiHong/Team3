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
        ResourceDac dac = new ResourceDac();
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        public List<CompanyVO> GetCompanyAll()
        {
           
            return dac.GetCompanyAll();
        }
        /// <summary>
        ///  Machine 설비 모든컬럼 select
        /// </summary>
        public List<MachineVO> GetMachineAll()
        {
            return dac.GetMachineAll();
        }
        /// <summary>
        /// MachineGreade 설비군 모든컬럼 select
        /// </summary>
        public List<MachineGradeVO> GetMachineGrpAll()
        {
            return dac.GetMachineGrpAll();
        }
        public bool InsertMachineGr(MachineGradeVO VO)
        {
            return dac.InsertMachineGr(VO);
        }
        public List<BORDB_VO> GetBORAll()
        {
            return dac.GetBORAll();
        }
        public List<FactoryDB_VO> GetFactoryAll()
        {
            return dac.GetFactoryAll();
        }
        public bool InsertFactory(FactoryVO VO)
        {
            return dac.InsertFactory(VO);
        }
        public FactoryVO GetFactoryByID(int id)
        {
            return dac.GetFactoryByID(id);
        }
        public bool UpdateFactory(FactoryVO VO)
        {
           return dac.UpdateFactory(VO);
                    }
        public bool DelelteFactory (int Id)
        {
         
            return dac.DeleteFactory(Id);
        }
    }
}
