﻿namespace Team3
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.TreeNode treeNode300 = new System.Windows.Forms.TreeNode("작업실적등록");
            System.Windows.Forms.TreeNode treeNode301 = new System.Windows.Forms.TreeNode("공정재고현황");
            System.Windows.Forms.TreeNode treeNode302 = new System.Windows.Forms.TreeNode("WorkOrder", new System.Windows.Forms.TreeNode[] {
            treeNode300,
            treeNode301});
            System.Windows.Forms.TreeNode treeNode303 = new System.Windows.Forms.TreeNode("자재불출요청");
            System.Windows.Forms.TreeNode treeNode304 = new System.Windows.Forms.TreeNode("Material", new System.Windows.Forms.TreeNode[] {
            treeNode303});
            System.Windows.Forms.TreeNode treeNode305 = new System.Windows.Forms.TreeNode("원자재불출");
            System.Windows.Forms.TreeNode treeNode306 = new System.Windows.Forms.TreeNode("Material Ledger", new System.Windows.Forms.TreeNode[] {
            treeNode305});
            System.Windows.Forms.TreeNode treeNode307 = new System.Windows.Forms.TreeNode("작업지시생성");
            System.Windows.Forms.TreeNode treeNode308 = new System.Windows.Forms.TreeNode("작업지시현황");
            System.Windows.Forms.TreeNode treeNode309 = new System.Windows.Forms.TreeNode("발주");
            System.Windows.Forms.TreeNode treeNode310 = new System.Windows.Forms.TreeNode("발주현황");
            System.Windows.Forms.TreeNode treeNode311 = new System.Windows.Forms.TreeNode("Purchasing", new System.Windows.Forms.TreeNode[] {
            treeNode309,
            treeNode310});
            System.Windows.Forms.TreeNode treeNode312 = new System.Windows.Forms.TreeNode("입고대기");
            System.Windows.Forms.TreeNode treeNode313 = new System.Windows.Forms.TreeNode("Supplier", new System.Windows.Forms.TreeNode[] {
            treeNode312});
            System.Windows.Forms.TreeNode treeNode314 = new System.Windows.Forms.TreeNode("자재입고");
            System.Windows.Forms.TreeNode treeNode315 = new System.Windows.Forms.TreeNode("자재입고현황");
            System.Windows.Forms.TreeNode treeNode316 = new System.Windows.Forms.TreeNode("Material Ledger", new System.Windows.Forms.TreeNode[] {
            treeNode314,
            treeNode315});
            System.Windows.Forms.TreeNode treeNode317 = new System.Windows.Forms.TreeNode("자재재고현황");
            System.Windows.Forms.TreeNode treeNode318 = new System.Windows.Forms.TreeNode("입출고현황");
            System.Windows.Forms.TreeNode treeNode319 = new System.Windows.Forms.TreeNode("Stock", new System.Windows.Forms.TreeNode[] {
            treeNode317,
            treeNode318});
            System.Windows.Forms.TreeNode treeNode298 = new System.Windows.Forms.TreeNode("생산계획");
            System.Windows.Forms.TreeNode treeNode299 = new System.Windows.Forms.TreeNode("외주계획");
            System.Windows.Forms.TreeNode treeNode320 = new System.Windows.Forms.TreeNode("영업마스터업로드(PO)");
            System.Windows.Forms.TreeNode treeNode321 = new System.Windows.Forms.TreeNode("영업마스터");
            System.Windows.Forms.TreeNode treeNode322 = new System.Windows.Forms.TreeNode("수요계획");
            System.Windows.Forms.TreeNode treeNode323 = new System.Windows.Forms.TreeNode("오더관리", new System.Windows.Forms.TreeNode[] {
            treeNode320,
            treeNode321,
            treeNode322});
            System.Windows.Forms.TreeNode treeNode324 = new System.Windows.Forms.TreeNode("품목관리");
            System.Windows.Forms.TreeNode treeNode325 = new System.Windows.Forms.TreeNode("BOM");
            System.Windows.Forms.TreeNode treeNode326 = new System.Windows.Forms.TreeNode("공장관리");
            System.Windows.Forms.TreeNode treeNode327 = new System.Windows.Forms.TreeNode("설비관리");
            System.Windows.Forms.TreeNode treeNode328 = new System.Windows.Forms.TreeNode("업체관리");
            System.Windows.Forms.TreeNode treeNode329 = new System.Windows.Forms.TreeNode("BOR");
            System.Windows.Forms.TreeNode treeNode330 = new System.Windows.Forms.TreeNode("자원관리", new System.Windows.Forms.TreeNode[] {
            treeNode326,
            treeNode327,
            treeNode328,
            treeNode329});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LeftMenuButton = new System.Windows.Forms.Button();
            this.닫기 = new System.Windows.Forms.Button();
            this.layoutButton = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LeftMenuTab = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.treeView8 = new System.Windows.Forms.TreeView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.treeView7 = new System.Windows.Forms.TreeView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.treeView6 = new System.Windows.Forms.TreeView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.treeView5 = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.treeView4 = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.MainTab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.LeftMenuTab.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "menulist1.png");
            this.imageList1.Images.SetKeyName(1, "close.png");
            this.imageList1.Images.SetKeyName(2, "layout.png");
            this.imageList1.Images.SetKeyName(3, "closeBlue.png");
            this.imageList1.Images.SetKeyName(4, "menulist1Blue.png");
            this.imageList1.Images.SetKeyName(5, "cloud-storage-download.png");
            this.imageList1.Images.SetKeyName(6, "menu-symbol-of-three-parallel-lines.png");
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1540, 52);
            this.panel2.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel11);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(200, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1340, 52);
            this.panel12.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.flowLayoutPanel1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1340, 49);
            this.panel11.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.LeftMenuButton);
            this.flowLayoutPanel1.Controls.Add(this.닫기);
            this.flowLayoutPanel1.Controls.Add(this.layoutButton);
            this.flowLayoutPanel1.Controls.Add(this.button15);
            this.flowLayoutPanel1.Controls.Add(this.button16);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.button12);
            this.flowLayoutPanel1.Controls.Add(this.button13);
            this.flowLayoutPanel1.Controls.Add(this.button14);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1340, 49);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // LeftMenuButton
            // 
            this.LeftMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.LeftMenuButton.FlatAppearance.BorderSize = 0;
            this.LeftMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftMenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.LeftMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LeftMenuButton.Image")));
            this.LeftMenuButton.Location = new System.Drawing.Point(3, 3);
            this.LeftMenuButton.Name = "LeftMenuButton";
            this.LeftMenuButton.Size = new System.Drawing.Size(83, 43);
            this.LeftMenuButton.TabIndex = 5;
            this.LeftMenuButton.Text = "메뉴";
            this.LeftMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LeftMenuButton.UseVisualStyleBackColor = false;
            this.LeftMenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // 닫기
            // 
            this.닫기.FlatAppearance.BorderSize = 0;
            this.닫기.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.닫기.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.닫기.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.닫기.Image = ((System.Drawing.Image)(resources.GetObject("닫기.Image")));
            this.닫기.Location = new System.Drawing.Point(92, 3);
            this.닫기.Name = "닫기";
            this.닫기.Size = new System.Drawing.Size(88, 43);
            this.닫기.TabIndex = 4;
            this.닫기.Text = "닫기";
            this.닫기.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.닫기.UseVisualStyleBackColor = true;
            this.닫기.Click += new System.EventHandler(this.CloseTab);
            // 
            // layoutButton
            // 
            this.layoutButton.FlatAppearance.BorderSize = 0;
            this.layoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.layoutButton.Image = ((System.Drawing.Image)(resources.GetObject("layoutButton.Image")));
            this.layoutButton.Location = new System.Drawing.Point(186, 3);
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.Size = new System.Drawing.Size(111, 43);
            this.layoutButton.TabIndex = 12;
            this.layoutButton.Text = "화면분할";
            this.layoutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.layoutButton.UseVisualStyleBackColor = true;
            this.layoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // button15
            // 
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.button15.Image = ((System.Drawing.Image)(resources.GetObject("button15.Image")));
            this.button15.Location = new System.Drawing.Point(303, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(86, 43);
            this.button15.TabIndex = 13;
            this.button15.Text = "설정";
            this.button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.button16.Image = ((System.Drawing.Image)(resources.GetObject("button16.Image")));
            this.button16.Location = new System.Drawing.Point(395, 3);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(86, 43);
            this.button16.TabIndex = 14;
            this.button16.Text = "정보";
            this.button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(649, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(730, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 9;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(811, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 10;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Visible = false;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(892, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 11;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 52);
            this.panel4.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Team3.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LeftMenuTab
            // 
            this.LeftMenuTab.AutoScroll = true;
            this.LeftMenuTab.BackColor = System.Drawing.Color.White;
            this.LeftMenuTab.Controls.Add(this.panel10);
            this.LeftMenuTab.Controls.Add(this.panel9);
            this.LeftMenuTab.Controls.Add(this.panel8);
            this.LeftMenuTab.Controls.Add(this.panel7);
            this.LeftMenuTab.Controls.Add(this.panel6);
            this.LeftMenuTab.Controls.Add(this.panel5);
            this.LeftMenuTab.Controls.Add(this.panel3);
            this.LeftMenuTab.Controls.Add(this.panel1);
            this.LeftMenuTab.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMenuTab.Location = new System.Drawing.Point(0, 52);
            this.LeftMenuTab.Name = "LeftMenuTab";
            this.LeftMenuTab.Size = new System.Drawing.Size(200, 793);
            this.LeftMenuTab.TabIndex = 13;
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.Controls.Add(this.button11);
            this.panel10.Controls.Add(this.treeView8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 985);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(183, 114);
            this.panel10.TabIndex = 10;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button11.Location = new System.Drawing.Point(0, 0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(183, 32);
            this.button11.TabIndex = 1;
            this.button11.Tag = "8";
            this.button11.Text = "공정등록";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView8
            // 
            this.treeView8.BackColor = System.Drawing.Color.White;
            this.treeView8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView8.Location = new System.Drawing.Point(0, 33);
            this.treeView8.Name = "treeView8";
            treeNode300.Name = "노드3";
            treeNode300.Text = "작업실적등록";
            treeNode301.Name = "노드5";
            treeNode301.Text = "공정재고현황";
            treeNode302.Name = "노드0";
            treeNode302.Text = "WorkOrder";
            this.treeView8.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode302});
            this.treeView8.Size = new System.Drawing.Size(200, 78);
            this.treeView8.TabIndex = 0;
            this.treeView8.Tag = "8";
            this.treeView8.Visible = false;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.button10);
            this.panel9.Controls.Add(this.treeView7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 854);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(183, 131);
            this.panel9.TabIndex = 9;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(183, 32);
            this.button10.TabIndex = 1;
            this.button10.Tag = "7";
            this.button10.Text = "구매관리";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView7
            // 
            this.treeView7.BackColor = System.Drawing.Color.White;
            this.treeView7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView7.Location = new System.Drawing.Point(0, 32);
            this.treeView7.Name = "treeView7";
            treeNode303.Name = "노드0";
            treeNode303.Text = "자재불출요청";
            treeNode304.Name = "노드0";
            treeNode304.Text = "Material";
            treeNode305.Name = "노드3";
            treeNode305.Text = "원자재불출";
            treeNode306.Name = "노드2";
            treeNode306.Text = "Material Ledger";
            this.treeView7.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode304,
            treeNode306});
            this.treeView7.Size = new System.Drawing.Size(200, 96);
            this.treeView7.TabIndex = 0;
            this.treeView7.Tag = "7";
            this.treeView7.Visible = false;
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.button9);
            this.panel8.Controls.Add(this.treeView6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 767);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(183, 87);
            this.panel8.TabIndex = 8;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(183, 32);
            this.button9.TabIndex = 1;
            this.button9.Tag = "6";
            this.button9.Text = "공정관리";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView6
            // 
            this.treeView6.BackColor = System.Drawing.Color.White;
            this.treeView6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView6.Location = new System.Drawing.Point(0, 34);
            this.treeView6.Name = "treeView6";
            treeNode307.Name = "노드0";
            treeNode307.Text = "작업지시생성";
            treeNode308.Name = "노드1";
            treeNode308.Text = "작업지시현황";
            this.treeView6.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode307,
            treeNode308});
            this.treeView6.Size = new System.Drawing.Size(200, 50);
            this.treeView6.TabIndex = 0;
            this.treeView6.Tag = "6";
            this.treeView6.Visible = false;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.button8);
            this.panel7.Controls.Add(this.treeView5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 465);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(183, 302);
            this.panel7.TabIndex = 7;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(183, 32);
            this.button8.TabIndex = 1;
            this.button8.Tag = "5";
            this.button8.Text = "구매관리";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView5
            // 
            this.treeView5.BackColor = System.Drawing.Color.White;
            this.treeView5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView5.Location = new System.Drawing.Point(0, 33);
            this.treeView5.Name = "treeView5";
            treeNode309.Name = "노드1";
            treeNode309.Text = "발주";
            treeNode310.Name = "노드2";
            treeNode310.Text = "발주현황";
            treeNode311.Name = "노드0";
            treeNode311.Text = "Purchasing";
            treeNode312.Name = "노드5";
            treeNode312.Text = "입고대기";
            treeNode313.Name = "노드4";
            treeNode313.Text = "Supplier";
            treeNode314.Name = "노드7";
            treeNode314.Text = "자재입고";
            treeNode315.Name = "노드8";
            treeNode315.Text = "자재입고현황";
            treeNode316.Name = "노드6";
            treeNode316.Text = "Material Ledger";
            treeNode317.Name = "노드10";
            treeNode317.Text = "자재재고현황";
            treeNode318.Name = "노드13";
            treeNode318.Text = "입출고현황";
            treeNode319.Name = "노드9";
            treeNode319.Text = "Stock";
            this.treeView5.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode311,
            treeNode313,
            treeNode316,
            treeNode319});
            this.treeView5.Size = new System.Drawing.Size(200, 266);
            this.treeView5.TabIndex = 0;
            this.treeView5.Tag = "5";
            this.treeView5.Visible = false;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.treeView4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 379);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(183, 86);
            this.panel6.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(183, 32);
            this.button7.TabIndex = 1;
            this.button7.Tag = "4";
            this.button7.Text = "수주/생산관리";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView4
            // 
            this.treeView4.BackColor = System.Drawing.Color.White;
            this.treeView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView4.Location = new System.Drawing.Point(0, 34);
            this.treeView4.Name = "treeView4";
            treeNode298.Name = "노드0";
            treeNode298.Text = "생산계획";
            treeNode299.Name = "노드1";
            treeNode299.Text = "외주계획";
            this.treeView4.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode298,
            treeNode299});
            this.treeView4.Size = new System.Drawing.Size(200, 49);
            this.treeView4.TabIndex = 0;
            this.treeView4.Tag = "4";
            this.treeView4.Visible = false;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.treeView3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 247);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 132);
            this.panel5.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(183, 32);
            this.button5.TabIndex = 1;
            this.button5.Tag = "3";
            this.button5.Text = "수주/계획관리";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView3
            // 
            this.treeView3.BackColor = System.Drawing.Color.White;
            this.treeView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView3.Location = new System.Drawing.Point(0, 33);
            this.treeView3.Name = "treeView3";
            treeNode320.Name = "노드1";
            treeNode320.Text = "영업마스터업로드(PO)";
            treeNode321.Name = "노드2";
            treeNode321.Text = "영업마스터";
            treeNode322.Name = "노드4";
            treeNode322.Text = "수요계획";
            treeNode323.Name = "노드0";
            treeNode323.Text = "오더관리";
            this.treeView3.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode323});
            this.treeView3.Size = new System.Drawing.Size(200, 96);
            this.treeView3.TabIndex = 0;
            this.treeView3.Tag = "3";
            this.treeView3.Visible = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.treeView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 90);
            this.panel3.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(183, 32);
            this.button4.TabIndex = 1;
            this.button4.Tag = "2";
            this.button4.Text = "품목관리";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.Color.White;
            this.treeView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView2.Location = new System.Drawing.Point(0, 33);
            this.treeView2.Name = "treeView2";
            treeNode324.Name = "품목관리";
            treeNode324.Text = "품목관리";
            treeNode325.Name = "BOM";
            treeNode325.Text = "BOM";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode324,
            treeNode325});
            this.treeView2.Size = new System.Drawing.Size(200, 54);
            this.treeView2.TabIndex = 0;
            this.treeView2.Tag = "2";
            this.treeView2.Visible = false;
            this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 157);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(121)))), ((int)(((byte)(152)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 32);
            this.button3.TabIndex = 1;
            this.button3.Tag = "1";
            this.button3.Text = "자원관리";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.LeftTabMenuClick);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(0, 34);
            this.treeView1.Name = "treeView1";
            treeNode326.Name = "공장관리";
            treeNode326.Text = "공장관리";
            treeNode327.Name = "설비관리";
            treeNode327.Text = "설비관리";
            treeNode328.Name = "업체관리";
            treeNode328.Text = "업체관리";
            treeNode329.Name = "BOR";
            treeNode329.Text = "BOR";
            treeNode330.Name = "자원관리";
            treeNode330.Text = "자원관리";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode330});
            this.treeView1.Size = new System.Drawing.Size(200, 120);
            this.treeView1.TabIndex = 0;
            this.treeView1.Tag = "1";
            this.treeView1.Visible = false;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // MainTab
            // 
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(200, 52);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1340, 793);
            this.MainTab.TabIndex = 14;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.LeftMenuTab);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.LeftMenuTab.ResumeLayout(false);
            this.LeftMenuTab.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.Panel LeftMenuTab;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TreeView treeView8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TreeView treeView7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TreeView treeView6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TreeView treeView5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TreeView treeView4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button LeftMenuButton;
        private System.Windows.Forms.Button 닫기;
        private System.Windows.Forms.Button layoutButton;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
    }
}

