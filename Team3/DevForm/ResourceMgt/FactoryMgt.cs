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
    public partial class FactoryMgt : Team3.VerticalGridBaseForm
    {
        ResourceService service = new ResourceService();
        List<CommonVO> common_list;
        List<FactoryDB_VO> list;
        public FactoryMgt()
        {
            InitializeComponent();
        }
        private void FactoryMgt_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            list = service.GetFactoryAll();
            dataGridView1.DataSource = list;

            CommonCodeService Common_service = new CommonCodeService();
            common_list = Common_service.GetCommonCodeAll();

            var mCode = (from item in common_list
                         where item.COMMON_TYPE == "facility_class_id"
                         select item).ToList();

            ComboUtil.ComboBinding<CommonVO>(cboSearchFacilityGroup, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Update);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
