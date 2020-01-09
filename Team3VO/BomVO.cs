using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //BOM 부분 VO
    //담당 : 김우근
    //기본생성자 1개, full 생성자 1개.

    class BomVO
    {
        private int BOM_ID { get; set; }
        private int BOM_PARENT_ID { get; set; }
        private int PRODUCT_ID { get; set; }
        private int BOM_USE_COUNT { get; set; }
        private string BOM_SDATE { get; set; }
        private string BOM_EDATE { get; set; }
        private string BOM_YN { get; set; }
        private int PLAN_ID { get; set; }
        private string BOM_COMMENT { get; set; }
        private string BOM_UADMIN { get; set; }
        private string BOM_UDATE { get; set; }

        public BomVO() { }
    }


}
