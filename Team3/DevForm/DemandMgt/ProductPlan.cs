using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Team3VO;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using log4net.Core;

namespace Team3
{
    public partial class ProductPlan : Team3.VerticalGridBaseForm
    {
        DateTime today = DateTime.Now;
        public ProductPlan()
        {
            InitializeComponent();
        }
        ProductionService service = new ProductionService();
        ResourceService R_service = new ResourceService();


        private void ProductPlan_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            //GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gray; //Color.DimGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            DataTable dt = service.GetProductPlan(cboPlanID.Text, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

            InitComboBox();


            dataGridView1.AllowUserToAddRows = false;
            //string startDate = today.AddDays(-10).ToString("yyyyMMdd");
            //string endDate = today.AddDays(20).ToString("yyyyMMdd");
            dateTimePicker1.Value = today.AddDays(-7);
            dateTimePicker2.Value = today.AddDays(14);
            //DataTable dt = service.GetProductPlan("20200121_P", startDate, endDate);
            //  dataGridView1.DataSource = dt;
            //   btnSearch.PerformClick();

        }

        private void InitComboBox()
        {
            OrderService service = new OrderService();
            List<string> list = service.GetPlanID();
            // list.Insert(0, );
            cboPlanID.DataSource = list;
            List<MachineVO> lst = R_service.GetMachineAll();
            ComboUtil.ComboBinding(cboMachine, lst, "m_id", "m_name", "전체");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비", "m_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "공정", "bor_route", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상품코드", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상품명", "producct_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "영업마스터ID", "plan_id", false);

            string Machine = cboMachine.Text;
            DataTable dt = service.GetProductPlan(cboPlanID.Text, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            DataTable table = new DataTable();
            try
            {
                //if (Machine == "전체" && txtProduct.Text == "") //둘다 빈값
                //{
                //    dataGridView1.DataSource = dt;
                //}
                if (txtProduct.Text == "" && Machine == "전체") // 둘다 빈값
                {
                    dataGridView1.DataSource = dt;
                }
                else if (txtProduct.Text != "" && Machine == "전체")  //product만 입력
                {

                    table =
                             dt.AsEnumerable().Where(Row =>
                             Row.Field<string>("product_codename") == txtProduct.Text).CopyToDataTable();
                    dataGridView1.DataSource = table;

                }
                else if (Machine != "" && txtProduct.Text == "") //설비만 입력
                {
                    table =
                             dt.AsEnumerable().Where(Row =>
                             Row.Field<string>("m_name") == cboMachine.Text).CopyToDataTable();
                    dataGridView1.DataSource = table;

                }
                else if (Machine != "" && txtProduct.Text != "") //둘다 입력
                {
                    table =
                        dt.AsEnumerable().Where(Row =>
                        Row.Field<string>("m_name") == cboMachine.Text && Row.Field<string>("product_codename") == txtProduct.Text).CopyToDataTable();
                    dataGridView1.DataSource = table;

                }



            }

            catch (InvalidOperationException)
            {
                SetBottomStatusLabel("해당 조건의 검색결과가 없습니다");
                MessageBox.Show("해당 조건의 검색결과가 없습니다");

            }
            catch (Exception err)
            {
                string str = err.Message;
            }
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };

                string filename = "test" + ".xlsx"; // ++ 파일명 변경 

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

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
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = today.AddDays(-7);
            dateTimePicker2.Value = today.AddDays(14);
            DataTable dt = service.GetProductPlan(cboPlanID.Text, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;

            foreach (Control ctrl in panel1.Controls)
            {
                if (typeof(TextBox) == ctrl.GetType())
                {
                    ctrl.Text = "";
                }
            }

            cboMachine.SelectedIndex = 0;
        }
    }
}
