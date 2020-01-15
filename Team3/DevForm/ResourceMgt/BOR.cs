using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;


namespace Team3
{
    public partial class BOR : Team3.VerticalGridBaseForm
    {
        CommonCodeService common_service;
        List<CommonVO> common_list;
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

            common_service = new CommonCodeService();
            common_list = common_service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.COMMON_TYPE == "route"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboProcess, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BORPop frm = new BORPop(BORPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BORPop frm = new BORPop(BORPop.EditMode.Update, lblID.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
