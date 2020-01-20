﻿using System;
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

            ComboUtil.ComboBinding<CommonVO>(cboFactoryGrade, Combo("facility_class_id"), "COMMON_VALUE", "COMMON_NAME", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboTypeFactory, Combo("facility_type"), "COMMON_VALUE", "COMMON_NAME", "미선택");
            ComboUtil.ComboBinding<CommonVO>(cboYN, Combo("user_flag2"), "COMMON_VALUE", "COMMON_NAME");

            {

                if (mode == EditMode.Update)
                {

                    VO = R_service.GetFactoryByID(Convert.ToInt32(lblID.Text));
                  string Comapany_Name=  (VO.COMPANY_NAME == null) ? "" : VO.COMPANY_NAME.ToString();
                    txtCodeFactory.Text = VO.FACTORY_CODE;
                    txtComment.Text = VO.FACTORY_COMMENT;
                    txtUadmin.Text = VO.FACTORY_UADMIN;
                    txtUdate.Text = DateTime.Now.ToString();
                    txtNameFactory.Text = VO.FACTORY_NAME;
                    cboCompany.Text = Comapany_Name;
                    cboTypeFactory.Text = VO.FACTORY_TYPE;
                  txtpr.Text= VO.FACTORY_PARENT;
                    cboYN.Text = VO.FACTORY_YN;
                    cboFactoryGrade.Text = VO.FACTORY_GRADE;

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
            if (mode== EditMode.Input)
            {
                VO.FACTORY_GRADE = cboFactoryGrade.SelectedValue.ToString();
                
                if (cboParent.Text == "미선택"|| cboParent.Text=="")
                    cboParent.SelectedValue= "";
                VO.FACTORY_PARENT = cboParent.SelectedValue.ToString();
                //VO.FACTORY_PARENT = cboHigh.Text;
                VO.FACTORY_NAME = txtNameFactory.Text;
                VO.FACTORY_TYPE = cboTypeFactory.SelectedValue.ToString();
                VO.COMPANY_ID = (int)cboCompany.SelectedValue;
                VO.FACTORY_YN = cboYN.SelectedValue.ToString();
                VO.FACTORY_UDATE = DateTime.Now.ToString();
                VO.FACTORY_UADMIN = txtUadmin.Text;
                VO.FACTORY_CODE = txtCodeFactory.Text;
                VO.FACTORY_COMMENT = txtComment.Text;
                bResult = Fac_service.InsertFactory(VO);

            }
            if(mode==EditMode.Update)
            {
                VO.FACTORY_GRADE = cboFactoryGrade.SelectedValue.ToString();
                VO.FACTORY_PARENT = cboParent.SelectedValue.ToString();
                if (cboParent.Text == "미선택")
                    cboParent.SelectedValue = "";
                //VO.FACTORY_PARENT = cboHigh.Text;
                VO.FACTORY_NAME = txtNameFactory.Text;
                VO.FACTORY_TYPE = cboTypeFactory.SelectedValue.ToString();
                VO.COMPANY_ID = (int)cboCompany.SelectedValue;
                VO.FACTORY_YN = cboYN.SelectedValue.ToString();
                VO.FACTORY_UDATE = DateTime.Now.ToString();
                VO.FACTORY_UADMIN = txtUadmin.Text;
                VO.FACTORY_CODE = txtCodeFactory.Text;
                VO.FACTORY_COMMENT = txtComment.Text;
                VO.FACTORY_ID = Convert.ToInt32(lblID.Text);
                bResult = Fac_service.UpdateFactory(VO);

            }
        }

        private void cbofacilitiesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFactoryGrade.SelectedIndex == 3) //창고
            {
                List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                var High = (from H_Item in F_list
                            where H_Item.FACILITY_CLASS != "창고"
                            select H_Item).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboParent, High, "FACTORY_ID", "FACTORY_NAME");

                if (mode == EditMode.Update)
                {
                   
                    cboParent.Text = txtpr.Text;
                }
            }
            else if (cboFactoryGrade.SelectedIndex == 2) //공장
            {
                List<FactoryDB_VO> F_list = R_service.GetFactoryAll();
                var High = (from H_Item in F_list
                            where H_Item.FACILITY_CLASS == "회사"
                            select H_Item).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboParent, High, "FACTORY_ID", "FACTORY_NAME");
           
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
