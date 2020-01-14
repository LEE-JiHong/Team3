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
            SetTrvImage(treeView8);
            SetTrvImage2(treeView9);
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
            if (MainTab.SelectedTab.Tag.ToString() != "메인화면")
            {
                MainTab.Controls.Remove(MainTab.SelectedTab);
                MainTab.SelectedTab = MainTab.TabPages[MainTab.Controls.Count-1];
            }
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
                case "영업마스터업로드(PO)":
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
                case "자재소요계획":
                    MRP MRP = new MRP();
                    MadeTabMenu(MRP);
                    break;

                //구매관리-Purchase
                case "정규발주":
                    RegularOrder RegularOrder = new RegularOrder();
                    MadeTabMenu(RegularOrder);
                    break;
                case "발주현황":
                    OrderList OrderList = new OrderList();
                    MadeTabMenu(OrderList);
                    break;

                //구매관리-Supplier
                case "입고대기":
                    WatingReceiving WatingReceiving = new WatingReceiving();
                    MadeTabMenu(WatingReceiving);
                    break;

                //구매관리-Material Ledger
                case "자재입고":
                    MaterialReceiving MaterialReceiving = new MaterialReceiving();
                    MadeTabMenu(MaterialReceiving);
                    break;
                case "자재입고현황":
                    MaterialReceivingList MaterialReceivingList = new MaterialReceivingList();
                    MadeTabMenu(MaterialReceivingList);
                    break;
                case "원자재불출":
                    RequestRawMaterial_sDistribution RequestRawMaterial_sDistribution = new RequestRawMaterial_sDistribution();
                    MadeTabMenu(RequestRawMaterial_sDistribution);
                    break;

                //구매관리-Stock
                case "자재재고현황":
                    MaterialStockList MaterialStockList = new MaterialStockList();
                    MadeTabMenu(MaterialStockList);
                    break;
                case "입출고현황":
                    InOutList InOutList = new InOutList();
                    MadeTabMenu(InOutList);
                    break;

                //구매관리-Material
                case "자재불출요청":
                    DMRMgt DMRMgt = new DMRMgt();
                    MadeTabMenu(DMRMgt);
                    break;

                //공정관리
                case "작업지시생성":
                    GOO GOO = new GOO();
                    MadeTabMenu(GOO);
                    break;
                case "작업지시현황":
                    SOO SOO = new SOO();
                    MadeTabMenu(SOO);
                    break;

                //공정등록
                case "작업실적등록":
                    Business_showings Business_showings = new Business_showings();
                    MadeTabMenu(Business_showings);
                    break;
                case "공정재고현황":
                    Process_Inventory Process_Inventory = new Process_Inventory();
                    MadeTabMenu(Process_Inventory);
                    break;

                //단가관리
                case "영업단가관리":
                    SUPMMgt SUPMMgt = new SUPMMgt();
                    MadeTabMenu(SUPMMgt);
                    break;
                case "자재단가관리":
                    MUPMMgt MUPMMgt = new MUPMMgt();
                    MadeTabMenu(MUPMMgt);
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
                case "영업마스터업로드(PO)":
                    SalesMasterUpload SalesMasterUpload = new SalesMasterUpload();
                    SalesMasterUpload = (SalesMasterUpload)InitForm(SalesMasterUpload);
                    SalesMasterUpload.SubWindowState = WinState.independ;
                    break;
                case "영업마스터":
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
                case "자재소요계획":
                    MRP MRP = new MRP();
                    MRP = (MRP)InitForm(MRP);
                    MRP.SubWindowState = WinState.independ;
                    break;

                //구매관리-Purchase
                case "정규발주":
                    RegularOrder RegularOrder = new RegularOrder();
                    RegularOrder = (RegularOrder)InitForm(RegularOrder);
                    RegularOrder.SubWindowState = WinState.independ;
                    break;
                case "발주현황":
                    OrderList OrderList = new OrderList();
                    OrderList = (OrderList)InitForm(OrderList);
                    OrderList.SubWindowState = WinState.independ;
                    break;

                //구매관리-Supplier
                case "입고대기":
                    WatingReceiving WatingReceiving = new WatingReceiving();
                    WatingReceiving = (WatingReceiving)InitForm(WatingReceiving);
                    WatingReceiving.SubWindowState = WinState.independ;
                    break;

                //구매관리-Material Ledger
                case "자재입고":
                    MaterialReceiving MaterialReceiving = new MaterialReceiving();
                    MaterialReceiving = (MaterialReceiving)InitForm(MaterialReceiving);
                    MaterialReceiving.SubWindowState = WinState.independ;
                    break;
                case "자재입고현황":
                    MaterialReceivingList MaterialReceivingList = new MaterialReceivingList();
                    MaterialReceivingList = (MaterialReceivingList)InitForm(MaterialReceivingList);
                    MaterialReceivingList.SubWindowState = WinState.independ;
                    break;
                case "원자재불출":
                    RequestRawMaterial_sDistribution RequestRawMaterial_sDistribution = new RequestRawMaterial_sDistribution();
                    RequestRawMaterial_sDistribution = (RequestRawMaterial_sDistribution)InitForm(RequestRawMaterial_sDistribution);
                    RequestRawMaterial_sDistribution.SubWindowState = WinState.independ;
                    break;

                //구매관리-Stock
                case "자재재고현황":
                    MaterialStockList MaterialStockList = new MaterialStockList();
                    MaterialStockList = (MaterialStockList)InitForm(MaterialStockList);
                    MaterialStockList.SubWindowState = WinState.independ;
                    break;
                case "입출고현황":
                    InOutList InOutList = new InOutList();
                    InOutList = (InOutList)InitForm(InOutList);
                    InOutList.SubWindowState = WinState.independ;
                    break;

                //구매관리-Material
                case "자재불출요청":
                    DMRMgt DMRMgt = new DMRMgt();
                    DMRMgt = (DMRMgt)InitForm(DMRMgt);
                    DMRMgt.SubWindowState = WinState.independ;
                    break;

                //공정관리
                case "작업지시생성":
                    GOO GOO = new GOO();
                    GOO = (GOO)InitForm(GOO);
                    GOO.SubWindowState = WinState.independ;
                    break;
                case "작업지시현황":
                    SOO SOO = new SOO();
                    SOO = (SOO)InitForm(SOO);
                    SOO.SubWindowState = WinState.independ;
                    break;

                //공정등록
                case "작업실적등록":
                    Business_showings Business_showings = new Business_showings();
                    Business_showings = (Business_showings)InitForm(Business_showings);
                    Business_showings.SubWindowState = WinState.independ;
                    break;
                case "공정재고현황":
                    Process_Inventory Process_Inventory = new Process_Inventory();
                    Process_Inventory = (Process_Inventory)InitForm(Process_Inventory);
                    Process_Inventory.SubWindowState = WinState.independ;
                    break;

                //단가관리
                case "영업단가관리":
                    SUPMMgt SUPMMgt = new SUPMMgt();
                    SUPMMgt = (SUPMMgt)InitForm(SUPMMgt);
                    SUPMMgt.SubWindowState = WinState.independ;
                    break;
                case "자재단가관리":
                    MUPMMgt MUPMMgt = new MUPMMgt();
                    MUPMMgt = (MUPMMgt)InitForm(MUPMMgt);
                    MUPMMgt.SubWindowState = WinState.independ;
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
            if (MainTab.TabPages.Count > 1)
            {
                if (MainTab.SelectedTab.Tag.ToString() != "메인화면")
                {
                    foreach (dynamic item in MainTab.SelectedTab.Controls)
                    {
                        GetoutForm(item.Tag.ToString());
                    }
                }
            }
        }

        private bool ExsistTap(string tag)
        {
            foreach (TabPage tp in MainTab.Controls)
            {
                if (tp.Tag.ToString() == tag)
                {
                    MainTab.SelectedTab = tp;
                    return true;
                }

            }
            return false;
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
            //MessageBox.Show(e.Node.Text, e.Node.Index.ToString());
            if (e.Node.Text == "정규발주")
            {
                RegularOrder frm = new RegularOrder();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }
                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "발주현황")
            {
                OrderList frm = new OrderList();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            if (e.Node.Text == "입고대기")
            {
                WatingReceiving frm = new WatingReceiving();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재입고")
            {
                MaterialReceiving frm = new MaterialReceiving();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재입고현황")
            {
                MaterialReceivingList frm = new MaterialReceivingList();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재재고현황")
            {
                MaterialStockList frm = new MaterialStockList();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "입출고현황")
            {
                InOutList frm = new InOutList();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재불출요청")
            {
                DMRMgt frm = new DMRMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "원자재불출")
            {
                RequestRawMaterial_sDistribution frm = new RequestRawMaterial_sDistribution();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //DevTestForm2 frm = new DevTestForm2();
            //Form obejectForm = frm;
            //MadeTabMenu(frm);
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
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "설비관리")
            {         
                facilityMgt frm = new facilityMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            if (e.Node.Text == "업체관리")
            {
                businessMgt frm = new businessMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "BOR")
            {
                BOR frm = new BOR();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Text == "품목관리")
            {
                ProductMgt frm = new ProductMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if(e.Node.Text == "BOM")
            {
                BomMgt frm = new BomMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else
            {
                ISIMgt frm = new ISIMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void treeView6_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "작업지시생성")
            {
                GOO frm = new GOO();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else
            {
                SOO frm = new SOO();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void treeView3_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "영업마스터업로드(PO)")
            {
                SalesMasterUpload frm = new SalesMasterUpload();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "영업마스터")
            {
                SalesMaster frm = new SalesMaster();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "수요계획")
            {
                DemandPlan frm = new DemandPlan();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            Process.Start("Chrome.exe", "https://localhost:44387/");
        }

        private void TreeView4_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "생산계획")
            {
                ProductPlan frm = new ProductPlan();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재소요계획")
            {
                MRP frm = new MRP();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void TreeView8_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "작업실적등록")
            {
                Business_showings frm = new Business_showings();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "공정재고현황")
            {
                Process_Inventory frm = new Process_Inventory();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }

        private void treeView9_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "영업단가관리")
            {
                SUPMMgt frm = new SUPMMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
            else if (e.Node.Text == "자재단가관리")
            {
                MUPMMgt frm = new MUPMMgt();
                if (ExsistTap(e.Node.Text))
                {
                    return;
                }

                MadeTabMenu(frm);
            }
        }
    }
}

