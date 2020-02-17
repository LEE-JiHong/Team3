namespace Team3
{
    partial class BomPop
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
            this.lblTopProd = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboParentProduct = new System.Windows.Forms.ComboBox();
            this.cboAutoDeduction = new System.Windows.Forms.ComboBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.cboIsUsed = new System.Windows.Forms.ComboBox();
            this.cboRequiredPlan = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.txtModifyDate = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUseCount = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(197, 387);
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
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.Text = "BOM";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(552, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUseCount);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.txtModifyDate);
            this.panel2.Controls.Add(this.txtNote);
            this.panel2.Controls.Add(this.txtModifier);
            this.panel2.Controls.Add(this.dtpEndDate);
            this.panel2.Controls.Add(this.cboRequiredPlan);
            this.panel2.Controls.Add(this.cboIsUsed);
            this.panel2.Controls.Add(this.cboProduct);
            this.panel2.Controls.Add(this.cboParentProduct);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbl);
            this.panel2.Controls.Add(this.lblTopProd);
            this.panel2.Size = new System.Drawing.Size(551, 298);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(511, 7);
            // 
            // linePanel
            // 
            this.linePanel.Size = new System.Drawing.Size(598, 439);
            // 
            // lblTopProd
            // 
            this.lblTopProd.AutoSize = true;
            this.lblTopProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopProd.ForeColor = System.Drawing.Color.Orange;
            this.lblTopProd.Location = new System.Drawing.Point(16, 15);
            this.lblTopProd.Name = "lblTopProd";
            this.lblTopProd.Size = new System.Drawing.Size(55, 15);
            this.lblTopProd.TabIndex = 0;
            this.lblTopProd.Text = "상위품목";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Orange;
            this.lbl.Location = new System.Drawing.Point(16, 75);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(43, 15);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "소요량";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(285, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "종료일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "수정자";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(4, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "자동차감";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "비고";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(286, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "품목";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(17, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "사용유무";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(286, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "수정일";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(286, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "소요계획";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(17, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "시작일";
            // 
            // cboParentProduct
            // 
            this.cboParentProduct.FormattingEnabled = true;
            this.cboParentProduct.Location = new System.Drawing.Point(92, 12);
            this.cboParentProduct.Name = "cboParentProduct";
            this.cboParentProduct.Size = new System.Drawing.Size(168, 23);
            this.cboParentProduct.TabIndex = 12;
            // 
            // cboAutoDeduction
            // 
            this.cboAutoDeduction.FormattingEnabled = true;
            this.cboAutoDeduction.Location = new System.Drawing.Point(80, 20);
            this.cboAutoDeduction.Name = "cboAutoDeduction";
            this.cboAutoDeduction.Size = new System.Drawing.Size(168, 20);
            this.cboAutoDeduction.TabIndex = 13;
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(361, 12);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(168, 23);
            this.cboProduct.TabIndex = 14;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // cboIsUsed
            // 
            this.cboIsUsed.FormattingEnabled = true;
            this.cboIsUsed.Location = new System.Drawing.Point(92, 131);
            this.cboIsUsed.Name = "cboIsUsed";
            this.cboIsUsed.Size = new System.Drawing.Size(168, 23);
            this.cboIsUsed.TabIndex = 15;
            // 
            // cboRequiredPlan
            // 
            this.cboRequiredPlan.FormattingEnabled = true;
            this.cboRequiredPlan.Location = new System.Drawing.Point(361, 72);
            this.cboRequiredPlan.Name = "cboRequiredPlan";
            this.cboRequiredPlan.Size = new System.Drawing.Size(168, 23);
            this.cboRequiredPlan.TabIndex = 16;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(361, 41);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(168, 21);
            this.dtpEndDate.TabIndex = 17;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(92, 162);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(437, 113);
            this.txtNote.TabIndex = 21;
            // 
            // txtModifier
            // 
            this.txtModifier.Enabled = false;
            this.txtModifier.Location = new System.Drawing.Point(92, 102);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(168, 21);
            this.txtModifier.TabIndex = 20;
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Enabled = false;
            this.txtModifyDate.Location = new System.Drawing.Point(361, 102);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(168, 21);
            this.txtModifyDate.TabIndex = 23;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(92, 41);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(168, 21);
            this.dtpStartDate.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAutoDeduction);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(762, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtUseCount
            // 
            this.txtUseCount.Location = new System.Drawing.Point(92, 75);
            this.txtUseCount.Name = "txtUseCount";
            this.txtUseCount.Size = new System.Drawing.Size(168, 21);
            this.txtUseCount.TabIndex = 25;
            // 
            // BomPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(598, 439);
            this.Controls.Add(this.groupBox1);
            this.Name = "BomPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BomPop_Load);
            this.Controls.SetChildIndex(this.linePanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTopProd;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtModifyDate;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cboRequiredPlan;
        private System.Windows.Forms.ComboBox cboIsUsed;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboAutoDeduction;
        private System.Windows.Forms.ComboBox cboParentProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUseCount;
    }
}
