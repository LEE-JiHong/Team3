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
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            ////TeamTextBox 컨트롤을 모두 찾아서 ErrorProviderMsg 속성에
            ////폼에 있는 errorprovider1을 매핑해준다.

            //var controls = GetAll(this, typeof(TextBox));
            ////MessageBox.Show(Convert.ToString(controls.Count()));
            //foreach (TextBox txt in controls)
            //{
            //    txt.Tag = this.errorProvider1;
            //}

        }

        private void DialogForm_KeyUp(object sender, KeyEventArgs e)
        {
            Form frm = (Form)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point mousePoint;

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();
        //    return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        //}

    }
}
