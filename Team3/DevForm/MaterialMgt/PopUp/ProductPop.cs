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
    //컨트롤 위치 맞추기
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
            //ComboBoxBinding();

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

            if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                product_service = new ProductService();
                ProductVO vo = new ProductVO();

                vo.product_id = Convert.ToInt32(txtProduct.Text);
                vo.product_name = txtProductName.Text;
                vo.product_unit = cboProductUnit.SelectedValue.ToString();
                vo.product_unit_count = txtUnitAmount.Text;
                vo.product_type = cboProductType.SelectedValue.ToString();
                vo.product_in_sector = cboInWH.Text.ToString();
                vo.product_out = cboOutWH.Text.ToString();
                vo.product_leadtime = txtLeadTime.Text;
                vo.product_lorder_count = Convert.ToInt32(txtLeastOrder.Text);
                vo.product_safety_count = Convert.ToInt32(txtSafetyAmount.Text);
                vo.product_admin = cboNameDirector.Text.ToString();
                vo.product_ordertype = cboOrderType.Text.ToString();
                vo.product_yn = cboIsUsed.SelectedValue.ToString();
                vo.product_supply_com = cboDeliveryCompany.Text.ToString();
                vo.product_demand_com = cboDemandCompany.Text.ToString();
                vo.product_uadmin = txtModifier.Text;
                vo.product_udate = txtModifyDate.Text;
                vo.product_comment = txtNote.Text;
                vo.product_itemcode = txtBarcode.Text;
                vo.product_code = txtProductCode.Text;
                vo.product_lsl = txtProductLsl.Text;
                vo.product_usl = txtProductUsl.Text;
                vo.product_meastype = txtMeasType.Text;


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
