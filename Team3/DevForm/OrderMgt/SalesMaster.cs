using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Team3
{
    public partial class SalesMaster : VerticalGridBaseForm
    {
        List<CompanyVO> CompanyList;
        List<CompanyVO> DestinationList;

        public SalesMaster()
        {
            InitializeComponent();
        }

        private void SalesMaster_Load(object sender, EventArgs e)
        {
            //납기일 초기화
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            //등록일 초기화
            dtpRegFirstDate.Value = DateTime.Now.AddMonths(-1);
            dtpRegLastDate.Value = DateTime.Now;

            OrderService service = new OrderService();
            //List<SOMasterVO> list = service.GetSOMasterAll();

            //고객사, 도착지 콤보박스 바인딩
            CompanyList = new List<CompanyVO>();

            try
            {
                CompanyList = service.GetCompanyAll("cooperative");
                ComboUtil.ComboBinding(cboCompany, CompanyList, "company_code", "company_name", "선택");

                DestinationList = new List<CompanyVO>();
                DestinationList = service.GetCompanyAll("cooperative");
                ComboUtil.ComboBinding(cboDestination, DestinationList, "company_code", "company_name", "선택");

            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            //datagridview
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객WO", "so_wo_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사코드", "company_code", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사명", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지코드", "company_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지명", "company_name", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객주문유형", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "등록일", "so_sdate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "생산납기일", "so_edate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문수량", "so_pcount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출고수량", "so_ocount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소수량", "so_ccount", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주구분", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "비고", "so_comment", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정자", "so_uadmin", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정일", "so_udate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "so_id", "so_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "plan_id", "plan_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "company_type", "company_type", false);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //등록버튼
            SODialog frm = new SODialog(SODialog.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSearch.PerformClick();
                SetBottomStatusLabel("등록이 완료되었습니다.");
            }
        }

        private void btnDemandPlan_Click(object sender, EventArgs e)
        {
            ////수요계획생성 버튼
            DemandPop frm = new DemandPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("변경할 영업마스터가 없습니다. 영업마스터를 먼저 선택하여 주십시오.");
                SetBottomStatusLabel("변경할 영업마스터가 없습니다. 영업마스터를 먼저 선택하여 주십시오.");
            }
            else
            {
                SOMasterVO vo = new SOMasterVO();

                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    vo = row.DataBoundItem as SOMasterVO;
                    //if (vo != null)
                    //{
                    //    MessageBox.Show("데이터를 선택하여주십시오.");
                    //}
                }
                //for (int i = 0; i <= dataGridView1.Rows.Count; i++)
                //{
                //    vo = (SOMasterVO)dataGridView1.SelectedRows[i].DataBoundItem;
                //}

                //수정버튼
                SODialog frm = new SODialog(SODialog.EditMode.Update, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnSearch.PerformClick();
                    SetBottomStatusLabel("수정이 완료되었습니다.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            WhereSoVO vo = new WhereSoVO();
            vo.startDate = dtpStartDate.Value.ToShortDateString();
            vo.endDate = dtpEndDate.Value.ToShortDateString();

            vo.RegStartDate = dtpRegFirstDate.Value.ToShortDateString();
            vo.RegEndDate = dtpRegLastDate.Value.ToShortDateString();

            if (cboCompany.Text != "선택")
            {
                vo.CompanyName = cboCompany.Text;
            }

            OrderService service = new OrderService();

            try
            {
                List<SOMasterVO> list = service.GetSOMasterAll(vo);
                dataGridView1.DataSource = list;
                SetBottomStatusLabel("조회가 완료되었습니다.");
            }
            catch(Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                SetBottomStatusLabel("조회에 실패하였습니다. 다시 시도하여 주십시오.");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ////엑셀 버튼
            //using (frmWaitForm frm = new frmWaitForm(ExcelDown))
            //{
            //    frm.ShowDialog(this);
            //}

            LoadingForm f = new LoadingForm();

            f.Function = (() => { ExcelDown(); });

            f.ShowDialog();

        }

        private void ExcelDown()
        {
            try
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };

                string filename = "test" + ".xlsx";

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);//tempPath

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count-3; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count-3; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }

                SetBottomStatusLabel("다운로드가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
