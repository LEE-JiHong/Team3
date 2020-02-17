using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3.DevForm.ShipmentMgt
{
    public partial class ShipmentClosingStatusMgt : Team3.VerticalGridBaseForm
    {
        ShipmentService shipment_service;
        List<ShipmentOutVO> shipment_list;
        public ShipmentClosingStatusMgt()
        {
            InitializeComponent();
        }

        private void ShipmentClosingStatusMgt_Load(object sender, EventArgs e)
        {
            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();



            #region 고객사cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCustomer, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 고객창고cbo
            List<FactoryDB_VO> _cboOutSector = (from item in f_list
                                                where item.facility_value == "FAC700"
                                                select item).ToList();
            ComboUtil.ComboBinding(cboCustomerWH, _cboOutSector, "factory_code", "factory_name", "선택");
            #endregion


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            dgvClientOrder.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvClientOrder.SelectAll();
            DataObject dataObj = dgvClientOrder.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetDGV();

        }

        private void SetDGV()
        {
            shipment_service = new ShipmentService();
            shipment_list = shipment_service.GetClientOrder();


            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "plan_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사코드", "company_code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사", "company_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            
            //TODO 쿼리수정
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문가능수량", "orderable_count", false, 100, DataGridViewContentAlignment.MiddleRight);

            //GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "매출확정수량", "incount", true, 130);

            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "매출확정수량", "s_count", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "매출확정금액", "s_TotalPrice", true, 100, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감일자", "s_date", true, 100, DataGridViewContentAlignment.MiddleRight);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품번", "product_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "so_id", "so_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "취소수량", "so_ccount", false, 100, DataGridViewContentAlignment.MiddleRight);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "w_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "납기일", "so_edate", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고", "from_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고재고", "w_count_present", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "비고", "wh_comment", false, 130);


            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업로드날짜", "so_sdate", false, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업체유형", "company_type", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고코드", "from_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "출고수량", "so_ocount", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고", "to_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고코드", "to_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "수정자", "uadmin", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "factory_name", false, 100, DataGridViewContentAlignment.MiddleCenter);

            dgvClientOrder.AutoGenerateColumns = false;
            dgvClientOrder.DataSource = shipment_list;
        }
    }
}
