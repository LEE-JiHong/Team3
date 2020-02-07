namespace Team3.WorkOrder
{
    partial class Business_showingsPop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Business_showingsPop));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel9.SuspendLayout();
            this.linePanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGrid1Name
            // 
            this.lblGrid1Name.Image = ((System.Drawing.Image)(resources.GetObject("lblGrid1Name.Image")));
            this.lblGrid1Name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGrid1Name.Location = new System.Drawing.Point(6, 4);
            this.lblGrid1Name.Size = new System.Drawing.Size(79, 24);
            this.lblGrid1Name.Text = "실적등록";
            this.lblGrid1Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.flowLayoutPanel1);
            this.panel9.Location = new System.Drawing.Point(657, -1);
            // 
            // lblGrid2Name
            // 
            this.lblGrid2Name.Image = ((System.Drawing.Image)(resources.GetObject("lblGrid2Name.Image")));
            this.lblGrid2Name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGrid2Name.Location = new System.Drawing.Point(7, 7);
            this.lblGrid2Name.Size = new System.Drawing.Size(106, 27);
            this.lblGrid2Name.Text = "실적등록이력";
            this.lblGrid2Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Location = new System.Drawing.Point(6, 27);
            this.panel6.Size = new System.Drawing.Size(962, 99);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataGridView2);
            this.panel8.Location = new System.Drawing.Point(6, 32);
            this.panel8.Size = new System.Drawing.Size(962, 184);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(457, 518);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            // 
            // label1
            // 
            this.label1.Text = "작업마감실적등록";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 99);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(962, 184);
            this.dataGridView2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(316, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Image = global::Team3.Properties.Resources.Trash_16x16;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(231, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(82, 23);
            this.btnDel.TabIndex = 54;
            this.btnDel.Text = "실적취소";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // Business_showingsPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1066, 568);
            this.Name = "Business_showingsPop";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel9.ResumeLayout(false);
            this.linePanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnDel;
    }
}
