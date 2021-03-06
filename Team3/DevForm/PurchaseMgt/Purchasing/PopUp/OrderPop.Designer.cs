﻿namespace Team3
{
    partial class OrderDialog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.dgvCompany = new System.Windows.Forms.DataGridView();
            this.dgvOrdering = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdering)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(309, 17);
            this.panel6.Size = new System.Drawing.Size(888, 500);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(12, 17);
            this.panel5.Size = new System.Drawing.Size(281, 500);
            // 
            // lblMasterName
            // 
            this.lblMasterName.Image = global::Team3.Properties.Resources.list_menu;
            this.lblMasterName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMasterName.Location = new System.Drawing.Point(9, 18);
            this.lblMasterName.Size = new System.Drawing.Size(79, 19);
            this.lblMasterName.Text = "발주업체";
            this.lblMasterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetailName
            // 
            this.lblDetailName.Image = global::Team3.Properties.Resources.list_menu;
            this.lblDetailName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetailName.Location = new System.Drawing.Point(12, 18);
            this.lblDetailName.Size = new System.Drawing.Size(56, 19);
            this.lblDetailName.Text = "발주";
            this.lblDetailName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(118, 11);
            this.panel7.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.flowLayoutPanel1);
            this.panel8.Location = new System.Drawing.Point(723, 11);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dgvOrdering);
            this.panel10.Size = new System.Drawing.Size(863, 436);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgvCompany);
            this.panel9.Size = new System.Drawing.Size(259, 436);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(485, 633);
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
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.Text = "발주";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(27, 21);
            this.panel1.Size = new System.Drawing.Size(1209, 36);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(27, 85);
            this.panel2.Size = new System.Drawing.Size(1208, 538);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(1168, 7);
            // 
            // linePanel
            // 
            this.linePanel.Size = new System.Drawing.Size(1264, 692);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "업체";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddOrder);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(151, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnAddOrder.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Image = global::Team3.Properties.Resources.Editor_Edit;
            this.btnAddOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrder.Location = new System.Drawing.Point(93, 3);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(55, 23);
            this.btnAddOrder.TabIndex = 70;
            this.btnAddOrder.Text = "발주";
            this.btnAddOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // dgvCompany
            // 
            this.dgvCompany.AllowUserToAddRows = false;
            this.dgvCompany.AllowUserToDeleteRows = false;
            this.dgvCompany.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompany.Location = new System.Drawing.Point(0, 0);
            this.dgvCompany.Name = "dgvCompany";
            this.dgvCompany.RowTemplate.Height = 23;
            this.dgvCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompany.Size = new System.Drawing.Size(259, 436);
            this.dgvCompany.TabIndex = 0;
            this.dgvCompany.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompany_CellValueChanged);
            // 
            // dgvOrdering
            // 
            this.dgvOrdering.AllowUserToAddRows = false;
            this.dgvOrdering.AllowUserToDeleteRows = false;
            this.dgvOrdering.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvOrdering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdering.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.dgvOrdering.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdering.MultiSelect = false;
            this.dgvOrdering.Name = "dgvOrdering";
            this.dgvOrdering.RowTemplate.Height = 23;
            this.dgvOrdering.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdering.Size = new System.Drawing.Size(863, 436);
            this.dgvOrdering.TabIndex = 0;
            this.dgvOrdering.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdering_CellValueChanged);
            this.dgvOrdering.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrdering_DataBindingComplete);
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
            this.btnSearch.Location = new System.Drawing.Point(1106, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 30);
            this.btnSearch.TabIndex = 90;
            this.btnSearch.Text = "조회";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // OrderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1264, 692);
            this.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.Name = "OrderDialog";
            this.Load += new System.EventHandler(this.OrderDialog_Load);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdering)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
       // private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvOrdering;
        private System.Windows.Forms.DataGridView dgvCompany;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnSearch;
    }
}
