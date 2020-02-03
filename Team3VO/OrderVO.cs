using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //DemandPlan 부분 VO
    //담당 : 이지홍
    //수정일 : 2020년 02월 03일 18:00
    // 발주 VO
    public class OrderVO
    {
        public string order_id { get; set; }
        public int product_id { get; set; }
        public int order_count { get; set; }
        public string plan_id { get; set; }
        public string order_serial { get; set; }
        public string order_state { get; set; }
        public string order_udate { get; set; }
        public string order_uadmin { get; set; }
        public string product_codename { get; set; }
        public string company_name { get; set; }
    }

    //public class SubOrderVO
    //{
        
    //    public int pro_count { get; set; }
    //    public string plan_id { get; set; }
    //}
}
