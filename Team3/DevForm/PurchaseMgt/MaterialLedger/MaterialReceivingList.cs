using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class MaterialReceivingList : Team3.VerticalGridBaseForm
    {
        public MaterialReceivingList()
        {
            InitializeComponent();
        }

        private void MaterialReceivingList_Load(object sender, EventArgs e)
        {
            try
            {
                //발주업체 콤보박스 바인딩
                OrderService service = new OrderService();
                List<CompanyVO> CompanyList = new List<CompanyVO>();
                CompanyList = service.GetCompanyAll("customer");
                ComboUtil.ComboBinding(cboCompany, CompanyList, "company_code", "company_name", "선택");

                StockService sService = new StockService();
                List<FactoryComboVO> fList = new List<FactoryComboVO>();
                fList = sService.GetInFactory();
                ComboUtil.ComboBinding(cboFactory, fList, "factory_code", "factory_name", "선택");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetLoad();

            SetDataGrid();
        }

        private void SetLoad()
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            cboCompany.SelectedIndex = 0;
            cboFactory.SelectedIndex = 0;
            txtOrderSerial.Text = "";
            txtProduct.Text = "";
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";
            chk.Name = "chk";
            chk.Width = 40;
            dataGridView1.Columns.Add(chk);

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고일", "order_pdate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고창고", "factory_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고량", "order_qcount", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "취소량", "", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "잔량", "order_qcount", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체", "company_name", true, 150);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialSearchVO vo = new MaterialSearchVO();
                vo.startDate = dtpStartDate.Value.ToShortDateString();
                vo.endDate = dtpEndDate.Value.ToShortDateString();

                if (cboCompany.Text != "선택")
                {
                    vo.company_name = cboCompany.Text;
                }
                if (cboFactory.Text != "선택")
                {
                    vo.factory_name = cboFactory.Text;
                }
                if (txtOrderSerial.Text != "")
                {
                    vo.order_serial = txtOrderSerial.Text;
                }
                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text;
                }

                //조회 버튼
                MaterialLedgerService service = new MaterialLedgerService();
                DataTable dt = service.GetMaterialInList(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //입고취소 버튼
            List<MaterialReceivingVO> list = new List<MaterialReceivingVO>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    MaterialReceivingVO vo = new MaterialReceivingVO();
                    vo.order_serial = row.Cells[1].Value.ToString();
                    vo.product_codename = row.Cells[4].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[7].Value);
                    vo.product_name = row.Cells[5].Value.ToString();

                    list.Add(vo);
                }
            }

            MaterialLedgerService service = new MaterialLedgerService();

            if (MessageBox.Show("입고 취소하시겠습니까?", "입고취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool result = service.CancelMaterial(list);

                    if (result)
                    {
                        MessageBox.Show("성공적으로 입고취소가 완료되었습니다.", "입고취소", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetBottomStatusLabel("성공적으로 입고취소가 완료되었습니다.");
                        btnSearch.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("입고취소 실패하였습니다. 다시 시도하여 주십시오.", "입고취소", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetBottomStatusLabel("입고취소 실패하였습니다. 다시 시도하여 주십시오.");
                    }
                }
                catch (Exception err)
                {
                    LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //새로고침 버튼
            SetLoad();

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridViewUtil.SetDgvTextBoxColor(dataGridView1, 7);
        }
    }
}
