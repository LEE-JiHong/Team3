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
    public partial class ShiftPop : Team3.DialogForm
    {

        DateTime today = DateTime.Now;
        public enum EditMode { Input, Update };
        EditMode mode;


        public ShiftPop(EditMode editMode)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
            }
        }
        public ShiftPop(EditMode editMode, string i)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                lblID.Text = i;
            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
            }
        }

        private void ShiftPop_Load(object sender, EventArgs e)
        {
            InitComboBind();
        }

        private void InitComboBind()
        {
            string todayFormat = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
            txtUdate.Text = todayFormat;
            ResourceService R_service = new ResourceService();
            List<MachineVO> m_list = R_service.GetMachineAll();
            ComboUtil.ComboBinding(cboM_code, m_list, "m_id", "m_code");

            CommonCodeService C_service = new CommonCodeService();
            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            var shift_code = (from shift in c_list
                              where shift.common_type == "shift_code"
                              select shift).ToList();
            ComboUtil.ComboBinding(cboShiftID, shift_code, "common_value", "common_name");

            var YN = (from shift in c_list
                      where shift.common_type == "user_flag"
                      select shift).ToList();
            ComboUtil.ComboBinding(cboYN, YN, "common_value", "common_name");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bResult = false;

            ShiftVO vo = new ShiftVO();
            ShiftService S_service = new ShiftService();
            vo.m_id = int.Parse(cboM_code.SelectedValue.ToString());
            vo.shift_id = cboShiftID.SelectedValue.ToString();
            vo.shift_stime = txtStime.Text;
            vo.shift_etime = txtEtime.Text;
            vo.shift_sdate = dtpSdate.Value.ToShortDateString();
            vo.shift_edate = dtpEdate.Value.ToShortDateString();
            vo.shift_udate = txtUdate.Text;
            vo.shift_uadmin = txtUadmin.Text;
            vo.shift_yn = cboYN.Text;
            vo.shift_comment = txtComment.Text;
            if (mode == EditMode.Input)
            {
                bResult = S_service.InsertShift(vo);
                this.DialogResult = DialogResult.OK;
                if (bResult)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (!bResult)
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }

            }
            if (mode == EditMode.Update)
            {
                vo.s_id = Convert.ToInt32(lblID.Text);
                bResult = S_service.UpdateShift(vo);
                if (bResult)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (!bResult)
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
        }
    }
}
