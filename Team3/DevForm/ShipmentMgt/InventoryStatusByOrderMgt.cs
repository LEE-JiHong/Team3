using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3.DevForm.NewFolder1
{
    public partial class InventoryStatusByOrder : Team3.VerticalGridBaseForm
    {
        public InventoryStatusByOrder()
        {
            InitializeComponent();
        }

        private void InventoryStatusByOrder_Load(object sender, EventArgs e)
        {
            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();

            List<FactoryDB_VO> _cboFromFac = (from item in f_list
                                               where item.facility_value == "FAC300"
                                               select item).ToList();
            ComboUtil.ComboBinding(cboFromFac, _cboFromFac, "factory_code", "factory_name", "선택");


            List<FactoryDB_VO> _cboToFac = (from item in f_list
                                               where item.facility_value == "FAC400"
                                               select item).ToList();
            ComboUtil.ComboBinding(cboToFac, _cboToFac, "factory_code", "factory_name", "선택");
        }
    }
}
