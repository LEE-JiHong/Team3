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
        ProductService product_service;
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

            List<CommonVO> _cboUnit = (from item in codelist
                                      where item.COMMON_TYPE == "item_unit"
                                      select item).ToList();
            ComboUtil.ComboBinding(cboProductUnit, _cboUnit, "COMMON_VALUE", "COMMON_NAME", "선택");

            
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.COMMON_TYPE == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "COMMON_VALUE", "COMMON_NAME", "선택");

          
            List<CommonVO> _cboProductType = (from item in codelist
                                              where item.COMMON_TYPE == "item_type"
                                              select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _cboProductType, "COMMON_VALUE", "COMMON_NAME", "선택");
            //TODO : User목록 콤보바인딩
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("등록하시겠습니까?","신규등록",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductVO vo = new ProductVO();
         //       vo.product_name
         //       vo.product_name
         //       vo.product_unit
         //       vo.product_count
         //     vo.product_type
         //    vo.product_in_sector
         //        vo.product_out
         //vo.product_leadtime
         //   vo.product_lorder_count
         //   vo.product_safety_count
         // vo.product_admin
         //      vo.product_ordertype
         //       vo.product_yn
         //    vo.product_supply_com
         //  vo.product_demand_com
         //   vo.product_uadmin
         //   vo.product_udate
         //      vo.product_comment
         //    vo.product_count
         //       vo.product_itemcode
         //     vo.product_code
         //       vo.product_lsl
         //       vo.product_usl
         //    vo.product_meastype
                bool bResult = product_service.AddProduct(vo);
                if (bResult)
                {
                    MessageBox.Show("등록성공");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("등록실패 , 다시시도 하세요");
                    return;
                }
            }

            
        }
    }
}
