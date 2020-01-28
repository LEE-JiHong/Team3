using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    /// <summary>
    /// 검색조건 패널 없는 HorizondgvForm
    /// </summary>
    public partial class HorizonDgvBaseForm : nomalBaseForm
    {
        public HorizonDgvBaseForm()
        {
            InitializeComponent();
        }

        private void HorizonDgvBaseForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
                SetBottomStatusLabel("Welcome! " + this.Tag.ToString() + " 페이지입니다.");
        }
    }
}
