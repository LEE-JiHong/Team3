using log4net.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Team3VO;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class WatingReceiving : Vertical2GridBaseForm
    {
        CheckBox headerCheckBox1 = new CheckBox();
        CheckBox headerCheckBox2 = new CheckBox();
        List<CompanyVO> CompanyList;
        DataTable dt;

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

            headerCheckBox1.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox1.BackColor = Color.White;
            headerCheckBox1.Size = new Size(18, 18);
            headerCheckBox1.Click += new EventHandler(HeaderCheckbox_Click);
            dgvWatingReceive.Controls.Add(headerCheckBox1);

            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주일자", "order_ddate", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주업체", "company_name", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "품목", "product_codename", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "품명", "product_name", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "발주량", "order_count", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "입고일자", "order_pdate", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingReceive, "주문상태", "common_name", true, 200);
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

            headerCheckBox2.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox2.BackColor = Color.White;
            headerCheckBox2.Size = new Size(18, 18);
            headerCheckBox2.Click += new EventHandler(HeaderCheckbox_Click2);
            dgvResult.Controls.Add(headerCheckBox2);

            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주일자", "order_ddate", true,200);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주업체", "company_name", true,200);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "품목", "product_codename", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "품명", "product_name", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "발주량", "order_count", true, 200);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvResult, "입고일자", "order_pdate", true, 200);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvResult, "출발일", "order_sdate", true, 200);
            GridViewUtil.AddNewColumnToDataGridView(dgvResult, "주문상태", "common_name", true, 200);
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
                dt = service.GetAlreadyOrderList(vo);

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
                chkBox.Value = headerCheckBox1.Checked;
            }
        }

        private void HeaderCheckbox_Click2(object sender, EventArgs e)
        {
            dgvResult.EndEdit();

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox2.Checked;
            }
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
                for (j = 0; j < dgvWatingReceive.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvWatingReceive.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgvWatingReceive.Rows.Count; i++)
                {
                    for (j = 0; j < dgvWatingReceive.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvWatingReceive[j, i].Value == null ? "" : dgvWatingReceive[j, i].Value;
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

        private void btnChoose_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dlist = new List<DataGridViewRow>();
            List<WatingReceivingVO> list = new List<WatingReceivingVO>();

            foreach (DataGridViewRow row in dgvWatingReceive.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    //DataRow newrow = (row.DataBoundItem as DataRowView).Row;

                    WatingReceivingVO vo = new WatingReceivingVO();
                    vo.order_id = row.Cells[1].Value.ToString();
                    vo.order_ddate = row.Cells[2].Value.ToString();
                    vo.company_name = row.Cells[3].Value.ToString();
                    vo.product_codename = row.Cells[4].Value.ToString();
                    vo.product_name = row.Cells[5].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[6].Value);
                    vo.order_pdate = row.Cells[7].Value.ToString();
                    vo.common_name = row.Cells[8].Value.ToString();

                    list.Add(vo);
                    dlist.Add(row);
                }
            }

            foreach (WatingReceivingVO vo in list)
            {
                dgvResult.Rows.Add(true,vo.order_id,vo.order_ddate, vo.company_name, vo.product_codename, vo.product_name, vo.order_count, vo.order_pdate, DateTime.Now.ToShortDateString(), vo.common_name);
            }

            foreach (DataGridViewRow row in dlist)
            {
                dgvWatingReceive.Rows.Remove(row);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dlist = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    WatingReceivingVO vo = new WatingReceivingVO();
                    vo.order_id = row.Cells[1].Value.ToString();
                    vo.order_ddate = row.Cells[2].Value.ToString();
                    vo.company_name = row.Cells[3].Value.ToString();
                    vo.product_codename = row.Cells[4].Value.ToString();
                    vo.product_name = row.Cells[5].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[6].Value);
                    vo.order_pdate = row.Cells[7].Value.ToString();
                    vo.common_name = row.Cells[8].Value.ToString();

                    dt.Rows.Add(vo.order_id, vo.order_ddate, vo.company_name, vo.product_codename, vo.product_name, vo.order_count, vo.order_pdate, vo.common_name);
                    dlist.Add(row);
                }
            }

            foreach (DataGridViewRow row in dlist)
            {
                dgvResult.Rows.Remove(row);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<WatingReceivingVO> list = new List<WatingReceivingVO>();

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    WatingReceivingVO vo = new WatingReceivingVO();
                    vo.order_id = row.Cells[1].Value.ToString();
                    vo.order_pdate = row.Cells[7].Value.ToString().Trim();
                    vo.order_sdate = row.Cells[8].Value.ToString().Trim();
                    //vo.order_count = Convert.ToInt32(row.Cells[8].Value);

                    list.Add(vo);
                }
            }

            if (MessageBox.Show("입고대기처리하시겠습니까?", "입고대기처리", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SupplierService service = new SupplierService();
                    bool result = service.UpdateOrderState(list);

                    if (result)
                    {
                        MessageBox.Show("성공적으로 입고대기처리가 완료되었습니다.");
                        dgvResult.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("입고대기처리 실패하였습니다. 다시 시도하여 주십시오.");
                    }
                }
                catch (Exception err)
                {
                    LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
