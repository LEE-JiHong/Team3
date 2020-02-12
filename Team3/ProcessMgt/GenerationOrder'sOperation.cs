using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;

namespace Team3
{
    //Generation of Order's Operation  작업 지시 생성
    public partial class GOO : Team3.VerticalGridBaseForm
    {
        DataTable dt;
        public GOO()
        {
            InitializeComponent();
        }
        ProcessService P_service = new ProcessService();
        private void GOO_Load(object sender, EventArgs e)
        {
            CommonCodeService C_service = new CommonCodeService();
            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            {
                var list_c = (from item in c_list
                              where item.common_type == "create_work_order"
                              select item).ToList();

                ComboUtil.ComboBinding(cboStatus, list_c, "common_value", "common_name", "미선택");
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
            dateTimePicker2.Value = DateTime.Now.AddDays(7);
            ResourceService R_service = new ResourceService();
            List<MachineVO> m_list = R_service.GetMachineAll();

            ComboUtil.ComboBinding(cboMachine, m_list, "m_code", "m_name", "미선택");

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkBoxColumn.HeaderText = "선택";
            dataGridView1.Columns.Add(checkBoxColumn);

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "작업지시번호", "WorkID", true, 60);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상태", "common_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상태", "pro_state", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비코드", "m_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비명", "m_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획수량", "pro_count", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "지시수량", "pro_pcount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획시작일", "pro_date", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "마스터ID", "plan_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상품ID", "pro_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "소요시간", "use_time", true);
            GridViewUtil.SetDataGridView(dataGridView1);


            LoadData();
        }

        private void LoadData()
        {
            dt = P_service.GetProductionPlanCheck(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dt.Rows.Count)
                {
                    int p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value.ToString());
                    //string proDate = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    bool bresult = false;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value) == p_id)
                        {
                            bresult = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                            dataGridView1.Rows[i].Cells[0].Value = !bresult;
                        }
                    }
                }
            }
            catch (Exception err)
            {

                string st = err.Message;
            }
        }
        List<int> lst = new List<int>();
        List<string> strlist = new List<string>();

        private void btnWork_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true) //체크박스가 true?
                    {
                        lst.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value.ToString())); //true인 행의 아이디를 가져옴
                        strlist.Add(dataGridView1.Rows[i].Cells[10].Value.ToString());
                    }
                }
                int k = lst.Count;
                lst = lst.Distinct().ToList(); //중복제거
                int t = lst.Count;
                strlist = strlist.Distinct().ToList();

                //bool bResult = false;
                for (int i = 0; i < strlist.Count; i++)
                {
                    /*  bResult =*/
                    P_service.UpdateCommand(Convert.ToInt32(lst[i].ToString()), strlist[i].ToString());
                }
                //if (bResult)
                LoadData();

            }

            catch (Exception err)
            {
                string st = err.Message;
            }

        }

        DataTable table = new DataTable();
        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                dt = P_service.GetProductionPlanCheck(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

                if (textBox1.Text != "" && cboStatus.Text == "미선택" && cboMachine.Text == "미선택")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "product_codename = '" + textBox1.Text + "'";
                    if (dv.Count > 0)
                    {
                        table = dv.ToTable();
                        dataGridView1.DataSource = table;
                        textBox1.Text = "";
                    }
                }

                else if (cboStatus.Text == "미선택" && cboMachine.Text == "미선택")
                {
                    dataGridView1.DataSource = dt;
                }

                else
                {
                    if (cboStatus.Text != "미선택")
                    {
                        DataView dv = dt.DefaultView;
                        dv.RowFilter = "common_name = '" + cboStatus.Text + "'";
                        if (dv.Count > 0)
                        {
                            table = dv.ToTable();
                        }
                        if (cboMachine.Text != "미선택")
                        {
                            dv = table.DefaultView;
                            dv.RowFilter = "m_name ='" + cboMachine.Text + "'";
                            if (dv.Count > 0)
                            {
                                table = dv.ToTable();
                            }

                        }
                        if (table.Columns.Count == 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else if (table.Columns.Count > 0)
                        {
                            dataGridView1.DataSource = table;
                        }

                    }
                    else //상태 없을경우
                    {
                        DataView dv = dt.DefaultView;
                        dv.RowFilter = "m_name ='" + cboMachine.Text + "'";
                        if (dv.Count > 0)
                        {
                            table = dv.ToTable();

                        }
                        else
                        {
                            dataGridView1.DataSource = dt;
                        }
                        dataGridView1.DataSource = table;
                    }
                }

            }
            catch (Exception err)
            {
                string st = err.Message;
            }

        }
    }
}
