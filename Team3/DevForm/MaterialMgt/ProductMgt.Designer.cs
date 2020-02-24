namespace Team3
{
    partial class ProductMgt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMgt));
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblDeliveryCompany = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWHing = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblWH = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.cboSupplyCompany = new System.Windows.Forms.ComboBox();
            this.cboInSector = new System.Windows.Forms.ComboBox();
            this.cboAdmin = new System.Windows.Forms.ComboBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.cboOutSector = new System.Windows.Forms.ComboBox();
            this.cboIsUsed = new System.Windows.Forms.ComboBox();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProductList);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Size = new System.Drawing.Size(1131, 268);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.cboIsUsed);
            this.panel1.Controls.Add(this.cboOutSector);
            this.panel1.Controls.Add(this.cboCompany);
            this.panel1.Controls.Add(this.cboSupplyCompany);
            this.panel1.Controls.Add(this.lblDeliveryCompany);
            this.panel1.Controls.Add(this.cboProductType);
            this.panel1.Controls.Add(this.cboAdmin);
            this.panel1.Controls.Add(this.cboInSector);
            this.panel1.Controls.Add(this.txtProduct);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblWH);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblWHing);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Size = new System.Drawing.Size(1131, 116);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::Team3.Properties.Resources.list_menu;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Size = new System.Drawing.Size(89, 32);
            this.label1.Text = "품목정보";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(823, 138);
            this.panel3.Size = new System.Drawing.Size(320, 32);
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(1155, 60);
            // 
            // layoutButton
            // 
            this.layoutButton.FlatAppearance.BorderSize = 0;
            // 
            // 닫기
            // 
            this.닫기.FlatAppearance.BorderSize = 0;
            // 
            // basepanel
            // 
            this.basepanel.Size = new System.Drawing.Size(1155, 454);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            this.imageList1.Images.SetKeyName(3, "copy-document.png");
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProduct.Location = new System.Drawing.Point(37, 12);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(33, 20);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "품목";
            // 
            // lblDeliveryCompany
            // 
            this.lblDeliveryCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliveryCompany.AutoSize = true;
            this.lblDeliveryCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDeliveryCompany.Location = new System.Drawing.Point(820, 49);
            this.lblDeliveryCompany.Name = "lblDeliveryCompany";
            this.lblDeliveryCompany.Size = new System.Drawing.Size(57, 20);
            this.lblDeliveryCompany.TabIndex = 1;
            this.lblDeliveryCompany.Text = "납품업체";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(25, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "담당자";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(423, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "품목유형";
            // 
            // lblWHing
            // 
            this.lblWHing.AutoSize = true;
            this.lblWHing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWHing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWHing.Location = new System.Drawing.Point(13, 49);
            this.lblWHing.Name = "lblWHing";
            this.lblWHing.Size = new System.Drawing.Size(57, 20);
            this.lblWHing.TabIndex = 4;
            this.lblWHing.Text = "입고창고";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(423, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "사용여부";
            // 
            // lblWH
            // 
            this.lblWH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWH.AutoSize = true;
            this.lblWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWH.Location = new System.Drawing.Point(423, 49);
            this.lblWH.Name = "lblWH";
            this.lblWH.Size = new System.Drawing.Size(57, 20);
            this.lblWH.TabIndex = 7;
            this.lblWH.Text = "출고창고";
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCompany.Location = new System.Drawing.Point(820, 12);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(57, 20);
            this.lblCompany.TabIndex = 6;
            this.lblCompany.Text = "발주업체";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtProduct.Location = new System.Drawing.Point(113, 7);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(225, 26);
            this.txtProduct.TabIndex = 9;
            // 
            // cboSupplyCompany
            // 
            this.cboSupplyCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSupplyCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplyCompany.FormattingEnabled = true;
            this.cboSupplyCompany.Location = new System.Drawing.Point(918, 46);
            this.cboSupplyCompany.Name = "cboSupplyCompany";
            this.cboSupplyCompany.Size = new System.Drawing.Size(209, 28);
            this.cboSupplyCompany.TabIndex = 11;
            // 
            // cboInSector
            // 
            this.cboInSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInSector.FormattingEnabled = true;
            this.cboInSector.Location = new System.Drawing.Point(113, 46);
            this.cboInSector.Name = "cboInSector";
            this.cboInSector.Size = new System.Drawing.Size(225, 28);
            this.cboInSector.TabIndex = 12;
            // 
            // cboAdmin
            // 
            this.cboAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAdmin.FormattingEnabled = true;
            this.cboAdmin.Location = new System.Drawing.Point(113, 84);
            this.cboAdmin.Name = "cboAdmin";
            this.cboAdmin.Size = new System.Drawing.Size(225, 28);
            this.cboAdmin.TabIndex = 13;
            // 
            // cboProductType
            // 
            this.cboProductType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(520, 84);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(230, 28);
            this.cboProductType.TabIndex = 14;
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(918, 7);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(209, 28);
            this.cboCompany.TabIndex = 15;
            // 
            // cboOutSector
            // 
            this.cboOutSector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboOutSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOutSector.FormattingEnabled = true;
            this.cboOutSector.Location = new System.Drawing.Point(520, 46);
            this.cboOutSector.Name = "cboOutSector";
            this.cboOutSector.Size = new System.Drawing.Size(230, 28);
            this.cboOutSector.TabIndex = 16;
            // 
            // cboIsUsed
            // 
            this.cboIsUsed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboIsUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIsUsed.FormattingEnabled = true;
            this.cboIsUsed.Location = new System.Drawing.Point(520, 7);
            this.cboIsUsed.Name = "cboIsUsed";
            this.cboIsUsed.Size = new System.Drawing.Size(230, 28);
            this.cboIsUsed.TabIndex = 17;
            // 
            // dgvProductList
            // 
            this.dgvProductList.AllowUserToAddRows = false;
            this.dgvProductList.AllowUserToDeleteRows = false;
            this.dgvProductList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 0);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.RowTemplate.Height = 23;
            this.dgvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductList.Size = new System.Drawing.Size(1131, 268);
            this.dgvProductList.TabIndex = 0;
            this.dgvProductList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProductList_DataBindingComplete);
            this.dgvProductList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.SetDgvNumbering);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.btnExcel);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExcel.Image = global::Team3.Properties.Resources.ExportToXLSX_16x16;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(173, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(56, 26);
            this.btnExcel.TabIndex = 32;
            this.btnExcel.Text = "엑셀";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Image = global::Team3.Properties.Resources.Editor_Edit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(115, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 26);
            this.button1.TabIndex = 35;
            this.button1.Text = "수정";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Image = global::Team3.Properties.Resources.Editor_Edit;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(57, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 26);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "등록";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Image = global::Team3.Properties.Resources.Zoom_16x16;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(1062, 80);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(65, 32);
            this.btnSelect.TabIndex = 78;
            this.btnSelect.Text = "조회";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Team3.Properties.Resources.Refresh_16x16;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(235, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 26);
            this.btnRefresh.TabIndex = 47;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // ProductMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1155, 536);
            this.KeyPreview = true;
            this.Name = "ProductMgt";
            this.Tag = "품목관리";
            this.Text = "품목관리";
            this.Load += new System.EventHandler(this.Materials_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboIsUsed;
        private System.Windows.Forms.ComboBox cboOutSector;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboAdmin;
        private System.Windows.Forms.ComboBox cboInSector;
        private System.Windows.Forms.ComboBox cboSupplyCompany;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblWH;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWHing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDeliveryCompany;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
    }
}
