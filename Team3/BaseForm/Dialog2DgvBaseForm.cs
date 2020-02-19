using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class Dialog2DgvBaseForm : Team3.DialogForm
    {
        public Dialog2DgvBaseForm()
        {
            InitializeComponent();

        }

        private void Dialog2DgvBaseForm_KeyUp(object sender, KeyEventArgs e)
        {
            Form frm = (Form)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }

        }

        private void Dialog2DgvBaseForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}
