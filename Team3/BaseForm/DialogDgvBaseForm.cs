using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class DialogDgvBaseForm : DialogForm
    {
        public DialogDgvBaseForm()
        {
            InitializeComponent();
        }

        private void DialogDgvBaseForm_KeyUp(object sender, KeyEventArgs e)
        {
            Form frm = (Form)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }

        }

        private void DialogDgvBaseForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}
