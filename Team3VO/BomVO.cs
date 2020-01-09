using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //BOM 부분 VO
    //담당 : 김우근
    //기본생성자 1개, full 생성자 1개.

    class BomVO
    {
        private int bom_id;
        private int bom_parent_id;
        private int product_id;
        private int bom_use_count;
        private string bom_sdate;
        private string bom_edate;
        private string bom_yn;
        private int plan_id;
        private string bom_comment;
        private string bom_uadmin;
        private string bom_udate;

        public BomVO() { }
        public BomVO(int bom_id, int bom_parent_id, int  product_id, int bom_use_count,int plan_id,
            string bom_sdate, string bom_edate, string bom_yn, string bom_comment, string bom_uadmin,string bom_udate)
        {
            this.bom_id = bom_id;
            this.bom_parent_id = bom_parent_id;
            this.product_id = product_id;
            this.bom_use_count = bom_use_count;
            this.plan_id = plan_id;
            this.bom_sdate = bom_sdate;
            this.bom_edate = bom_edate;
            this.bom_yn = bom_yn;
            this.bom_comment = bom_comment;
            this.bom_uadmin = bom_uadmin;
            this.bom_udate = bom_udate;
        }
        public int BOM_ID
        {
            get { return bom_id; }
            set { bom_id = value; }
        }
        public int BOM_PARENT_ID
        {
            get { return bom_parent_id; }
            set { bom_parent_id = value; }
        }
        public int PRODUCT_ID
        {
            get { return PRODUCT_ID; }
            set { PRODUCT_ID = value; }
        }
        public int BOM_USE_COUNT
        {
            get { return bom_use_count; }
            set { bom_use_count = value; }
        }
        public int PLAN_ID
        {
            get { return plan_id; }
            set { plan_id = value; }
        }
        public string BOM_SDATE
        {
            get { return bom_sdate; }
            set { bom_sdate = value; }
        }
        public string BOM_EDATE
        {
            get { return bom_edate; }
            set { bom_edate = value; }
        }
        public string BOM_YN
        {
            get { return bom_yn; }
            set { bom_yn = value; }
        }
        public string BOM_COMMENT
        {
            get { return bom_comment; }
            set { bom_comment = value; }
        }
        public string BOM_UADMIN
        {
            get { return bom_uadmin; }
            set { bom_uadmin = value; }
        }
        public string BOM_UDATE
        {
            get { return bom_udate; }
            set { bom_udate = value; }
        }

    }


}
