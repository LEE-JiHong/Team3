using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;


namespace Team3
{
    public partial class FactoryPop : DialogForm
    {
        List<CommonVO> list;
        public FactoryPop()
        {
            InitializeComponent();
        }

        private void FactoryPop_Load(object sender, EventArgs e)
        {
            CommonCodeService service = new CommonCodeService();
            list=service.GetCommonCodeAll();
      //      List<CommonVO> mCode =(from item in list
      //                             where item.)
      //ComboUtil.ComboBinding<CommonVO>(cbofacilitiesGroup
        }
    }
}
