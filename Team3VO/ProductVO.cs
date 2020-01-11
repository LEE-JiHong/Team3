using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    public class ProductVO
    {
        public int PRODUCT_ID { get; set; }
        public int PRODUCT_LORDER_COUNT { get; set; }
        public int PRODUCT_COUNT { get; set; }
        public int PRODUCT_SAFETY_COUNT { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_UNIT { get; set; }
        public string PRODUCT_UNIT_COUNT { get; set; }
        public string PRODUCT_TYPE { get; set; }
        public string PRODUCT_IN_SECTOR { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_LSL { get; set; }     //품목최솟값(완제품일 때 입력 , 완제품 레벨이 아닐 시 null값)
        public string PRODUCT_USL { get; set; }     //품목최댓값(완제품일 때 입력, 완제품 레벨이 아닐 시 null값)
        public string PRODUCT_MEASTYPE { get; set; }     //품목 측정 방식(완제품일 때 입력, 완제품 레벨이 아닐 시 null값)/공통코드
        public string PRODUCT_OUT { get; set; }
        public string PRODUCT_LEADTIME { get; set; }
        public string PRODUCT_ADMIN { get; set; }
        public string PRODUCT_ORDERTYPE { get; set; }
        public string PRODUCT_ITEMCODE { get; set; }
        public string PRODUCT_YN { get; set; }
        public string PRODUCT_SUPPLY_COM { get; set; }
        public string PRODUCT_DEMAND_COM { get; set; }
        public string PRODUCT_UADMIN { get; set; }
        public string PRODUCT_UDATE { get; set; }
        public string PRODUCT_COMMENT { get; set; }

    }
}
