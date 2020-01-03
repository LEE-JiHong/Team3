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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }



        private void Main_Load(object sender, EventArgs e)
        {
            //entryBaseForm frm = new entryBaseForm();
            //frm.MdiParent = this;

            //frm.Show();
        }
        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.LeftMenuTab.Visible = !this.LeftMenuTab.Visible;
            InitLeftTab();
        }

        private void CloseTab(object sender, EventArgs e)
        {
            MainTab.Controls.Remove(MainTab.SelectedTab);
          
        }
        public void GetForm(string name)
        {
            switch (name)
            {
                case "Form1":
                    Form1 form1 = new Form1();
                    MadeTabMenu(form1);
                    break;
                case "Form3":
                    Form3 form3 = new Form3();
                    MadeTabMenu(form3);
                    break;
                case "Form4":
                    Form4 form4 = new Form4();
                    MadeTabMenu(form4);
                    break;
            }
        }

        public void GetoutForm(string name)
        {
            switch (name)
            {
                case "Form1":
                    Form1 form1 = new Form1();
                    form1= (Form1)InitForm(form1);
                    form1.SubWindowState = WinState.independ;
                    break;

                case "Form3":
                    Form3 form3 = new Form3();
                    form3 = (Form3)InitForm(form3);
                    form3.SubWindowState = WinState.independ;
                    break;

                case "Form4":
                    Form4 form4 = new Form4();
                    form4 = (Form4)InitForm(form4);
                    form4.SubWindowState = WinState.independ;
                    break;
            }

        }

        private Form InitForm(Form frm)
        {
            frm.Tag = MainTab.SelectedTab.Text;           
            frm.ControlBox = true;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowIcon = true;
            frm.ShowInTaskbar = true;
            frm.SizeGripStyle = SizeGripStyle.Show;
            frm.Show();
            TabPage t1 = MainTab.SelectedTab;
            MainTab.TabPages.Remove(t1);
            return frm;
        }
        private void LayoutButton_Click(object sender, EventArgs e)
        {
            if (MainTab.TabPages.Count > 0)
            {
                foreach (dynamic item in MainTab.SelectedTab.Controls)
                {
                   
                    GetoutForm(item.Tag.ToString());
                }

            }
        }

        public void MadeTabMenu(nomalBaseForm frm, int state = 0)
        {
      
            frm.SubWindowState = WinState.sub;
            frm.ControlBox = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowIcon = false;
            frm.ShowInTaskbar = false;
            frm.SizeGripStyle = SizeGripStyle.Hide;
            frm.Dock = DockStyle.Fill;

            TabPage p1 = new TabPage();
            p1.Tag = frm.Tag.ToString();
            p1.BackColor = Color.AliceBlue;  
            p1.Text = frm.Tag.ToString();
            
            foreach (TabPage item in MainTab.Controls)
            {
                if (item.Tag.ToString() == p1.Tag.ToString())
                {
                    return;
                }
            }

            MainTab.Controls.Add(p1);
            p1.Controls.Clear();

            foreach (Control item in p1.Controls.OfType<Control>())
            {
                p1.Controls.Remove(item);
            }
            // 다른 폼을 Tabpage/Panel 에 띄우기
            frm.TopLevel = false;
            frm.TopMost = true;
            p1.Controls.Add(frm);
            frm.Show();

            MainTab.SelectedTab = p1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();       
            MadeTabMenu(frm);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();          
            MadeTabMenu(frm);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            MadeTabMenu(frm);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = MainTab.SelectedIndex;
        }

        private void LeftTabMenuClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (Panel item in LeftMenuTab.Controls)
            {
                foreach (var pitem in item.Controls)
                {
                    if (pitem is TreeView t1)
                    {
                        if (Convert.ToInt32(t1.Tag) == Convert.ToInt32(btn.Tag))
                        {
                            t1.Visible = !t1.Visible;
                            t1.ExpandAll();
                        }
                    }
                }
            }

            LeftMenuTab.HorizontalScroll.SmallChange = 10;
    }

        private void InitLeftTab()
        {
            foreach (Panel item in LeftMenuTab.Controls)
            {
                foreach (var pitem in item.Controls)
                {
                    if (pitem is TreeView t1)
                    {
                        t1.Visible = !t1.Visible;
                        t1.ExpandAll();
                    }
                }
            }
        }




        private void treeView5_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text, e.Node.Index.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //DevTestForm2 frm = new DevTestForm2();
            //Form obejectForm = frm;
            //MadeTabMenu(frm);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            MadeTabMenu(frm);
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //switch (e.Node.Text)
            //{
            //    case "공정관리":
            //        Form1 frm = new Form1(WinState.sub);
            //        Form obejectForm = frm;
            //        frm.Dock = DockStyle.Fill;
            //        MadeTabMenu(frm);
            //        break;
            //}
        }

        private void LayoutShowWindow(string text)
        {

        }
    }
}

