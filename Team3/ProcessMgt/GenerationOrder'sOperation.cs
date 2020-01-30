using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3.Service;

namespace Team3
{
    //Generation of Order's Operation  작업 지시 생성
    public partial class GOO : Team3.VerticalGridBaseForm
    {
        public GOO()
        {
            InitializeComponent();
        }

        private void GOO_Load(object sender, EventArgs e)
        {
            ProcessService P_service = new ProcessService();
            DataTable dt = P_service.GetProductionPlanCheck(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // string selectID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
         
          
        }
    }
}
