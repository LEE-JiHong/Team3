﻿namespace Team3.DevForm.ShipmentMgt
{
    partial class ShipmentClosingMgt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentClosingMgt));
            this.dgvClientOrder = new System.Windows.Forms.DataGridView();
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblStandardDate = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboWH = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDeliveryCompany = new System.Windows.Forms.Label();
            this.cboDestination = new System.Windows.Forms.ComboBox();
            this.lblWH = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblWHing = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientOrder)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvClientOrder);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 189);
            this.panel2.Size = new System.Drawing.Size(1188, 415);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.txtOrderNum);
            this.panel1.Controls.Add(this.txtProduct);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.lblStandardDate);
            this.panel1.Controls.Add(this.cboCustomer);
            this.panel1.Controls.Add(this.cboWH);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblDeliveryCompany);
            this.panel1.Controls.Add(this.cboDestination);
            this.panel1.Controls.Add(this.lblWH);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.lblWHing);
            this.panel1.Size = new System.Drawing.Size(1187, 137);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::Team3.Properties.Resources.list_menu;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.Text = "고객주문";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(1040, 154);
            this.panel3.Size = new System.Drawing.Size(160, 33);
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(1212, 60);
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
            this.basepanel.Size = new System.Drawing.Size(1212, 617);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            // 
            // dgvClientOrder
            // 
            this.dgvClientOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvClientOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientOrder.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.dgvClientOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvClientOrder.Name = "dgvClientOrder";
            this.dgvClientOrder.RowTemplate.Height = 23;
            this.dgvClientOrder.Size = new System.Drawing.Size(1188, 415);
            this.dgvClientOrder.TabIndex = 0;
            this.dgvClientOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientOrder_CellValueChanged);
            this.dgvClientOrder.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvClientOrder_DataBindingComplete);
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNum.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtOrderNum.Location = new System.Drawing.Point(975, 61);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.Size = new System.Drawing.Size(209, 26);
            this.txtOrderNum.TabIndex = 126;
            // 
            // txtProduct
            // 
            this.txtProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtProduct.Location = new System.Drawing.Point(547, 61);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(230, 26);
            this.txtProduct.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(654, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "~";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(671, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(108, 26);
            this.dtpToDate.TabIndex = 122;
            // 
            // lblStandardDate
            // 
            this.lblStandardDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStandardDate.AutoSize = true;
            this.lblStandardDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardDate.ForeColor = System.Drawing.Color.Black;
            this.lblStandardDate.Location = new System.Drawing.Point(450, 21);
            this.lblStandardDate.Name = "lblStandardDate";
            this.lblStandardDate.Size = new System.Drawing.Size(45, 20);
            this.lblStandardDate.TabIndex = 121;
            this.lblStandardDate.Text = "납기일";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(975, 18);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(209, 28);
            this.cboCustomer.TabIndex = 119;
            // 
            // cboWH
            // 
            this.cboWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWH.FormattingEnabled = true;
            this.cboWH.Location = new System.Drawing.Point(128, 18);
            this.cboWH.Name = "cboWH";
            this.cboWH.Size = new System.Drawing.Size(225, 28);
            this.cboWH.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(30, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 107;
            this.label6.Text = "창고";
            // 
            // lblDeliveryCompany
            // 
            this.lblDeliveryCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliveryCompany.AutoSize = true;
            this.lblDeliveryCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDeliveryCompany.Location = new System.Drawing.Point(877, 64);
            this.lblDeliveryCompany.Name = "lblDeliveryCompany";
            this.lblDeliveryCompany.Size = new System.Drawing.Size(81, 20);
            this.lblDeliveryCompany.TabIndex = 106;
            this.lblDeliveryCompany.Text = "고객주문번호";
            // 
            // cboDestination
            // 
            this.cboDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDestination.FormattingEnabled = true;
            this.cboDestination.Location = new System.Drawing.Point(128, 61);
            this.cboDestination.Name = "cboDestination";
            this.cboDestination.Size = new System.Drawing.Size(225, 28);
            this.cboDestination.TabIndex = 116;
            // 
            // lblWH
            // 
            this.lblWH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWH.AutoSize = true;
            this.lblWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWH.Location = new System.Drawing.Point(450, 64);
            this.lblWH.Name = "lblWH";
            this.lblWH.Size = new System.Drawing.Size(33, 20);
            this.lblWH.TabIndex = 112;
            this.lblWH.Text = "품목";
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCompany.Location = new System.Drawing.Point(877, 23);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(45, 20);
            this.lblCompany.TabIndex = 111;
            this.lblCompany.Text = "고객사";
            // 
            // lblWHing
            // 
            this.lblWHing.AutoSize = true;
            this.lblWHing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWHing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWHing.Location = new System.Drawing.Point(28, 64);
            this.lblWHing.Name = "lblWHing";
            this.lblWHing.Size = new System.Drawing.Size(45, 20);
            this.lblWHing.TabIndex = 109;
            this.lblWHing.Text = "도착지";
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
            this.btnSelect.Location = new System.Drawing.Point(1119, 102);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(65, 32);
            this.btnSelect.TabIndex = 129;
            this.btnSelect.Text = "조회";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExcel);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 33);
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
            this.btnExcel.Location = new System.Drawing.Point(99, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(58, 26);
            this.btnExcel.TabIndex = 40;
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
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(18, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 41;
            this.button1.Text = "마감처리";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(546, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 26);
            this.dateTimePicker1.TabIndex = 130;
            // 
            // ShipmentClosingMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1212, 699);
            this.KeyPreview = true;
            this.Name = "ShipmentClosingMgt";
            this.Tag = "매출마감";
            this.Text = "매출마감";
            this.Load += new System.EventHandler(this.ShipmentClosingMgt_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientOrder)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientOrder;
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblStandardDate;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboWH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDeliveryCompany;
        private System.Windows.Forms.ComboBox cboDestination;
        private System.Windows.Forms.Label lblWH;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblWHing;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
