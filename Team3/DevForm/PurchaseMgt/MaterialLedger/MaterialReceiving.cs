using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class MaterialReceiving : Team3.Vertical2GridBaseForm
    {
        CheckBox headerCheckBox1 = new CheckBox();
        CheckBox headerCheckBox2 = new CheckBox();
        List<CompanyVO> CompanyList;
        List<OrderStateVO> orderStateList;
        DataTable dt;

        public MaterialReceiving()
        {
            InitializeComponent();
        }

        private void MaterialReceiving_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1);

            //발주업체, 주문상태 콤보박스 바인딩
            OrderService oService = new OrderService();
            MaterialLedgerService mService = new MaterialLedgerService(); 

            CompanyList = new List<CompanyVO>();
            orderStateList = new List<OrderStateVO>();

            try
            {
                CompanyList = oService.GetCompanyAll("customer");
                ComboUtil.ComboBinding(cboCompany, CompanyList, "company_code", "company_name", "선택");

                orderStateList = mService.GetOrderState();
                ComboUtil.ComboBinding(cboOrderState, orderStateList, "state_code", "state_name", "선택");
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
            dgvWatingList.Columns.Clear();

            GridViewUtil.SetDataGridView(dgvWatingList);
            dgvWatingList.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvWatingList.Columns.Add(chk);

            Point headerLocation = dgvWatingList.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox1.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox1.BackColor = Color.White;
            headerCheckBox1.Size = new Size(18, 18);
            headerCheckBox1.Click += new EventHandler(HeaderCheckbox_Click);
            dgvWatingList.Controls.Add(headerCheckBox1);

            //GridViewUtil.SetDataGridColumnColor(dgvWatingList);

            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "발주일자", "order_ddate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "발주업체", "company_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "발주량", "order_count", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "입고일자", "order_pdate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "출발일", "order_sdate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvWatingList, "주문상태", "common_name", true, 150);
        }

        private void SetDataGridResult()
        {
            dgvMaterialReceiving.Columns.Clear();


            GridViewUtil.SetDataGridView(dgvMaterialReceiving);
            dgvMaterialReceiving.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvMaterialReceiving.Columns.Add(chk);

            Point headerLocation = dgvMaterialReceiving.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox2.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox2.BackColor = Color.White;
            headerCheckBox2.Size = new Size(18, 18);
            headerCheckBox2.Click += new EventHandler(HeaderCheckbox_Click2);
            dgvMaterialReceiving.Controls.Add(headerCheckBox2);

            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "발주일자", "order_ddate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "발주업체", "company_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "발주량", "order_count", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvMaterialReceiving, "입고량", "order_qcount", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvMaterialReceiving, "입고일자", "order_pdate", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvMaterialReceiving, "출발일", "order_sdate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dgvMaterialReceiving, "주문상태", "common_name", true, 150);
        }

        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dgvWatingList.EndEdit();

            foreach (DataGridViewRow row in dgvWatingList.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox1.Checked;
            }
        }

        private void HeaderCheckbox_Click2(object sender, EventArgs e)
        {
            dgvMaterialReceiving.EndEdit();

            foreach (DataGridViewRow row in dgvMaterialReceiving.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox2.Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            try
            {
                SupplierVO vo = new SupplierVO();
                vo.start_date = dtpStartDate.Value.ToShortDateString();
                vo.end_date = dtpEndDate.Value.ToShortDateString();

                if (cboCompany.Text != "선택")
                {
                    vo.company_name = cboCompany.Text;
                }

                if (cboOrderState.Text != "선택")
                {
                    vo.order_state = cboOrderState.SelectedValue.ToString();
                }

                MaterialLedgerService service = new MaterialLedgerService();
                dt = service.GetWatingReceivingList(vo);

                dgvWatingList.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dlist = new List<DataGridViewRow>();
            List<WatingReceivingVO> list = new List<WatingReceivingVO>();

            foreach (DataGridViewRow row in dgvWatingList.Rows)
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
                    vo.order_sdate = row.Cells[8].Value.ToString();
                    vo.common_name = row.Cells[9].Value.ToString();
                    

                    list.Add(vo);
                    dlist.Add(row);
                }
            }

            foreach (WatingReceivingVO vo in list)
            {
                dgvMaterialReceiving.Rows.Add(true, vo.order_id, vo.order_ddate, vo.company_name, vo.product_codename, vo.product_name, vo.order_count,"", vo.order_pdate, vo.order_sdate, vo.common_name);
            }

            foreach (DataGridViewRow row in dlist)
            {
                dgvWatingList.Rows.Remove(row);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dlist = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgvMaterialReceiving.Rows)
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
                dgvMaterialReceiving.Rows.Remove(row);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //입고처리 버튼
            //order_state = P_COMPLETE 로 바꾸고
            //warehouse에 insert
            //

            List<MaterialReceivingVO> list = new List<MaterialReceivingVO>();

            foreach (DataGridViewRow row in dgvMaterialReceiving.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    MaterialReceivingVO vo = new MaterialReceivingVO();
                    vo.order_serial = row.Cells[1].Value.ToString();
                    vo.product_codename = row.Cells[4].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[7].Value);
                    vo.order_pdate = row.Cells[8].Value.ToString().Trim();
                    vo.product_name = row.Cells[5].Value.ToString().Trim();
                    vo.order_sdate = row.Cells[8].Value.ToString().Trim();

                    list.Add(vo);
                }
            }

            try
            {
                MaterialLedgerService service = new MaterialLedgerService();
                bool result = service.AddMaterialQauntity(list);

                if (result)
                {
                    MessageBox.Show("성공적으로 입고처리가 완료되었습니다.");
                    dgvMaterialReceiving.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("입고처리 실패하였습니다. 다시 시도하여 주십시오.");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
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
                for (j = 0; j < dgvWatingList.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvWatingList.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgvWatingList.Rows.Count; i++)
                {
                    for (j = 0; j < dgvWatingList.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvWatingList[j, i].Value == null ? "" : dgvWatingList[j, i].Value;
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
    }
}
