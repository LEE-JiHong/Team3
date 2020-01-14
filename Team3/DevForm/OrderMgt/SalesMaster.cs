using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class SalesMaster : Team3.VerticalGridBaseForm
    {
        public SalesMaster()
        {
            InitializeComponent();
        }

        private void SalesMaster_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1);
        }
    }
}
