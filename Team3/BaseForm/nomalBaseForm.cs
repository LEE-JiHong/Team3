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
    public partial class nomalBaseForm : entryBaseForm
    {
        private WinState windowstate = WinState.sub;


        public WinState SubWindowState
        {
            set
            {
                windowstate = value;
                if (windowstate == WinState.sub)
                {
                    TopMenu.Visible = false;
                }
                else
                {
                    TopMenu.Visible = true;
                }
            }
        }

        public nomalBaseForm()
        {
            InitializeComponent();
        }

        public nomalBaseForm(WinState winState)
        {
            InitializeComponent();
            windowstate = winState;
        }


        public void SetBottomStatusLabel(string text)
        {
            toolStripStatusLabel1.BorderStyle = Border3DStyle.Flat;
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.None;
            toolStripStatusLabel1.Text = text;
        }

        private void nomalBaseForm_Load(object sender, EventArgs e)
        {
            SetBottomStatusLabel(this.Tag.ToString());
        }

        private void 닫기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            
            Form fc = Application.OpenForms["Main"];
            Main frm = (Main)fc;
          
            frm.GetForm(this.Tag.ToString());
            this.Close();
        }
    }

    public enum WinState
    {
        sub,
        independ

    }
}
