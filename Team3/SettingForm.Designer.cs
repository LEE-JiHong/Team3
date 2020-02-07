namespace Team3
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoadPlan = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataCollectTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMachineAddress1 = new System.Windows.Forms.TextBox();
            this.txtMachineName1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("나눔바른펜", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(532, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 32);
            this.label8.TabIndex = 113;
            this.label8.Text = "초";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(205, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 33);
            this.button2.TabIndex = 118;
            this.button2.Text = "종료";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(122, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 33);
            this.button1.TabIndex = 117;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnOK);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 33);
            this.panel1.TabIndex = 119;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Team3.Properties.Resources.cross_out1;
            this.button3.Location = new System.Drawing.Point(337, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 23);
            this.button3.TabIndex = 120;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Image = global::Team3.Properties.Resources.edit;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 120;
            this.label1.Text = "설비 세팅";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtLoadPlan);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtDataCollectTime);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtMachineAddress1);
            this.panel2.Controls.Add(this.txtMachineName1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 227);
            this.panel2.TabIndex = 120;
            // 
            // txtLoadPlan
            // 
            this.txtLoadPlan.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLoadPlan.Location = new System.Drawing.Point(170, 148);
            this.txtLoadPlan.Mask = "90:00:00";
            this.txtLoadPlan.Name = "txtLoadPlan";
            this.txtLoadPlan.Size = new System.Drawing.Size(176, 26);
            this.txtLoadPlan.TabIndex = 123;
            this.txtLoadPlan.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("나눔바른펜", 15.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(20, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 32);
            this.label9.TabIndex = 122;
            this.label9.Text = "작업 Load 시간";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataCollectTime
            // 
            this.txtDataCollectTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDataCollectTime.Location = new System.Drawing.Point(170, 115);
            this.txtDataCollectTime.Name = "txtDataCollectTime";
            this.txtDataCollectTime.Size = new System.Drawing.Size(176, 26);
            this.txtDataCollectTime.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("나눔바른펜", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(20, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 32);
            this.label7.TabIndex = 120;
            this.label7.Text = "데이터 수집시간";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMachineAddress1
            // 
            this.txtMachineAddress1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachineAddress1.Location = new System.Drawing.Point(170, 73);
            this.txtMachineAddress1.Name = "txtMachineAddress1";
            this.txtMachineAddress1.Size = new System.Drawing.Size(176, 26);
            this.txtMachineAddress1.TabIndex = 119;
            // 
            // txtMachineName1
            // 
            this.txtMachineName1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachineName1.Location = new System.Drawing.Point(170, 41);
            this.txtMachineName1.Name = "txtMachineName1";
            this.txtMachineName1.Size = new System.Drawing.Size(176, 26);
            this.txtMachineName1.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("나눔바른펜", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 32);
            this.label5.TabIndex = 117;
            this.label5.Text = " IP Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("나눔바른펜", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 32);
            this.label4.TabIndex = 116;
            this.label4.Text = "설비명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(391, 329);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button button3;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtLoadPlan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataCollectTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMachineAddress1;
        private System.Windows.Forms.TextBox txtMachineName1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}