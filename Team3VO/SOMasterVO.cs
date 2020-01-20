using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //SOMaster 부분 VO(영업마스터VO)
    //담당 : 이지홍

    public class SOMasterVO
    {
         public int so_id {get;set;}
         public string plan_id {get;set;}
        public string so_wo_id {get;set;}
         public string company_code {get;set;}
         public string company_type {get;set;}
         public string product_name {get;set;}
         public int so_pcount {get;set;}
         public int so_ocount {get;set;}
         public int so_ccount {get;set;}
         public string so_edate {get;set;}
         public string so_sdate {get;set;}
         public string so_uadmin {get;set;}
         public string so_udate {get;set;}
         public string so_comment {get;set;}
         public string so_production_state { get; set; }
    }
}
