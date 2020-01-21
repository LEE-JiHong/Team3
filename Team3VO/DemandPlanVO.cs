using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //DemandPlan 부분 VO
    //담당 : 이지홍

    public class DayVO
    {
        public string date { get; set; }
        public string plan_type { get; set; }
    }

    public class DemandPlanVO
    {
        public int d_id { get; set; }
        public int so_id { get; set; }
        public string plan_id { get; set; }
        public string d_date { get; set; }
        public int d_count { get; set; }
    }
}
