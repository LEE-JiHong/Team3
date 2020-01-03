namespace Team3
{
    partial class process_control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(process_control));
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 128);
            this.panel2.Size = new System.Drawing.Size(1095, 449);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboName);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Size = new System.Drawing.Size(1095, 83);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 113);
            this.label1.Size = new System.Drawing.Size(122, 12);
            this.label1.Text = "Bill of Resource";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "menulist1.png");
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(1119, 60);
            // 
            // layoutButton
            // 
            this.layoutButton.FlatAppearance.BorderSize = 0;
            // 
            // 닫기
            // 
            this.닫기.FlatAppearance.BorderSize = 0;
            // 
            // basepanel
            // 
            this.basepanel.Controls.Add(this.button3);
            this.basepanel.Controls.Add(this.button2);
            this.basepanel.Controls.Add(this.button1);
            this.basepanel.Size = new System.Drawing.Size(1119, 586);
            this.basepanel.Controls.SetChildIndex(this.panel1, 0);
            this.basepanel.Controls.SetChildIndex(this.panel2, 0);
            this.basepanel.Controls.SetChildIndex(this.label1, 0);
            this.basepanel.Controls.SetChildIndex(this.button1, 0);
            this.basepanel.Controls.SetChildIndex(this.button2, 0);
            this.basepanel.Controls.SetChildIndex(this.button3, 0);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(991, 30);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "조회";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "시설코드/명";
            // 
            // txtName
            // 
            this.txtName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtName.Location = new System.Drawing.Point(105, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 2;
            // 
            // cboName
            // 
            this.cboName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(288, 31);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(121, 20);
            this.cboName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(241, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "시설군";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1095, 449);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 19);
            this.button1.TabIndex = 16;
            this.button1.Text = "등록";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(959, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 19);
            this.button2.TabIndex = 16;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1003, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 19);
            this.button3.TabIndex = 16;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // process_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1119, 668);
            this.Name = "process_control";
            this.Tag = "공장관리";
            this.Text = "공장관리";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
