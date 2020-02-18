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
        DataTable dt;
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
            dt = new DataTable();
            shipment_service = new ShipmentService();
            dt = shipment_service.GetSalesCompleteStatus();

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "so_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "plan_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사코드", "s_company", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사", "company_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감수량", "s_count", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "매출액", "s_TotalPrice", true, 100, DataGridViewContentAlignment.MiddleRight,true);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감일", "s_date", true, 100, DataGridViewContentAlignment.MiddleCenter);



            dgvClientOrder.AutoGenerateColumns = false;
            dgvClientOrder.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            shipment_service.GetSalesCompleteStatus();




            SalesComplete ds = new SalesComplete();
            Report_SalesComplete rpt = new Report_SalesComplete();
            
            rpt.DataSource = dt;



           
            
            
            
            //ReportPreview frm = new ReportPreview(rpt);

            //Form2 frm = new Form2();
            //frm.documentViewer1.DocumentSource = rpt;
            //frm.ShowDialog();









        }
    }
}
