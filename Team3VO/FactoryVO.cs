using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class FactoryVO
    {
        public int FACTORY_ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int FACTORY_UADMIN { get; set; }
        public string FACTORY_GRADE { get; set; }
        public string FACTORY_PARENT { get; set; }
        public string FACTORY_NAME { get; set; }
        public string FACTORY_CODE { get; set; }
        public string FACTORY_TYPE { get; set; }
        public string FACTORY_YN { get; set; }
        public string FACTORY_UDATE { get; set; }
        public string FACTORY_COMMENT { get; set; }
        public FactoryVO()
        {

        }

    }
    public class FactoryDB_VO
    {
    public string    FACTORY_ID { get; set; }
    public string    FACILITY_CLASS { get; set; } //시설군
        public string    FACILITY_TYPE { get; set; } //시설구분
        public string    FACILITY_VALUE { get; set; }//시설타입
        public string    FACTORY_CODE { get; set; } //시설코드
        public string    FACTORY_NAME { get; set; } //시설명
        public string    FACTORY_PARENT { get; set; } //상위시설
        public string    COMPANY_NAME { get; set; } //업체명
        public string    FACTORY_YN { get; set; } //사용유무
        public string    FACTORY_UADMIN { get; set; } //수정자
        public string    FACTORY_UDATE { get; set; } //수정시간
    }
}
