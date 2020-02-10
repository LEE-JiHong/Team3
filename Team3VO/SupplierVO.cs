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
    /// 영업마스터 VO
    /// </summary>
    public class SupplierVO
    {
        public string order_state { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string company_name { get; set; }
        public string order_id { get; set; }
    }
}
