using log4net.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class WatingReceiving : Vertical2GridBaseForm
    {
        CheckBox headerCheckBox = new CheckBox();
        List<CompanyVO> CompanyList;

        public WatingReceiving()
        {
            InitializeComponent();
        }

        private void WatingReceiving_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1);

            OrderService service = new OrderService();

            //발주업체 콤보박스 바인딩
            CompanyList = new List<CompanyVO>();

            try
            {
                CompanyList = service.GetCompanyAll("customer");
                ComboUtil.ComboBinding(cboCompany, CompanyList, "company_code", "company_name", "선택");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetDataGridWatingReceiving();
            SetDataGridResult();
        }

        private void SetDataGridWatingReceiving()
        {
            dgvWatingReceive.Columns.Clear();


            GridViewUtil.SetDataGridView(dgvWatingReceive);
            dgvWatingReceive.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvWatingReceive.Columns.Add(chk);

            Point headerLocation = dgvWatingReceive.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            dgvWatingReceive.Controls.Add(headerCheckBox);

            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주번호", "order_id", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주일자", "order_ddate", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주업체", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주량", "order_count", true, 70);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "납기일", "order_pdate", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "주문상태", "common_name", true, 80);
        }

        private void SetDataGridResult()
        {
            dgvResult.Columns.Clear();


            GridViewUtil.SetDataGridView(dgvResult);
            dgvResult.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvResult.Columns.Add(chk);

            Point headerLocation = dgvResult.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click2);
            dgvResult.Controls.Add(headerCheckBox);

            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주번호", "order_id", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주일자", "order_ddate", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주업체", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주량", "order_count", true, 70);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "납기일", "order_pdate", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "주문상태", "common_name", true, 80);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            try
            {
                SupplierVO vo = new SupplierVO();
                vo.order_state = "O_COMPLETE";
                vo.start_date = dtpStartDate.Value.ToShortDateString();
                vo.end_date = dtpEndDate.Value.ToShortDateString();

                if (cboCompany.Text != "선택")
                {
                    vo.company_name = cboCompany.Text;
                }

                if (txtOrderID.Text != "")
                {
                    vo.order_id = txtOrderID.Text;
                }

                SupplierService service = new SupplierService();
                DataTable dt = service.GetAlreadyOrderList(vo);

                dgvWatingReceive.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dgvWatingReceive.EndEdit();

            foreach (DataGridViewRow row in dgvWatingReceive.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
            }
        }

        private void HeaderCheckbox_Click2(object sender, EventArgs e)
        {
            dgvResult.EndEdit();

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvWatingReceive.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow = row;

                    list.Add(newRow);
                }
            }

            int i = 0;
            foreach (DataGridViewRow row in list)
            {
                //DataGridViewRow newRow = new DataGridViewRow();
                //newRow = row;

                // dgvResult.Rows.Insert(row.Index, row);


                // dgvResult.Rows.Add(row);
                // dgvResult.accept();

                dgvResult.Rows.Add();

                dgvWatingReceive.Rows.Remove(row);



            }
           // dgvResult.DataSource = list;
        }
    }
}
