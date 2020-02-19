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
            this.KeyPreview = true;
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
        private Point mousePoint; // 현재 마우스 포인터의 좌표저장 변수 선언

        // 마우스 누를때 현재 마우스 좌표를 저장한다 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); //현재 마우스 좌표 저장
        }

        // 마우스 왼쪽 버튼을 누르고 움직이면 폼을 이동시킨다
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //마우스 왼쪽 클릭 시에만 실행
            {
                //폼의 위치를 드래그중인 마우스의 좌표로 이동 
                Location = new Point(Left - (mousePoint.X - e.X), Top - (mousePoint.Y - e.Y));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();
        //    return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        //}

    }
}
