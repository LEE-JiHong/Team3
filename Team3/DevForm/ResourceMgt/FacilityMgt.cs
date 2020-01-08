using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class facilityMgt :  HorizonDgvBaseForm
    {
        public facilityMgt()
        {
            InitializeComponent();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FacilitiesPop group = new FacilitiesPop();
            if(group.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FacilitieInfoPop frm = new FacilitieInfoPop();
            if(frm.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}
