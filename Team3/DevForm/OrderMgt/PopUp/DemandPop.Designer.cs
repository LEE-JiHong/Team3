namespace Team3
{
    partial class DemandPop
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
            this.cbOrderGubun = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdoWeekend = new System.Windows.Forms.RadioButton();
            this.rdoWeekday = new System.Windows.Forms.RadioButton();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(173, 443);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.Text = "생산계획생성";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(505, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.cbOrderGubun);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Size = new System.Drawing.Size(504, 352);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(469, 7);
            // 
            // cbOrderGubun
            // 
            this.cbOrderGubun.FormattingEnabled = true;
            this.cbOrderGubun.Location = new System.Drawing.Point(74, 33);
            this.cbOrderGubun.Name = "cbOrderGubun";
            this.cbOrderGubun.Size = new System.Drawing.Size(196, 23);
            this.cbOrderGubun.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "planID";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Image = global::Team3.Properties.Resources.Zoom_16x16;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(419, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 30);
            this.btnSearch.TabIndex = 72;
            this.btnSearch.Text = "조회";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(467, 264);
            this.dataGridView1.TabIndex = 73;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdoWeekend);
            this.panel5.Controls.Add(this.rdoWeekday);
            this.panel5.Location = new System.Drawing.Point(286, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(127, 35);
            this.panel5.TabIndex = 74;
            // 
            // rdoWeekend
            // 
            this.rdoWeekend.AutoSize = true;
            this.rdoWeekend.Location = new System.Drawing.Point(69, 8);
            this.rdoWeekend.Name = "rdoWeekend";
            this.rdoWeekend.Size = new System.Drawing.Size(49, 19);
            this.rdoWeekend.TabIndex = 1;
            this.rdoWeekend.TabStop = true;
            this.rdoWeekend.Text = "주말";
            this.rdoWeekend.UseVisualStyleBackColor = true;
            // 
            // rdoWeekday
            // 
            this.rdoWeekday.AutoSize = true;
            this.rdoWeekday.Location = new System.Drawing.Point(9, 8);
            this.rdoWeekday.Name = "rdoWeekday";
            this.rdoWeekday.Size = new System.Drawing.Size(49, 19);
            this.rdoWeekday.TabIndex = 0;
            this.rdoWeekday.TabStop = true;
            this.rdoWeekday.Text = "주중";
            this.rdoWeekday.UseVisualStyleBackColor = true;
            // 
            // DemandPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(551, 505);
            this.Name = "DemandPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DemandPop_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrderGubun;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdoWeekend;
        private System.Windows.Forms.RadioButton rdoWeekday;
    }
}
