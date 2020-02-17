using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team3WebAPI;

namespace Team3WebAPI.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index()
        {
            WorkVO workvo = new WorkVO();
            
            
            WorkDac wdac = new WorkDac();
            workvo.WorkRateList = wdac.GetWorkRatePlan();


            WorkDac wdac1 = new WorkDac();
            workvo.TodayWorkList = wdac1.GetTodayWorkRate();

            WorkDac wdac2 = new WorkDac();
            List<UnWorkingTimeRank> unlist = wdac2.GetUnWorkingTimeData();
            int sum = 0;
            sum =unlist.Sum(p => p.total);
            foreach(var item in unlist)
            {
                item.rate =(int)((item.total* 1.0 / sum * 1.0)*100);
            }
            workvo.UnWorkingList = unlist;


            WorkDac wdac3 = new WorkDac();
            workvo.TodayUnworkData = wdac3.GetTodayUnWorkingTimeData();

            WorkDac wdac4 = new WorkDac();
            workvo.ChartRankData = wdac4.GetWorkTimeRank();
            string data = "[";
            string name = string.Empty;
            foreach (var item in workvo.ChartRankData)
            { 
                name += item.user_name + ",";
                data += item.time+",";
            }
            data = data.TrimEnd(',') + "]";

            ViewBag.Data = data;
            ViewBag.Name = name;
            return View(workvo);
        }
    }
}