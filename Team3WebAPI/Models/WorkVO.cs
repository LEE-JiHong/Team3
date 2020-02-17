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
        List<TodayWorkRateVO> todayWorkList;
        List<UnWorkingTimeRank> unWorkingList;
        List<TodayUnWorkingVO> todayUnworkData;
        List<WorkChartVO> chartRankData;
        public List<WorkRatePlanVO> WorkRateList
        {
            get { return workRateList; }
            set { workRateList = value; }
        }

        public List<TodayWorkRateVO> TodayWorkList
        {
            get { return todayWorkList; }
            set { todayWorkList = value; }
        }
        public List<UnWorkingTimeRank> UnWorkingList
        {
            get { return unWorkingList; }
            set { unWorkingList = value; }
        }
        public List<TodayUnWorkingVO> TodayUnworkData
        {
            get { return todayUnworkData; }
            set { todayUnworkData = value; }
        }
        public List<WorkChartVO> ChartRankData
        {
            get { return chartRankData; }
            set { chartRankData = value; }
        }


    }
    public class TodayWorkRateVO
    {
        public int row { get; set; }
        public string bor_comment { get; set; }
        public int work { get; set; }
        public int pro_count { get; set; }
        public string rate { get; set; }
      
    }


    public class WorkChartVO
    {
        public string user_name { get; set; }
        public int time { get; set; }

    }

    public class UnWorkingTimeRank
    {
        public int row { get; set; }
        public string w_comment { get; set; }
        public int w_time { get; set; }

        public int total { get; set; }
        public int rate { get; set; }


    }

    public class TodayUnWorkingVO
    {
        public int m_id { get; set; }
        public string w_edate { get; set; }
        public string m_name { get; set; }
        public string w_category { get; set; }
        public string w_comment { get; set; }
        public int min { get; set; }
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