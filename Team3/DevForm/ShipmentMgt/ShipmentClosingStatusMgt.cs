using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3.DevForm.ShipmentMgt
{
    public partial class ShipmentClosingStatusMgt : Team3.VerticalGridBaseForm
    {
        public ShipmentClosingStatusMgt()
        {
            InitializeComponent();
        }

        private void ShipmentClosingStatusMgt_Load(object sender, EventArgs e)
        {
            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();



            #region 고객사cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCustomer, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 고객창고cbo
            List<FactoryDB_VO> _cboOutSector = (from item in f_list
                                                where item.facility_value == "FAC700"
                                                select item).ToList();
            ComboUtil.ComboBinding(cboCustomerWH, _cboOutSector, "factory_code", "factory_name", "선택");
            #endregion


        }
    }
}
