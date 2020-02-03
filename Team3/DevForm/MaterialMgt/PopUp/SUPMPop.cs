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
    //영업단가관리
    public partial class SUPMPop : Team3.DialogForm
    {

        PriceService price_service;
        public enum EditMode { Insert, Update }
        EditMode edit = EditMode.Insert;
        public PriceInfoVO vo;
        public PriceInfoVO VO
        {
            get { return vo; }
            set { vo = value; }
        }

        public List<PriceInfoVO> list;
        public SUPMPop(EditMode edit, List<PriceInfoVO> list = null, PriceInfoVO vo = null)
        {
            InitializeComponent();
            if (edit == EditMode.Insert)
            {
                this.Text = "영업 단가 등록";
                this.edit = EditMode.Insert;
                this.list = list;
            }
            else if (edit == EditMode.Update)
            {
                this.Text = "영업 단가 수정";
                this.edit = EditMode.Update;
                this.vo = vo;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == EditMode.Insert)
            {


                if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    price_service = new PriceService();
                    PriceInfoVO vo = new PriceInfoVO();

                    vo.product_id = Convert.ToInt32(cboProduct.SelectedValue);
                    vo.company_id = Convert.ToInt32(cboCompany.SelectedValue);
                    vo.price_present = Convert.ToDecimal(txtCurrentPrice.Text);
                    vo.price_past = Convert.ToDecimal(txtBeforePrice.Text);
                    vo.price_sdate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                    vo.price_edate = txtEndDate.Text;
                    vo.price_udate = txtModifyDate.Text;
                    vo.price_uadmin = txtModifier.Text;
                    vo.price_yn = cboIsUsed.SelectedValue.ToString();
                    vo.price_comment = txtNote.Text;

                    bool bResult = price_service.AddPriceInfo(vo);
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
            else if (edit == EditMode.Update)
            {

                if (MessageBox.Show("수정하시겠습니까?", "자재 단가 수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    price_service = new PriceService();
                    PriceInfoVO vo = new PriceInfoVO();


                    vo.price_id = this.vo.price_id;
                    vo.product_id = Convert.ToInt32(cboProduct.SelectedValue);
                    vo.company_id = Convert.ToInt32(cboCompany.SelectedValue);
                    vo.price_present = Convert.ToDecimal(txtBeforePrice.Text);
                    vo.price_past = Convert.ToDecimal(txtCurrentPrice.Text);
                    vo.price_sdate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                    vo.price_edate = txtEndDate.Text;
                    vo.price_udate = txtModifyDate.Text;
                    vo.price_uadmin = txtModifier.Text;
                    vo.price_yn = cboIsUsed.SelectedValue.ToString();
                    vo.price_comment = txtNote.Text;



                    bool bResult = price_service.UpdatePriceInfo(vo);
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

        private void SUPMPop_Load(object sender, EventArgs e)
        {
            CboBinding();
            SetUpdateLoad();
        }

        private void SetUpdateLoad()
        {
            if (edit == EditMode.Update)
            {
                cboCompany.SelectedValue = vo.company_id;
                cboProduct.SelectedValue = vo.product_id;
                cboIsUsed.SelectedValue = vo.price_yn;
                txtBeforePrice.Text =  vo.price_past.ToString();
                txtCurrentPrice.Text = vo.price_present.ToString();
                dtpStartDate.Value = Convert.ToDateTime(vo.price_sdate);
                txtEndDate.Text = vo.price_edate;
                txtModifyDate.Text = vo.price_udate;
                //txt수정자
                txtNote.Text = vo.price_comment;

                txtModifyDate.Enabled = false;
                txtEndDate.Enabled = false;
            }
        }

        private void CboBinding()
        {
            OrderService order_service = new OrderService();
            ProductService product_service = new ProductService();
            CommonCodeService common_service = new CommonCodeService();
            #region 발주업체cbo
            List<CompanyVO> company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_id", "company_name", "선택");
            #endregion

            #region 품목cbo

            product_service = new ProductService();
            List<ProductVO> product_list = new List<ProductVO>();
            product_list = product_service.GetAllProducts();
            ComboUtil.ComboBinding(cboProduct, product_list, "product_id", "product_name", "선택");
            #endregion

            #region 사용여부
            List<CommonVO> codelist = common_service.GetCommonCodeAll();
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");
            #endregion
            

        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                if (edit == EditMode.Insert)
                {

                    List<PriceInfoVO> p_list = (from item in list
                                                where item.product_id == Convert.ToInt32(cboProduct.SelectedValue) && item.price_edate == "9999-12-31"
                                                select item).ToList();
                    if (p_list.Count > 0)
                    {
                        txtBeforePrice.Text = p_list[0].price_present.ToString();
                        cboCompany.SelectedValue = p_list[0].company_id;
                        txtEndDate.Text = p_list[0].price_edate;
                        txtNote.Text = p_list[0].price_comment;
                        txtModifyDate.Text = p_list[0].price_udate;
                        txtModifier.Text = p_list[0].price_uadmin;
                        cboIsUsed.SelectedValue = p_list[0].price_yn;

                    }
                    else
                    {
                        txtBeforePrice.Text = "";
                    }

                }

            }

        }
    }
}
