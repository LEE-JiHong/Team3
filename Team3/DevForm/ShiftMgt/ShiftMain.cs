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
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "ID", "s_id", false, 60);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비코드", "m_code", true, 80);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비명", "m_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "Shift", "common_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시작시간", "shift_stime", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "완료시간", "shift_etime", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "적용시작일", "shift_sdate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "적용완료일", "shift_edate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "사용유무", "shift_yn", true);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //     ShiftService S_service = new ShiftService();
            LoadData();

            ResourceService R_service = new ResourceService();
            List<MachineVO> m_list = R_service.GetMachineAll();
            ComboUtil.ComboBinding(cboMachine, m_list, "m_id", "m_name", "미선택");

            CommonCodeService C_service = new CommonCodeService();


            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            var shift_code = (from shift in c_list
                              where shift.common_type == "shift_code"
                              select shift).ToList();
            ComboUtil.ComboBinding(cboShift, shift_code, "common_value", "common_name", "전체");
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
                SetBottomStatusLabel("Shift정보 등록성공");
                MessageBox.Show("Shift정보 등록성공");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
            {
                ShiftPop frm = new ShiftPop(ShiftPop.EditMode.Update, lblID.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SetBottomStatusLabel("Shift정보 수정성공");
                    MessageBox.Show("Shift정보 수정성공");
                }
            }
            else
            {
                SetBottomStatusLabel("선택된 정보가 없습니다");
                MessageBox.Show("선택된 정보가 없습니다");
                return;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            try
            {//(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " 를(을) 삭제하시겠습니까?
                DialogResult dr = MessageBox.Show("선택한 데이터를 지우시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {

                    bResult = S_service.DeleteShift(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

                    if (bResult)
                    {
                        LoadData();
                        SetBottomStatusLabel("Shift 삭제성공");
                        MessageBox.Show("Shift 삭제성공");
                    }
                    else if (!bResult)
                    {
                        SetBottomStatusLabel("Shift 삭제실패");
                        MessageBox.Show("Shift 삭제실패");
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                string str = err.Message;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = S_service.GetShiftAll();
            DataTable table = new DataTable();
            if (cboShift.Text == "전체" && cboMachine.Text == "미선택")
            {
                dataGridView1.DataSource = dt;
            }
            else if (cboShift.Text != "전체")
            {
                table = dt.AsEnumerable().Where(Row => Row.Field<string>("common_name") == cboShift.Text).CopyToDataTable();
                
                dataGridView1.DataSource = table;

            }

            else if (cboMachine.Text != "미선택")
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "m_name = '" + cboMachine.Text + "'";
                if (dv.Count > 0)
                {
                    table = dv.ToTable();
                    dataGridView1.DataSource = table;

                }
                else
                {
                    dataGridView1.DataSource = dt;
                }

            }
            if(cboShift.Text != "전체" &&cboMachine.Text != "미선택")
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "common_name = '" + cboShift.Text + "' and m_name = '" + cboMachine.Text + "'";
                if (dv.Count > 0)
                {
                    table = dv.ToTable();
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
