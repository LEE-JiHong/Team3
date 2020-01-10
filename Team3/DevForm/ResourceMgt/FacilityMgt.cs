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
            FacilitiesPop group = new FacilitiesPop();
            if (group.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FacilitieInfoPop frm = new FacilitieInfoPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
