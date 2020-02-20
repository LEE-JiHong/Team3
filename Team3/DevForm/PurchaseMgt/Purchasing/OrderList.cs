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
    public partial class OrderList : Team3.VerticalGridBaseForm
    {
        DataTable dt;
        CheckBox headerCheckBox = new CheckBox();
        List<CompanyVO> CompanyList;

        public OrderList()
        {
            InitializeComponent();
        }

        private void OrderList_Load(object sender, EventArgs e)
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


            //PurchasingService service = new PurchasingService();

            //dt = service.GetOrderList();

            SetDataGrid();

            //SetRowNumber();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";
            chk.Name = "chk";
            chk.Width = 45;
            dataGridView1.Columns.Add(chk);

            //Point headerLocation = dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;

            //headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            //dataGridView1.Controls.Add(headerCheckBox);

            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "No.", "count", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주번호", "order_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "PlanID", "plan_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품업체", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문상태", "common_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "order_pdate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주량", "order_count", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고량", "", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출발량", "company_order_code", true);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "취소량", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소가능량", "order_count", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주일", "order_ddate", true);
        }

        private void SetRowNumber()
        {
            for (int count = 0; count <= (dataGridView1.Rows.Count - 1); count++)
            {
                dataGridView1.Rows[count].Cells[1].Value = string.Format((count + 1).ToString(), "0");
            }
        }

        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            List<OrderVO> list = new List<OrderVO>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    OrderVO vo = new OrderVO();
                    vo.order_id = row.Cells[1].Value.ToString();
                    vo.plan_id = row.Cells[2].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[9].Value);

                    list.Add(vo);
                }
            }

            //발주취소 버튼 (발주번호, PlanID 값)
            PurchasingService service = new PurchasingService();

            if (MessageBox.Show("발주 취소하시겠습니까?", "발주취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bool result = service.UpdateOrder(list);

                    if (result)
                    {
                        MessageBox.Show("성공적으로 발주취소가 완료되었습니다.");
                        SetBottomStatusLabel("성공적으로 발주취소가 완료되었습니다.");
                        btnSearch.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("발주취소 실패하였습니다. 다시 시도하여 주십시오.");
                        SetBottomStatusLabel("발주취소 실패하였습니다. 다시 시도하여 주십시오.");
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //수량 입력하면 체크박스 true
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value != null)
            {
                if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value) < Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value))
                {
                    MessageBox.Show("취소수량이 발주수량보다 클 수는 없습니다. 다시 입력하여 주십시오.");
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = null;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["chk"].Value = true;
                }
            }
        }

        private void btnEditDate_Click(object sender, EventArgs e)
        {
            OrderVO vo = new OrderVO();

            vo.order_pdate = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            vo.order_id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            vo.plan_id = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            EditDatePop frm = new EditDatePop(vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            try
            {
                SupplierVO vo = new SupplierVO();
                //vo.order_state = "O_COMPLETE";
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
                PurchasingService service = new PurchasingService();

                dt = service.GetOrderList(vo);

                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridViewUtil.SetDgvTextBoxColor(dataGridView1, 9);
        }
    }
}
