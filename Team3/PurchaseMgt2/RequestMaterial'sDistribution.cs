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
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkBoxColumn.HeaderText = "선택";
            dataGridView1.Columns.Add(checkBoxColumn);



            DateTime today = DateTime.Now;
            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);
            ProcessService P_service = new ProcessService();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
            GridViewUtil.SetDataGridView(dataGridView1);
        }
        ProcessService P_service = new ProcessService();
        List<string> lst = new List<string>();
        List<string> st = new List<string>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //string date = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //ProcessService P_service = new ProcessService();
            //DataTable dt = P_service.AAA(id, date);
            //dataGridView2.DataSource = dt;
            List<DMRVO> lst = new List<DMRVO>();
            ProcessService P_service = new ProcessService();
            DMRVO vo = new DMRVO();
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true) //체크박스가 true?
                    {
                        vo.product_codename = dataGridView1.Rows[i].Cells[9].Value.ToString(); //코드네임

                        vo.factory_name = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        vo.pro_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        vo.plan_id = dataGridView1.Rows[i].Cells[2].Value.ToString();
                      //  lst=P_service.GetDMRMgt(vo);

                    }
                }
                lst = P_service.GetDMRMgt(vo);
                dataGridView2.DataSource = lst;
                int k = lst.Count;
             //lst = lst.Distinct().ToList(); //중복제거

                //bool bResult = false;
                for (int i = 0; i < lst.Count; i++)
                {
                    //   dt.Rows.Add(P_service.GetProductFromBOM(lst[i]));


                }
                //      dataGridView2.DataSource = dt;


            }

            catch (Exception err)
            {
                string st = err.Message;
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                //string proDate = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                bool bresult = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) == p_id)
                    {
                        bresult = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[0].Value = !bresult;
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
