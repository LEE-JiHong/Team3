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
        public enum EditMode { Insert, Update }
        string edit = string.Empty;
        public ProductVO vo;
        public ProductVO VO 
        {
            get { return vo; }
            set { vo = value; }
        }

        List<CommonVO> codelist;
        CommonCodeService common_service;
        ProductService product_service;
        public ProductPop(EditMode edit,  ProductVO vo = null)
        {
            InitializeComponent();
            if (edit == EditMode.Insert)
            {
                this.Text = "품목 등록";
                this.edit = "Insert";
            }
            else if (edit == EditMode.Update)
            {
                this.Text = "품목 수정";
                this.edit = "Update";
                this.vo = vo;
                //TODO 수정모드일때 발주방식 콤보박스?
                #region 수정모드일떄 Vo로 받아오는 방법
                /* txtProductName.Text = vo.product_name;
                      txtProductCode.Text = vo.product_code;
                      txtUadmin.Text = vo.product_uadmin;
                      txtLeadTime.Text = vo.product_leadtime;
                      txtLeastOrder.Text = vo.product_lorder_count.ToString();
                      txtProduct.Text = vo.product_codename;
                      cboProductType.Text = vo.product_type;
                      txtItemCode.Text = vo.product_itemcode;
                      txtProductLsl.Text = vo.product_lsl;
                      txtProductUsl.Text = vo.product_usl;
                      txtUnitAmount.Text = vo.product_unit_count;
                      cboInSector.Text = vo.product_in_sector;
                      cboOutSector.Text = vo.product_out;
                      cboAdmin.Text = vo.product_admin;
                      cboIsUsed.Text = vo.product_yn;
                      cboOrderType.Text = vo.product_type;
                      txtNote.Text = vo.product_comment;
                      cboDemandCompany.Text = vo.product_demand_com;
                      txtUdate.Text = vo.product_udate;
                      cboSupplyCompany.Text = vo.product_supply_com;
                      txtSafetyAmount.Text = vo.product_safety_count.ToString();
                      txtMeasType.Text = vo.product_meastype;*/
                #endregion
                txtProductName.Text = vo.product_name;
                txtProduct.Text = vo.product_codename;
                
                txtSafetyAmount.Text = vo.product_safety_count.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductPop_Load(object sender, EventArgs e)
        {
            Dictionary<string,string> dic = new Dictionary<string, string>();
            dic.Add("SP", "반제품");
            dic.Add("RM", "원자재");
            dic.Add("FP", "제품");
            ComboBoxBinding();
            if(edit == "Update")
            {
                var _key = dic.FirstOrDefault(x => x.Value == vo.product_type).Key;
                cboProductType.SelectedValue = _key;
              
            }

        }

        private void ComboBoxBinding()
        {
            //TODO 메서드 하나로 모듈화
            ProductService product_service = new ProductService();
            ResourceService resource_service = new ResourceService();
            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
           
        

            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();

            List<UserVO> user_list = product_service.GetUserAll();


            List<CommonVO> _cboUnit = (from item in codelist
                                      where item.common_type == "item_unit"
                                      select item).ToList();
            ComboUtil.ComboBinding(cboProductUnit, _cboUnit, "common_value", "common_name", "선택");

            
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");

          
            List<CommonVO> _commonlist = (from item in codelist
                                              where item.common_type == "item_type"
                                              select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _commonlist, "common_value", "common_name", "선택");

            #region 담당자cbo

            ComboUtil.ComboBinding(cboAdmin, user_list, "user_id", "user_name", "선택");
            #endregion

            #region 입고창고cbo
            f_list = resource_service.GetFactoryAll();
            List<FactoryDB_VO> _cboInSector = (from item in f_list
                                               where item.facility_value == "FAC200"
                                               select item).ToList();
            ComboUtil.ComboBinding(cboInSector, _cboInSector, "factory_code", "factory_name", "선택");
            #endregion

            #region 출고창고cbo
            List<FactoryDB_VO> _cboOutSector = (from item in f_list
                                                where item.facility_value == "FAC100"
                                                select item).ToList();
            ComboUtil.ComboBinding(cboOutSector, _cboOutSector, "factory_code", "factory_name", "선택");
            #endregion


            #region 발주방식cbo
            _commonlist = (from item in codelist
                           where item.common_type == "order_method"
                           select item).ToList();
            ComboUtil.ComboBinding(cboOrderType, _commonlist, "common_value", "common_name", "선택");
            #endregion

            #region 납품업체cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("customer");
            ComboUtil.ComboBinding(cboDemandCompany, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 발주업체cbo
            company_list = order_service.GetCompanyAll("cooperative");
            ComboUtil.ComboBinding(cboSupplyCompany, company_list, "company_code", "company_name", "선택");

            List<UserVO> user_vo = new List<UserVO>();
            #endregion



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == "Insert")
            {
                if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    product_service = new ProductService();
                    ProductVO vo = new ProductVO();


                    vo.product_name = txtProductName.Text;
                    vo.product_unit = cboProductUnit.Text.ToString();
                    vo.product_unit_count = txtUnitAmount.Text;
                    vo.product_type = cboProductType.SelectedValue.ToString();
                    vo.product_in_sector = cboInSector.Text.ToString();
                    vo.product_out = cboOutSector.Text.ToString();
                    vo.product_leadtime = txtLeadTime.Text;
                    vo.product_lorder_count = Convert.ToInt32(txtLeastOrder.Text);
                    vo.product_safety_count = Convert.ToInt32(txtSafetyAmount.Text);
                    vo.product_admin = cboAdmin.Text.ToString();
                    vo.product_ordertype = cboOrderType.Text.ToString();
                    vo.product_yn = cboIsUsed.SelectedValue.ToString();
                    vo.product_supply_com = cboSupplyCompany.Text.ToString();
                    vo.product_demand_com = cboDemandCompany.Text.ToString();
                    vo.product_uadmin = txtUadmin.Text;
                    vo.product_udate = txtUdate.Text;
                    vo.product_comment = txtNote.Text;
                    vo.product_itemcode = txtItemCode.Text;
                    vo.product_code = txtProductCode.Text;
                    vo.product_lsl = txtProductLsl.Text;
                    vo.product_usl = txtProductUsl.Text;
                    vo.product_meastype = txtMeasType.Text;
                    vo.product_codename = txtProduct.Text;

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
           else if(edit == "Update")
            {
                if (MessageBox.Show("수정하시겠습니까?", "품목수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    product_service = new ProductService();
                    ProductVO vo = new ProductVO();

                    vo.product_id = this.vo.product_id;
                    vo.product_name = txtProductName.Text;
                    vo.product_unit = cboProductUnit.Text.ToString();
                    vo.product_unit_count = txtUnitAmount.Text;
                    vo.product_type = cboProductType.Text.ToString();
                    vo.product_in_sector = cboInSector.Text.ToString();
                    vo.product_out = cboOutSector.Text.ToString();
                    vo.product_leadtime = txtLeadTime.Text;
                    vo.product_lorder_count = Convert.ToInt32(txtLeastOrder.Text);
                    vo.product_safety_count = Convert.ToInt32(txtSafetyAmount.Text);
                    vo.product_admin = cboAdmin.Text.ToString();
                    vo.product_ordertype = cboOrderType.Text.ToString();
                    vo.product_yn = cboIsUsed.Text.ToString();
                    vo.product_supply_com = cboSupplyCompany.Text.ToString();
                    vo.product_demand_com = cboDemandCompany.Text.ToString();
                    vo.product_uadmin = txtUadmin.Text;
                    vo.product_udate = txtUdate.Text;
                    vo.product_comment = txtNote.Text;
                    vo.product_itemcode = txtItemCode.Text;
                    vo.product_code = txtProductCode.Text;
                    vo.product_lsl = txtProductLsl.Text;
                    vo.product_usl = txtProductUsl.Text;
                    vo.product_meastype = txtMeasType.Text;
                    vo.product_codename = txtProduct.Text;

                    //bool bResult = product_service.UpdateProduct(vo);
                    //if (bResult)
                    //{
                    //    MessageBox.Show("수정성공");
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("수정실패 , 다시시도 하세요");
                    //    return;
                    //}
                }
            }


        }
    }
}
