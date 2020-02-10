using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    //Sales of unit's price management 영업 단가 관리
    public partial class SUPMMgt : Team3.VerticalGridBaseForm
    {
        List<PriceInfoVO> pricelist;
        PriceService price_service;
        public SUPMMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<PriceInfoVO> list = new List<PriceInfoVO>();
            foreach (DataGridViewRow row in this.dgvSUPM.Rows)
            {
                PriceInfoVO vo = new PriceInfoVO();
                vo = row.DataBoundItem as PriceInfoVO;
                list.Add(vo);            
            }
            SUPMPop frm = new SUPMPop(SUPMPop.EditMode.Insert, list);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> new_priceinfo_list = price_service.GetPriceInfo("CUSTOMER");    //등록후 다시 조회
                dgvSUPM.DataSource = new_priceinfo_list;
                SetBottomStatusLabel("신규 영업 단가가 등록되었습니다.");
            }
        }

        private void SUPMMgt_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        private void InitControl()
        {
            OrderService order_service = new OrderService();
            #region 납품업체cbo
            List<CompanyVO> company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_id", "company_name", "선택");
            #endregion





            price_service = new PriceService();
             pricelist = price_service.GetPriceInfo("CUSTOMER");

            dgvSUPM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSUPM.Columns.Add("Number", "No.");
            dgvSUPM.Columns[0].Width = 53;

            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "업체", "company_code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "업체명", "company_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "현재단가", "price_present", true, 100, DataGridViewContentAlignment.MiddleRight,true);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "이전단가", "price_past", true, 100, DataGridViewContentAlignment.MiddleRight,true);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "시작일", "price_sdate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "종료일", "price_edate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "비고", "price_comment", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvSUPM, "사용유무", "price_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            
            GridViewUtil.SetDataGridView(dgvSUPM);
            dgvSUPM.AutoGenerateColumns = false;
            dgvSUPM.DataSource = pricelist;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PriceInfoVO vo = new PriceInfoVO();
            foreach (DataGridViewRow row in this.dgvSUPM.SelectedRows)
            {
                vo = row.DataBoundItem as PriceInfoVO;
            }

            SUPMPop frm = new SUPMPop(SUPMPop.EditMode.Update, null,vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> newPricelist = price_service.GetPriceInfo("CUSTOMER");    //등록후 다시 조회
                dgvSUPM.DataSource = newPricelist;
                dgvSUPM.ClearSelection();
                SetBottomStatusLabel("영업단가 수정이 완료되었습니다.");
            }
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

            dgvSUPM.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvSUPM.SelectAll();
            DataObject dataObj = dgvSUPM.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
        }
    }
}
