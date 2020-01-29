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

        private void ProductPlan_Load(object sender, EventArgs e)
        {
            InitComboBox();
        }

        private void InitComboBox()
        {
            OrderService service = new OrderService();
            List<string> list = service.GetPlanID();
            list.Insert(0, "전체");
            cboPlanID.DataSource = list;
        }
    }
}
