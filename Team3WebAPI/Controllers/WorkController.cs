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





            return View(workvo);
        }
    }
}