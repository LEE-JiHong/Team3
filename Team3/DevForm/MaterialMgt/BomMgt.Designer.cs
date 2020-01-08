namespace Team3
{
    partial class BomMgt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BomMgt));
            this.cboDeployment = new System.Windows.Forms.ComboBox();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtStandardDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblUse = new System.Windows.Forms.Label();
            this.lblStandardDate = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnAddExcel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnFormDownload = new System.Windows.Forms.Button();
            this.dgvBom = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvBom);
            this.panel2.Location = new System.Drawing.Point(12, 121);
            this.panel2.Size = new System.Drawing.Size(1169, 324);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.cboDeployment);
            this.panel1.Controls.Add(this.cboUse);
            this.panel1.Controls.Add(this.txtProduct);
            this.panel1.Controls.Add(this.txtStandardDate);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Controls.Add(this.lblUse);
            this.panel1.Controls.Add(this.lblStandardDate);
            this.panel1.Size = new System.Drawing.Size(1169, 77);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "BOM";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(760, 91);
            this.panel3.Size = new System.Drawing.Size(422, 29);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(1193, 60);
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
            this.basepanel.Size = new System.Drawing.Size(1193, 454);
            // 
            // cboDeployment
            // 
            this.cboDeployment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDeployment.FormattingEnabled = true;
            this.cboDeployment.Location = new System.Drawing.Point(809, 8);
            this.cboDeployment.Name = "cboDeployment";
            this.cboDeployment.Size = new System.Drawing.Size(178, 20);
            this.cboDeployment.TabIndex = 34;
            // 
            // cboUse
            // 
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(133, 47);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(216, 20);
            this.cboUse.TabIndex = 30;
            // 
            // txtProduct
            // 
            this.txtProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProduct.Location = new System.Drawing.Point(434, 8);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(221, 21);
            this.txtProduct.TabIndex = 29;
            // 
            // txtStandardDate
            // 
            this.txtStandardDate.Location = new System.Drawing.Point(133, 8);
            this.txtStandardDate.Name = "txtStandardDate";
            this.txtStandardDate.Size = new System.Drawing.Size(216, 21);
            this.txtStandardDate.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(731, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "전개방식";
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProduct.Location = new System.Drawing.Point(383, 12);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(31, 15);
            this.lblProduct.TabIndex = 22;
            this.lblProduct.Text = "품목";
            // 
            // lblUse
            // 
            this.lblUse.AutoSize = true;
            this.lblUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUse.Location = new System.Drawing.Point(15, 50);
            this.lblUse.Name = "lblUse";
            this.lblUse.Size = new System.Drawing.Size(55, 15);
            this.lblUse.TabIndex = 20;
            this.lblUse.Text = "사용유무";
            // 
            // lblStandardDate
            // 
            this.lblStandardDate.AutoSize = true;
            this.lblStandardDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandardDate.Location = new System.Drawing.Point(15, 11);
            this.lblStandardDate.Name = "lblStandardDate";
            this.lblStandardDate.Size = new System.Drawing.Size(55, 15);
            this.lblStandardDate.TabIndex = 19;
            this.lblStandardDate.Text = "기준일자";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.Location = new System.Drawing.Point(1046, 48);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 23);
            this.btnSelect.TabIndex = 35;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnAddExcel
            // 
            this.btnAddExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddExcel.Location = new System.Drawing.Point(344, 3);
            this.btnAddExcel.Name = "btnAddExcel";
            this.btnAddExcel.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcel.TabIndex = 29;
            this.btnAddExcel.Text = "Excel 등록";
            this.btnAddExcel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCopy.Location = new System.Drawing.Point(84, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 26;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExcel.Location = new System.Drawing.Point(165, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.Text = "엑셀";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnFormDownload
            // 
            this.btnFormDownload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFormDownload.Location = new System.Drawing.Point(246, 3);
            this.btnFormDownload.Name = "btnFormDownload";
            this.btnFormDownload.Size = new System.Drawing.Size(92, 23);
            this.btnFormDownload.TabIndex = 28;
            this.btnFormDownload.Text = "양식 다운로드";
            this.btnFormDownload.UseVisualStyleBackColor = true;
            // 
            // dgvBom
            // 
            this.dgvBom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBom.Location = new System.Drawing.Point(0, 0);
            this.dgvBom.Name = "dgvBom";
            this.dgvBom.RowTemplate.Height = 23;
            this.dgvBom.Size = new System.Drawing.Size(1169, 324);
            this.dgvBom.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddExcel);
            this.flowLayoutPanel1.Controls.Add(this.btnFormDownload);
            this.flowLayoutPanel1.Controls.Add(this.btnExcel);
            this.flowLayoutPanel1.Controls.Add(this.btnCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BomMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1193, 536);
            this.Name = "BomMgt";
            this.Tag = "BOM";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboDeployment;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtStandardDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblUse;
        private System.Windows.Forms.Label lblStandardDate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnAddExcel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnFormDownload;
        private System.Windows.Forms.DataGridView dgvBom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
