using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Team3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Gradient);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient);
            //this.button3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button4.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button5.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button7.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button8.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button9.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button10.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
            //this.button11.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Gradient2);
        }

        //private void Form_Gradient(object sender, PaintEventArgs e)
        //{
        //    LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 255, 255),
        //        Color.FromArgb(0, 0, 0), 0, false);
        //    e.Graphics.FillRectangle(br, this.ClientRectangle);
        //}

        private void Panel_Gradient(object sender, PaintEventArgs e)
        {
            //Color startColor = Color.FromArgb(202, 210, 220);
            //Color middleColor = Color.FromArgb(149, 165, 186);
            //Color endColor = Color.FromArgb(96, 121, 152);

            Color startColor = Color.FromArgb(255, 255, 255);
            Color middleColor = Color.FromArgb(96, 121, 152);
            Color endColor = Color.FromArgb(36, 56, 91);

            LinearGradientBrush br = new LinearGradientBrush(this.panel2.ClientRectangle, System.Drawing.Color.Black, System.Drawing.Color.Black, 0, false);

            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 1 / 2f, 1 };
            cb.Colors = new[] { startColor, middleColor, endColor };
            br.InterpolationColors = cb;

            br.RotateTransform(0);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }

        //private void Panel_Gradient2(object sender, PaintEventArgs e)
        //{
        //    //Color startColor = Color.FromArgb(202, 210, 220);
        //    //Color middleColor = Color.FromArgb(149, 165, 186);
        //    //Color endColor = Color.FromArgb(96, 121, 152);

        //    Color startColor = Color.FromArgb(96, 121, 152);
        //    Color middleColor = Color.FromArgb(36, 56, 91);
        //    Color endColor = Color.FromArgb(24, 37, 60);

        //    LinearGradientBrush br = new LinearGradientBrush(this.button3.ClientRectangle, System.Drawing.Color.Black, System.Drawing.Color.Black, 0, false);

           

        //    ColorBlend cb = new ColorBlend();
        //    cb.Positions = new[] { 0, 1 / 2f, 1 };
        //    cb.Colors = new[] { startColor, middleColor, endColor };
        //    br.InterpolationColors = cb;
            
        //    br.RotateTransform(0);
        //    e.Graphics.FillRectangle(br, this.ClientRectangle);
        //    button3.Text = "관리";
        //}

        private void Main_Load(object sender, EventArgs e)
        {
            //entryBaseForm frm = new entryBaseForm();
            //frm.MdiParent = this;

            //frm.Show();
            SetTrvImage(treeView1);
            SetTrvImage2(treeView2);
            SetTrvImage(treeView3);
            SetTrvImage2(treeView4);
            SetTrvImage(treeView5);
            SetTrvImage2(treeView6);
            SetTrvImage(treeView7);
            SetTrvImage(treeView8);

        }

        //트리뷰 이미지 설정
        //트리뷰는 폴더img, 노드는 파일img
        private void SetTrvImage(TreeView trv)
        {
            ImageList imgList = new ImageList();
            imgList.Images.Add(new Bitmap(Properties.Resources.BOFolder_16x16));//Application.StartupPath + @"\image\doc_icon.png"
            imgList.Images.Add(new Bitmap(Properties.Resources.file));//Application.StartupPath + @"\image\doc_icon.png"
            trv.ImageList = imgList;
            foreach (TreeNode node in trv.Nodes)
            {
                foreach (TreeNode node2 in node.Nodes)
                {
                    node2.ImageIndex = 1;
                    node2.SelectedImageIndex = 1;
                }
            }
        }

        //트리뷰 이미지 설정
        //폴더가 없을 경우 -> 파일img
        private void SetTrvImage2(TreeView trv)
        {
            ImageList imgList = new ImageList();
            imgList.Images.Add(new Bitmap(Properties.Resources.file));//Application.StartupPath + @"\image\doc_icon.png"
            trv.ImageList = imgList;
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
                //자원관리
                case "공장관리":
                    FactoryMgt FactoryMgt = new FactoryMgt();
                    MadeTabMenu(FactoryMgt);
                    break;
                case "설비관리":
                    facilityMgt facilityMgt = new facilityMgt();
                    MadeTabMenu(facilityMgt);
                    break;
                case "업체관리":
                    businessMgt businessMgt = new businessMgt();
                    MadeTabMenu(businessMgt);
                    break;
                case "BOR":
                    BOR BOR = new BOR();
                    MadeTabMenu(BOR);
                    break;

                //품목관리
                case "품목관리":
                    ProductMgt ProductMgt = new ProductMgt();
                    MadeTabMenu(ProductMgt);
                    break;
                case "BOM":
                    BomMgt BomMgt = new BomMgt();
                    MadeTabMenu(BomMgt);
                    break;

                //수주/계획관리 - 오더관리
                case "영업마스터업로드(P/O)":
                    SalesMasterUpload SalesMasterUpload = new SalesMasterUpload();
                    MadeTabMenu(SalesMasterUpload);
                    break;
                case "영업마스터":
                    SalesMaster SalesMaster = new SalesMaster();
                    MadeTabMenu(SalesMaster);
                    break;
                case "수요계획":
                    DemandPlan DemandPlan = new DemandPlan();
                    MadeTabMenu(DemandPlan);
                    break;

                //수주/생산관리
                case "생산계획":
                    ProductPlan ProductPlan = new ProductPlan();
                    MadeTabMenu(ProductPlan);
                    break;

                //구매관리-
                case "정규발주":
                    RegularOrder RegularOrder = new RegularOrder();
                    MadeTabMenu(RegularOrder);
                    break;
            }
        }

        public void GetoutForm(string name)
        {
            switch (name)
            {
                //자원관리
                case "공장관리":
                    FactoryMgt FactoryMgt = new FactoryMgt();
                    FactoryMgt = (FactoryMgt)InitForm(FactoryMgt);
                    FactoryMgt.SubWindowState = WinState.independ;
                    break;
                case "설비관리":
                    facilityMgt facilityMgt = new facilityMgt();
                    facilityMgt = (facilityMgt)InitForm(facilityMgt);
                    facilityMgt.SubWindowState = WinState.independ;
                    break;
                case "업체관리":
                    businessMgt businessMgt = new businessMgt();
                    businessMgt = (businessMgt)InitForm(businessMgt);
                    businessMgt.SubWindowState = WinState.independ;
                    break;
                case "BOR":
                    BOR BOR = new BOR();
                    BOR = (BOR)InitForm(BOR);
                    BOR.SubWindowState = WinState.independ;
                    break;

                //품목관리
                case "품목관리":
                    ProductMgt ProductMgt = new ProductMgt();
                    ProductMgt = (ProductMgt)InitForm(ProductMgt);
                    ProductMgt.SubWindowState = WinState.independ;
                    break;
                case "BOM":
                    BomMgt BomMgt = new BomMgt();
                    BomMgt = (BomMgt)InitForm(BomMgt);
                    BomMgt.SubWindowState = WinState.independ;
                    break;

                //수주/계획관리 - 오더관리
                case "영업마스터업로드(P/O)":
                    SalesMasterUpload SalesMasterUpload = new SalesMasterUpload();
                    SalesMasterUpload = (SalesMasterUpload)InitForm(SalesMasterUpload);
                    SalesMasterUpload.SubWindowState = WinState.independ;
                    break;
                case "영업마스터업로드":
                    SalesMaster SalesMaster = new SalesMaster();
                    SalesMaster = (SalesMaster)InitForm(SalesMaster);
                    SalesMaster.SubWindowState = WinState.independ;
                    break;
                case "수요계획":
                    DemandPlan DemandPlan = new DemandPlan();
                    DemandPlan = (DemandPlan)InitForm(DemandPlan);
                    DemandPlan.SubWindowState = WinState.independ;
                    break;

                //수주/생산관리
                case "생산계획":
                    ProductPlan ProductPlan = new ProductPlan();
                    ProductPlan = (ProductPlan)InitForm(ProductPlan);
                    ProductPlan.SubWindowState = WinState.independ;
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

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "공장관리")
            {
                FactoryMgt frm = new FactoryMgt();
                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "설비관리")
            {         
                facilityMgt frm = new facilityMgt();
                MadeTabMenu(frm);
            }
            if (e.Node.Text == "업체관리")
            {
                businessMgt frm = new businessMgt();
                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "BOR")
            {
                BOR frm = new BOR();
                MadeTabMenu(frm);
            }
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Text == "품목관리")
            {
                ProductMgt frm = new ProductMgt();
                MadeTabMenu(frm);
            }
            else if(e.Node.Text == "BOM")
            {
                BomMgt frm = new BomMgt();
                MadeTabMenu(frm);
            }
            else
            {
                ISIMgt frm = new ISIMgt();
                MadeTabMenu(frm);
            }
        }

        private void treeView6_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "작업지시생성")
            {
                GOO frm = new GOO();
                MadeTabMenu(frm);
            }
            else
            {
                SOO frm = new SOO();
                MadeTabMenu(frm);
            }
        }

        private void treeView3_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "영업마스터업로드(PO)")
            {
                SalesMasterUpload frm = new SalesMasterUpload();
                MadeTabMenu(frm);
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            Process.Start("Chrome.exe", "https://localhost:44387/");
        }
    }
}

