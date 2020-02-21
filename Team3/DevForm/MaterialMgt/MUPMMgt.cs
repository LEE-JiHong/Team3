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

namespace Team3
{
    //Material of unit's price management 자재 단가 관리
    public partial class MUPMMgt : Team3.VerticalGridBaseForm
    {
        List<PriceInfoVO> pricelist;
        PriceService price_service;
        public MUPMMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<PriceInfoVO> list = new List<PriceInfoVO>();
            foreach (DataGridViewRow row in this.dgvMUPM.Rows)
            {
                PriceInfoVO vo = new PriceInfoVO();
                vo = row.DataBoundItem as PriceInfoVO;
                list.Add(vo);
            }
            MUPMPop frm = new MUPMPop(MUPMPop.EditMode.Insert,list);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> new_priceinfo_list = price_service.GetPriceInfo("COOPERATIVE");    //등록후 다시 조회
                dgvMUPM.DataSource = new_priceinfo_list;
                SetBottomStatusLabel("신규 자재단가가 등록되었습니다.");
            }
        }

        private void MUPMMgt_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void InitControl()
        {
            OrderService order_service = new OrderService();
            #region 업체cbo
            List<CompanyVO> company_list = order_service.GetCompanyAll("CUSTOMER");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_id", "company_name", "전체");
            #endregion

            price_service = new PriceService();
            pricelist = price_service.GetPriceInfo("COOPERATIVE");

            dgvMUPM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMUPM.Columns.Add("Number", "No.");
            dgvMUPM.Columns[0].Width = 53;

            #region DGV바인딩
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "업체", "company_code", true, 170, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "업체명", "company_name", true, 200, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "품목", "product_codename", true, 180, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "품명", "product_name", true, 240, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "현재단가", "price_present", true, 150, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "이전단가", "price_past", true, 150, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "시작일", "price_sdate", true, 150, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "종료일", "price_edate", true, 150, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "비고", "price_comment", true, 170, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "사용유무", "price_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            #endregion
            GridViewUtil.SetDataGridView(dgvMUPM);
            dgvMUPM.AutoGenerateColumns = false;
            dgvMUPM.DataSource = pricelist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriceInfoVO vo = new PriceInfoVO();
            foreach (DataGridViewRow row in this.dgvMUPM.SelectedRows)
            {
                vo = row.DataBoundItem as PriceInfoVO;
            }

            MUPMPop frm = new MUPMPop(MUPMPop.EditMode.Update, null, vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> newPricelist = price_service.GetPriceInfo("COOPERATIVE");    //등록후 다시 조회
                dgvMUPM.DataSource = newPricelist;
                dgvMUPM.ClearSelection();
                SetBottomStatusLabel("자재단가 수정이 완료되었습니다.");
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

            dgvMUPM.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvMUPM.SelectAll();
            DataObject dataObj = dgvMUPM.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text != "")
            {
                if (cboCompany.SelectedIndex > 0)       //업체 선택했을 떄
                {
                    var _product = (from code in pricelist
                                    where code.product_codename.ToUpper().Contains(txtProduct.Text.ToUpper())
                                    && code.company_id == Convert.ToInt32(cboCompany.SelectedValue)
                                    select code).ToList();
                    dgvMUPM.DataSource = _product;
                    PrintResultCount(_product);
                    if (_product.Count == 0)
                    {
                        dgvMUPM.DataSource = _product;
                        PrintResultCount(_product);
                    }

                }

                else if (cboCompany.SelectedIndex == 0)                   //업체를 선택하지 않았을 때 
                {
                    var _product = (from code in pricelist
                                    where code.product_codename.ToUpper().Contains(txtProduct.Text.ToUpper())
                                    select code).ToList();
                    dgvMUPM.DataSource = _product;
                    PrintResultCount(_product);
                }
            }
            else if (txtProduct.Text == "")
            {

                if (cboCompany.SelectedIndex > 0)       //업체 선택했을 떄
                {
                    var _product = (from code in pricelist
                                    where code.company_id == Convert.ToInt32(cboCompany.SelectedValue)
                                    select code).ToList();
                    dgvMUPM.DataSource = _product;
                    PrintResultCount(_product);
                    if (_product.Count == 0)
                    {
                        dgvMUPM.DataSource = _product;
                        PrintResultCount(_product);
                    }

                }
                else if (cboCompany.SelectedIndex == 0)                      //업체를 선택하지 않았을 때
                {
                    var _product = (from code in pricelist
                                    where code.product_codename.Contains(txtProduct.Text) 
                                    select code).ToList();
                    dgvMUPM.DataSource = _product;
                    PrintResultCount(_product);
                }
            }
        }

        private void PrintResultCount(List<PriceInfoVO> _product)
        {
            SetBottomStatusLabel($"{_product.Count}건이 검색되었습니다.");
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSelect.PerformClick();
            }
        }
    }
}
