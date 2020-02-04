using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class OrderList : Team3.VerticalGridBaseForm
    {
        DataTable dt;

        public OrderList()
        {
            InitializeComponent();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            PurchasingService service = new PurchasingService();

            dt = service.GetOrderList();

            SetDataGrid();

            SetRowNumber();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "No.", "count", true, 30);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주번호", "order_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품업체", "company_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문상태", "common_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "order_pdate", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주량", "order_count", true, 78);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "입고량", "company_order_code", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출발량", "company_order_code", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소가능량", "order_count", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주일", "order_sdate", true, 78);
            dataGridView1.DataSource = dt;
        }

        private void SetRowNumber()
        {
            for (int count = 0; count <= (dataGridView1.Rows.Count - 1); count++)
            {
                dataGridView1.Rows[count].Cells[0].Value = string.Format((count + 1).ToString(), "0");
            }
        }
    }
}
