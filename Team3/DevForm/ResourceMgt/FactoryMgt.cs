using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class FactoryMgt : Team3.VerticalGridBaseForm
    {
        public FactoryMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FactoryPop frm = new FactoryPop();
            if(frm.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}
