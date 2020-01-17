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
    public partial class FactoryPop : DialogForm
    {

        List<CompanyVO> Company_list;
        public enum EditMode { Input, Update };
        CommonCodeService service;
        List<CommonVO> Common_list;

        public FactoryPop(EditMode editMode)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "공장정보 수정";
                txtModifyTime.ReadOnly = true;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "공장정보 추가";
                txtModifyTime.ReadOnly = true;
            }
        }

        public FactoryPop(EditMode editMode, string i)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                txtModifyTime.ReadOnly = true;
                this.Text = "공장정보 수정";
                lblID.Text = i;



            }
            if (editMode == EditMode.Input)
            {
                txtModifyTime.ReadOnly = true;
                this.Text = "공장정보 추가";
            }
        }

        public List<CommonVO> Combo(string s)
        {
            var mCode = (from item in Common_list
                         where item.COMMON_TYPE == s
                         select item).ToList();
            return mCode;
        }
        ResourceService R_service = new ResourceService();
        private void FactoryPop_Load(object sender, EventArgs e)
        {
            {
                //콤보박스 업체 바인딩
                R_service = new ResourceService();
                Company_list = R_service.GetCompanyAll();
                var C_Code = (from R_Item in Company_list
                              select R_Item).ToList();

                ComboUtil.ComboBinding<CompanyVO>(cboCompany, C_Code, "COMPANY_ID", "COMPANY_NAME", "미선택");
            }

            service = new CommonCodeService();

            Common_list = service.GetCommonCodeAll();

            ComboUtil.ComboBinding<CommonVO>(cbofacilitiesGroup, Combo("facility_class_id"), "COMMON_VALUE", "COMMON_NAME", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboDivFacility, Combo("facility_type"), "COMMON_VALUE", "COMMON_NAME", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboIsUsed, Combo("user_flag2"), "COMMON_VALUE", "COMMON_NAME");

            {
                if (this.Text == "공장정보 수정")
                {

                    FactoryVO VO = R_service.GetFactoryByID(Convert.ToInt32(lblID.Text));
                    txtCodeFacility.Text = VO.FACTORY_CODE;
                    txtInfoFacility.Text = VO.FACTORY_COMMENT;
                    txtModifier.Text = VO.FACTORY_UADMIN;
                    txtModifyTime.Text = DateTime.Now.ToString();
                    txtNameFacility.Text = VO.FACTORY_NAME;
                    cboCompany.Text = VO.COMPANY_ID.ToString();
                    cboDivFacility.Text = VO.FACTORY_TYPE;
                    cboHigh.Text = VO.FACTORY_PARENT;
                    cboIsUsed.Text = VO.FACTORY_YN;

                }
            }
        }
        ResourceService Fac_service = new ResourceService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboCompany.SelectedIndex == 0)
            {
                MessageBox.Show("업체를 선택해주세요");
                this.DialogResult = DialogResult.None;
                return;
            }
            bool bResult = false;
            FactoryVO VO = new FactoryVO();
            if (this.Text == "공장정보 추가")
            {
                VO.FACTORY_GRADE = cbofacilitiesGroup.SelectedValue.ToString();
                VO.FACTORY_PARENT = cboHigh.SelectedValue.ToString();
                //VO.FACTORY_PARENT = cboHigh.Text;
                VO.FACTORY_NAME = txtNameFacility.Text;
                VO.FACTORY_TYPE = cboDivFacility.SelectedValue.ToString();
                VO.COMPANY_ID = (int)cboCompany.SelectedValue;
                VO.FACTORY_YN = cboIsUsed.SelectedValue.ToString();
                VO.FACTORY_UDATE = DateTime.Now.ToString().Substring(0, 10);
                VO.FACTORY_UADMIN = txtModifier.Text;
                VO.FACTORY_CODE = txtCodeFacility.Text;
                VO.FACTORY_COMMENT = txtInfoFacility.Text;
                bResult = Fac_service.InsertFactory(VO);
            }
        }



        private void cbofacilitiesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbofacilitiesGroup.SelectedIndex == 3) //창고
            {
                List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                var High = (from H_Item in F_list
                            where H_Item.FACILITY_CLASS != "창고"
                            select H_Item).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboHigh, High, "FACTORY_ID", "FACTORY_NAME");
            }
            else if (cbofacilitiesGroup.SelectedIndex == 2) //공장
            {
                List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                var High = (from H_Item in F_list
                            where H_Item.FACILITY_CLASS == "회사"
                            select H_Item).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboHigh, High, "FACTORY_ID", "FACTORY_NAME");
            }
            else
            {

            }
        }
    }
}
