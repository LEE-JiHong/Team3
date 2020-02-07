using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;
using Team3.Service;

namespace Team3
{
    //State of Order's Operation 작업 지시 현황
    public partial class SOO : Team3.VerticalGridBaseForm
    {

        public SOO()
        {
            InitializeComponent();
        }
        ProcessService P_service = new ProcessService();
        private void SOO_Load(object sender, EventArgs e)
        {
            
            ResourceService R_service = new ResourceService();
            CommonCodeService C_service = new CommonCodeService();
            List<CommonVO> c_list = C_service.GetCommonCodeAll();
            {
                var list_c = (from item in c_list
                              where item.common_type == "create_work_order"
                              select item).ToList();

                ComboUtil.ComboBinding(cboStatus, list_c, "common_value", "common_name", "미선택");
            }
            {
                var R_list = (from item in R_service.GetFactoryAll()
                              where item.facility_class == "창고"
                              select item).ToList();
                ComboUtil.ComboBinding(cboFactory, R_list, "factory_id", "factory_name", "미선택");
            }
            {
                
               ComboUtil.ComboBinding(cboMachine, R_service.GetMachineAll(), "m_id", "m_name", "미선택");
            }
            dateTimePicker1.Value = Convert.ToDateTime("2020-01-28"); 
            dateTimePicker2.Value = Convert.ToDateTime("2020-03-28");
            DataTable dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            
            dataGridView1.DataSource = dt;
            GridViewUtil.SetDataGridView(dataGridView1);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = P_service.GetProductionPlanCheckHis(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
            dataGridView1.DataSource = dt;
        }
    }
}
