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
    public partial class businessMgt : Team3.VerticalGridBaseForm
    {
        public List<CompanyVO> lst;
        public businessMgt()
        {
            InitializeComponent();
        }

       
        private void businessMgt_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            lst=service.GetCompanyAll();
            dataGridView2.DataSource = lst; 
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CompanyPop frm = new CompanyPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
