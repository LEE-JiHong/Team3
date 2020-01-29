using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class ProductPlan : Team3.VerticalGridBaseForm
    {
        public ProductPlan()
        {
            InitializeComponent();
        }
        ProductionService service = new ProductionService();

        private void ProductPlan_Load(object sender, EventArgs e)
        {
            InitComboBox();

            DateTime today = DateTime.Now;

            string startDate = today.AddDays(-10).ToString("yyyyMMdd");
            string endDate = today.AddDays(20).ToString("yyyyMMdd");
             
           DataTable dt= service.GetProductPlan("20200121_P", startDate,endDate);
            dataGridView1.DataSource = dt;

        }

        private void InitComboBox()
        {
            OrderService service = new OrderService();
            List<string> list = service.GetPlanID();
            list.Insert(0, "전체");
            cboPlanID.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = service.GetProductPlan(cboPlanID.Text, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()) ;
            dataGridView1.DataSource = dt;
        }
    }
}
