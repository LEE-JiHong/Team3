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
        DateTime today;
        public enum EditMode { Input, Update };

        public FacilitiesPop(EditMode editMode)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "설비군 수정";


            }
            if (editMode == EditMode.Input)
            {
                this.Text = "설비군 추가";
            }
        }
        public FacilitiesPop(EditMode editMode,string i)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "설비군 수정";
                lblID.Text = i;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "설비군 추가";
            }
        }


        private void FacilitiesPop_Load(object sender, EventArgs e)
        {
             today = DateTime.Now;
            service = new CommonCodeService();
            list = service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in list
                             where item.common_type == "user_flag2"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboYN, mCode, "common_value", "common_name");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string todayFormat = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
                MachineGradeVO VO = new MachineGradeVO();
                VO.mgrade_name = txtMgrade_name.Text;
                VO.mgrade_code = txtMgrade_code.Text;
                VO.mgrade_yn = cboYN.SelectedValue.ToString();
                VO.mgrade_udate = todayFormat;
                VO.mgrade_uadmin = txtMgrade_uadmin.Text;
                VO.mgrade_comment = txtMgrade_comment.Text;
                bool bResult = R_Service.InsertMachineGr(VO);
                if (bResult)
                    MessageBox.Show("등록성공");
                else if (!bResult)
                    MessageBox.Show("등록실패");
            }
            catch(Exception err)
            {
                string str = err.Message;
            }
        }
    }
}
