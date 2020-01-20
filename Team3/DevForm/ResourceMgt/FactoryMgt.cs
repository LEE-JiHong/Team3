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
    public partial class FactoryMgt : Team3.VerticalGridBaseForm
    {
        ResourceService service = new ResourceService();
        List<CommonVO> common_list;
        List<FactoryDB_VO> list;

        public FactoryMgt()
        {
            InitializeComponent();
        }
        private void FactoryMgt_Load(object sender, EventArgs e)
        {
            list = service.GetFactoryAll();
            dataGridView1.DataSource = list;

            CommonCodeService Common_service = new CommonCodeService();
            common_list = Common_service.GetCommonCodeAll();

            var mCode = (from item in common_list
                         where item.COMMON_TYPE == "facility_class_id"
                         select item).ToList();
            ComboUtil.ComboBinding<CommonVO>(cboSearchFacilityGroup, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Input);
            frm.ShowDialog();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
            {
                FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Update, lblID.Text);
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {


            try
            {
                DialogResult dr = MessageBox.Show(dataGridView1.CurrentRow.Cells[5].Value.ToString() + " 를(을) 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    bool bResult = service.DelelteFactory(Convert.ToInt32(lblID.Text));
                    if (bResult)
                    {
                        MessageBox.Show("삭제완료");
                    }
                    else if (!bResult)
                    {
                        MessageBox.Show("삭제 실패");
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                string sr = err.Message;
            }
        }

        private void FactoryMgt_Activated(object sender, EventArgs e)
        {
            list = service.GetFactoryAll();
            dataGridView1.DataSource = list;

        }
    }
}
