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

            //GridViewUtil.AddNewColumnToDataGridView(dgvCompany, "No.", "", true, 50);
            //SetRowNumber(dgvCompany);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvCompany.Columns.Add(chk);

            Point headerLocation = dgvCompany.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            dgvCompany.Controls.Add(headerCheckBox);

            PurchasingService service = new PurchasingService();
            dgvOrdering.DataSource = service.GetOrderList(planID);
        }

        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dgvCompany.EndEdit(); //가끔 체크박스가 내가 체크를 했는데 바로바로인식이 안되고 다른 셀을 클릭해야만 에디트모드가 끝낼 때가 있는데
            //그6게 endedit

            foreach (DataGridViewRow row in dgvCompany.Rows)
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
            for (int count = 0; count <= (dgv.Rows.Count - 2); count++)
            {
                dgv.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
            }
        }
    }
}
