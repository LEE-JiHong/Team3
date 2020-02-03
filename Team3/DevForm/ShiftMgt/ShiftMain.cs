using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using System.Linq;


namespace Team3
{
    public partial class ShiftMain : Team3.VerticalGridBaseForm
    {
        public ShiftMain()
        {
            InitializeComponent();
        }


        ShiftService S_service = new ShiftService();
        private void ShiftMain_Load(object sender, EventArgs e)
        {
            //     ShiftService S_service = new ShiftService();
            LoadData();

            ResourceService R_service = new ResourceService();
            List<MachineVO> m_list = R_service.GetMachineAll();
            ComboUtil.ComboBinding(cboMachine, m_list, "m_id", "m_name");

            CommonCodeService C_service = new CommonCodeService();


            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            var shift_code = (from shift in c_list
                              where shift.common_type == "shift_code"
                              select shift).ToList();
            ComboUtil.ComboBinding(cboShift, shift_code, "common_value", "common_name");
        }

        private void LoadData()
        {
            DataTable dt = S_service.GetShiftAll();
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ShiftService S_service = new ShiftService();

            ShiftPop frm = new ShiftPop(ShiftPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                LoadData();
                SetBottomStatusLabel("등록 성공");
                MessageBox.Show("등록 성공");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShiftPop frm = new ShiftPop(ShiftPop.EditMode.Update, lblID.Text);
            if(frm.ShowDialog()==DialogResult.OK)
            {
                LoadData();
                SetBottomStatusLabel("수정 성공");
                MessageBox.Show("수정 성공");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
