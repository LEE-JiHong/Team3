using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //BOR 부분 VO
    //담당 : 심우균
    //기본생성자 1개, full 생성자 1개.



    public class BorVO
    {
        public int bor_id { get; set; }
        public int bom_id { get; set; }
        public string bor_route { get; set; }
        public int m_id { get; set; }
        public int bor_tacktime { get; set; }
        public int bor_readytime { get; set; }
        public string bor_yn { get; set; }
        public string bor_comment { get; set; }

        public BorVO()
        {

        }
    }
    public class BORDB_VO
    {
        public int bor_id { get; set; }
        public int bom_id { get; set; }
        public string product_name { get; set; }
        public string product_codename { get; set; }
        public string common_type { get; set; }
        public string common_name { get; set; }
        public string m_code { get; set; }
        public string m_name { get; set; }
        public int bor_tacktime { get; set; }
        public int bor_readytime { get; set; }
        public string bor_yn { get; set; }
        public string bor_comment { get; set; }



    }
}
