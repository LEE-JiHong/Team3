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


        public enum EditMode { Input, Update };
        CommonCodeService service;
        List<CommonVO> list;

        public FactoryPop(EditMode editMode)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "공장정보 수정";
           

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "공장정보 추가";
            }
        }

        public FactoryPop(EditMode editMode ,string i)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "공장정보 수정";
                lblID.Text = i;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "공장정보 추가";
            }
        }
       

        private void FactoryPop_Load(object sender, EventArgs e)
        {
            service = new CommonCodeService();

            list = service.GetCommonCodeAll();
            {
                //시설군
                var mCode = (from item in list
                             where item.COMMON_TYPE == "facility_class_id"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cbofacilitiesGroup, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");
            }
            {
                var mCode = (from item in list
                             where item.COMMON_TYPE == "facility_type"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboDivFacility, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");

            }
        }
        ResourceService Fac_service = new ResourceService();
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            FactoryVO VO = new FactoryVO();
            if (this.Text == "공장정보 추가")
            {
                VO.FACTORY_GRADE = cbofacilitiesGroup.SelectedValue.ToString();

                // VO.FACTORY_PARENT = cboHigh.SelectedValue.ToString();
                VO.FACTORY_PARENT = cboHigh.Text;

                VO.FACTORY_NAME = txtNameFacility.Text;


                //VO.FACTORY_TYPE = cboDivFacility.SelectedValue.ToString();
                VO.FACTORY_TYPE = cboDivFacility.SelectedValue.ToString();

                //VO.COMPANY_ID = (int)cboCompany.SelectedValue;
                VO.COMPANY_ID = Convert.ToInt32(cboCompany.Text);

                //VO.FACTORY_YN = cboIsUsed.SelectedValue.ToString();
                VO.FACTORY_YN = cboIsUsed.Text;

                VO.FACTORY_UDATE = DateTime.Now.ToString();
                VO.FACTORY_UADMIN = txtModifier.Text;
                VO.FACTORY_CODE = txtCodeFacility.Text;
                VO.FACTORY_COMMENT = txtInfoFacility.Text;


                //bResult=Fac_service.InsertFactory(VO);
            }
        }
    }
}
