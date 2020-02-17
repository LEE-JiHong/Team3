using log4net.Core;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string pwd = txtPwd.Text;

            //if (txtID.Text == "")
            //{
            //    MessageBox.Show("아이디를 입력하세요.");
            //    return;
            //}
            //if (txtPwd.Text == "")
            //{
            //    MessageBox.Show("비밀번호를 입력하세요.");
            //    return;
            //}

            try
            {
                //UserService service = new UserService();
                //int result = service.LoginCheck(id, pwd);

                //if (result > 0)
                //{
                    Main frm = new Main();
                    frm.Show();
                    this.Hide();
                //}
                //else
                //{
                //    MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.");
                //    return;
                //}
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 1;
            Color borderColor = Color.FromArgb(147, 166, 185);

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
             borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

            ButtonBorderStyle.Solid, borderColor, borderWidth,
             ButtonBorderStyle.Solid,

            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}
