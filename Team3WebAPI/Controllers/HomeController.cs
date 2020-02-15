using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;




namespace Team3WebAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            HomeVO homevo = new HomeVO();
            HomeDac hdac = new HomeDac();
            
            
            List<UserVO> userlist = hdac.GetLastestUsers();
            homevo.Userlist = userlist;
            
            HomeDac hdac1 = new HomeDac();
            homevo.WorkRate = hdac1.GetWorkRate();

            HomeDac hdac2 = new HomeDac();
            homevo.CompanyCount = hdac2.GetCompanyCount();
            List<CompanyVO> clist = hdac2.GetCompanyCount();
            CompanyVO result = new CompanyVO();
            result.sum = clist.Sum(item => item.sum);
            result.month = clist[1].sum;
            homevo.CompanyData = result;

            HomeDac hdac3 = new HomeDac();
            homevo.SalseRate = hdac3.GetSalesRate();

            homevo.SalesPrice = string.Format("{0:c}", Convert.ToInt32(homevo.SalseRate[1].price));
            homevo.SalesRateToView = ((homevo.SalseRate[1].price  / homevo.SalseRate[0].price ) * 100).ToString()+"%";
            
            
            if((homevo.SalseRate[1].price / homevo.SalseRate[0].price) * 100>100)
            {
                homevo.SalesRateBool = true;
            }
            else
            {
                homevo.SalesRateBool = false;
                homevo.SalesRateToView = (100 - ((homevo.SalseRate[1].price / homevo.SalseRate[0].price) * 100)).ToString()+"%";
            }



            HomeDac hdac4 = new HomeDac();

            homevo.Orderlist = hdac4.GetLastestOrderList();


            //OrderDac oDac = new OrderDAC();
            //List<OrderStatsVO> list = oDac.GetOrderBestProduct();

            //var listStat = from stat in list
            //               orderby stat.MM
            //               group stat by stat.ProductName;

            //List<string> keys = new List<string>();
            //StringBuilder sb = new StringBuilder();
            //string data1 = string.Empty, data2 = string.Empty, data3 = string.Empty;

            //int k = 0;
            //foreach (var group in listStat)
            //{
            //    keys.Add(group.Key);
            //    List<int> qtys = new List<int>();
            //    foreach (var product in group)
            //    {
            //        if (k == 0)
            //        {
            //            sb.Append(product.MM + "월,");
            //        }
            //        qtys.Add(product.Qty);
            //    }
            //    if (k == 0)
            //        data1 = "[" + string.Join(",", qtys.ToArray()) + "]";
            //    else if (k == 1)
            //        data2 = "[" + string.Join(",", qtys.ToArray()) + "]";
            //    else if (k == 2)
            //        data3 = "[" + string.Join(",", qtys.ToArray()) + "]";
            //    k++;
            //    qtys.Clear();
            //}
            //string labels = sb.ToString().TrimEnd(',');
            //string label1 = keys[0];
            //string label2 = keys[1];
            //string label3 = keys[2];


            //ViewBag.Label1 = label1;
            //ViewBag.Data1 = data1;
            //ViewBag.Label2 = label2;
            //ViewBag.Data2 = data2;
            //ViewBag.Label3 = label3;
            //ViewBag.Data3 = data3;
            return View(homevo);
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}