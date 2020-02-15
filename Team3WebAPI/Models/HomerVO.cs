using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3WebAPI
{
    public class HomeVO
    {
        private List<UserVO> userlist;
        private WorkRateVO workrate;
        private List<SalesVO> salesrate;
        private List<CompanyVO> companylist;
        private CompanyVO companyData;
        private List<WorkOrderVO> orderlist;
        public List<UserVO> Userlist
        {
            get {return userlist; } set { userlist = value; }
        }

        public List<WorkOrderVO> Orderlist
        {
            get { return orderlist; }
            set { orderlist = value; }
        }

        public CompanyVO CompanyData
        {
            get { return companyData; }
            set { companyData = value; }
        }

        public List<CompanyVO> CompanyCount
        {
            get { return companylist; }
            set { companylist = value; }
        }

        public string SalesPrice
        {
            get; set;
        }


        public string SalesRateToView
        {
            get; set;
        }

        public bool SalesRateBool
        {
            get; set;
        }

        public WorkRateVO WorkRate
        {
            get { return workrate; }
            set { workrate = value; }
        }

        public List<SalesVO> SalseRate
        {
            get { return salesrate; }
            set { salesrate = value; }
        }

 




    }

    public class UserVO
    {
        public string user_id { get; set; }
        public string user_pwd { get; set; }
        public string user_name { get; set; }
        public string department_id { get; set; }

        public string user_pic { get; set; }
        public string user_cdate { get; set; }
        public string user_national { get; set; }

    }
    public class SalesVO {
        public int month { get; set; }
        public decimal price { get; set; }
    }
    public class CompanyVO
    {
        public int month { get; set; }
        public int sum { get; set; }
    }

    public class WorkRateVO
    {
        public string totaldate { get; set; }
        public int workdate { get; set; }
        public string workrate { get; set; }
    }

    public class WorkOrderVO
    {
        public string so_edate { get; set; }
        public int so_pcount { get; set; }
        public string company_code { get; set; }

        public string company_pic { get; set; }

        public string product_name { get; set; }
    }


}
