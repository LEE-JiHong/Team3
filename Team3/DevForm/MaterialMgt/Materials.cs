using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class Materials : VerticalGridBaseForm
    {
        public Materials()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPop frm = new ProductPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
