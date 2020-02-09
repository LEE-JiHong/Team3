using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using log4net.Core;

namespace Team3
{
    public partial class MRP : Team3.VerticalGridBaseForm
    {
        string planID;

        public MRP()
        {
            InitializeComponent();
        }

        private void MRP_Load(object sender, EventArgs e)
        {
            try
            {
                OrderService service = new OrderService();

                List<string> planIDlist = service.GetPlanID();
                cboPlanID.DataSource = planIDlist;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            //string planID = cboPlanID.Text;

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            //dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }

        private void BtnSearch_Click(object sender, EventArgs e)
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

                SetBottomStatusLabel("조회가 완료되었습니다.");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
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
    }
}
