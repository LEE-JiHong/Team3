using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;

namespace Team3
{
    public partial class BomMgt : Team3.VerticalGridBaseForm
    {
        public BomMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BomPop frm = new BomPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void BomMgt_Load(object sender, EventArgs e)
        {
            cboDeployment.SelectedIndex = 0;
            cboIsUsed.SelectedIndex = 0;

            BomService service = new BomService();

            List<BomVO> list = service.GetBomAll();
            dgvBom.DataSource = list;



        }
    }
}
