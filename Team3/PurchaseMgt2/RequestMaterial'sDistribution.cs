using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            checkBoxColumn.Name = "ck";
            checkBoxColumn.HeaderText = "선택";
            dataGridView1.Columns.Add(checkBoxColumn);

            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "pro_id", "pro_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "플랜id", "plan_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "", "pro_date", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, " ", "so_sdate", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "설비코드", "m_code", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "설비명", "m_name", true, 100, DataGridViewContentAlignment.MiddleLeft);//
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "pro_state", true, 100, DataGridViewContentAlignment.MiddleLeft);//ff
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "common_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상품코드", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상품명", "producct_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "소요창고", "m_use_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "양품창고", "m_ok_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "불량창고", "m_ng_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "계획수량", "pro_count", true, 100, DataGridViewContentAlignment.MiddleLeft);


            DateTime today = DateTime.Now;
            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);
            ProcessService P_service = new ProcessService();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
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
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            ndt = null;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
               
            //}
         


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
                dataGridView2.DataSource = lst;
                //int k = lst.Count;
                //lst = lst.Distinct().ToList(); //중복제거
                //bool bResult = false;
                //for (int i = 0; i < lst.Count; i++)
                //{
                //   dt.Rows.Add(P_service.GetProductFromBOM(lst[i]));
                //}
                //      dataGridView2.DataSource = dt;
            }

            catch (Exception err)
            {
                string st = err.Message;
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

            try
            {
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells[0].Value = false;
                //}
                int p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                string proDate = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                bool bresult = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) == p_id)
                    {
                        //dataGridView1.Rows[i].Cells[0].Value = !bresult;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {


            DataTable table = new DataTable();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "pro_id", "pro_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "플랜id", "plan_id", true, 100, DataGridViewContentAlignment.MiddleLeft);//f
            //GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "계획일", "pro_date", false, 100, DataGridViewContentAlignment.MiddleLeft);//f
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
                string st = err.Message;
            }
        }
    }
}
