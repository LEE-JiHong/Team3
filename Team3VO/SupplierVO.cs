using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //Supplier(입고대기) 
    //담당 : 이지홍

    /// <summary>
    /// 입고대기 조건검색 vo
    /// </summary>
    public class SupplierVO
    {
        public string order_state { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string company_name { get; set; }
        public string order_id { get; set; }
    }

    /// <summary>
    /// 입고대기 vo
    /// </summary>
    public class WatingReceivingVO
    { 
        public string order_id { get; set; }
        public string order_ddate { get; set; }
        public string company_name { get; set; }
        public string product_codename { get; set; }
        public string product_name { get; set; }
        public int order_count { get; set; }
        public string order_pdate { get; set; }
        public string order_sdate { get; set; }
        public string common_name { get; set; }
    }

    /// <summary>
    /// 발주상태 vo
    /// </summary>
    public class OrderStateVO
    {
        public string state_code { get; set; }
        public string state_name { get; set; }
    }

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
