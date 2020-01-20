using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class FactoryVO
    {
        public int factory_id { get; set; } //ID
        public int company_id { get; set; } //업체
        public string company_name { get; set; }
        public string factory_uadmin { get; set; } //수정자
        public string factory_grade { get; set; } //시설군
        public string factory_parent { get; set; } //상위시설
        public string factory_name { get; set; } //시설명
        public string factory_code { get; set; } //시설코드
        public string factory_type { get; set; } //시설구분
        public string factory_yn { get; set; } // 사용유무
        public string factory_udate { get; set; } //수정시간
        public string factory_comment { get; set; } //설명
        public FactoryVO()
        {

        }

    }
    public class FactoryDB_VO
    {
    public int    FACTORY_ID { get; set; }
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
