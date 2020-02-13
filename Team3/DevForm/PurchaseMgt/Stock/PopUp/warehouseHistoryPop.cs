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
    }
}
