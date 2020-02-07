namespace Team3
{
    partial class EditDatePop
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
            this.dtpAsisDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTobeDate = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(93, 200);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Text = "변경";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.Text = "납기일자 변경";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(339, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpTobeDate);
            this.panel2.Controls.Add(this.dtpAsisDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(23, 75);
            this.panel2.Size = new System.Drawing.Size(338, 116);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(300, 7);
            // 
            // panel4
            // 
            this.linePanel.Size = new System.Drawing.Size(385, 259);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "변경할 날짜";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "기존 날짜";
            // 
            // dtpAsisDate
            // 
            this.dtpAsisDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAsisDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAsisDate.Location = new System.Drawing.Point(112, 15);
            this.dtpAsisDate.Name = "dtpAsisDate";
            this.dtpAsisDate.Size = new System.Drawing.Size(200, 26);
            this.dtpAsisDate.TabIndex = 2;
            // 
            // dtpTobeDate
            // 
            this.dtpTobeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTobeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTobeDate.Location = new System.Drawing.Point(112, 63);
            this.dtpTobeDate.Name = "dtpTobeDate";
            this.dtpTobeDate.Size = new System.Drawing.Size(200, 26);
            this.dtpTobeDate.TabIndex = 3;
            this.dtpTobeDate.ValueChanged += new System.EventHandler(this.dtpTobeDate_ValueChanged);
            // 
            // EditDatePop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(385, 259);
            this.Name = "EditDatePop";
            this.Load += new System.EventHandler(this.EditDatePop_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTobeDate;
        private System.Windows.Forms.DateTimePicker dtpAsisDate;
    }
}
