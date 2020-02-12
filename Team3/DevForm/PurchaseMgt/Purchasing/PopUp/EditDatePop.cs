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
    public partial class EditDatePop : DialogForm
    {
        OrderVO vo;

        public EditDatePop(OrderVO vo)
        {
            InitializeComponent();
            this.vo = vo;
        }

        private void EditDatePop_Load(object sender, EventArgs e)
        {
            dtpAsisDate.Value = Convert.ToDateTime(vo.order_pdate);
            //dtpTobeDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //변경버튼
            if (MessageBox.Show($"\"{dtpTobeDate.Value.ToShortDateString()}\"으로 변경하시겠습니까?") == DialogResult.OK)
            {
                vo.order_pdate = dtpTobeDate.Value.ToShortDateString();

                try
                {
                    PurchasingService service = new PurchasingService();
                    bool result = service.UpdateOrderDate(vo);

                    if (result)
                    {
                        MessageBox.Show("납기일이 성공적으로 변경되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("납기일 변경에 실패하였습니다.");
                    }
                }
                catch(Exception err)
                {
                    LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                }
            }
        }

        private void dtpTobeDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTobeDate.Value < DateTime.Now)
            {
                MessageBox.Show("납기일을 오늘날짜보다 더 빠른 날짜로 할 수 없습니다.");
                dtpTobeDate.Value = DateTime.Now;
                return;
            }
        }
    }
}
