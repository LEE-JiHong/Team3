using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class ProductMgt : VerticalGridBaseForm
    {
        ProductService product_service;
        CommonCodeService common_service = new CommonCodeService();
        List<CommonVO> codelist;

        public ProductVO vo;
        public ProductVO VO
        {
            get { return vo; }
            set { vo = value; }
        }

        public ProductMgt()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPop frm = new ProductPop(ProductPop.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            LoadDGV();
            ComboBinding();
        }
        private void LoadDGV()
        {
            //품목 가져오기
            ProductService product_service = new ProductService();
            List<ProductVO> list = product_service.GetAllProducts();
            ProductVO vo = new ProductVO();

            //GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "ID", , true, 100);

            //dgvProductList.AutoGenerateColumns = false;
            dgvProductList.DataSource = list;







        }
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            product_service = new ProductService();
            List<UserVO> user_list = product_service.GetUserAll();
            #region 사용여부cbo
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "COMMON_VALUE", "COMMON_NAME", "선택");
            #endregion

            #region 품목유형cbo
            _cboUseFlag = (from item in codelist
                           where item.common_type == "item_type"
                           select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _cboUseFlag, "COMMON_VALUE", "COMMON_NAME", "선택");
            #endregion

            #region 납품업체cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("customer");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 발주업체cbo
            company_list = order_service.GetCompanyAll("cooperative");
            ComboUtil.ComboBinding(cboSupplyCompany, company_list, "company_code", "company_name", "선택");

            List<UserVO> user_vo = new List<UserVO>();
            #endregion
            ComboUtil.ComboBinding(cboAdmin, user_list, "USER_ID", "USER_NAME", "선택");

            







            //List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            //ResourceService Resource_service = new ResourceService();
            //f_list = Resource_service.GetFactoryAll();





        }
        private static void TestComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm)
        {
            if (list == null)
                list = new List<T>();

            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vo = new ProductVO();

            #region VO추가(수정)
            vo.product_id = Convert.ToInt32(dgvProductList[0, dgvProductList.CurrentRow.Index].Value);
            vo.product_lorder_count = Convert.ToInt32(dgvProductList[1, dgvProductList.CurrentRow.Index].Value);
            vo.product_safety_count = Convert.ToInt32(dgvProductList[2, dgvProductList.CurrentRow.Index].Value);
            vo.product_codename = dgvProductList[3, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_name = dgvProductList[4, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_unit = dgvProductList[5, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_unit_count = dgvProductList[6, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_type = dgvProductList[7, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_in_sector = dgvProductList[8, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_code = dgvProductList[9, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_lsl = dgvProductList[10, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_usl = dgvProductList[11, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_meastype = dgvProductList[12, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_out = dgvProductList[13, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_leadtime = dgvProductList[14, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_admin = dgvProductList[15, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_ordertype = dgvProductList[16, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_itemcode = dgvProductList[17, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_yn = dgvProductList[18, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_supply_com = dgvProductList[19, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_demand_com = dgvProductList[20, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_uadmin = dgvProductList[21, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_udate = dgvProductList[22, dgvProductList.CurrentRow.Index].Value.ToString();
            vo.product_comment = dgvProductList[23, dgvProductList.CurrentRow.Index].Value.ToString();
            #endregion

            ProductPop frm = new ProductPop(ProductPop.EditMode.Update, vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}
