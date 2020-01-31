using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class MRP : Team3.VerticalGridBaseForm
    {
        string planID;

        public MRP()
        {
            InitializeComponent();
        }

        private void MRP_Load(object sender, EventArgs e)
        {
            OrderService service = new OrderService();

            List<string> planIDlist = service.GetPlanID();
            cboPlanID.DataSource = planIDlist;

            string planID = cboPlanID.Text;

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            string planID = cboPlanID.Text;

            OrderService service = new OrderService();
            dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }
    }
}
