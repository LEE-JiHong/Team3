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

  public  class BomVO
    {
        public int BOM_ID { get; set; }
        public int BOM_PARENT_ID { get; set; }
        public int PRODUCT_ID { get; set; }
        public int BOM_USE_COUNT { get; set; }
        public string BOM_SDATE { get; set; }
        public string BOM_EDATE { get; set; }
        public string BOM_YN { get; set; }
        public int PLAN_ID { get; set; }
        public string BOM_COMMENT { get; set; }
        public string BOM_UADMIN { get; set; }
        public string BOM_UDATE { get; set; }

        public BomVO() { }
    }


}
