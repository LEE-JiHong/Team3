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
        public SODialog()
        {
            InitializeComponent();
        }

        

        private void SODialog_Load(object sender, EventArgs e)
        {
            List<CompanyVO> list = new List<CompanyVO>();
            OrderService service = new OrderService();
            list = service.GetCompanyAll();

            ComboUtil.ComboBinding(cbCompany, list, "company_code", "company_name", "선택");

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
