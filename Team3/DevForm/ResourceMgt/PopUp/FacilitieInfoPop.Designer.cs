namespace Team3
{
    partial class FacilitieInfoPop
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodeFacility = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModifyTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNameFacility = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboOkWH = new System.Windows.Forms.ComboBox();
            this.cboUseWH = new System.Windows.Forms.ComboBox();
            this.cboIsUsed = new System.Windows.Forms.ComboBox();
            this.cboNgWH = new System.Windows.Forms.ComboBox();
            this.cboIsOS = new System.Windows.Forms.ComboBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblGrCodeID = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.linePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(309, 405);
            this.panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.TabIndex = 11;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.Text = "설비정보";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(750, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblGrCodeID);
            this.panel2.Controls.Add(this.cboIsOS);
            this.panel2.Controls.Add(this.cboNgWH);
            this.panel2.Controls.Add(this.cboIsUsed);
            this.panel2.Controls.Add(this.cboUseWH);
            this.panel2.Controls.Add(this.cboOkWH);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtNameFacility);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtModifyTime);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.txtCheck);
            this.panel2.Controls.Add(this.txtCodeFacility);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMgrade_code);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(749, 314);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(716, 6);
            // 
            // linePanel
            // 
            this.linePanel.Controls.Add(this.txtModifier);
            this.linePanel.Controls.Add(this.label5);
            this.linePanel.Size = new System.Drawing.Size(796, 455);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "설비군코드";
            // 
            // txtMgrade_code
            // 
            this.txtMgrade_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMgrade_code.Location = new System.Drawing.Point(95, 22);
            this.txtMgrade_code.Name = "txtMgrade_code";
            this.txtMgrade_code.ReadOnly = true;
            this.txtMgrade_code.Size = new System.Drawing.Size(150, 21);
            this.txtMgrade_code.TabIndex = 20;
            this.txtMgrade_code.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(22, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "소진창고";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(22, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "사용유무";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(456, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "수정자";
            this.label5.Visible = false;
            // 
            // txtModifier
            // 
            this.txtModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtModifier.Location = new System.Drawing.Point(517, 57);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(150, 21);
            this.txtModifier.TabIndex = 8;
            this.txtModifier.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(271, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "설비코드";
            // 
            // txtCodeFacility
            // 
            this.txtCodeFacility.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCodeFacility.Location = new System.Drawing.Point(332, 22);
            this.txtCodeFacility.Name = "txtCodeFacility";
            this.txtCodeFacility.Size = new System.Drawing.Size(150, 21);
            this.txtCodeFacility.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(271, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "양품창고";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(503, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "수정시간";
            // 
            // txtModifyTime
            // 
            this.txtModifyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtModifyTime.Location = new System.Drawing.Point(564, 95);
            this.txtModifyTime.Name = "txtModifyTime";
            this.txtModifyTime.ReadOnly = true;
            this.txtModifyTime.Size = new System.Drawing.Size(150, 21);
            this.txtModifyTime.TabIndex = 21;
            this.txtModifyTime.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(503, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "설비명";
            // 
            // txtNameFacility
            // 
            this.txtNameFacility.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNameFacility.Location = new System.Drawing.Point(564, 22);
            this.txtNameFacility.Name = "txtNameFacility";
            this.txtNameFacility.Size = new System.Drawing.Size(150, 21);
            this.txtNameFacility.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(503, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "불량창고";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(271, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "외주여부";
            // 
            // cboOkWH
            // 
            this.cboOkWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboOkWH.FormattingEnabled = true;
            this.cboOkWH.Location = new System.Drawing.Point(332, 56);
            this.cboOkWH.Name = "cboOkWH";
            this.cboOkWH.Size = new System.Drawing.Size(150, 23);
            this.cboOkWH.TabIndex = 4;
            // 
            // cboUseWH
            // 
            this.cboUseWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboUseWH.FormattingEnabled = true;
            this.cboUseWH.Location = new System.Drawing.Point(95, 56);
            this.cboUseWH.Name = "cboUseWH";
            this.cboUseWH.Size = new System.Drawing.Size(150, 23);
            this.cboUseWH.TabIndex = 3;
            // 
            // cboIsUsed
            // 
            this.cboIsUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboIsUsed.FormattingEnabled = true;
            this.cboIsUsed.Location = new System.Drawing.Point(95, 94);
            this.cboIsUsed.Name = "cboIsUsed";
            this.cboIsUsed.Size = new System.Drawing.Size(150, 23);
            this.cboIsUsed.TabIndex = 6;
            // 
            // cboNgWH
            // 
            this.cboNgWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboNgWH.FormattingEnabled = true;
            this.cboNgWH.Location = new System.Drawing.Point(564, 56);
            this.cboNgWH.Name = "cboNgWH";
            this.cboNgWH.Size = new System.Drawing.Size(150, 23);
            this.cboNgWH.TabIndex = 5;
            // 
            // cboIsOS
            // 
            this.cboIsOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboIsOS.FormattingEnabled = true;
            this.cboIsOS.Location = new System.Drawing.Point(332, 94);
            this.cboIsOS.Name = "cboIsOS";
            this.cboIsOS.Size = new System.Drawing.Size(150, 23);
            this.cboIsOS.TabIndex = 7;
            // 
            // txtCheck
            // 
            this.txtCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCheck.Location = new System.Drawing.Point(95, 170);
            this.txtCheck.Multiline = true;
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(621, 50);
            this.txtCheck.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "특이사항";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "비고";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtComment.Location = new System.Drawing.Point(95, 240);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(621, 50);
            this.txtComment.TabIndex = 10;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(657, 64);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 11;
            this.lblID.Visible = false;
            // 
            // lblGrCodeID
            // 
            this.lblGrCodeID.AutoSize = true;
            this.lblGrCodeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrCodeID.Location = new System.Drawing.Point(329, 134);
            this.lblGrCodeID.Name = "lblGrCodeID";
            this.lblGrCodeID.Size = new System.Drawing.Size(0, 15);
            this.lblGrCodeID.TabIndex = 13;
            this.lblGrCodeID.Visible = false;
            // 
            // FacilitieInfoPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(796, 455);
            this.Controls.Add(this.lblID);
            this.Name = "FacilitieInfoPop";
            this.Load += new System.EventHandler(this.FacilitieInfoPop_Load);
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

        private System.Windows.Forms.TextBox txtMgrade_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboIsOS;
        private System.Windows.Forms.ComboBox cboNgWH;
        private System.Windows.Forms.ComboBox cboIsUsed;
        private System.Windows.Forms.ComboBox cboUseWH;
        private System.Windows.Forms.ComboBox cboOkWH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNameFacility;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtModifyTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodeFacility;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblGrCodeID;
    }
}
