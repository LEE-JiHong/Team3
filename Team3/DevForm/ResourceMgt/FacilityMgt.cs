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
    public partial class facilityMgt : HorizonDgvBaseForm
    {
        List<MachineVO> machineList;
        List<MachineGradeVO> machineGreadeList;
        public facilityMgt()
        {
            InitializeComponent();
        }

        private void facilityMgt_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            machineList = service.GetMachineAll();
            dataGridView2.DataSource = machineList;

            machineGreadeList= service.GetMachineGrpAll();
            dataGridView1.DataSource =  machineGreadeList;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FacilitiesPop group = new FacilitiesPop(FacilitiesPop.EditMode.Input);
            group.ShowDialog();
        }
        private void btnG_Update_Click(object sender, EventArgs e)
        {
            FacilitiesPop frm = new FacilitiesPop(FacilitiesPop.EditMode.Update, lblID1.Text);
            frm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FacilitieInfoPop frm = new FacilitieInfoPop(FacilitieInfoPop.EditMode.Input);
            frm.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FacilitieInfoPop frm = new FacilitieInfoPop(FacilitieInfoPop.EditMode.Input);
            frm.ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

       
    }
}
