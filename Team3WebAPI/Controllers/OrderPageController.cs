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
            List<SalesChartVO> ylist = odac2.GetYearSalesChartList();
            orderpageVo.YearSalesChartList= odac2.GetYearSalesChartList();

            OrderDac odac3 = new OrderDac();
            orderpageVo.YearSalesCompanyList = odac3.GetYearSalesCompanyList();
            ViewBag.SumTotalPrice = orderpageVo.YearSalesCompanyList.Sum(p => p.totalprice);


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

            foreach (var item in list)
            {
                foreach(var sitem in item)
                sitem.s_month = sitem.s_month.Substring(5, 2);
            }

            orderpageVo.YearSalesChartList= ylist;
            string[] month = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            int imon = DateTime.Now.Month;
            string months = string.Empty;
            for (int i = imon-1; i < imon + 11; i++)
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
            string data ="[";
            foreach(var sitem in orderpageVo.YearSalesChartList)
            {
                data += sitem.totalprice + ",";
            }
            


            //ViewBag.Labels = months.TrimEnd(',');
            ViewBag.Labels = months.TrimEnd(',');
            string[] testmonth = months.TrimEnd(',').Split(',');
            ViewBag.Label1 = testmonth[0];           
            ViewBag.Label2 = testmonth[1];
            ViewBag.Label3 = testmonth[2];
            ViewBag.Label4 = testmonth[3];
            ViewBag.Label5 = testmonth[4];
            ViewBag.Label6 = testmonth[5];
            ViewBag.Label7 = testmonth[6];
            ViewBag.Label8 = testmonth[7];
            ViewBag.Label9 = testmonth[8];
            ViewBag.Label10 = testmonth[9];
            ViewBag.Label11 = testmonth[10];
            ViewBag.Label12 = testmonth[11];
            ViewBag.data1 = data.TrimEnd(',')+"]";



            OrderDac odac4 = new OrderDac();
            orderpageVo.OrderCostList = odac4.GetOrderCostList();
            if(orderpageVo.OrderCostList[1].totalprice < orderpageVo.OrderCostList[0].totalprice)
            {
                ViewBag.OrderRate =100 - @Convert.ToInt32((orderpageVo.OrderCostList[1].totalprice / orderpageVo.OrderCostList[0].totalprice) * 100);
            }    
            
            


            return View(orderpageVo);
        }
    }
}