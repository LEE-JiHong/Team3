namespace Team3
{
    partial class MREMgt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MREMgt));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddExcel = new System.Windows.Forms.Button();
            this.btnFormDownload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtUnitPrice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStandardDate = new System.Windows.Forms.Label();
            this.dtpStandardDate = new System.Windows.Forms.DateTimePicker();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvExchange = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvExchange);
            this.panel2.Location = new System.Drawing.Point(12, 112);
            this.panel2.Size = new System.Drawing.Size(876, 333);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.dtpStandardDate);
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblStandardDate);
            this.panel1.Size = new System.Drawing.Size(875, 57);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Text = "환율관리";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(466, 77);
            this.panel3.Size = new System.Drawing.Size(422, 29);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            // 
            // layoutButton
            // 
            this.layoutButton.FlatAppearance.BorderSize = 0;
            // 
            // 닫기
            // 
            this.닫기.FlatAppearance.BorderSize = 0;
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
            // btnAddExcel
            // 
            this.btnAddExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddExcel.Location = new System.Drawing.Point(344, 3);
            this.btnAddExcel.Name = "btnAddExcel";
            this.btnAddExcel.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcel.TabIndex = 29;
            this.btnAddExcel.Text = "Excel 등록";
            this.btnAddExcel.UseVisualStyleBackColor = true;
            // 
            // btnFormDownload
            // 
            this.btnFormDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormDownload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFormDownload.Location = new System.Drawing.Point(246, 3);
            this.btnFormDownload.Name = "btnFormDownload";
            this.btnFormDownload.Size = new System.Drawing.Size(92, 23);
            this.btnFormDownload.TabIndex = 28;
            this.btnFormDownload.Text = "양식 다운로드";
            this.btnFormDownload.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExcel.Location = new System.Drawing.Point(165, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.Text = "엑셀";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCopy.Location = new System.Drawing.Point(84, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 26;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitPrice.FormattingEnabled = true;
            this.txtUnitPrice.Location = new System.Drawing.Point(434, 18);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(173, 20);
            this.txtUnitPrice.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(360, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "화폐단위";
            // 
            // lblStandardDate
            // 
            this.lblStandardDate.AutoSize = true;
            this.lblStandardDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandardDate.Location = new System.Drawing.Point(31, 20);
            this.lblStandardDate.Name = "lblStandardDate";
            this.lblStandardDate.Size = new System.Drawing.Size(55, 15);
            this.lblStandardDate.TabIndex = 4;
            this.lblStandardDate.Text = "기준일자";
            // 
            // dtpStandardDate
            // 
            this.dtpStandardDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStandardDate.Location = new System.Drawing.Point(112, 17);
            this.dtpStandardDate.Name = "dtpStandardDate";
            this.dtpStandardDate.Size = new System.Drawing.Size(118, 21);
            this.dtpStandardDate.TabIndex = 8;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.Location = new System.Drawing.Point(752, 16);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 23);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // dgvExchange
            // 
            this.dgvExchange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExchange.Location = new System.Drawing.Point(0, 0);
            this.dgvExchange.Name = "dgvExchange";
            this.dgvExchange.RowTemplate.Height = 23;
            this.dgvExchange.Size = new System.Drawing.Size(876, 333);
            this.dgvExchange.TabIndex = 0;
            // 
            // MREMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(894, 536);
            this.Name = "MREMgt";
            this.Tag = "환율관리";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddExcel;
        private System.Windows.Forms.Button btnFormDownload;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpStandardDate;
        private System.Windows.Forms.ComboBox txtUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStandardDate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvExchange;
    }
}
