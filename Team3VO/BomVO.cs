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
        //public BomVO() { }
        public int bom_id { get; set; }
        public string bom_parent_id { get; set; }
        public int product_id { get; set; }
        public string bom_name { get; set; }
        public int bom_level { get; set; }
        public int bom_use_count { get; set; }
        public string bom_sdate { get; set; }
        public string bom_edate { get; set; }
        public string bom_yn { get; set; }
        public string plan_yn { get; set; }
        public string bom_comment { get; set; }
        public string bom_uadmin { get; set; }
        public string bom_udate { get; set; }

       
    }


}
