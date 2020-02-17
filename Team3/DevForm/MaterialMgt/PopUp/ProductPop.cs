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
    //TODO 발주방식 콤보박스로 바꾸기
    public partial class ProductPop : Team3.DialogForm
    {
        public enum EditMode { Insert, Update }
        EditMode edit = EditMode.Insert;
        public ProductVO vo;
        public ProductVO VO
        {
            get { return vo; }
            set { vo = value; }
        }

        List<CommonVO> codelist;
        CommonCodeService common_service;
        ProductService product_service;
        public ProductPop(EditMode edit, ProductVO vo = null)
        {
            InitializeComponent();
            if (edit == EditMode.Insert)
            {
                this.Text = "품목 등록";
                this.edit = EditMode.Insert;
            }
            else if (edit == EditMode.Update)
            {
                this.Text = "품목 수정";
                this.edit = EditMode.Update;
                this.vo = vo;             

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductPop_Load(object sender, EventArgs e)
        {
            ComboBoxBinding();

            if (edit == EditMode.Update)
            {

                IsNullCbo(vo.product_insector_value, cboInSector);
                IsNullCbo(vo.product_outsector_value, cboOutSector);
                IsNullCbo(vo.product_yn, cboIsUsed);
                IsNullCbo(vo.product_demandcom_value, cboDemandCompany);
                IsNullCbo(vo.product_supplycom_value, cboSupplyCompany);
                IsNullCbo(vo.product_admin_value, cboAdmin);
                IsNullCbo(vo.product_productunit_value, cboProductUnit);
                IsNullCbo(vo.product_ordertype_value, cboOrderType);
                IsNullCbo(vo.product_type_value, cboProductType);
                IsNullCbo(vo.product_meastypevalue, cboMeasType);
                

                txtProductName.Text = vo.product_name;
                txtProduct.Text = vo.product_codename;
                txtLeadTime.Text = vo.product_leadtime;
                txtUadmin.Text = vo.product_uadmin;
                txtProductLsl.Text = vo.product_lsl;
                txtItemCode.Text = vo.product_itemcode;
                txtLeastOrder.Text = vo.product_lorder_count.ToString();
                txtUdate.Text = vo.product_udate;
                txtProductUsl.Text = vo.product_usl;
                txtProductCode.Text = vo.product_code;
                txtComment.Text = vo.product_comment;
               
                txtUnitAmount.Text = vo.product_unit_count;
                txtSafetyAmount.Text = vo.product_safety_count.ToString();
            }

        }

        private void IsNullCbo(string vo, ComboBox cbo)
        {
            if (vo == null || vo =="")
            {
                cbo.SelectedIndex = 0;
            }
            else
            {
                cbo.SelectedValue = vo;
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

            List<CommonVO> _commonmeastype = (from item in codelist
                                       where item.common_type == "meastype"
                                       select item).ToList();
            ComboUtil.ComboBinding(cboMeasType, _commonmeastype, "common_value", "common_name", "선택");

            #region 담당자cbo

            ComboUtil.ComboBinding(cboAdmin, user_list, "user_id", "user_name", "선택");
            #endregion

            #region 입고창고cbo
            f_list = resource_service.GetFactoryAll();
            List<FactoryDB_VO> _cboInSector = (from item in f_list
                                               where item.facility_value == "FAC200" || item.facility_value=="FAC400"
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
            company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboSupplyCompany, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 발주업체cbo
            company_list = order_service.GetCompanyAll("CUSTOMER");
            ComboUtil.ComboBinding(cboDemandCompany, company_list, "company_code", "company_name", "선택");

            List<UserVO> user_vo = new List<UserVO>();
            #endregion
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == EditMode.Insert)
            {
                if (MessageBox.Show("등록하시겠습니까?", "신규등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    product_service = new ProductService();
                    ProductVO vo = new ProductVO();



                    vo.product_name = txtProductName.Text;
                    vo.product_unit = (cboProductUnit.SelectedValue == null) ? "" : cboProductUnit.SelectedValue.ToString();
                    vo.product_unit_count = txtUnitAmount.Text;
                    vo.product_type = (cboProductType.SelectedValue == null) ? "" : cboProductType.SelectedValue.ToString();
                    vo.product_in_sector = (cboInSector.SelectedValue == null) ? "" : cboInSector.SelectedValue.ToString();
                    vo.product_out = (cboOutSector.SelectedValue == null) ? "" : cboOutSector.SelectedValue.ToString();
                    vo.product_leadtime = txtLeadTime.Text;
                    vo.product_lorder_count = Convert.ToInt32(txtLeastOrder.Text);
                    vo.product_safety_count = Convert.ToInt32(txtSafetyAmount.Text);
                    vo.product_admin = (cboAdmin.SelectedValue == null) ? "" : cboAdmin.SelectedValue.ToString();
                    vo.product_ordertype = (cboOrderType.SelectedValue == null) ? "" : cboOrderType.SelectedValue.ToString();
                    vo.product_yn = (cboIsUsed.SelectedValue == null) ? "" : cboIsUsed.SelectedValue.ToString();
                    vo.product_supply_com = (cboSupplyCompany.SelectedValue == null) ? "" : cboSupplyCompany.SelectedValue.ToString();
                    vo.product_demand_com = (cboDemandCompany.SelectedValue == null) ? "" : cboDemandCompany.SelectedValue.ToString();
                    vo.product_uadmin = txtUadmin.Text;
                    vo.product_udate = txtUdate.Text;
                    vo.product_comment = txtComment.Text;
                    vo.product_itemcode = txtItemCode.Text;
                    vo.product_code = txtProductCode.Text;
                    vo.product_lsl = txtProductLsl.Text;
                    vo.product_usl = txtProductUsl.Text;
                    vo.product_meastype = cboMeasType.SelectedValue.ToString();
                    vo.product_codename = txtProduct.Text;

                    foreach (var item in panel2.Controls)
                    {
                        if (item is ComboBox)
                        {
                            if (((ComboBox)item).SelectedIndex == 0)
                            {
                                ((ComboBox)item).Text = "";
                            }
                        }
                    }



                    bool bResult = product_service.AddProduct(vo);
                    if (bResult)
                    {
                       

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
                if (MessageBox.Show("수정하시겠습니까?", "품목수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    product_service = new ProductService();
                    ProductVO vo = new ProductVO();

                    vo.product_id = this.vo.product_id;
                    vo.product_name = txtProductName.Text;
                    vo.product_unit = (cboProductUnit.SelectedValue == null) ? "" : cboProductUnit.SelectedValue.ToString();
                    vo.product_unit_count = txtUnitAmount.Text;
                    vo.product_type = (cboProductType.SelectedValue == null) ? "" : cboProductType.SelectedValue.ToString();
                    vo.product_in_sector = (cboInSector.SelectedValue == null) ? "" : cboInSector.SelectedValue.ToString();
                    vo.product_out = (cboOutSector.SelectedValue == null) ? "" : cboOutSector.SelectedValue.ToString();
                    vo.product_leadtime = txtLeadTime.Text;
                    vo.product_lorder_count = Convert.ToInt32(txtLeastOrder.Text);
                    vo.product_safety_count = Convert.ToInt32(txtSafetyAmount.Text);
                    vo.product_admin = (cboAdmin.SelectedValue == null) ? "" : cboAdmin.SelectedValue.ToString();
                    vo.product_ordertype = (cboOrderType.SelectedValue == null) ? "" : cboOrderType.SelectedValue.ToString();
                    vo.product_yn = (cboIsUsed.SelectedValue == null) ? "" : cboIsUsed.SelectedValue.ToString();
                    vo.product_supply_com = (cboSupplyCompany.SelectedValue == null) ? "" : cboSupplyCompany.SelectedValue.ToString();
                    vo.product_demand_com = (cboDemandCompany.SelectedValue == null) ? "" : cboDemandCompany.SelectedValue.ToString();
                    vo.product_uadmin = txtUadmin.Text;
                    vo.product_udate = txtUdate.Text;
                    vo.product_comment = txtComment.Text;
                    vo.product_itemcode = txtItemCode.Text;
                    vo.product_code = txtProductCode.Text;
                    vo.product_lsl = txtProductLsl.Text;
                    vo.product_usl = txtProductUsl.Text;
                    vo.product_meastype = (cboMeasType.SelectedValue==null)?"": cboMeasType.SelectedValue.ToString();
                    vo.product_codename = txtProduct.Text;

                    bool bResult = product_service.UpdateProduct(vo);
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
    }
}
