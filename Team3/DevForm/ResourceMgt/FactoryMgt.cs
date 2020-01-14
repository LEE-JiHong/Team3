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
    public partial class FactoryMgt : Team3.VerticalGridBaseForm
    {
        List<FactoryDB_VO> list;
        public FactoryMgt()
        {
            InitializeComponent();
        }
        private void FactoryMgt_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            list=service.GetFactoryAll();
            dataGridView1.DataSource = list;


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
