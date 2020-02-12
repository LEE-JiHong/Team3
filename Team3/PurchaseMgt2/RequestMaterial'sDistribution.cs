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
            checkBoxColumn.HeaderText = "선택";
            dataGridView1.Columns.Add(checkBoxColumn);



            DateTime today = DateTime.Now;
            dateTimePicker1.Value = today.AddDays(-10);
            dateTimePicker2.Value = today.AddDays(20);
            ProcessService P_service = new ProcessService();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
            //DataView dv = dt.DefaultView;
            //dv.RowFilter = "pro_state = 'COMMAND' ";
            //if (dv.Count > 0)
            //{
            //    table = dv.ToTable();
            //    dataGridView1.DataSource = table;

            //}
            GridViewUtil.SetDataGridView(dataGridView1);
        }


        ProcessService P_service = new ProcessService();
        List<string> lst = new List<string>();
        List<string> st = new List<string>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            DataTable ndt = new DataTable();
            //string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //string date = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //ProcessService P_service = new ProcessService();
            //DataTable dt = P_service.AAA(id, date);
            //dataGridView2.DataSource = dt;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "pro_id", "pro_id", true,100,DataGridViewContentAlignment.MiddleLeft,false,false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "플랜id", "plan_id", true,100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "pro_id", "pro_id", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "상품코드명", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "상품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "창고아이디", "factory_id", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2 ,"창고이름", "factory_name", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "개수", "pro_count", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2 ,"들어가는 수", "bom_use_count", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2 ,"현재고", "w_count_present", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "이전재고", "w_count_past", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청창고", "req_factory", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청수량", "req_count", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "요청일", "req_date", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "사유", "reason", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "잔량", "nam", true, 100, DataGridViewContentAlignment.MiddleLeft, false, false);

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
                        if (P_service.GetDMRMgt(vo).Count >= 5)
                        {
                            ndt = (P_service.GetDMR_dt(vo));
                        }
                    }
                }
                //  lst = P_service.GetDMRMgt(vo);
 

                dataGridView2.DataSource = ndt;


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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            DataView dv = dt.DefaultView;
            dv.RowFilter = "pro_state = 'COMMAND' ";
            if (dv.Count > 0)
            {
                table = dv.ToTable();
                dataGridView1.DataSource = table;

            }
            dataGridView1.DataSource = table;
        }
    }
}
