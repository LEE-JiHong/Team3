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



    class BorVO
    {
        private int BOR_ID { get; set; }
        private int BOM_ID { get; set; }
        private string BOR_ROUTE { get; set; }
        private int M_ID { get; set; }
        private int BOR_TACKTIME { get; set; }
        private int BOR_READYTIME { get; set; }
        private string BOR_YN { get; set; }
        private string BOR_COMMENT { get; set; }

        public BorVO()
        {

        }

    }
}
