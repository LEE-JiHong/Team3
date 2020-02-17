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

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입출고일", "wh_udate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "번호", "wh_id", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "카테고리", "wh_category", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고", "factory_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목형태", "product_type", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주시리얼", "order_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수량", "wh_product_count", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "단가", "price_present", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "금액", "totalprice", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "비고", "wh_comment", true, 150);

            GridViewUtil.SetDoNotSort(dataGridView1);
        }

        
    }
}
