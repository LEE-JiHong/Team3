using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    //Sales of unit's price management 영업 단가 관리
    public partial class SUPMMgt : Team3.VerticalGridBaseForm
    {
        public SUPMMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SUPMPop frm = new SUPMPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
