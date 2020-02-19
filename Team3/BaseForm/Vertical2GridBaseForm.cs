using System;
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
    public partial class Vertical2GridBaseForm : nomalBaseForm
    {
  
        public Vertical2GridBaseForm()
        {
            InitializeComponent();           
        }

        public Vertical2GridBaseForm(WinState state) : base(state)
        {
            InitializeComponent();
        }

        private void Vertical2GridBaseForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (this.Tag != null)
                SetBottomStatusLabel("Welcome! " + this.Tag.ToString() + " 페이지입니다.");
        }

        private void Vertical2GridBaseForm_KeyUp(object sender, KeyEventArgs e)
        {
            Form frm = (Form)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }

        }
    }
    }

