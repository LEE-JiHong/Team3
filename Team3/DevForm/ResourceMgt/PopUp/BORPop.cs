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
    public partial class BORPop : Team3.DialogForm
    {
        CommonCodeService common_service;
        List<CommonVO> common_list;

        public enum EditMode { Input, Update };
        public BORPop(EditMode editMode)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "BOR정보 수정";


            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
            }
        }
        public BORPop(EditMode editMode,string i)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "BOR정보 수정";
                lblID.Text = i;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
            }
        }


        private void BORPop_Load(object sender, EventArgs e)
        {
            common_service = new CommonCodeService();
            common_list = common_service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "route"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboProcess, mCode, "COMMON_VALUE", "COMMON_NAME","미선택");
            }
            {
                {
                    //사용유무
                    var mCode = (from item in common_list
                                 where item.common_type == "user_flag2"
                                 select item).ToList();

                    ComboUtil.ComboBinding<CommonVO>(cboIsUsed, mCode, "COMMON_VALUE", "COMMON_NAME");
                }
            }
        }
    }
}
