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

            StockService service = new StockService();
            try
            {
                //품목유형 콤보박스 바인딩
                List<CommonVO> productTypeList = new List<CommonVO>();
                productTypeList = service.GetProductType("item_type");
                ComboUtil.ComboBinding(cboProductType, productTypeList, "common_value", "common_name", "선택");

                List<FactoryComboVO> factoryList = new List<FactoryComboVO>();
                factoryList = service.GetFactory();
                ComboUtil.ComboBinding(cboFactory, factoryList, "factory_code", "factory_name", "선택");

            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetLoad();

            SetDataGrid();
            //조회버튼
            try
            {
                MaterialStockVO vo = new MaterialStockVO();

                if (txtProductCode.Text != "")
                {
                    vo.product_codename = txtProductCode.Text;
                }

                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }

                if (cboFactory.Text != "선택")
                {
                    vo.factory_code = cboFactory.SelectedValue.ToString();
                }

                DataTable dt = service.GetMaterialStockList(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
                SetRowNumber();

                //dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Red;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void SetLoad()
        {
            txtProductCode.Text = "";
            cboFactory.SelectedIndex = 0;
            cboProductType.SelectedIndex = 0;
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
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목유형", "product_type", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "재고량", "w_count_present", true, 150);

            GridViewUtil.SetDoNotSort(dataGridView1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회버튼
            try
            {
                MaterialStockVO vo = new MaterialStockVO();

                if (txtProductCode.Text != "")
                {
                    vo.product_codename = txtProductCode.Text;
                }

                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }

                if (cboFactory.Text != "선택")
                {
                    vo.factory_code = cboFactory.SelectedValue.ToString();
                }

                StockService service = new StockService();
                DataTable dt = service.GetMaterialStockList(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
                SetRowNumber();

                //dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Red;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }


        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetLoad();
            //조회버튼
            try
            {
                MaterialStockVO vo = new MaterialStockVO();

                if (txtProductCode.Text != "")
                {
                    vo.product_codename = txtProductCode.Text;
                }

                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }

                if (cboFactory.Text != "선택")
                {
                    vo.factory_code = cboFactory.SelectedValue.ToString();
                }

                StockService service = new StockService();
                DataTable dt = service.GetMaterialStockList(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
                SetRowNumber();

                //dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Red;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    }
}
