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
        string planID = "20200121_P";

        public MRP()
        {
            InitializeComponent();
        }

        private void MRP_Load(object sender, EventArgs e)
        {
            
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            OrderService service = new OrderService();
            dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            OrderService service = new OrderService();
            dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }
    }
}
