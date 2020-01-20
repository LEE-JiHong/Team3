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
        CommonCodeService service;
        List<CommonVO> list;
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
            service = new CommonCodeService();
            list = service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in list
                             where item.common_type == "user_flag2"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboIsUsed, mCode, "common_value", "common_name");
            }
        }
    }
}
