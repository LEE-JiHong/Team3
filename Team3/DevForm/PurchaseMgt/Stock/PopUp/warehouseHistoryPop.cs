using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class warehouseHistoryPop : Team3.DialogForm
    {
        StockVO vo;

        public warehouseHistoryPop(StockVO vo)
        {
            InitializeComponent();
            this.vo = vo;
        }

        private void warehouseHistoryPop_Load(object sender, EventArgs e)
        {
            SetDataGrid();

            try
            {
                StockService service = new StockService();
                DataTable dt = service.GetMaterialHistory(vo);
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

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "HISTORY 번호", "wh_id", false, 110);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고번호", "w_id", false, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "제품번호", "product_id", false, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "Plan ID", "plan_id", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수량", "wh_product_count", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "수정일", "wh_udate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "잔량", "wh_comment", false, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "카테고리", "common_name", true, 150);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
