using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class DMRVO
    {
        public int pro_id { get; set; }
        public string plan_id { get; set; }//플랜ID
        public int product_id { get; set; }//상품ID
        public string product_codename { get; set; } //상품코드명
        public string product_name { get; set; }//상품명
        public int factory_id { get; set; }//창고아이디
        public string factory_name { get; set; }//창고이름
        public int pro_count { get; set; }// pro_count*bom_use_count= 계획수량
        public int bom_use_count { get; set; }
        public int plan_count { get; set; } //계획수량
        public int w_count_present { get; set; }//현재고
        public int w_count_past { get; set; }//이전재고
        public int req_factory_id { get; set; }
        public string req_factory { get; set; }//요청창고
        public string req_count { get; set; } //요청수량
        public string req_date { get; set; }// 요청일
        public string reason { get; set; }//사유
        public int nam { get; set; } //잔량
        public int w_id { get; set; }
        public string order_id { get; set; }
    }
    public class DMRDBVO
    {
        public string product_id { get; set; }
        public string product_codename { get; set; } //상품코드명
        public string product_name { get; set; }//상품명
        public string factory_name { get; set; }//창고 이름
        public string req_factory { get; set; }
        public int req_count { get; set; } //요청수량
        public int w_count_present { get; set; }//현재고
        public int w_count_past { get; set; }//이전재고
        public int nam { get; set; }
    }

    public class WorkRecode_VO
    {
        public string worknum { get; set; }
        public int  pro_id { get; set; }
        public string pro_date { get; set; }
        public string pd_stime { get; set; }
        public string pd_etime { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string pro_state { get; set; }
        public string common_name { get; set; }
        public int worktime { get; set; }
        public int pro_count { get; set; }
        public int ok_cnt { get; set; }
        public int ng_cnt { get; set; }
        public string m_name { get; set; }
        public string m_use_sector { get; set; }
        public string m_ok_sector { get; set; }
        public string plan_id { get; set; }
        public int m_use_sector_id { get; set; }
        public int m_ok_sector_id { get; set; }
        public string req_date { get; set; }// 요청일
        public string reason { get; set; }//사유
        public int w_id { get; set; }
        public string order_id { get; set; }
        public int m_id { get; set; }
    }
}
