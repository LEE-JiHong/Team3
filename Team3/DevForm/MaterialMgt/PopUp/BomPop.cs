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
    public partial class BomPop : Team3.DialogForm
    {
        List<CommonVO> codelist;
        CommonCodeService common_service;
        BomService bom_service;
        ProductService product_service;
        public BomPop()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bom_service = new BomService();
                BomVO vo = new BomVO();

                vo.bom_id = Convert.ToInt32(txtNote.Text);
                vo.bom_parent_id = cboParentProduct.Text;
                vo.product_id = Convert.ToInt32(cboProduct.Text);
                vo.bom_use_count = Convert.ToInt32(txtUseCount.Text);
                vo.bom_sdate = dtpStartDate.Value.ToString();
                vo.bom_edate = dtpEndDate.Value.ToString();
                vo.bom_yn = cboIsUsed.Text;
                vo.plan_yn = cboRequiredPlan.Text;
                vo.bom_comment = txtNote.Text;
                vo.bom_uadmin = txtModifier.Text;
                vo.bom_udate = txtModifyDate.Text;


                bool bResult = bom_service.AddBom(vo);
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

        private void BomPop_Load(object sender, EventArgs e)
        {
            ComboBoxBinding();

        }

        private void ComboBoxBinding()
        {
            common_service = new CommonCodeService();
            bom_service = new BomService();
            codelist = common_service.GetCommonCodeAll();
            #region 사용여부cbo
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");

            ComboUtil.ComboBinding(cboRequiredPlan, _cboUseFlag, "common_value", "common_name");
            #endregion

            #region 품목cbo

            product_service = new ProductService();
            List<ProductVO> product_list = new List<ProductVO>();
            product_list = product_service.GetAllProducts();
            ComboUtil.ComboBinding(cboProduct, product_list, "product_id", "product_name", "선택");
            #endregion

            #region 상위품목cbo
            List<BomVO> bom_list = new List<BomVO>();
            bom_list = bom_service.GetBomAll();
            ComboUtil.ComboBinding(cboParentProduct, bom_list, "bom_id", "bom_name", "선택");
            


            #endregion
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

        }
    }
}
