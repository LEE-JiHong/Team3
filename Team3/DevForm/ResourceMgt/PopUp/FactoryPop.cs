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
        DateTime today = DateTime.Now;


        FactoryVO VO;
        List<CompanyVO> Company_list;

        CommonCodeService service;
        List<CommonVO> Common_list;
        EditMode mode;

        public enum EditMode { Input, Update };


        public FactoryPop(EditMode editMode)
        {
            InitializeComponent();

            mode = editMode;

            if (editMode == EditMode.Update)
            {
                this.Text = "공장정보 수정";
                txtUdate.ReadOnly = true;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "공장정보 추가";
                txtUdate.ReadOnly = true;
            }
        }

        public FactoryPop(EditMode editMode, string i)
        {

            mode = editMode;
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                txtUdate.ReadOnly = true;
                this.Text = "공장정보 수정";
                lblID.Text = i;



            }
            if (editMode == EditMode.Input)
            {
                txtUdate.ReadOnly = true;
                this.Text = "공장정보 추가";
            }
        }

        /// <summary>
        /// 공통코드 LINQ
        /// </summary>
        public List<CommonVO> Combo(string s)
        {
            var mCode = (from item in Common_list
                         where item.common_type == s
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

                ComboUtil.ComboBinding<CompanyVO>(cboCompany, C_Code, "company_id", "company_name", "미선택");
            }

            service = new CommonCodeService();

            Common_list = service.GetCommonCodeAll();

            ComboUtil.ComboBinding<CommonVO>(cboFactoryGrade, Combo("facility_class_id"), "common_value", "common_name", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboTypeFactory, Combo("facility_type"), "common_value", "common_name", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboYN, Combo("user_flag2"), "common_value", "common_name");

            {

                if (mode == EditMode.Update)
                {

                    VO = R_service.GetFactoryByID(Convert.ToInt32(lblID.Text));
                    string Comapany_Name = (VO.company_name == null) ? "" : VO.company_name.ToString();
                    txtCodeFactory.Text = VO.factory_code;
                    txtComment.Text = VO.factory_comment;
                    txtUadmin.Text = VO.factory_uadmin;
                    txtUdate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
                    txtNameFactory.Text = VO.factory_name;
                    cboCompany.Text = Comapany_Name;
                    cboTypeFactory.Text = VO.factory_type;
                    txtpr.Text = VO.factory_parent;
                    cboYN.Text = VO.factory_yn;
                    cboFactoryGrade.Text = VO.factory_grade;

                }
            }
        }
        ResourceService Fac_service = new ResourceService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cboCompany.SelectedIndex == 0)
            //{
            //    MessageBox.Show("업체를 선택해주세요");
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}
            bool bResult = false;
            FactoryVO VO = new FactoryVO();
            VO.factory_grade = cboFactoryGrade.SelectedValue.ToString();

            if (cboParent.Text == "미선택" || cboParent.Text == "")
                cboParent.SelectedValue = "";
            else
                VO.factory_parent = cboParent.SelectedValue.ToString();
            VO.factory_name = txtNameFactory.Text;
            VO.factory_type = cboTypeFactory.SelectedValue.ToString();
            VO.company_id = (int)cboCompany.SelectedValue;
            VO.factory_yn = cboYN.SelectedValue.ToString();
            VO.factory_udate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
            VO.factory_uadmin = txtUadmin.Text;
            VO.factory_code = txtCodeFactory.Text;
            VO.factory_comment = txtComment.Text;



            if (mode == EditMode.Input)
            {

                bResult = Fac_service.InsertFactory(VO);
                if (bResult)
                    MessageBox.Show("등록성공");
                else if (!bResult)
                {
                    MessageBox.Show("등록실패");
                    return;
                }
            }
            if (mode == EditMode.Update)
            {

                VO.factory_id = Convert.ToInt32(lblID.Text);
                bResult = Fac_service.UpdateFactory(VO);
                if (bResult)
                    MessageBox.Show("수정성공");
                else if (!bResult)
                {
                    MessageBox.Show("수정실패");
                    return;
                }
            }
        }

            private void cbofacilitiesGroup_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboFactoryGrade.SelectedIndex == 3) //창고
                {
                    List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                    var High = (from H_Item in F_list
                                where H_Item.facility_class != "창고"
                                select H_Item).ToList();
                    ComboUtil.ComboBinding<FactoryDB_VO>(cboParent, High, "factory_id", "factory_name");

                    if (mode == EditMode.Update)
                    {

                        cboParent.Text = txtpr.Text;
                    }
                }
                else if (cboFactoryGrade.SelectedIndex == 2) //공장
                {
                    List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                    var High = (from H_Item in F_list
                                where H_Item.facility_class == "회사"
                                select H_Item).ToList();
                    ComboUtil.ComboBinding<FactoryDB_VO>(cboParent, High, "factory_id", "factory_name");

                    if (mode == EditMode.Update)
                    {

                        cboParent.Text = txtpr.Text;
                    }
                }

                else if (cboFactoryGrade.SelectedIndex == 1)
                {
                    cboParent.Text = "";

                }
            }
        }
    }