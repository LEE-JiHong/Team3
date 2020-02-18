using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3.DevForm.ShipmentMgt
{
    public partial class WinReport_SC : Form
    {
        XtraReport rpt;
        public WinReport_SC(XtraReport rpt)
        {
            InitializeComponent();
            this.rpt = rpt;
        }

       

        private void 인쇄ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
