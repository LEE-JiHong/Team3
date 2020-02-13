using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //자재입고VO
    //담당 : 이지홍
    public class MaterialReceivingVO
    {
        public string order_serial { get; set; }
        public string plan_id { get; set; }
        public string company_name { get; set; }
        public string product_codename { get; set; }
        public string product_name { get; set; }
        public int order_count { get; set; }
        public int order_qcount { get; set; }
        public int factory_id { get; set; }
        public int product_id { get; set; }
        public string order_pdate { get; set; }
        public string order_sdate { get; set; }
        public string common_name { get; set; }
        public int w_id { get; set; }
        public string wh_comment { get; set; }
        public string wh_udate { get; set; }
    }
}
