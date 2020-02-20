using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Team3
{
    //Request of Material's Distribution  자재 불출 요청
    public partial class DMRMgt : Team3.Vertical2GridBaseForm
    {
        public DMRMgt()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void DMRMgt_Load(object sender, EventArgs e)
        {
            {
                ResourceService R_survice = new ResourceService();
                List<MachineVO> lst = R_survice.GetMachineAll();
                ComboUtil.ComboBinding<MachineVO>(comboBox1, lst, "m_id", "m_name", "미선택");
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkBoxColumn.Name = "ck";
            checkBoxColumn.HeaderText = "선택";
            checkBoxColumn.MinimumWidth = 50;
            dataGridView1.Columns.Add(checkBoxColumn);

            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "pro_id", "pro_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "플랜id", "plan_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "계획시작일자", "pro_date", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, " ", "so_sdate", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "설비코드", "m_code", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "설비명", "m_name", true, 100, DataGridViewContentAlignment.MiddleLeft);//
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "pro_state", false, 100, DataGridViewContentAlignment.MiddleLeft);//ff
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "common_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상품코드", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상품명", "producct_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "소요창고", "m_use_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "양품창고", "m_ok_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "불량창고", "m_ng_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "계획수량", "pro_count", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "", "pro_pcount", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "", "pro_mcount", false, 100, DataGridViewContentAlignment.MiddleLeft);



            DateTime today = DateTime.Now;
            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);
            ProcessService P_service = new ProcessService();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            //  dataGridView1.DataSource = 
            DataView dv = dt.DefaultView;
            DataTable table = new DataTable();
            dv.RowFilter = "pro_state = 'COMMAND' ";
            if (dv.Count > 0)
            {
                table = dv.ToTable();
                dataGridView1.DataSource = table;

            }
            GridViewUtil.SetDataGridView(dataGridView1);
        }


        ProcessService P_service = new ProcessService();
        List<string> lst = new List<string>();
        List<string> st = new List<string>();
        DataTable ndt = new DataTable();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                ndt = null;

                List<DMRVO> lst = new List<DMRVO>();
                ProcessService P_service = new ProcessService();
                DMRVO vo = new DMRVO();
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true) //체크박스가 true?
                        {
                            vo.product_codename = dataGridView1.Rows[i].Cells[9].Value.ToString(); //제품코드네임

                            vo.factory_name = dataGridView1.Rows[i].Cells[11].Value.ToString(); //창고명
                            vo.pro_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());//pro_id
                            vo.plan_id = dataGridView1.Rows[i].Cells[2].Value.ToString();//plan_id
                            if (P_service.GetDMRMgt(vo).Count >= 5)
                            {
                                lst = (P_service.GetDMRMgt(vo));
                            }
                        }
                    }
                    for (int i = 0; i < lst.Count; i++)
                    {
                        lst[i].req_date = DateTime.Now.ToShortDateString();
                    }
                    //  lst = P_service.GetDMRMgt(vo);
                    //dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "pro_id", "pro_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "플랜id", "plan_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "product_id", "product_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "제품코드명", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "제품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "", "factory_id", false, 100, DataGridViewContentAlignment.MiddleLeft);//
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "창고명", "factory_name", true, 100, DataGridViewContentAlignment.MiddleLeft);//ff
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "계획수량", "pro_count", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "소요량", "bom_use_count", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "소요수량", "plan_count", true, 100, DataGridViewContentAlignment.MiddleLeft);

                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "현재재고", "w_count_present", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "이전재고", "w_count_past", false, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청창고id", "req_factory_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청창고", "req_factory", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "요청량", "req_count", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청일", "req_date", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "사유", "reason", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "잔량", "nam", true, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "w_id", "w_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
                    GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "", "order_id", false, 100, DataGridViewContentAlignment.MiddleLeft);

                    dataGridView2.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
 
                    dataGridView2.DataSource = lst;
                                 
                }
                catch (Exception err)
                {
                    string st = err.Message;
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
         

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0) return;

            try
            {
                int p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                bool bresult = !Convert.ToBoolean(dataGridView1.CurrentRow.Cells[0].EditedFormattedValue);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) == p_id)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = bresult;
                    }
                    else
                    {
                        if (bresult)
                        { dataGridView1.Rows[i].Cells[0].Value = !bresult; }
                    }
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dataGridView2.Columns.Clear();
            DataTable table = new DataTable();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "pro_id", "pro_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "플랜id", "plan_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "계획일", "pr", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "요청일", "so_sdate", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "설비코드", "m_code", true, 100, DataGridViewContentAlignment.MiddleLeft);
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "설비명", "m_name", true, 100, DataGridViewContentAlignment.MiddleLeft);//
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상태", "pro_state", true, 100, DataGridViewContentAlignment.MiddleLeft);//ff
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상태", "common_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상품코드명", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);

            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "소진창고", "m_use_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "양품창고", "m_ok_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "불량창고", "m_ng_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "pro_state = 'COMMAND' ";
            if (dv.Count > 0)
            {
                table = dv.ToTable();
                dataGridView1.DataSource = table;
            }

            if (textBox1.Text != "")
            {
                dv = table.DefaultView;
                dv.RowFilter = "product_codename = '" + textBox1.Text + "'";
                if (dv.Count > 0)
                {
                    table = dv.ToTable();

                }
            }
            if (comboBox1.SelectedIndex != 0)
            {
                dv = table.DefaultView;
                dv.RowFilter = "m_name = '" + comboBox1.Text + "'";
                if (dv.Count > 0)
                {
                    table = dv.ToTable();

                }
            }
            dataGridView1.DataSource = table;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                List<DMRVO> n_dt = (List<DMRVO>)dataGridView2.DataSource;
                bool bResult;
                bResult = P_service.tranWH(n_dt);
                if (bResult)
                {
                    MessageBox.Show("성공");
                }
                else
                    MessageBox.Show("실패");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelEX(dataGridView1);
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        public void ExcelEX(DataGridView grid)
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
            for (j = 0; j < grid.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = grid.Columns[j].HeaderText;
            }

            StartRow++;

            //Write datagridview content
            for (i = 0; i < grid.Rows.Count; i++)
            {
                for (j = 0; j < grid.Columns.Count; j++)
                {
                    try
                    {
                        Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = grid[j, i].Value == null ? "" : grid[j, i].Value;
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExcelEX(dataGridView2);
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (typeof(TextBox) == ctrl.GetType())
                {
                    ctrl.Text = "";
                }
            }

            foreach (Control con in panel1.Controls)
            {
                if (con is ComboBox cb)
                {
                    cb.SelectedIndex = 0;

                }
            }
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            //  dataGridView1.DataSource = 
            DataView dv = dt.DefaultView;
            DataTable table = new DataTable();
            dv.RowFilter = "pro_state = 'COMMAND' ";
            if (dv.Count > 0)
            {
                table = dv.ToTable();
                dataGridView1.DataSource = table;

            }
        }
    }
}
