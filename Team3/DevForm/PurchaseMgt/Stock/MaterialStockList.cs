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
    public partial class MaterialStockList : VerticalGridBaseForm
    {
        public MaterialStockList()
        {
            InitializeComponent();
        }

        private void MaterialStockList_Load(object sender, EventArgs e)
        {
            //품목유형 콤보박스 바인딩
            StockService service = new StockService();

            List<CommonVO> productTypeList = new List<CommonVO>();

            try
            {
                productTypeList = service.GetProductType("item_type");
                ComboUtil.ComboBinding(cboProductType, productTypeList, "common_value", "common_name", "선택");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "No.", "count", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고코드", "factory_code", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "창고", "factory_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목타입", "product_type", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "w_count_present", true, 150);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회버튼
            try
            {
                StockService service = new StockService();
                DataTable dt = service.GetMaterialStockList();
                SetDataGrid();
                dataGridView1.DataSource = dt;
                SetRowNumber();

               // dataGridView1.Columns["w_count_present"].DefaultCellStyle.BackColor = Color.Red;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }


        private void btnHistory_Click(object sender, EventArgs e)
        {
            StockVO vo = new StockVO();
            vo.product_codename = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            vo.factory_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            warehouseHistoryPop frm = new warehouseHistoryPop(vo);
            frm.ShowDialog();
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
