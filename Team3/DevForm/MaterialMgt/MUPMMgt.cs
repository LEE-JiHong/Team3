using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    //Material of unit's price management 자재 단가 관리
    public partial class MUPMMgt : Team3.VerticalGridBaseForm
    {
        public MUPMMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MUPMPop frm = new MUPMPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
