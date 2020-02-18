using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Team3VO;

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
            try
            {
                //창고 콤보박스 바인딩
                StockService service = new StockService();
                List<FactoryComboVO> fList = new List<FactoryComboVO>();
                fList = service.GetInFactory();
                ComboUtil.ComboBinding(cboFactory, fList, "factory_code", "factory_name", "선택");

                //품목유형 콤보박스 바인딩
                List<CommonVO> productTypeList = new List<CommonVO>();
                productTypeList = service.GetProductType("item_type");
                ComboUtil.ComboBinding(cboProductType, productTypeList, "common_value", "common_name", "선택");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetLoad();
            try
            {
                MaterialSearchVO vo = new MaterialSearchVO();
                vo.startDate = dtpStartDate.Value.ToShortDateString();
                vo.endDate = dtpEndDate.Value.ToShortDateString();

                if (cboFactory.Text != "선택")
                {
                    vo.factory_name = cboFactory.Text;
                }
                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }
                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text;
                }

                StockService service = new StockService();
                DataTable dt = service.GetInOutHistory(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

        }

        private void SetLoad()
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            cboFactory.SelectedIndex = 0;
            cboProductType.SelectedIndex = 0;
            txtProduct.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialSearchVO vo = new MaterialSearchVO();
                vo.startDate = dtpStartDate.Value.ToShortDateString();
                vo.endDate = dtpEndDate.Value.ToShortDateString();

                if (cboFactory.Text != "선택")
                {
                    vo.factory_name = cboFactory.Text;
                }
                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }
                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text;
                }

                StockService service = new StockService();
                DataTable dt = service.GetInOutHistory(vo);
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };

                string filename = "test" + ".xlsx";

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);//tempPath

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetLoad();
            try
            {
                MaterialSearchVO vo = new MaterialSearchVO();
                vo.startDate = dtpStartDate.Value.ToShortDateString();
                vo.endDate = dtpEndDate.Value.ToShortDateString();

                if (cboFactory.Text != "선택")
                {
                    vo.factory_name = cboFactory.Text;
                }
                if (cboProductType.Text != "선택")
                {
                    vo.product_type = cboProductType.Text;
                }
                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text;
                }

                StockService service = new StockService();
                DataTable dt = service.GetInOutHistory(vo);
                SetDataGrid();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    }
}
