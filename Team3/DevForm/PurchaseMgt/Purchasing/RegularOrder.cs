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
    public partial class RegularOrder : VerticalGridBaseForm
    {
        public RegularOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Add("P/N",);
            //dataGridView1.Columns.Add("품목명", "품목명");
            //dataGridView1.Columns.Add("품목유형", "품목유형");

            //dataGridView1.Columns.Add("공급L/T", "P/N");
            //dataGridView1.Columns.Add("표준발주", "P/N");
            //dataGridView1.Columns.Add("현재고", "P/N");
            //GridViewUtil.SetDataGridView(dataGridView1);
            SetCombo();
        }

        private void SetCombo()
        {
            OrderService service = new OrderService();
            //List<CompanyVO> Companylist = service.GetCompanyAll("CUSTOMER");

            //ComboUtil.ComboBinding(cboCompany, Companylist, "company_code", "company_name", "전체");

            List<string> planIDlist = service.GetPlanID();
            cboPlanID.DataSource = planIDlist;

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderDialog frm = new OrderDialog(cboPlanID.Text);
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            string planID = cboPlanID.Text;

            try
            {
                OrderService service = new OrderService();

                DataTable dt = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());

                dt.Columns[0].ColumnName = "품목";
                dt.Columns[1].ColumnName = "품명";
                dt.Columns[2].ColumnName = "Plan ID";
                dt.Columns[3].ColumnName = "카테고리";
                dt.Columns[4].ColumnMapping = MappingType.Hidden;
                dt.Columns[5].ColumnMapping = MappingType.Hidden;

                dataGridView1.DataSource = dt;

                //GridViewUtil.SetDataGridView(dataGridView1);

                SetBottomStatusLabel("조회가 완료되었습니다.");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 3 == 2)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //수량 입력하면 체크박스 true
        }
    }
}
