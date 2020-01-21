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
    public partial class facilityMgt : HorizonDgvBaseForm
    {
        DateTime today = DateTime.Now;
        List<MachineVO> machineList;
        List<MachineGradeVO> machineGreadeList;
        ResourceService R_service;
        public facilityMgt()
        {
            InitializeComponent();
        }

        private void facilityMgt_Load(object sender, EventArgs e)
        {
            R_service = new ResourceService();
            machineList = R_service.GetMachineAll();
            dataGridView2.DataSource = machineList;

            machineGreadeList = R_service.GetMachineGrpAll();
            dataGridView1.DataSource = machineGreadeList;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FacilitiesPop group = new FacilitiesPop(FacilitiesPop.EditMode.Input);
            group.ShowDialog();
        }
        private void btnG_Update_Click(object sender, EventArgs e)
        {
            MachineGradeVO VO = new MachineGradeVO();
            VO.mgrade_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            VO.mgrade_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            VO.mgrade_name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            VO.mgrade_yn = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            VO.mgrade_uadmin = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            VO.mgrade_udate = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            VO.mgrade_comment = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            FacilitiesPop frm = new FacilitiesPop(FacilitiesPop.EditMode.Update, VO);

            frm.ShowDialog();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //FacilitieInfoPop frm = new FacilitieInfoPop
            //    (FacilitieInfoPop.EditMode.Input, dataGridView1.CurrentRow.Cells[1].Value.ToString(), lblID1.Text);
            //frm.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DataGridViewRow rows = dataGridView2.CurrentRow;
            MachineVO VO = new MachineVO();
            VO.m_id = Convert.ToInt32(rows.Cells[0].Value.ToString());
            VO.mgrade_code = rows.Cells[2].Value.ToString();
            VO.mgrade_id = Convert.ToInt32(rows.Cells[1].Value);
            VO.m_code = rows.Cells[3].Value.ToString();
            VO.m_name = rows.Cells[4].Value.ToString();
            VO.m_use_sector = rows.Cells[5].Value.ToString();
            VO.m_ok_sector = rows.Cells[6].Value.ToString();
            VO.m_ng_sector = rows.Cells[7].Value.ToString();
            VO.m_yn = rows.Cells[11].Value.ToString();
            VO.m_os_yn = rows.Cells[8].Value.ToString();
            VO.m_uadmin = rows.Cells[12].Value.ToString();
            VO.m_udate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
           
            if (rows.Cells[9].Value == null)
                VO.m_check = "";
            else
                VO.m_check = rows.Cells[9].Value.ToString();
            VO.m_comment = rows.Cells[10].Value.ToString();

            FacilitieInfoPop frm = new FacilitieInfoPop(FacilitieInfoPop.EditMode.Update, VO);
            frm.ShowDialog();

        } 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lblID1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Y")
                radioButton1.Checked = true;
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "N")
                radioButton2.Checked = true;
            txtAdmin.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDate.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtComment.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString() + " 를(을) 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    bool bResult = R_service.DeleteMachineGr(Convert.ToInt32(lblID1.Text));
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            machineList = R_service.GetMachineAll();
            var aaa = (from list in machineList
                       where list.mgrade_id.ToString() == code
                       select list).ToList();
            dataGridView2.DataSource = aaa;
        }
    }
}
