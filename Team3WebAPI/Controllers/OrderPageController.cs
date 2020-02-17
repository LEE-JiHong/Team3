using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3WebAPI.Controllers
{
    public class OrderPageController : Controller
    {
        // GET: OderPage
        public ActionResult Index()
        {
            OrderPageVO orderpageVo = new OrderPageVO();
            OrderDac odac = new OrderDac();
            orderpageVo.LastestList = odac.GetLastestOrderList();

            OrderDac odac1 = new OrderDac();
            orderpageVo.LastestOrderList = odac1.GetLastestOrderDataList();
            OrderDac odac2 = new OrderDac();
            orderpageVo.YearSalesChartList = odac2.GetYearSalesChartList();


            OrderDac odac3 = new OrderDac();
            orderpageVo.YearSalesCompanyList = odac3.GetYearSalesCompanyList();
            string labels = string.Empty;
            List<List<SalesChartVO>> list = new List<List<SalesChartVO>>();
            foreach (var item in orderpageVo.YearSalesCompanyList)
            {
                labels += item.s_month + ",";
                var tlist = (from titem in orderpageVo.YearSalesChartList
                             where titem.s_company == item.s_company
                             select titem).ToList();
                list.Add(tlist);

            }


            string[] month = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            int imon = DateTime.Now.Month;
            string months = string.Empty;
            for (int i = imon-1; i < imon + 12; i++)
            {
                if (i >= 12)
                {
                   
                    months += month[i - 12] + ",";
                }
                else
                {
                    if (i == int.Parse(month[i-1]))
                    {
                        months += month[i] + ",";
                    }
                }
            }
            string data = string.Empty;
            foreach(var sitem in orderpageVo.YearSalesChartList)
            {
                data += sitem.totalprice+",";
            }

            orderpageVo.TotalyearSalesCompanyList = list;

            ViewBag.Labels = labels.TrimEnd(',');
            ViewBag.Label1 = "labels1";
            ViewBag.data1 = data.TrimEnd(',');
            ViewBag.Label2 = "labels2";

            ViewBag.Label3 = "label3";

            return View(orderpageVo);
        }
    }
}