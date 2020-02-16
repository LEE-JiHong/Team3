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
            foreach(var item in unlist)
            {
                item.rate =(int)((item.w_time*1.0 /item.total*1.0)*100);
            }
            workvo.UnWorkingList = unlist;


            WorkDac wdac3 = new WorkDac();
            workvo.TodayUnworkData = wdac3.GetTodayUnWorkingTimeData();
            

            return View(workvo);
        }
    }
}