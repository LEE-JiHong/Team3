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
        public FacilitiesPop()
        {
            InitializeComponent();
        }

        private void FacilitiesPop_Load(object sender, EventArgs e)
        {
            service = new CommonCodeService();
            list = service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in list
                             where item.COMMON_TYPE == "user_flag2"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboIsUsed, mCode, "COMMON_VALUE", "COMMON_NAME");
            }
        }
    }
}
