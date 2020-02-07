using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class ShipmentVO
    {
        public int so_id { get; set; }
        public string plan_id { get; set; }
        public string company_code { get; set; }
        public string company_type { get; set; }
        public string product_name { get; set; }
        public int so_pcount { get; set; }
        public int so_ocount { get; set; }
        public int so_ccount { get; set; }
        public string so_edate { get; set; }
        public string so_sdate { get; set; }
    }
}
