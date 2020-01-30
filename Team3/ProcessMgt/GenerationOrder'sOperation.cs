using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3.Service;

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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboBox1.Items.Add("계획시작");
            comboBox1.Items.Add("납기일");
            comboBox1.Items.Add("등록시간");
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now.AddDays(7);
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(checkBoxColumn);




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
                    int p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value.ToString());
                    string proDate = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    bool bresult = false;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value) == p_id)
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
                        lst.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value.ToString())); //true인 행의 아이디를 가져옴
                        strlist.Add(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    }
                }
                lst = lst.Distinct().ToList(); //중복제거
                strlist = strlist.Distinct().ToList();


                for (int i = 0; i <= lst.Count; i++)
                {
                    P_service.UpdateCommand(Convert.ToInt32(lst[i].ToString()), strlist[i].ToString());
                }

            }
            catch (Exception err)
            {
                string st = err.Message;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "계획시작")
            {
                dt = P_service.GetProductionPlanCheck(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                dataGridView1.DataSource = dt;
            }
        }
    }
}

