using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    /// <summary>
    /// 고객 주문별 재고현황 조건검색 VO
    /// </summary>
    public class InventoryOrderMgtVO
    { 
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string fromFactory { get; set; }
        public string toFactory { get; set; }
        public string product_name { get; set; }
    }
    /// <summary>
    /// 매출마감 현황 조건검색 vo
    /// </summary>
    public class ShipmentClosingVO
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string company_code { get; set; }
        public string product_name { get; set; }
    }

    /// <summary>
    /// 이동수량VO
    /// </summary>
    public class ShipmentVO
    {
        public int so_id { get; set; }
        public int so_ocount { get; set; }
        public int so_ccount { get; set; }
        public int so_pcount { get; set; }
        public int w_count_present { get; set; }
        public int product_id { get; set; }
        public string so_edate { get; set; }
        public string so_sdate { get; set; }
        public string plan_id { get; set; }
        public string company_code { get; set; }
        public string company_type { get; set; }
        public string product_name { get; set; }
        public string product_codename { get; set; }
        public string from_wh { get; set; }
        public string from_wh_value { get; set; }
        public string to_wh { get; set; }
        public string to_wh_value { get; set; }
        public int uadmin { get; set; }
        // public string wh_comment { get; set; }
        public string factory_name { get; set; }
        public string category { get; set; }
        public string udate { get; set; }
        public int transfer_count { get; set; }

    }
    /// <summary>
    /// 마감처리VO
    /// </summary>
    public class ShipmentOutVO
    {
        public int so_id { get; set; }
        public int so_ocount { get; set; }
        //public int so_ccount { get; set; }
        public int so_pcount { get; set; }
        //public int w_count_present { get; set; }
        public int product_id { get; set; }
        //public string so_edate { get; set; }
        //public string so_sdate { get; set; }
        public string plan_id { get; set; }
        public string company_code { get; set; }
        //public string company_type { get; set; }
        public string product_name { get; set; }
        public string product_codename { get; set; }
        //public string from_wh { get; set; }
        //public string from_wh_value { get; set; }
        //public string to_wh { get; set; }
        //public string to_wh_value { get; set; }
        //public int uadmin { get; set; }
        //public string wh_comment { get; set; }
        //public string factory_name { get; set; }
        //public string category { get; set; }
        //public string udate { get; set; }
        //public int transfer_count { get; set; }

        public decimal s_totalprice { get; set; }
        public string company_name { get; set; }
        public string s_date { get; set; }
        public int s_count { get; set; }
        //public int w_id { get; set; }
        public int orderable_count { get; set; }
    }
    public class SalesCompleteVO
    {
       public int     so_id                {get;set;}
       public int     plan_id              {get;set;}
       public string     product_codename     {get;set;}
       public string product_name         {get;set;}
       public int     s_count              {get;set;}
       public decimal     s_TotalPrice         {get;set;}
       public string s_company            {get;set;}
       public string company_name         {get;set;}
       public int     so_pcount            {get;set;}
       public string     s_date            {get;set;}
    }
}
