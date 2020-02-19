namespace Team3
{
    partial class FacilitiesPop
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
            this.txtMgrade_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMgrade_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMgrade_uadmin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMgrade_udate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMgrade_comment = new System.Windows.Forms.TextBox();
            this.cboYN = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.linePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(103, 427);
            this.panel3.TabIndex = 1;
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
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Size = new System.Drawing.Size(101, 36);
            this.label1.Text = "설비군정보";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(365, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboYN);
            this.panel2.Controls.Add(this.txtMgrade_comment);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtMgrade_udate);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMgrade_name);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMgrade_code);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(364, 338);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(332, 5);
            // 
            // linePanel
            // 
            this.linePanel.Controls.Add(this.txtMgrade_uadmin);
            this.linePanel.Controls.Add(this.label5);
            this.linePanel.Size = new System.Drawing.Size(411, 479);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(50, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "설비군 코드";
            // 
            // txtMgrade_code
            // 
            this.txtMgrade_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_code.Location = new System.Drawing.Point(145, 45);
            this.txtMgrade_code.Name = "txtMgrade_code";
            this.txtMgrade_code.Size = new System.Drawing.Size(172, 21);
            this.txtMgrade_code.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(50, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "설비군 명";
            // 
            // txtMgrade_name
            // 
            this.txtMgrade_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_name.Location = new System.Drawing.Point(145, 83);
            this.txtMgrade_name.Name = "txtMgrade_name";
            this.txtMgrade_name.Size = new System.Drawing.Size(172, 21);
            this.txtMgrade_name.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(50, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "사용유무";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(73, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "수정자";
            this.label5.Visible = false;
            // 
            // txtMgrade_uadmin
            // 
            this.txtMgrade_uadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_uadmin.Location = new System.Drawing.Point(168, 57);
            this.txtMgrade_uadmin.Name = "txtMgrade_uadmin";
            this.txtMgrade_uadmin.Size = new System.Drawing.Size(172, 21);
            this.txtMgrade_uadmin.TabIndex = 3;
            this.txtMgrade_uadmin.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(50, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "수정시간";
            // 
            // txtMgrade_udate
            // 
            this.txtMgrade_udate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_udate.Location = new System.Drawing.Point(145, 159);
            this.txtMgrade_udate.Name = "txtMgrade_udate";
            this.txtMgrade_udate.ReadOnly = true;
            this.txtMgrade_udate.Size = new System.Drawing.Size(172, 21);
            this.txtMgrade_udate.TabIndex = 15;
            this.txtMgrade_udate.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(50, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "시설설명";
            // 
            // txtMgrade_comment
            // 
            this.txtMgrade_comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_comment.Location = new System.Drawing.Point(53, 218);
            this.txtMgrade_comment.Multiline = true;
            this.txtMgrade_comment.Name = "txtMgrade_comment";
            this.txtMgrade_comment.Size = new System.Drawing.Size(264, 71);
            this.txtMgrade_comment.TabIndex = 4;
            // 
            // cboYN
            // 
            this.cboYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboYN.FormattingEnabled = true;
            this.cboYN.Location = new System.Drawing.Point(145, 121);
            this.cboYN.Name = "cboYN";
            this.cboYN.Size = new System.Drawing.Size(172, 23);
            this.cboYN.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(247, 67);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 4;
            this.lblID.Visible = false;
            // 
            // FacilitiesPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(411, 479);
            this.Controls.Add(this.lblID);
            this.Name = "FacilitiesPop";
            this.Load += new System.EventHandler(this.FacilitiesPop_Load);
            this.Controls.SetChildIndex(this.linePanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.linePanel.ResumeLayout(false);
            this.linePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMgrade_udate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMgrade_uadmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMgrade_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMgrade_code;
        private System.Windows.Forms.TextBox txtMgrade_comment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboYN;
        private System.Windows.Forms.Label lblID;
    }
}
