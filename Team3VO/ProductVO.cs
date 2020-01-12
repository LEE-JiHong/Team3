using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class ProductVO
    {
        public int product_id { get; set; }
        public int product_lorder_count { get; set; }
        public int product_count { get; set; }
        public int product_safety_count { get; set; }
        public string product_name { get; set; }
        public string product_unit { get; set; }
        public string product_unit_count { get; set; }
        public string product_type { get; set; }
        public string product_in_sector { get; set; }
        public string product_code { get; set; }
        public string product_lsl { get; set; }     //품목최솟값(완제품일 때 입력 , 완제품 레벨이 아닐 시 null값)
        public string product_usl { get; set; }     //품목최댓값(완제품일 때 입력, 완제품 레벨이 아닐 시 null값)
        public string product_meastype { get; set; }     //품목 측정 방식(완제품일 때 입력, 완제품 레벨이 아닐 시 null값)/공통코드
        public string product_out { get; set; }
        public string product_leadtime { get; set; }
        public string product_admin { get; set; }
        public string product_ordertype { get; set; }
        public string product_itemcode { get; set; }
        public string product_yn { get; set; }
        public string product_supply_com { get; set; }
        public string product_demand_com { get; set; }
        public string product_uadmin { get; set; }
        public string product_udate { get; set; } 
        public string product_comment { get; set; }
    }
}
