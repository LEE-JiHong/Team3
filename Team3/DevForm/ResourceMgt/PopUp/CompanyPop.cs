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
    public partial class CompanyPop : Team3.DialogForm
    {
        ResourceService R_service;
        CommonCodeService service;
        List<CommonVO> common_list;
        List<UserVO> u_list;
        EditMode mode;
        public enum EditMode { Input, Update };
        public CompanyPop(EditMode editMode)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "거래처 수정";

                mode = EditMode.Update;
            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
                this.Text = "거래처 추가";
            }
        }
        public CompanyPop(EditMode editMode,string i)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "거래처 수정";
                lblID.Text = i;
            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
                this.Text = "거래처 추가";
            }
        }

        private void CompanyPop_Load(object sender, EventArgs e)
        {
            service = new CommonCodeService();
            common_list = service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "vendor_type"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboCompanyType, mCode, "common_value", "common_name");
            }
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "user_flag"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboYN, mCode, "common_value", "common_name");
            }
            {
                R_service = new ResourceService();
                u_list = R_service.GetUserAll();
                
                ComboUtil.ComboBinding<UserVO>(cboUser, u_list, "user_id", "user_name");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CompanyVO VO = new CompanyVO();
            VO.company_code = txtCodeCompany.Text;
            VO.company_name = txtNameCompany.Text;
            VO.company_type = txtbtype.Text;
            VO.company_gtype = txtGtype.Text;
            VO.user_id = Convert.ToInt32(cboUser.SelectedValue);
            VO.company_email = txtEmail.Text;
            VO.company_phone = txtPhone.Text;
            VO.company_fax = txtFax.Text;
            VO.company_yn = cboYN.SelectedValue.ToString();
            VO.company_comment = txtComment.Text;
            VO.company_uadmin = txtAdmin.Text;
            VO.company_udate = txtUdate.Text;
            VO.company_cnum = txtCnum.Text;
            VO.company_ceo = txtCEO.Text;
            
        }
    }
}
