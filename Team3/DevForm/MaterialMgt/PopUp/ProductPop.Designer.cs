namespace Team3
{
    partial class ProductPop
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtLeastOrder = new System.Windows.Forms.TextBox();
            this.txtUdate = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cboProductUnit = new System.Windows.Forms.ComboBox();
            this.cboInSector = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUnitAmount = new System.Windows.Forms.TextBox();
            this.cboSupplyCompany = new System.Windows.Forms.ComboBox();
            this.cboOutSector = new System.Windows.Forms.ComboBox();
            this.cboAdmin = new System.Windows.Forms.ComboBox();
            this.cboIsUsed = new System.Windows.Forms.ComboBox();
            this.cboOrderType = new System.Windows.Forms.ComboBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboDemandCompany = new System.Windows.Forms.ComboBox();
            this.txtLeadTime = new System.Windows.Forms.TextBox();
            this.txtSafetyAmount = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtProductLsl = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtProductUsl = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.cboMeasType = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(242, 447);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.Text = "품목";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(642, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboMeasType);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.txtProductUsl);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.txtProductLsl);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.txtProductCode);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.txtItemCode);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.txtSafetyAmount);
            this.panel2.Controls.Add(this.txtLeadTime);
            this.panel2.Controls.Add(this.cboProductType);
            this.panel2.Controls.Add(this.cboOrderType);
            this.panel2.Controls.Add(this.cboDemandCompany);
            this.panel2.Controls.Add(this.cboIsUsed);
            this.panel2.Controls.Add(this.cboAdmin);
            this.panel2.Controls.Add(this.cboOutSector);
            this.panel2.Controls.Add(this.cboSupplyCompany);
            this.panel2.Controls.Add(this.txtUnitAmount);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Controls.Add(this.cboInSector);
            this.panel2.Controls.Add(this.cboProductUnit);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.txtUdate);
            this.panel2.Controls.Add(this.txtLeastOrder);
            this.panel2.Controls.Add(this.txtProduct);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(641, 358);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(601, 7);
            // 
            // linePanel
            // 
            this.linePanel.Size = new System.Drawing.Size(688, 499);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "품목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(425, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "단위";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "입고창고";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "최소발주수량";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(223, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "수정일";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(224, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "품명";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(425, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 11;
            this.label13.Text = "단위수량";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(425, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 13;
            this.label15.Text = "납품업체";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(223, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 18);
            this.label16.TabIndex = 14;
            this.label16.Text = "출고창고";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(425, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 18);
            this.label18.TabIndex = 16;
            this.label18.Text = "담당자";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Orange;
            this.label20.Location = new System.Drawing.Point(223, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 18);
            this.label20.TabIndex = 18;
            this.label20.Text = "사용여부";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(16, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 18);
            this.label21.TabIndex = 19;
            this.label21.Text = "발주방식";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Orange;
            this.label23.Location = new System.Drawing.Point(425, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 18);
            this.label23.TabIndex = 21;
            this.label23.Text = "품목유형";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(223, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 18);
            this.label25.TabIndex = 23;
            this.label25.Text = "발주업체";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(17, 82);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(86, 18);
            this.label26.TabIndex = 24;
            this.label26.Text = "Lead Time";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(425, 111);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 18);
            this.label27.TabIndex = 25;
            this.label27.Text = "안전재고수량";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(16, 228);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 18);
            this.label31.TabIndex = 29;
            this.label31.Text = "비고";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(102, 15);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 21);
            this.txtProduct.TabIndex = 30;
            // 
            // txtLeastOrder
            // 
            this.txtLeastOrder.Location = new System.Drawing.Point(102, 138);
            this.txtLeastOrder.Name = "txtLeastOrder";
            this.txtLeastOrder.Size = new System.Drawing.Size(100, 21);
            this.txtLeastOrder.TabIndex = 31;
            this.txtLeastOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUdate
            // 
            this.txtUdate.Enabled = false;
            this.txtUdate.Location = new System.Drawing.Point(309, 137);
            this.txtUdate.Name = "txtUdate";
            this.txtUdate.Size = new System.Drawing.Size(100, 21);
            this.txtUdate.TabIndex = 31;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(102, 228);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(509, 111);
            this.txtComment.TabIndex = 33;
            // 
            // cboProductUnit
            // 
            this.cboProductUnit.FormattingEnabled = true;
            this.cboProductUnit.Location = new System.Drawing.Point(511, 78);
            this.cboProductUnit.Name = "cboProductUnit";
            this.cboProductUnit.Size = new System.Drawing.Size(100, 23);
            this.cboProductUnit.TabIndex = 34;
            // 
            // cboInSector
            // 
            this.cboInSector.FormattingEnabled = true;
            this.cboInSector.Location = new System.Drawing.Point(102, 108);
            this.cboInSector.Name = "cboInSector";
            this.cboInSector.Size = new System.Drawing.Size(100, 23);
            this.cboInSector.TabIndex = 37;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(309, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(100, 21);
            this.txtProductName.TabIndex = 40;
            // 
            // txtUnitAmount
            // 
            this.txtUnitAmount.Location = new System.Drawing.Point(511, 192);
            this.txtUnitAmount.Name = "txtUnitAmount";
            this.txtUnitAmount.Size = new System.Drawing.Size(100, 21);
            this.txtUnitAmount.TabIndex = 41;
            this.txtUnitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboSupplyCompany
            // 
            this.cboSupplyCompany.FormattingEnabled = true;
            this.cboSupplyCompany.Location = new System.Drawing.Point(511, 43);
            this.cboSupplyCompany.Name = "cboSupplyCompany";
            this.cboSupplyCompany.Size = new System.Drawing.Size(100, 23);
            this.cboSupplyCompany.TabIndex = 44;
            // 
            // cboOutSector
            // 
            this.cboOutSector.FormattingEnabled = true;
            this.cboOutSector.Location = new System.Drawing.Point(309, 110);
            this.cboOutSector.Name = "cboOutSector";
            this.cboOutSector.Size = new System.Drawing.Size(100, 23);
            this.cboOutSector.TabIndex = 45;
            // 
            // cboAdmin
            // 
            this.cboAdmin.FormattingEnabled = true;
            this.cboAdmin.Location = new System.Drawing.Point(511, 138);
            this.cboAdmin.Name = "cboAdmin";
            this.cboAdmin.Size = new System.Drawing.Size(100, 23);
            this.cboAdmin.TabIndex = 46;
            // 
            // cboIsUsed
            // 
            this.cboIsUsed.FormattingEnabled = true;
            this.cboIsUsed.Location = new System.Drawing.Point(309, 78);
            this.cboIsUsed.Name = "cboIsUsed";
            this.cboIsUsed.Size = new System.Drawing.Size(100, 23);
            this.cboIsUsed.TabIndex = 48;
            // 
            // cboOrderType
            // 
            this.cboOrderType.FormattingEnabled = true;
            this.cboOrderType.Location = new System.Drawing.Point(102, 45);
            this.cboOrderType.Name = "cboOrderType";
            this.cboOrderType.Size = new System.Drawing.Size(100, 23);
            this.cboOrderType.TabIndex = 49;
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(511, 14);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(100, 23);
            this.cboProductType.TabIndex = 50;
            // 
            // cboDemandCompany
            // 
            this.cboDemandCompany.FormattingEnabled = true;
            this.cboDemandCompany.Location = new System.Drawing.Point(309, 44);
            this.cboDemandCompany.Name = "cboDemandCompany";
            this.cboDemandCompany.Size = new System.Drawing.Size(100, 23);
            this.cboDemandCompany.TabIndex = 52;
            // 
            // txtLeadTime
            // 
            this.txtLeadTime.Location = new System.Drawing.Point(102, 80);
            this.txtLeadTime.Name = "txtLeadTime";
            this.txtLeadTime.Size = new System.Drawing.Size(100, 21);
            this.txtLeadTime.TabIndex = 56;
            // 
            // txtSafetyAmount
            // 
            this.txtSafetyAmount.Location = new System.Drawing.Point(511, 108);
            this.txtSafetyAmount.Name = "txtSafetyAmount";
            this.txtSafetyAmount.Size = new System.Drawing.Size(100, 21);
            this.txtSafetyAmount.TabIndex = 57;
            this.txtSafetyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(102, 192);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(100, 21);
            this.txtItemCode.TabIndex = 63;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(16, 192);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 18);
            this.label33.TabIndex = 62;
            this.label33.Text = "아이템코드";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(309, 192);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 21);
            this.txtProductCode.TabIndex = 65;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(223, 190);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 18);
            this.label34.TabIndex = 64;
            this.label34.Text = "품명코드";
            // 
            // txtProductLsl
            // 
            this.txtProductLsl.Location = new System.Drawing.Point(102, 165);
            this.txtProductLsl.Name = "txtProductLsl";
            this.txtProductLsl.Size = new System.Drawing.Size(100, 21);
            this.txtProductLsl.TabIndex = 67;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(16, 165);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(78, 18);
            this.label35.TabIndex = 66;
            this.label35.Text = "품목 최솟값";
            // 
            // txtProductUsl
            // 
            this.txtProductUsl.Location = new System.Drawing.Point(309, 165);
            this.txtProductUsl.Name = "txtProductUsl";
            this.txtProductUsl.Size = new System.Drawing.Size(100, 21);
            this.txtProductUsl.TabIndex = 69;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(223, 168);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(78, 18);
            this.label36.TabIndex = 68;
            this.label36.Text = "품목 최댓값";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(425, 165);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 18);
            this.label37.TabIndex = 70;
            this.label37.Text = "측정방식";
            // 
            // cboMeasType
            // 
            this.cboMeasType.FormattingEnabled = true;
            this.cboMeasType.Location = new System.Drawing.Point(511, 165);
            this.cboMeasType.Name = "cboMeasType";
            this.cboMeasType.Size = new System.Drawing.Size(100, 23);
            this.cboMeasType.TabIndex = 72;
            // 
            // ProductPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(688, 499);
            this.Name = "ProductPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProductPop_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSafetyAmount;
        private System.Windows.Forms.TextBox txtLeadTime;
        private System.Windows.Forms.ComboBox cboDemandCompany;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboOrderType;
        private System.Windows.Forms.ComboBox cboIsUsed;
        private System.Windows.Forms.ComboBox cboAdmin;
        private System.Windows.Forms.ComboBox cboOutSector;
        private System.Windows.Forms.ComboBox cboSupplyCompany;
        private System.Windows.Forms.TextBox txtUnitAmount;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cboInSector;
        private System.Windows.Forms.ComboBox cboProductUnit;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtUdate;
        private System.Windows.Forms.TextBox txtLeastOrder;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtProductUsl;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtProductLsl;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cboMeasType;
    }
}
