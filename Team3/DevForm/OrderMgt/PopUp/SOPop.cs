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
    public partial class SODialog : Team3.DialogForm
    {
        DateTime today = DateTime.Now;

        public enum EditMode { Insert, Update }
        EditMode edit = EditMode.Insert;
        public SOMasterVO vo;

        List<CompanyVO> list;

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
                this.edit = EditMode.Insert;
            }
            else if (edit == EditMode.Update)
            {
                this.vo = vo;
                this.edit = EditMode.Update;
                txtSOWO.Enabled = false;
            }
        }


        private void SODialog_Load(object sender, EventArgs e)
        {
            txtOutput.Enabled = false;

            list = new List<CompanyVO>();

            OrderService service = new OrderService();
            list = service.GetCompanyAll("cooperative");

            ComboUtil.ComboBinding(cbCompany, list, "company_code", "company_name", "선택");
            ComboUtil.ComboBinding(cbDestination, list, "company_code", "company_name");

            List<ProductVO> pList = new List<ProductVO>();
            pList = service.GetProductList();

            ComboUtil.ComboBinding(cbProduct, pList, "product_codename", "product_name", "선택");

            if (edit == EditMode.Update)
            {
                //수정 데이터 바인딩
                txtSOWO.Text = vo.so_wo_id;
                cbProduct.SelectedValue = vo.product_codename;
                cbCompany.SelectedValue = vo.company_code;
                dtpsDate.Value = Convert.ToDateTime(vo.so_edate);
                txtOrder.Text = vo.so_pcount.ToString();
                txtOutput.Text = vo.so_ocount.ToString();
                txtCancel.Text = vo.so_ccount.ToString();
                txtComment.Text = vo.so_comment;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (edit == EditMode.Insert)
            {
                //영업마스터 추가
                string planID = DateTime.Now.ToShortDateString().Replace("-", "") + "_P";

                SOMasterVO vo = new SOMasterVO();
                vo.plan_id = planID;
                vo.so_wo_id = txtSOWO.Text;

                List<CompanyVO> company = (from item in list
                                           where item.company_code == (string)cbCompany.SelectedValue
                                           select item).ToList();

                vo.company_code = (string)cbCompany.SelectedValue;
                vo.company_type = company[0].company_type;
                vo.product_name = (string)cbProduct.SelectedValue;
                vo.so_pcount = Convert.ToInt32(txtOrder.Text);
                vo.so_edate = dtpsDate.Value.ToShortDateString();
                vo.so_sdate = DateTime.Now.ToShortDateString();
                vo.so_comment = txtComment.Text;

                OrderService service = new OrderService();
                bool result = service.AddOneSOMaster(vo);

                if (result)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("등록 실패");
                }
            }
            else if (edit == EditMode.Update)
            {
                vo.so_id = vo.so_id;

                List<CompanyVO> company = (from item in list
                                           where item.company_code == (string)cbCompany.SelectedValue
                                           select item).ToList();

                vo.company_code = (string)cbCompany.SelectedValue;
                vo.company_type = company[0].company_type;
                vo.product_codename = (string)cbProduct.SelectedValue;
                vo.so_pcount = Convert.ToInt32(txtOrder.Text);
                vo.so_ccount = Convert.ToInt32(txtCancel.Text);
                vo.so_edate = dtpsDate.Value.ToShortDateString();
                vo.so_udate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
                vo.so_comment = txtComment.Text;

                OrderService service = new OrderService();
                bool result = service.UpdateOneSOMaster(vo);

                if (result)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("등록 실패");
                }
            }
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

        private void txtCancel_TextChanged(object sender, EventArgs e)
        {
            if (txtCancel.Text == "")
            {
                txtCancel.Text = "0";
            }
        }
    }
}
