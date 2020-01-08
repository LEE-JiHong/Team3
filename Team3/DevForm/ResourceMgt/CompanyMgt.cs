using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class businessMgt : Team3.VerticalGridBaseForm
    {
        public businessMgt()
        {
            InitializeComponent();
        }

        private void businessMgt_Load(object sender, EventArgs e)
        {

        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CompanyPop frm = new CompanyPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
