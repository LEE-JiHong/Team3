using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class ProductPriceVO
    {
        private int price_id { get; set; }
        private int product_id { get; set; }
        private int company_id { get; set; }
        private int price_present { get; set; }
        private int price_past { get; set; }
        private string price_sdate { get; set; }
        private string price_edate { get; set; }
        private string price_yn { get; set; }
        private string price_uadmin { get; set; }
        private string price_udate { get; set; }
        private string price_comment { get; set; }
        public ProductPriceVO()
        {

        }

    }
}
