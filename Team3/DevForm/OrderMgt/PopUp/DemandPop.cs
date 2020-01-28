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
    public partial class DemandPop : Team3.DialogForm
    {
        List<SOMasterVO> somasterList;

        public DemandPop()
        {
            InitializeComponent();
        }
        private void DemandPop_Load(object sender, EventArgs e)
        {
           
            OrderService service = new OrderService();
            List<string> list = service.GetPlanID();

            cbOrderGubun.DataSource = list;

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string startDate = DateTime.Now.ToShortDateString();

            OrderService service = new OrderService();

            somasterList = service.GetSOMaster(cbOrderGubun.Text);

            dataGridView1.DataSource = somasterList;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<DemandPlanVO> list = new List<DemandPlanVO>();

            for (int i = 0; i < somasterList.Count; i++)
            {
                DemandPlanVO vo = new DemandPlanVO();
                vo.plan_id = cbOrderGubun.Text;
                vo.d_count = somasterList[i].so_pcount;
                vo.d_date = somasterList[i].so_edate;
                vo.so_id = somasterList[i].so_id;
                list.Add(vo);
            }
            OrderService service = new OrderService();
            bool result = service.AddDemandPlan(list);

            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("수요계획 생성 실패");
            }
        }
    }
}
