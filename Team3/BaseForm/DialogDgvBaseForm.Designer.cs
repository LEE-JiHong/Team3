namespace Team3
{
    partial class DialogDgvBaseForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblMasterName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(282, 505);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Text = "닫기";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Visible = false;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(70, 19);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(723, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Size = new System.Drawing.Size(722, 416);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(682, 7);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(12, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(699, 87);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.lblMasterName);
            this.panel5.Location = new System.Drawing.Point(12, 140);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(267, 255);
            this.panel5.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Location = new System.Drawing.Point(9, 46);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(247, 194);
            this.panel9.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Location = new System.Drawing.Point(108, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(149, 28);
            this.panel7.TabIndex = 17;
            // 
            // lblMasterName
            // 
            this.lblMasterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterName.ForeColor = System.Drawing.Color.Black;
            this.lblMasterName.Location = new System.Drawing.Point(6, 3);
            this.lblMasterName.Name = "lblMasterName";
            this.lblMasterName.Size = new System.Drawing.Size(61, 19);
            this.lblMasterName.TabIndex = 16;
            this.lblMasterName.Text = "label2";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.lblDetailName);
            this.panel6.Location = new System.Drawing.Point(309, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(402, 255);
            this.panel6.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Location = new System.Drawing.Point(11, 46);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(379, 194);
            this.panel10.TabIndex = 19;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Location = new System.Drawing.Point(239, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(151, 28);
            this.panel8.TabIndex = 19;
            // 
            // lblDetailName
            // 
            this.lblDetailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailName.ForeColor = System.Drawing.Color.Black;
            this.lblDetailName.Location = new System.Drawing.Point(8, 3);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(61, 19);
            this.lblDetailName.TabIndex = 18;
            this.lblDetailName.Text = "label3";
            // 
            // DialogDgvBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(769, 557);
            this.Name = "DialogDgvBaseForm";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel6;
        protected System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.Label lblMasterName;
        protected System.Windows.Forms.Label lblDetailName;
        protected System.Windows.Forms.Panel panel7;
        protected System.Windows.Forms.Panel panel8;
        protected System.Windows.Forms.Panel panel10;
        protected System.Windows.Forms.Panel panel9;
    }
}
