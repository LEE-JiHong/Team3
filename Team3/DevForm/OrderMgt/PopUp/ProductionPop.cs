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
    public partial class ProductionPop : Team3.DialogForm
    {
        List<SOMasterVO> somasterList;

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
            string startDate = DateTime.Now.ToShortDateString();

            OrderService service = new OrderService();

            somasterList = service.GetSOMaster(cbOrderGubun.Text);

            string endDate = somasterList[0].so_edate;

            List<DayVO> dayList = new List<DayVO>();

            dayList = service.GetDays(startDate, endDate);

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
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<DemandPlanVO> list = new List<DemandPlanVO>();

            int soQty = 0;

            foreach (SOMasterVO vo in somasterList)
            {
                soQty += vo.so_pcount;
            }

            int qty = 0;
            int totalQty = 0;

            int idx = somasterList.Count-1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DemandPlanVO vo = new DemandPlanVO();
                vo.plan_id = cbOrderGubun.Text;
                vo.d_count = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                vo.d_date = dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 10);
                vo.so_id = somasterList[idx].so_id;
                if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 10)) == Convert.ToDateTime(somasterList[idx].so_edate))
                {
                    if (qty < somasterList[idx].so_pcount)
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
                
                if (vo.d_count > 0)
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
            bool result = service.AddDemandPlan(list);

            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("생산계획 생성 실패");
            }
        }
    }
}
