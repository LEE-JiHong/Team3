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
    public partial class FacilitiesPop : Team3.DialogForm
    {
        ResourceService R_Service;
        CommonCodeService service;
        List<CommonVO> list;
        DateTime today = DateTime.Now;
        EditMode mode;
        public enum EditMode { Input, Update };

        public FacilitiesPop(EditMode editMode)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "설비군 수정";
                mode = EditMode.Update;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "설비군 추가";
                mode = EditMode.Input;
            }
        }
        public FacilitiesPop(EditMode editMode, MachineGradeVO VO)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "설비군 수정";
                lblID.Text = VO.mgrade_id.ToString();
                txtMgrade_name.Text = VO.mgrade_name;
                txtMgrade_code.Text = VO.mgrade_code;
                txtMgrade_uadmin.Text = VO.mgrade_uadmin;
                txtMgrade_udate.Text = txtMgrade_udate.Text;
                txtMgrade_comment.Text = VO.mgrade_comment;
                cboYN.Text = VO.mgrade_yn;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "설비군 추가";
                mode = EditMode.Input;
            }
        }
        


        private void FacilitiesPop_Load(object sender, EventArgs e)
        {
            
            string todayFormat = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
            txtMgrade_udate.Text = todayFormat;
            service = new CommonCodeService();
            list = service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in list
                             where item.common_type == "user_flag"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboYN, mCode, "common_value", "common_name");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResourceService R_Service = new ResourceService();
                MachineGradeVO VO = new MachineGradeVO();
                try
                {
                    VO.mgrade_name = txtMgrade_name.Text;
                    VO.mgrade_code = txtMgrade_code.Text;
                    VO.mgrade_yn = cboYN.SelectedValue.ToString();
                    VO.mgrade_udate = txtMgrade_udate.Text;
                    VO.mgrade_uadmin = txtMgrade_uadmin.Text;
                    VO.mgrade_comment = txtMgrade_comment.Text;

                    if (mode == EditMode.Input)
                    {
                        bool bResult = R_Service.InsertMachineGr(VO);
                        if (bResult)
                        {
                            MessageBox.Show("등록성공");
                            this.DialogResult = DialogResult.OK;

                        }
                        else if (!bResult)
                        {
                            MessageBox.Show("등록실패");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    else if (mode == EditMode.Update)
                    {
                        VO.mgrade_id = Convert.ToInt32(lblID.Text);
                        bool bResult = R_Service.UpdateMachineGr(VO);
                        if (bResult)
                        {
                            MessageBox.Show("수정성공");
                            this.DialogResult = DialogResult.OK;
                        }
                        else if (!bResult)
                        {
                            MessageBox.Show("수정실패");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                }
                catch (Exception err)
                {
                    string str = err.Message;
                }
            }
            catch(Exception err)
            {
                string str = err.Message;
            }
        }
    }
}
