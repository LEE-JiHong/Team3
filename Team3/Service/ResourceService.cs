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

        //
        public List<UserVO> GetUserAll()
        {
            return dac.GetUserAll();
        }


        //======이하 업체==============
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        public List<CompanyDB_VO> GetCompanyAll()
        {

            return dac.GetCompanyAll();
        }
        public bool InsertCompany(CompanyVO vo)
        {
            return dac.InsertCompany(vo);
        }
        public bool UpdateCompany(CompanyVO vo)
        {
            return dac.UpdateCompany(vo);
        }
        public CompanyDB_VO GetCompanyByID(int i)
        {
            return dac.GetCompanyByID(i);
        }
        public bool DeleteCompany(int i)
        {
            return dac.DeleteCompany(i);
        }
        //=====이하 설비==============
        /// <summary>
        ///  Machine 설비 모든컬럼 select
        /// </summary>
        public List<MachineVO> GetMachineAll()
        {
            return dac.GetMachineAll();
        }
        public bool InsertMachine(MachineVO VO)
        {
            return dac.InsertMachine(VO);
        }
        public bool UpdateMachine(MachineVO VO)
        {
            return dac.UpdateMachine(VO);
        }
        public bool DeleteMachin(int i)
        {
            return dac.DeleteMachin(i);
        }

        //=============이하 설비군=========
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
        public bool UpdateMachineGr(MachineGradeVO VO)
        {
            return dac.UpdateMachineGr(VO);
        }
        public bool DeleteMachineGr(int i)
        {
            return dac.DeleteMachineGr(i);
        }



        //=========이하 BOR=========

        public List<BORDB_VO> GetBORAll()
        {
            return dac.GetBORAll();
        }
        public BORDB_VO GetBORByID(int i, string route)
        {
            return dac.GetBORByID(i, route);
        }
        public bool InsertBOR(BorVO vo)
        {
            return dac.InsertBOR(vo);
        }
        public bool DeleteBOR(int i)
        {
            return dac.DeleteBOR(i);
        }
        public bool UpdateBOR(BorVO vo)
        {
            return dac.UpdateBOR(vo);
        }

        //=============이하 공장=======
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
        public bool DelelteFactory(int Id)
        {

            return dac.DeleteFactory(Id);
        }
    }
}
