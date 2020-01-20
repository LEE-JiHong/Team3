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
    public partial class SODialog : Team3.DialogForm
    {
        public enum EditMode { Insert, Update }
        string edit = string.Empty;
        public SOMasterVO vo;

        public SOMasterVO VO
        {
            get { return vo; }
            set { vo = value; }
        }

        public SODialog(EditMode edit, SOMasterVO vo = null)
        {
            InitializeComponent();

            if (edit == EditMode.Insert)
            {
                txtCancel.Enabled = false;
            }
            else if (edit == EditMode.Update)
            {

            }
        }


        private void SODialog_Load(object sender, EventArgs e)
        {
            List<CompanyVO> list = new List<CompanyVO>();
            OrderService service = new OrderService();
            list = service.GetCompanyAll("cooperative");

            ComboUtil.ComboBinding(cbCompany, list, "company_code", "company_name", "선택");
            ComboUtil.ComboBinding(cbDestination, list, "company_code", "company_name");
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtOrder_TextChanged(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(txtOrder.Text.Replace(",", ""), out i))
            {
                // textBox1의 값이 숫자이면 textBox1에 값 입력
                txtOrder.Text = i.ToString();
            }
            else
            {
                // textBox1의 값이 숫자가 아니면 0으로 변경
                txtOrder.Text = "0";
            }
        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
