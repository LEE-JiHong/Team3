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
        DateTime today = DateTime.Now;
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
        public CompanyPop(EditMode editMode, string i)
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

            string udate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
            txtUdate.Text = udate;
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
            if (mode == EditMode.Update)
            {
                if (lblID.Text != "")
                {
                    CompanyDB_VO vo = R_service.GetCompanyByID(Convert.ToInt32(lblID.Text));

                    txtCodeCompany.Text = vo.company_code;
                    txtNameCompany.Text = vo.company_name;
                    cboCompanyType.Text = vo.company_type;
                    txtCEO.Text = vo.company_ceo;
                    txtCnum.Text = vo.company_cnum;
                    txtbtype.Text = vo.company_btype;
                    txtGtype.Text = vo.company_gtype;
                    cboUser.Text = vo.user_name;
                    txtEmail.Text = vo.company_email;
                    txtPhone.Text = vo.company_phone;
                    txtFax.Text = vo.company_fax;
                    cboYN.Text = vo.company_yn;
                    txtAdmin.Text = vo.company_uadmin;
                    txtUdate.Text = udate;
                    txtComment.Text = vo.company_comment;
                    txtOrder_code.Text = vo.company_order_code;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CompanyVO VO = new CompanyVO();

            VO.company_code = txtCodeCompany.Text;
            VO.company_name = txtNameCompany.Text;
            VO.company_type = cboCompanyType.SelectedValue.ToString();
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
            VO.company_btype = txtbtype.Text;

            bool bResult = false;
            if (mode == EditMode.Input)
            {
                bResult = R_service.InsertCompany(VO);
                if (bResult)
                {
                 //   MessageBox.Show("등록성공");
                    this.DialogResult = DialogResult.OK;

                }
                else if (!bResult)
                {
               //     MessageBox.Show("등록실패");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            if (mode == EditMode.Update)
            {
                VO.company_order_code = txtOrder_code.Text;
                VO.company_id = Convert.ToInt32(lblID.Text);
                bResult = R_service.UpdateCompany(VO);
                if (bResult)
                {
                //    MessageBox.Show("수정성공");
                    this.DialogResult = DialogResult.OK;

                }
                else if (!bResult)
                {
                //    MessageBox.Show("수정실패");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

        }
    }
}

