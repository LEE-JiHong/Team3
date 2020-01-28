using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class DgvBaseForm : nomalBaseForm
    {
        public DgvBaseForm()
        {
            InitializeComponent();
        }

        private void DgvBaseForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
                SetBottomStatusLabel("Welcome! " + this.Tag.ToString() + " 페이지입니다.");
        }
    }
}
