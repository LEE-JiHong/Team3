using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class DMRVO
    {

        public string plan_id { get; set; }//플랜ID
        public string product_id { get; set; }//상품ID
        public string product_codename { get; set; } //상품코드명
        public string product_name { get; set; }//상품명
        public string factory_id { get; set; }//창고아이디
        public string factory_name { get; set; }//창고 이름
        public string pro_count { get; set; }// pro_count*bom_use_count= 계획수량
        public string bom_use_count { get; set; }
        public string w_count_present { get; set; }//현재고
        public string w_count_past { get; set; }//이전재고
        public string req_count { get; set; } //요청수량
        public string req_date { get; set; }// 요청일
        public string reason { get; set; }//사유

    }
}
