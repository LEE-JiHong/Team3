using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;

namespace Team3
{
    public partial class ProductPop : Team3.DialogForm
    {
        List<CommonVO> codelist;
        CommonCodeService common_service;
        public ProductPop()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductPop_Load(object sender, EventArgs e)
        {
            ComboBoxBinding();
           
        }

        private void ComboBoxBinding()
        {
            //TODO 메서드 하나로 모듈화
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            List<CommonVO> cboUnit = (from item in codelist
                                      where item.COMMON_TYPE == "item_unit"
                                      select item).ToList();

            ComboUtil.ComboBinding(cboProductUnit, cboUnit, "COMMON_VALUE", "COMMON_NAME", "선택");
            
            
            
            List<CommonVO> cboItemType = (from item in codelist
                                      where item.COMMON_TYPE == "item_type"
                                      select item).ToList();

            ComboUtil.ComboBinding(cboProductType, cboItemType, "COMMON_VALUE", "COMMON_NAME", "선택");
        }
    }
}
