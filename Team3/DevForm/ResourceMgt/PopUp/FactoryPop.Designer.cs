namespace Team3
{
    partial class FactoryPop
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
            this.cbofacilitiesGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDivFacility = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodeFacility = new System.Windows.Forms.TextBox();
            this.txtModifyTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboIsUsed = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNameFacility = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtInfoFacility = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboHigh = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(200, 420);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.TabIndex = 15;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.Text = "공장정보";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(558, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cboCompany);
            this.panel2.Controls.Add(this.txtModifier);
            this.panel2.Controls.Add(this.txtInfoFacility);
            this.panel2.Controls.Add(this.txtModifyTime);
            this.panel2.Controls.Add(this.txtNameFacility);
            this.panel2.Controls.Add(this.txtCodeFacility);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cboIsUsed);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cboHigh);
            this.panel2.Controls.Add(this.cboDivFacility);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbofacilitiesGroup);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Size = new System.Drawing.Size(557, 331);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(560, 7);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(27, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "시설군";
            // 
            // cbofacilitiesGroup
            // 
            this.cbofacilitiesGroup.FormattingEnabled = true;
            this.cbofacilitiesGroup.Location = new System.Drawing.Point(90, 24);
            this.cbofacilitiesGroup.Name = "cbofacilitiesGroup";
            this.cbofacilitiesGroup.Size = new System.Drawing.Size(150, 23);
            this.cbofacilitiesGroup.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(275, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "시설코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(275, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "시설구분";
            // 
            // cboDivFacility
            // 
            this.cboDivFacility.FormattingEnabled = true;
            this.cboDivFacility.Location = new System.Drawing.Point(353, 99);
            this.cboDivFacility.Name = "cboDivFacility";
            this.cboDivFacility.Size = new System.Drawing.Size(150, 23);
            this.cboDivFacility.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(275, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "수정시간";
            // 
            // txtCodeFacility
            // 
            this.txtCodeFacility.Location = new System.Drawing.Point(353, 62);
            this.txtCodeFacility.Name = "txtCodeFacility";
            this.txtCodeFacility.Size = new System.Drawing.Size(150, 21);
            this.txtCodeFacility.TabIndex = 2;
            // 
            // txtModifyTime
            // 
            this.txtModifyTime.Location = new System.Drawing.Point(353, 177);
            this.txtModifyTime.Name = "txtModifyTime";
            this.txtModifyTime.Size = new System.Drawing.Size(150, 21);
            this.txtModifyTime.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(27, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "시설명";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "업체";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(275, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "수정자";
            // 
            // cboIsUsed
            // 
            this.cboIsUsed.FormattingEnabled = true;
            this.cboIsUsed.Location = new System.Drawing.Point(90, 145);
            this.cboIsUsed.Name = "cboIsUsed";
            this.cboIsUsed.Size = new System.Drawing.Size(150, 23);
            this.cboIsUsed.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Orange;
            this.label15.Location = new System.Drawing.Point(12, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 0;
            this.label15.Text = "사용유무";
            // 
            // txtNameFacility
            // 
            this.txtNameFacility.Location = new System.Drawing.Point(90, 64);
            this.txtNameFacility.Name = "txtNameFacility";
            this.txtNameFacility.Size = new System.Drawing.Size(150, 21);
            this.txtNameFacility.TabIndex = 3;
            // 
            // txtModifier
            // 
            this.txtModifier.Location = new System.Drawing.Point(353, 138);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(150, 21);
            this.txtModifier.TabIndex = 11;
            // 
            // cboCompany
            // 
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(90, 102);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(150, 23);
            this.cboCompany.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(29, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 18);
            this.label16.TabIndex = 6;
            this.label16.Text = "시설설명";
            // 
            // txtInfoFacility
            // 
            this.txtInfoFacility.Location = new System.Drawing.Point(90, 213);
            this.txtInfoFacility.Multiline = true;
            this.txtInfoFacility.Name = "txtInfoFacility";
            this.txtInfoFacility.Size = new System.Drawing.Size(413, 79);
            this.txtInfoFacility.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(275, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "상위시설";
            // 
            // cboHigh
            // 
            this.cboHigh.FormattingEnabled = true;
            this.cboHigh.Location = new System.Drawing.Point(353, 24);
            this.cboHigh.Name = "cboHigh";
            this.cboHigh.Size = new System.Drawing.Size(150, 23);
            this.cboHigh.TabIndex = 4;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(551, 70);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 12);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "lblID";
            // 
            // FactoryPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(604, 472);
            this.Controls.Add(this.lblID);
            this.Name = "FactoryPop";
            this.Text = "공장정보";
            this.Load += new System.EventHandler(this.FactoryPop_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.TextBox txtInfoFacility;
        private System.Windows.Forms.TextBox txtModifyTime;
        private System.Windows.Forms.TextBox txtNameFacility;
        private System.Windows.Forms.TextBox txtCodeFacility;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIsUsed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboDivFacility;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbofacilitiesGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHigh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
    }
}
