﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class HorizonGridBaseForm : nomalBaseForm
    {
        public HorizonGridBaseForm()
        {
            InitializeComponent();
        }

        private void HorizonGridBaseForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
                SetBottomStatusLabel("Welcome! " + this.Tag.ToString() + " 페이지 입니다");
        }
    }
}
