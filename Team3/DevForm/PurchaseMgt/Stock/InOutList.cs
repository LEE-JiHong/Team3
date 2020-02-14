using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class InOutList : VerticalGridBaseForm
    {
        public InOutList()
        {
            InitializeComponent();
        }

        private void InOutList_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StockService service = new StockService();
                DataTable dt = service.GetInOutHistory();
                SetDataGrid();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }


        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);

            dataGridView1.AutoGenerateColumns = false;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "No.", "wh_id", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고코드", "pro_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고", "w_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "order_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목유형", "wh_product_count", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "wh_uadmin", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "wh_udate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "wh_comment", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "wh_category", true, 150);

            GridViewUtil.SetDoNotSort(dataGridView1);
        }

        
    }
}
