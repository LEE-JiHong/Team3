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
            dgvProductList.RowHeadersVisible = false;
            //품목 가져오기
            ProductService product_service = new ProductService();
            List<ProductVO> list = product_service.GetAllProducts();
            ProductVO vo = new ProductVO();


            dgvProductList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductList.Columns.Add("Number", "No.");
            dgvProductList.Columns[0].Width = 53;


            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품목유형", "product_type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품목", "product_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품명", "product_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "단위수량", "product_unit_count", true, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "발주방식", "product_ordertype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최소발주수량", "product_lorder_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "안전재고수량", "product_safety_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "사용여부", "product_yn", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "담당자", "product_admin", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "입고창고", "product_in_sector", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "출고창고", "product_out", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "납품업체", "product_supply_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "발주업체", "product_demand_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "측정방식", "product_meastype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "LeadTime", "product_leadtime", true, 80, DataGridViewContentAlignment.MiddleRight);
            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최솟값", "product_lsl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최댓값", "product_usl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "아이템코드", "product_itemcode", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품번", "product_id", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품명코드", "product_code", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "수정자", "product_uadmin", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "수정일", "product_udate", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "비고", "product_comment", false, 130);

            #endregion
            dgvProductList.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;



            dgvProductList.AutoGenerateColumns = false;
            dgvProductList.DataSource = list;
        }


        private void SetDgvNumbering(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            product_service = new ProductService();

            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();

            List<UserVO> user_list = product_service.GetUserAll();

            #region 사용여부cbo
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");
            #endregion

            #region 품목유형cbo
            _cboUseFlag = (from item in codelist
                           where item.common_type == "item_type"
                           select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _cboUseFlag, "common_value", "common_name", "선택");
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

            #region 담당자cbo

            ComboUtil.ComboBinding(cboAdmin, user_list, "user_id", "user_name", "선택");
            #endregion

            #region 입고창고cbo
            List<FactoryDB_VO> _cboInSector = (from item in f_list
                                               where item.facility_value == "FAC200"
                                               select item).ToList();
            ComboUtil.ComboBinding(cboInSector, _cboInSector, "factory_code", "factory_name", "선택");
            #endregion

            #region 출고창고cbo
            List<FactoryDB_VO> _cboOutSector = (from item in f_list
                                                where item.facility_value == "FAC100"
                                                select item).ToList();
            ComboUtil.ComboBinding(cboOutSector, _cboOutSector, "factory_code", "factory_name", "선택");
            #endregion



        }

        private void button1_Click(object sender, EventArgs e)
        {
            vo = new ProductVO();

            #region VO추가(수정)
          
               /* vo.product_id = Convert.ToInt32(dgvProductList[0, dgvProductList.CurrentRow.Index].Value);
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
            */
            #endregion

            ProductPop frm = new ProductPop(ProductPop.EditMode.Update,Convert.ToInt32(lblID.Text));
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            lblID.Text = dgvProductList[20, dgvProductList.CurrentRow.Index].Value.ToString();
        }
    }
}
