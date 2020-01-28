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
            SetBottomStatusLabel(this.Tag.ToString());
        }
    }
}
