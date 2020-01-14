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
        public int BOR_ID { get; set; }
        public int BOM_ID { get; set; }
        public string BOR_ROUTE { get; set; }
        public int M_ID { get; set; }
        public int BOR_TACKTIME { get; set; }
        public int BOR_READYTIME { get; set; }
        public string BOR_YN { get; set; }
        public string BOR_COMMENT { get; set; }

        public BorVO()
        {

        }
    }
    public class BORDB_VO
    {
        public int BOR_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CODENAME { get; set; }
        public string COMMON_TYPE { get; set; }
        public string COMMON_NAME { get; set; }
        public string M_CODE { get; set; }
        public string M_NAME { get; set; }
        public string BOR_TACKTIME { get; set; }
        public string BOR_READYTIME { get; set; }
        public string BOR_YN { get; set; }
        public string BOR_COMMENT { get; set; }



    }
}
