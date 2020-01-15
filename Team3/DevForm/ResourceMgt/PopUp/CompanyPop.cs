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
        CommonCodeService service;
        List<CommonVO> common_list;
        public enum EditMode { Input, Update };
        public CompanyPop(EditMode editMode)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "거래처 수정";


            }
            if (editMode == EditMode.Input)
            {
                this.Text = "거래처 추가";
            }
        }
        public CompanyPop(EditMode editMode,string i)
        {
            InitializeComponent();
            if (editMode == EditMode.Update)
            {
                this.Text = "거래처 수정";
                lblID.Text = i;

            }
            if (editMode == EditMode.Input)
            {
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
                             where item.COMMON_TYPE == "vendor_type"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboTypeCompany, mCode, "COMMON_VALUE", "COMMON_NAME");
            }
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.COMMON_TYPE == "user_flag2"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboIsUsed, mCode, "COMMON_VALUE", "COMMON_NAME");
            }
        }
    }
}
