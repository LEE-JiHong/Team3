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
        public MRP()
        {
            InitializeComponent();
        }

        private void MRP_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);
        }
    }
}
