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

        public OrderList()
        {
            InitializeComponent();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            PurchasingService service = new PurchasingService();

            dt = service.GetOrderList();

            SetDataGrid();

            //SetRowNumber();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dataGridView1.Columns.Add(chk);

            Point headerLocation = dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            dataGridView1.Controls.Add(headerCheckBox);

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "No.", "count", true, 30);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주번호", "order_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "PlanID", "plan_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품업체", "company_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문상태", "common_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "order_pdate", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주량", "order_count", true, 78);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "입고량", "", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출발량", "company_order_code", true, 78);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "취소량", "", true, 78);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소가능량", "order_count", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주일", "order_sdate", true, 78);

            dataGridView1.DataSource = dt;
        }

        private void SetRowNumber()
        {
            for (int count = 0; count <= (dataGridView1.Rows.Count - 1); count++)
            {
                dataGridView1.Rows[count].Cells[0].Value = string.Format((count + 1).ToString(), "0");
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
                    vo.order_id = row.Cells[2].Value.ToString();
                    vo.plan_id = row.Cells[3].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[12].Value);

                    list.Add(vo);
                }
            }

            //발주취소 버튼 (발주번호, PlanID 값)
            PurchasingService service = new PurchasingService();

            try
            {
                bool result = service.UpdateOrder(list);

                if (result)
                {
                    MessageBox.Show("성공적으로 발주취소가 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("발주취소 실패");
                }
            }
            catch(Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    }
}
