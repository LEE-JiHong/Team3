namespace Team3
{
    partial class Materials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materials));
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblDeliveryCompany = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWHing = new System.Windows.Forms.Label();
            this.lblStandard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblWH = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtStandard = new System.Windows.Forms.TextBox();
            this.txtDeliveryCompany = new System.Windows.Forms.ComboBox();
            this.cboPutWH = new System.Windows.Forms.ComboBox();
            this.cboPerson = new System.Windows.Forms.ComboBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.cboPullWH = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnFormDownload = new System.Windows.Forms.Button();
            this.btnAddExcel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.panel2.Size = new System.Drawing.Size(1185, 268);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.comboBox7);
            this.panel1.Controls.Add(this.cboPullWH);
            this.panel1.Controls.Add(this.cboCompany);
            this.panel1.Controls.Add(this.cboProductType);
            this.panel1.Controls.Add(this.cboPerson);
            this.panel1.Controls.Add(this.cboPutWH);
            this.panel1.Controls.Add(this.txtDeliveryCompany);
            this.panel1.Controls.Add(this.txtStandard);
            this.panel1.Controls.Add(this.txtProduct);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblWH);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblWHing);
            this.panel1.Controls.Add(this.lblStandard);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblDeliveryCompany);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Size = new System.Drawing.Size(1185, 116);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.Text = "품목정보";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(773, 138);
            this.panel3.Size = new System.Drawing.Size(424, 29);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            this.imageList1.Images.SetKeyName(3, "copy-document.png");
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(1209, 60);
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
            this.basepanel.Size = new System.Drawing.Size(1209, 454);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProduct.Location = new System.Drawing.Point(37, 13);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(31, 15);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "품목";
            // 
            // lblDeliveryCompany
            // 
            this.lblDeliveryCompany.AutoSize = true;
            this.lblDeliveryCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDeliveryCompany.Location = new System.Drawing.Point(13, 52);
            this.lblDeliveryCompany.Name = "lblDeliveryCompany";
            this.lblDeliveryCompany.Size = new System.Drawing.Size(55, 15);
            this.lblDeliveryCompany.TabIndex = 1;
            this.lblDeliveryCompany.Text = "납품업체";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(25, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "담당자";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(362, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "품목유형";
            // 
            // lblWHing
            // 
            this.lblWHing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWHing.AutoSize = true;
            this.lblWHing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWHing.Location = new System.Drawing.Point(362, 52);
            this.lblWHing.Name = "lblWHing";
            this.lblWHing.Size = new System.Drawing.Size(53, 12);
            this.lblWHing.TabIndex = 4;
            this.lblWHing.Text = "입고창고";
            // 
            // lblStandard
            // 
            this.lblStandard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandard.Location = new System.Drawing.Point(386, 13);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(29, 12);
            this.lblStandard.TabIndex = 3;
            this.lblStandard.Text = "규격";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(738, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "사용유무";
            // 
            // lblWH
            // 
            this.lblWH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWH.AutoSize = true;
            this.lblWH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWH.Location = new System.Drawing.Point(738, 52);
            this.lblWH.Name = "lblWH";
            this.lblWH.Size = new System.Drawing.Size(53, 12);
            this.lblWH.TabIndex = 7;
            this.lblWH.Text = "출고창고";
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.AutoSize = true;
            this.lblCompany.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCompany.Location = new System.Drawing.Point(762, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(29, 12);
            this.lblCompany.TabIndex = 6;
            this.lblCompany.Text = "업체";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(113, 10);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(225, 21);
            this.txtProduct.TabIndex = 9;
            // 
            // txtStandard
            // 
            this.txtStandard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStandard.Location = new System.Drawing.Point(468, 10);
            this.txtStandard.Name = "txtStandard";
            this.txtStandard.Size = new System.Drawing.Size(230, 21);
            this.txtStandard.TabIndex = 10;
            // 
            // txtDeliveryCompany
            // 
            this.txtDeliveryCompany.FormattingEnabled = true;
            this.txtDeliveryCompany.Location = new System.Drawing.Point(113, 49);
            this.txtDeliveryCompany.Name = "txtDeliveryCompany";
            this.txtDeliveryCompany.Size = new System.Drawing.Size(225, 20);
            this.txtDeliveryCompany.TabIndex = 11;
            // 
            // cboPutWH
            // 
            this.cboPutWH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboPutWH.FormattingEnabled = true;
            this.cboPutWH.Location = new System.Drawing.Point(468, 49);
            this.cboPutWH.Name = "cboPutWH";
            this.cboPutWH.Size = new System.Drawing.Size(230, 20);
            this.cboPutWH.TabIndex = 12;
            // 
            // cboPerson
            // 
            this.cboPerson.FormattingEnabled = true;
            this.cboPerson.Location = new System.Drawing.Point(113, 87);
            this.cboPerson.Name = "cboPerson";
            this.cboPerson.Size = new System.Drawing.Size(225, 20);
            this.cboPerson.TabIndex = 13;
            // 
            // cboProductType
            // 
            this.cboProductType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(468, 87);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(230, 20);
            this.cboProductType.TabIndex = 14;
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(835, 11);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(209, 20);
            this.cboCompany.TabIndex = 15;
            // 
            // cboPullWH
            // 
            this.cboPullWH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPullWH.FormattingEnabled = true;
            this.cboPullWH.Location = new System.Drawing.Point(835, 49);
            this.cboPullWH.Name = "cboPullWH";
            this.cboPullWH.Size = new System.Drawing.Size(209, 20);
            this.cboPullWH.TabIndex = 16;
            // 
            // comboBox7
            // 
            this.comboBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(835, 87);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(209, 20);
            this.comboBox7.TabIndex = 17;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.Location = new System.Drawing.Point(1065, 87);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 23);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // dgvProductList
            // 
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 0);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 23;
            this.dgvProductList.Size = new System.Drawing.Size(1185, 268);
            this.dgvProductList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(5, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCopy.Location = new System.Drawing.Point(86, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 21;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExcel.Location = new System.Drawing.Point(167, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Text = "엑셀";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnFormDownload
            // 
            this.btnFormDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormDownload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFormDownload.Location = new System.Drawing.Point(248, 3);
            this.btnFormDownload.Name = "btnFormDownload";
            this.btnFormDownload.Size = new System.Drawing.Size(92, 23);
            this.btnFormDownload.TabIndex = 23;
            this.btnFormDownload.Text = "양식 다운로드";
            this.btnFormDownload.UseVisualStyleBackColor = true;
            // 
            // btnAddExcel
            // 
            this.btnAddExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddExcel.Location = new System.Drawing.Point(346, 3);
            this.btnAddExcel.Name = "btnAddExcel";
            this.btnAddExcel.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcel.TabIndex = 24;
            this.btnAddExcel.Text = "Excel 등록";
            this.btnAddExcel.UseVisualStyleBackColor = true;
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1209, 536);
            this.Name = "Materials";
            this.Tag = "품목정보";
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

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox cboPullWH;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboPerson;
        private System.Windows.Forms.ComboBox cboPutWH;
        private System.Windows.Forms.ComboBox txtDeliveryCompany;
        private System.Windows.Forms.TextBox txtStandard;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblWH;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWHing;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDeliveryCompany;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Button btnAddExcel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnFormDownload;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
