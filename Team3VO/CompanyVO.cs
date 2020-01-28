using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class CompanyVO
    {
        public int company_id { get; set; }
        public string company_code { get; set; }
        public string company_name { get; set; }
        public string company_type { get; set; }
        public string company_ceo { get; set; }
        public string company_cnum { get; set; }
        public string company_btype { get; set; }
        public string company_gtype { get; set; }
        public int user_id { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_fax { get; set; }
        public string company_yn { get; set; }
        public string company_uadmin { get; set; }
        public string company_udate { get; set; }
        public string company_comment { get; set; }
        public string company_order_code { get; set; }

    }
    public class CompanyDB_VO
    {
        public int company_id { get; set; }//업체ID
        public string company_code { get; set; }//업체코드
        public string company_name { get; set; }//업체명
        public string common_name { get; set; }//업체타입
        public string company_type { get; set; }//업체타입 value
        public string company_ceo { get; set; }//대표자명
        public string company_cnum { get; set; }//사업자등록번호
        public string company_btype { get; set; }//업종
        public string company_gtype { get; set; }//업태
        public string user_name { get; set; }//담당자 
        public int user_id { get; set; }//담당자 id
        public string company_email { get; set; }//이메일
        public string company_phone { get; set; }//전화번호
        public string company_fax { get; set; }//팩스
        public string company_uadmin { get; set; }//수정자
        public string company_udate { get; set; }//수정시간
        public string company_comment { get; set; }//업체정보
        public string company_yn { get; set; }//사용유무
        public string company_order_code { get; set; }//업체발주코드
    }
}
