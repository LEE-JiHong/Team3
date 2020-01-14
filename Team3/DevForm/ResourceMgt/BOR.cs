using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
 


namespace Team3
{
    public partial class BOR : Team3.VerticalGridBaseForm
    {
        List<BORDB_VO> list;
        public BOR()
        {
            InitializeComponent();
        }
        private void BOR_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            list = service.GetBORAll();
            dataGridView1.DataSource = list;
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
