using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;
using Team3.Service;

namespace Team3
{
    //State of Order's Operation 작업 지시 현황
    public partial class SOO : Team3.VerticalGridBaseForm
    {
        
        public SOO()
        {
            InitializeComponent();
        }

        private void SOO_Load(object sender, EventArgs e)
        {
            ProcessService P_service = new ProcessService();
           DataTable dt = P_service.GetProductionPlanCheck(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
        }
    }
}
