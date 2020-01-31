using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class PriceInfoVO
    {
        public int price_id { get; set; }
        public int product_id { get; set; }
        public int company_id { get; set; }
        public string company_type { get; set; }
        public decimal price_present { get; set; }
        public decimal price_past { get; set; }
        public string price_sdate { get; set; }
        public string price_edate { get; set; }
        public string price_yn { get; set; }
        public string price_uadmin { get; set; }
        public string price_udate { get; set; }
        public string price_comment { get; set; }
        public string company_code { get; set; }
        public string company_name { get; set; }
        public string product_name { get; set; }
        public string product_unit { get; set; }
        public string product_codename { get; set; }





    }
}
