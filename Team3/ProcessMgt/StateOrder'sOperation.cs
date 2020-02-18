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
using System.Linq;
using Team3.Service;

namespace Team3
{
    //State of Order's Operation 작업 지시 현황
    public partial class SOO : Team3.VerticalGridBaseForm
    {
        DateTime today = DateTime.Now;
        public SOO()
        {
            InitializeComponent();
        }
        ProcessService P_service = new ProcessService();
        DataTable dt;
        private void SOO_Load(object sender, EventArgs e)
        {
            radioButton6.Checked = true;
            ResourceService R_service = new ResourceService();
            CommonCodeService C_service = new CommonCodeService();
            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            {
                var list_c = (from item in c_list
                              where item.common_type == "create_work_order"
                              select item).ToList();

                ComboUtil.ComboBinding(cboStatus, list_c, "common_value", "common_name", "미선택");
            }
            {
                var R_list = (from item in R_service.GetFactoryAll()
                              where item.facility_class == "창고"
                              select item).ToList();
                ComboUtil.ComboBinding(cboWH, R_list, "factory_id", "factory_name", "미선택");
            }
            {

                ComboUtil.ComboBinding(cboMachine, R_service.GetMachineAll(), "m_id", "m_name", "미선택");
            }

            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);


            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());


            GridViewUtil.SetDataGridView(dataGridView1);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상품ID", "pro_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "투입일", "pro_date", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "지시일", "so_sdate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비코드", "m_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비명", "m_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상태", "common_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상태", "pro_state", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "producct_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "소진창고", "m_use_sector", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "양품창고", "m_ok_sector", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "불량창고", "m_ng_sector", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획수량", "pro_count", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "지시수량", "pro_pcount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수량", "pro_mcount", true);
            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.DataSource = dt;
        }

        DataTable table = new DataTable();

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

                if (cboWH.Text == "미선택" && cboMachine.Text != "미선택")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "m_name = '" + cboMachine.Text + "'";
                    if (dv.Count > 0)
                    {
                        table = dv.ToTable();
                        dataGridView1.DataSource = table;
                    }
                }
                else if (cboWH.Text != "미선택" && cboMachine.Text == "미선택")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "m_use_sector = '" + cboWH.Text + "'";
                    if (dv.Count > 0)
                    {
                        table = dv.ToTable();
                        dataGridView1.DataSource = table;
                    }
                }
                else if (cboWH.Text != "미선택" && cboMachine.Text != "미선택")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "m_use_sector = '" + cboWH.Text + "' and m_name = '" + cboMachine.Text + "'";
                    if (dv.Count > 0)
                    {
                        table = dv.ToTable();
                        dataGridView1.DataSource = table;
                    }
                }
                dataGridView1.DataSource = dt;
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rb = (RadioButton)sender;
            if (rb.Tag.ToString() != "전체")
            {
                if (table.Rows.Count != 0)
                {

                    var collection = table.AsEnumerable()
                        .Where(x => x.Field<string>("common_name") == rb.Tag.ToString()).Select(y => y);

                    DataTable filtered = collection.Any() ? collection.CopyToDataTable() : null;
                    if (filtered != null)
                        dataGridView1.DataSource = filtered;
                    else
                        dataGridView1.DataSource = null;
                }
                else
                {
                    var collection = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()).AsEnumerable()
                     .Where(x => x.Field<string>("common_name") == rb.Tag.ToString()).Select(y => y);

                    var filtered = collection.Any() ? collection.CopyToDataTable() : null;
                    if (filtered != null)
                        dataGridView1.DataSource = filtered;
                    else
                        dataGridView1.DataSource = null;
                }
            }
            else if (rb.Tag.ToString() == "전체" && table.Rows.Count != 0)
                dataGridView1.DataSource = table;
            else
                dataGridView1.DataSource = dt;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cboWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton6.Checked = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            foreach (Control con in panel1.Controls)
            {
                if (con is ComboBox cb)
                {
                    cb.SelectedIndex = 0;

                }
            }
            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
        }
    }
}
