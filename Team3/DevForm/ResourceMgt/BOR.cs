using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class BOR : Team3.VerticalGridBaseForm
    {
        public BOR()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BORPop frm = new BORPop();
            if(frm.ShowDialog()== DialogResult.OK)
            {

            }
        }
    }
}
