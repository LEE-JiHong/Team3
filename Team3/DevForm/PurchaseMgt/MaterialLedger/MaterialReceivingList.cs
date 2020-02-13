using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class MaterialReceivingList : Team3.VerticalGridBaseForm
    {
        public MaterialReceivingList()
        {
            InitializeComponent();
        }

        private void MaterialReceivingList_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼

        }

    }
}
