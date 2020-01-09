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
        private int bor_id { get; set; }
        private int bom_id { get; set; }
        private string bor_route { get; set; }
        private int m_id { get; set; }
        private int bor_tacktime { get; set; }
        private int bor_readytime { get; set; }
        private string bor_yn { get; set; }
        private string bor_comment { get; set; }

        public BorVO()
        {

        }

    }
}
