using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class ProductionPop : DialogForm
    {
        int TotalCount;

        List<DemandPlanVO> demandList;

        public ProductionPop()
        {
            InitializeComponent();
        }
        private void DemandPop_Load(object sender, EventArgs e)
        {
            rdoWeekday.Checked = true;

            OrderService service = new OrderService();
            List<string> list = service.GetPlanID();

            cbOrderGubun.DataSource = list;

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "날짜", "date", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수량", "", true, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "수량", "", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주중/주말", "plan_type", false, 130);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TotalCount = 0;

            string startDate = DateTime.Now.ToShortDateString();

            OrderService service = new OrderService();

            demandList = service.GetDemandPlanFromPlanID(cbOrderGubun.Text);

            DateTime dt = Convert.ToDateTime(demandList[0].d_date).AddDays(-1);

            string endDate = dt.ToShortDateString();

            List<DayVO> dayList = service.GetDays(startDate, endDate);

            dataGridView1.DataSource = dayList;

            if (rdoWeekday.Checked) //주중 선택
            {
                //List<DayVO> weekdayList = (from item in dayList
                //                       where item.plan_type == "WEEKDAY"
                //                       select item).ToList();
                for (int i = 0; i < dayList.Count; i++)
                {
                    if (dayList[i].plan_type == "WEEKEND")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dataGridView1.Rows[i].ReadOnly = true;
                    }
                }
            }
            else if (rdoWeekend.Checked) //주말 선택
            {
                //List<DayVO> weekEndList = (from item in dayList
                //                       where item.plan_type == "WEEKEND"
                //                       select item).ToList();
                for (int i = 0; i < dayList.Count; i++)
                {
                    if (dayList[i].plan_type == "WEEKEND")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[i].ReadOnly = false;
                    }
                }
            }

            foreach (DemandPlanVO vo in demandList)
            {
                TotalCount += vo.d_count;   
            }

            lblCount.Text = TotalCount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ProductionPlanVO> list = new List<ProductionPlanVO>();

            int soQty = 0;

            foreach (DemandPlanVO vo in demandList)
            {
                soQty += vo.d_count;
            }

            int qty = 0;
            int totalQty = 0;

            int idx = demandList.Count-1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ProductionPlanVO vo = new ProductionPlanVO();
                vo.plan_id = cbOrderGubun.Text;
                vo.pro_count = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                vo.pro_date = dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 10);
                vo.d_id = demandList[idx].d_id;
                if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 10)) == Convert.ToDateTime(demandList[idx].d_date))
                {
                    if (qty < demandList[idx].d_count)
                    {
                        MessageBox.Show("테스트");
                        return;
                    }
                    idx--;

                    if (idx == -1)
                    {
                        MessageBox.Show("성공");
                    }
                    qty = 0;
                }
                else
                {
                    qty += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                }

                totalQty += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                
                if (vo.pro_count > 0)
                {
                    list.Add(vo);
                }
            }

            if (soQty > totalQty)
            {
                MessageBox.Show("수량이 계획수량보다 적습니다.");
                return;
            }

            OrderService service = new OrderService();
            bool result = service.AddProductionPlan(list);

            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("생산계획 생성 실패");
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int uphCount = 0;

            try
            {
                string planID =  cbOrderGubun.Text;

                OrderService service = new OrderService();
                uphCount = service.GetMaxUPHCount(planID);

            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            //수량 입력하면 하루생산량 체크
            if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value) > uphCount)
            {
                MessageBox.Show("Test");
            }
            else
            {
                TotalCount -= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                lblCount.Text = TotalCount.ToString();
            }
        }
    }
}
