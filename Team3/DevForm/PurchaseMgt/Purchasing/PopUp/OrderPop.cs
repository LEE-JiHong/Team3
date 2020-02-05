using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class OrderDialog : DialogDgvBaseForm
    {
        string planID;
        int companyName;
        CheckBox headerCheckBox = new CheckBox();

        public OrderDialog(int companyName, string planID)
        {
            InitializeComponent();
            this.companyName = companyName;
            this.planID = planID;
        }

        private void OrderDialog_Load(object sender, EventArgs e)
        {
            SetCombo();
            SetDataGridCompany();

            PurchasingService service = new PurchasingService();
            DataSet ds = service.GetOrderList(planID);
            dgvOrdering.DataSource = ds.Tables[0];
            dgvCompany.DataSource = ds.Tables[1];

            SetDataGridOrdering();

            SetRowNumber(dgvCompany);

        }

        private void SetDataGridOrdering()
        {
            dgvOrdering.Columns.Clear();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvOrdering.Columns.Add(chk);

            Point headerLocation = dgvOrdering.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            dgvOrdering.Controls.Add(headerCheckBox);

            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "Plan ID", "plan_id", true,110);
            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "발주업체", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "품목", "product_codename", true);
            //GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "창고", "factory_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "품명", "producct_name", true);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvOrdering, "납기일", "pro_date", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "현재고", "present_count", true,70, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvOrdering, "발주제안수량", "pro_count", true, 110,DataGridViewContentAlignment.MiddleRight,true);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvOrdering, "발주수량", "", true, 80, DataGridViewContentAlignment.MiddleRight);
        }

        private void SetDataGridCompany()
        {
            dgvCompany.Columns.Clear();
            //GridCheckBox(dgvCompany);
            GridViewUtil.AddNewColumnToDataGridView(dgvCompany, "No.", "count", true, 30);
            GridViewUtil.AddNewColumnToDataGridView(dgvCompany, "발주업체", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dgvCompany, "업체코드", "company_order_code", true, 78);
        }

        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dgvOrdering.EndEdit();

            foreach (DataGridViewRow row in dgvOrdering.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
            }
        }

        private void SetCombo()
        {
            OrderService service = new OrderService();
            List<CompanyVO> Companylist = service.GetCompanyAll("CUSTOMER");

            ComboUtil.ComboBinding(cboCompany, Companylist, "company_code", "company_name", "전체");
            cboCompany.SelectedIndex = companyName;
        }

        private void SetRowNumber(DataGridView dgv)
        {
            for (int count = 0; count <= (dgv.Rows.Count - 1); count++)
            {
                // dgv.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                dgv.Rows[count].Cells[0].Value = string.Format((count + 1).ToString(), "0");
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            //발주버튼
            List<OrderVO> list = new List<OrderVO>();
            foreach (DataGridViewRow row in dgvOrdering.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    OrderVO vo = new OrderVO();
                    vo.product_codename = row.Cells[3].Value.ToString();

                    for (int i = 0; i < dgvCompany.Rows.Count; i++)
                    {
                        if (dgvCompany.Rows[i].Cells[1].Value.ToString() == row.Cells[2].Value.ToString())
                        {
                            vo.order_id = dgvCompany.Rows[i].Cells[2].Value.ToString();
                        }
                    }

                    vo.order_count = Convert.ToInt32(row.Cells[8].Value);
                    vo.plan_id = row.Cells[1].Value.ToString().Trim();
                    vo.order_pdate = row.Cells[5].Value.ToString().Trim();

                    list.Add(vo);
                }
            }

            for (int i = 0; i < dgvCompany.Rows.Count; i++)
            {
                List<int> orders = new List<int>();
                int num = 1;
                for (int c = 0; c < list.Count; c++)
                {
                    if (dgvCompany.Rows[i].Cells[2].Value.ToString() == list[c].order_id)
                    {
                        if (!orders.Contains(Convert.ToInt32(dgvCompany.Rows[i].Cells[2].Value)))
                        {
                            list[c].order_id += "-" + string.Format("{0:D4}", num);
                            orders.Add(Convert.ToInt32(dgvCompany.Rows[i].Cells[2].Value));
                        }
                        else
                        {
                            list[c].order_id += "-" + string.Format("{0:D4}", num);
                        }
                        num++;
                    }
                }
            }

            try
            {
                PurchasingService service = new PurchasingService();
                bool result = service.InsertOrder(list);

                if (result)
                {
                    MessageBox.Show("성공적으로 발주완료하였습니다.");
                }
                else
                {
                    MessageBox.Show("발주실패");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void DgvOrdering_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //수량 입력하면 체크박스 true
            if (dgvOrdering.SelectedRows[e.RowIndex].Cells[7].Value.ToString() != "")
            {
                //DataGridViewCheckBoxCell chkBox = dgvOrdering.SelectedRows[e.RowIndex].Cells["chk"] as DataGridViewCheckBoxCell;
                //chkBox.Value = headerCheckBox.Checked;
                MessageBox.Show("Test");
            }
        }
    }
}



//List<string> companyList = (from r in dt.AsEnumerable()
//                            select r.Field<string>("company_name")).ToList();

//IEnumerable<string> result = companyList.Distinct();
//dgvCompany.DataSource = result.Select(num => Select );

