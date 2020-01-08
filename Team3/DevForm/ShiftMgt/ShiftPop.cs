using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class ShiftPop : Team3.DialogForm
    {
        public ShiftPop()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.AutoSize = true;
            int size = int.Parse(textBox1.Text);
            foreach (var item in panel4.Controls)
            {
                if (item is TextBox  tb)
                {
                   if( Convert.ToInt32( tb.Tag) <= size)
                    {
                        tb.Visible = true;
                    }
                    else
                    {
                        tb.Visible = false;
                    }
                }

                if (item is Label lb)
                {
                    if (Convert.ToInt32(lb.Tag) <= size)
                    {
                        lb.Visible = true;
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }

              
        }
    }
}
