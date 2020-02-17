using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3WebAPI
{
    public class OrderPageVO
    {
        List<LastestOrderVO> lastestList;
        List<LastestOrderDataVO> lastestOrderList;
        List<SalesChartVO> yearSalesChartList;
        List<SalesChartVO> yearSalesCompanyList;
        List<List<SalesChartVO>> totalyearSalesCompanyList;
        public List<LastestOrderVO> LastestList
        {
            get { return lastestList; }
            set { lastestList = value; }
        }

        public List<LastestOrderDataVO> LastestOrderList
        {
            get { return lastestOrderList; }
            set { lastestOrderList = value; }
        }

        public List<SalesChartVO> YearSalesChartList
        {
            get { return yearSalesChartList; }
            set { yearSalesChartList = value; }
        }


        public List<SalesChartVO> YearSalesCompanyList
        {
            get { return yearSalesCompanyList; }
            set { yearSalesCompanyList = value; }
        }

        public List<List<SalesChartVO>> TotalyearSalesCompanyList
        {
            get { return totalyearSalesCompanyList; }
            set { totalyearSalesCompanyList = value; }
        }
    }

    public class LastestOrderDataVO
    {
        public string order_id { get; set; }
        public string plan_id { get; set; }
        public string product_name { get; set; }
        public int order_count { get; set; }
        public string order_state { get; set; }
        public string order_sdate { get; set; }
    }


    public class LastestOrderVO
    {
        public string wh_udate { get; set; }
        public string order_id { get; set; }
        public string wh_comment { get; set; }
        public int wh_product_count { get; set; }

    }




    public class SalesChartVO
    {
        public string s_month { get; set; }
        public int s_count { get; set; }
        public decimal totalprice { get; set; }
        public string s_company { get; set; }

    }


}