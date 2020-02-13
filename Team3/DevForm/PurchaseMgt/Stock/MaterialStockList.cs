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
    public partial class MaterialStockList : Team3.VerticalGridBaseForm
    {
        public MaterialStockList()
        {
            InitializeComponent();
        }

        private void MaterialStockList_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;

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

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회버튼
            try
            {
                StockService service = new StockService();
                DataTable dt = service.GetMaterialStockList();
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }


        private void btnHistory_Click(object sender, EventArgs e)
        {
            warehouseHistoryPop frm = new warehouseHistoryPop();
            frm.ShowDialog();
        }
    }
}
