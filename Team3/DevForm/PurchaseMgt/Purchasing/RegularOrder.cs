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
    public partial class RegularOrder : Team3.VerticalGridBaseForm
    {
        public RegularOrder()
        {
            InitializeComponent();
        }

        private void RegularOrder_Load(object sender, EventArgs e)
        {

            //dataGridView1.Columns.Add("P/N",);
            //dataGridView1.Columns.Add("품목명", "품목명");
            //dataGridView1.Columns.Add("품목유형", "품목유형");

            //dataGridView1.Columns.Add("공급L/T", "P/N");
            //dataGridView1.Columns.Add("표준발주", "P/N");
            //dataGridView1.Columns.Add("현재고", "P/N");

            SetCombo();
        }
        private void SetCombo()
        {
            OrderService service = new OrderService();
            List<CompanyVO> Companylist = service.GetCompanyAll("CUSTOMER");

            ComboUtil.ComboBinding(cboCompany, Companylist, "company_code", "company_name", "전체");

            List<string> planIDlist = service.GetPlanID();
            cboPlanID.DataSource = planIDlist;

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderDialog frm = new OrderDialog(cboCompany.SelectedIndex);
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            string planID = cboPlanID.Text;

            OrderService service = new OrderService();
            dataGridView1.DataSource = service.GetMRP(planID, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
        }
    }
}
