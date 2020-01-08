using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class SalesMasterUpload : DgvBaseForm
    {
        public SalesMasterUpload()
        {
            InitializeComponent();
        }

        private void SalesMasterUpload_Load(object sender, EventArgs e)
        {

        }

        //엑셀 등록 버튼
        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            SalesMasterDialog frm = new SalesMasterDialog();

            if (frm.ShowDialog() == DialogResult.OK)
            {
            }
        }

        
    }
}
