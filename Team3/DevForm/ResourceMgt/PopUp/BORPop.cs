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
        BORDB_VO vo;
        ResourceService R_survice;

        public enum EditMode { Input, Update };
        EditMode mode;
        public BORPop(EditMode editMode)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "BOR정보 수정";
                mode = EditMode.Update;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
                mode = EditMode.Input;
            }
        }
        public BORPop(EditMode editMode, string i, string route)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "BOR정보 수정";
                lblID.Text = i;
                lblRoute.Text = route;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
                mode = EditMode.Input;
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

                ComboUtil.ComboBinding<CommonVO>(cboRoute, mCode, "common_value", "common_name", "미선택");
            }
            {
                {
                    //사용유무
                    var mCode = (from item in common_list
                                 where item.common_type == "user_flag"
                                 select item).ToList();

                    ComboUtil.ComboBinding<CommonVO>(cboYN, mCode, "common_value", "common_name");
                }
            }

            if (mode == EditMode.Update)
            {
                R_survice = new ResourceService();
                vo = R_survice.GetBORByID(Convert.ToInt32(lblID.Text),lblRoute.Text);
                lblID.Text = vo.bor_id.ToString();

                cboP_Name.Text = vo.product_name;
                cboM_name.Text = vo.m_name;
                cboYN.Text = vo.bor_yn;
                cboRoute.Text = vo.common_name;
                txtComment.Text = vo.bor_comment;
                txtReadyTime.Text = vo.bor_readytime.ToString();
                txtTactTime.Text = vo.bor_tacktime.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
