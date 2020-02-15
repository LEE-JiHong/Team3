using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3WebAPI
{
    public class WorkVO
    {
        List<WorkRatePlanVO> workRateList;

        public List<WorkRatePlanVO> WorkRateList
        {
            get { return workRateList; }
            set { workRateList = value; }
        }

        

    }
    public class TodayWorkRateVO
    {

    }


    public class WorkRatePlanVO
    {
        public int row { get; set; }
        public string plan_id { get; set; }
        public string product_name { get; set; }
        public int so_pcount { get; set; }
        public int pro_count { get; set; }
        public string rate { get; set; }
        public string company_code { get; set; }
    }

}