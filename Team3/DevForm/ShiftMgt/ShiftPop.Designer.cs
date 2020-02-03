namespace Team3
{
    partial class ShiftPop
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
            this.cboM_code = new System.Windows.Forms.ComboBox();
            this.cboShiftID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboYN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUadmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtStime = new System.Windows.Forms.MaskedTextBox();
            this.txtEtime = new System.Windows.Forms.MaskedTextBox();
            this.dtpSdate = new System.Windows.Forms.DateTimePicker();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.lblID = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.TabIndex = 1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Size = new System.Drawing.Size(88, 30);
            this.label1.Text = "ShiftPop";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUadmin);
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Controls.Add(this.dtpEdate);
            this.panel2.Controls.Add(this.dtpSdate);
            this.panel2.Controls.Add(this.txtEtime);
            this.panel2.Controls.Add(this.txtStime);
            this.panel2.Controls.Add(this.cboYN);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboShiftID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboM_code);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtUdate);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "설비코드";
            // 
            // cboM_code
            // 
            this.cboM_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboM_code.FormattingEnabled = true;
            this.cboM_code.Location = new System.Drawing.Point(111, 32);
            this.cboM_code.Name = "cboM_code";
            this.cboM_code.Size = new System.Drawing.Size(145, 23);
            this.cboM_code.TabIndex = 0;
            // 
            // cboShiftID
            // 
            this.cboShiftID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShiftID.FormattingEnabled = true;
            this.cboShiftID.Location = new System.Drawing.Point(401, 32);
            this.cboShiftID.Name = "cboShiftID";
            this.cboShiftID.Size = new System.Drawing.Size(139, 23);
            this.cboShiftID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(312, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shift_ID";
            // 
            // cboYN
            // 
            this.cboYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYN.FormattingEnabled = true;
            this.cboYN.Location = new System.Drawing.Point(111, 165);
            this.cboYN.Name = "cboYN";
            this.cboYN.Size = new System.Drawing.Size(145, 23);
            this.cboYN.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(29, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "사용유무";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(29, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "시작시간";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(312, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "완료시간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(29, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "적용시작일자";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(312, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "적용완료일자";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(312, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "수정자";
            // 
            // txtUadmin
            // 
            this.txtUadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUadmin.Location = new System.Drawing.Point(401, 165);
            this.txtUadmin.Name = "txtUadmin";
            this.txtUadmin.Size = new System.Drawing.Size(139, 21);
            this.txtUadmin.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(312, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "수정시간";
            // 
            // txtUdate
            // 
            this.txtUdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUdate.Location = new System.Drawing.Point(401, 205);
            this.txtUdate.Name = "txtUdate";
            this.txtUdate.ReadOnly = true;
            this.txtUdate.Size = new System.Drawing.Size(139, 21);
            this.txtUdate.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(29, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "비고";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(111, 249);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(429, 95);
            this.txtComment.TabIndex = 9;
            // 
            // txtStime
            // 
            this.txtStime.Location = new System.Drawing.Point(111, 77);
            this.txtStime.Mask = "00:00:00";
            this.txtStime.Name = "txtStime";
            this.txtStime.Size = new System.Drawing.Size(145, 21);
            this.txtStime.TabIndex = 2;
            // 
            // txtEtime
            // 
            this.txtEtime.Location = new System.Drawing.Point(401, 77);
            this.txtEtime.Mask = "90:00:00";
            this.txtEtime.Name = "txtEtime";
            this.txtEtime.Size = new System.Drawing.Size(145, 21);
            this.txtEtime.TabIndex = 3;
            this.txtEtime.ValidatingType = typeof(System.DateTime);
            // 
            // dtpSdate
            // 
            this.dtpSdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSdate.Location = new System.Drawing.Point(111, 123);
            this.dtpSdate.Name = "dtpSdate";
            this.dtpSdate.Size = new System.Drawing.Size(145, 21);
            this.dtpSdate.TabIndex = 4;
            // 
            // dtpEdate
            // 
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEdate.Location = new System.Drawing.Point(401, 123);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(145, 21);
            this.dtpEdate.TabIndex = 5;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(140, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 15);
            this.lblID.TabIndex = 10;
            // 
            // ShiftPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(628, 533);
            this.Name = "ShiftPop";
            this.Load += new System.EventHandler(this.ShiftPop_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboYN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboShiftID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboM_code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUadmin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtStime;
        private System.Windows.Forms.MaskedTextBox txtEtime;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpSdate;
        private System.Windows.Forms.Label lblID;
    }
}
