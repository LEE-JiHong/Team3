namespace Team3
{
    partial class SODialog
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSOWO = new System.Windows.Forms.TextBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtCancel = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.dtpsDate = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(255, 502);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.Text = "S/O";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpsDate);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.txtOrder);
            this.panel2.Controls.Add(this.txtCancel);
            this.panel2.Controls.Add(this.txtOutput);
            this.panel2.Controls.Add(this.cbProduct);
            this.panel2.Controls.Add(this.cbDestination);
            this.panel2.Controls.Add(this.cbCompany);
            this.panel2.Controls.Add(this.txtSOWO);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(26, 105);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Size = new System.Drawing.Size(664, 383);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            // 
            // linePanel
            // 
            this.linePanel.Size = new System.Drawing.Size(718, 582);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "고객WO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "고객사";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(16, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "납기일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "출고수량";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "비고";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(336, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 17;
            this.label13.Text = "취소수량";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(336, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 18);
            this.label14.TabIndex = 16;
            this.label14.Text = "주문수량";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Orange;
            this.label15.Location = new System.Drawing.Point(336, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 18);
            this.label15.TabIndex = 15;
            this.label15.Text = "품목";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(336, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 18);
            this.label16.TabIndex = 14;
            this.label16.Text = "도착지";
            // 
            // txtSOWO
            // 
            this.txtSOWO.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtSOWO.Location = new System.Drawing.Point(94, 29);
            this.txtSOWO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSOWO.Name = "txtSOWO";
            this.txtSOWO.Size = new System.Drawing.Size(223, 24);
            this.txtSOWO.TabIndex = 19;
            // 
            // cbCompany
            // 
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(94, 70);
            this.cbCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(223, 26);
            this.cbCompany.TabIndex = 21;
            // 
            // cbDestination
            // 
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Location = new System.Drawing.Point(427, 70);
            this.cbDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(223, 26);
            this.cbDestination.TabIndex = 22;
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(427, 29);
            this.cbProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(223, 26);
            this.cbProduct.TabIndex = 24;
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtOutput.Location = new System.Drawing.Point(94, 162);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(223, 24);
            this.txtOutput.TabIndex = 26;
            // 
            // txtCancel
            // 
            this.txtCancel.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtCancel.Location = new System.Drawing.Point(427, 162);
            this.txtCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(223, 24);
            this.txtCancel.TabIndex = 27;
            this.txtCancel.TextChanged += new System.EventHandler(this.txtCancel_TextChanged);
            // 
            // txtOrder
            // 
            this.txtOrder.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtOrder.Location = new System.Drawing.Point(427, 116);
            this.txtOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(223, 24);
            this.txtOrder.TabIndex = 28;
            this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrder_KeyPress);
            // 
            // txtComment
            // 
            this.txtComment.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtComment.Location = new System.Drawing.Point(94, 209);
            this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(557, 155);
            this.txtComment.TabIndex = 32;
            // 
            // dtpsDate
            // 
            this.dtpsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpsDate.Location = new System.Drawing.Point(94, 115);
            this.dtpsDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpsDate.Name = "dtpsDate";
            this.dtpsDate.Size = new System.Drawing.Size(223, 24);
            this.dtpsDate.TabIndex = 33;
            // 
            // SODialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(718, 582);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SODialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SODialog_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.TextBox txtCancel;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.TextBox txtSOWO;
        private System.Windows.Forms.DateTimePicker dtpsDate;
    }
}
