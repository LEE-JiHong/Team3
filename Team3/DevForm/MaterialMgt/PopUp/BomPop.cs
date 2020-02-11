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


        public enum EditMode { Insert, Update }     //추가,수정 모드
        EditMode edit = EditMode.Insert;
        public BomVO vo;
        public BomVO VO
        {
            get { return vo; }
            set { vo = value; }
        }



        public BomPop(EditMode edit, BomVO vo = null)
        {
            InitializeComponent();
            if (edit == EditMode.Insert)
            {
                this.Text = "BOM 등록";
                this.edit = EditMode.Insert;
            }
            else if (edit == EditMode.Update)
            {
                this.Text = "BOM 수정";
                this.edit = EditMode.Update;
                this.vo = vo;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == EditMode.Insert)        //신규등록
            {


                if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bom_service = new BomService();
                    BomVO vo = new BomVO();

                    if (cboParentProduct.SelectedIndex == 0)
                    {
                        vo.bom_parent_id = null;
                    }
                    else
                    {
                        vo.bom_parent_id = cboParentProduct.SelectedValue.ToString();
                    }

                    vo.product_id = Convert.ToInt32(cboProduct.SelectedValue);
                    vo.bom_use_count = Convert.ToInt32(txtUseCount.Text.Trim());
                    vo.bom_sdate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                    vo.bom_edate = dtpEndDate.Value.ToString("yyyy-MM-dd");
                    vo.bom_yn = cboIsUsed.SelectedValue.ToString();
                    vo.plan_yn = cboRequiredPlan.SelectedValue.ToString();
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
            else if (edit == EditMode.Update)       //수정
            {

                if (MessageBox.Show("수정하시겠습니까?", "품목수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bom_service = new BomService();
                    BomVO vo = new BomVO();


                    if (cboParentProduct.SelectedIndex == 0)
                    {
                        vo.bom_parent_id = null;
                    }
                    else
                    {
                        vo.bom_parent_id = (cboParentProduct.SelectedValue == null) ? "" : cboParentProduct.SelectedValue.ToString();
                    }
                    vo.bom_id = this.vo.bom_id;
                    vo.product_id = Convert.ToInt32(cboProduct.SelectedValue);
                    vo.bom_use_count = Convert.ToInt32(txtUseCount.Text.Trim());
                    vo.bom_sdate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                    vo.bom_edate = dtpEndDate.Value.ToString("yyyy-MM-dd");
                    vo.bom_yn = cboIsUsed.SelectedValue.ToString();
                    vo.plan_yn = cboRequiredPlan.SelectedValue.ToString();
                    vo.bom_comment = txtNote.Text;
                    vo.bom_uadmin = txtModifier.Text;
                    vo.bom_udate = txtModifyDate.Text;

                    bool bResult = bom_service.UpdateBOM(vo);
                    if (bResult)
                    {
                        MessageBox.Show("수정성공");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("수정실패 , 다시시도 하세요");
                        return;
                    }
                }
            }
        }

        private void BomPop_Load(object sender, EventArgs e)
        {
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            ComboBoxBinding();

            if (edit == EditMode.Update)        //수정모드일때 vo를 받아와서 매핑
            {

                IsNullCbo2(vo.product_id, cboProduct);
                IsNullCbo2(Convert.ToInt32(vo.bom_parent_id), cboParentProduct);
                IsNullCbo(vo.bom_yn, cboIsUsed);
                IsNullCbo(vo.plan_yn, cboRequiredPlan);

                txtUseCount.Text = vo.bom_use_count.ToString();
                txtModifier.Text = vo.bom_uadmin;
                txtModifyDate.Text = vo.bom_udate;
                txtNote.Text = vo.bom_comment;
                dtpEndDate.Value = Convert.ToDateTime(vo.bom_edate);
                dtpStartDate.Value = Convert.ToDateTime(vo.bom_sdate);
            }

        }

        private void IsNullCbo2(int vo, ComboBox cbo)
        {
            cbo.SelectedValue = vo;
        }   //cbo.SelectedValue null처리(int)

        private void IsNullCbo(string vo, ComboBox cbo)
        {
            if (vo == null || vo == "")
            {
                cbo.SelectedIndex = 0;
            }
            else
            {
                cbo.SelectedValue = vo;
            }
        }   //cbo.SelectedValue null처리(string)

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
            ComboUtil.ComboBinding(cboParentProduct, bom_list, "product_id", "bom_name", "-");



            #endregion
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {



        }
    }
}
