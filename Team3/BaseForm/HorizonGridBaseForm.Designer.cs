namespace Team3
{
    partial class HorizonGridBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorizonGridBaseForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TopMenu.SuspendLayout();
            this.basepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Size = new System.Drawing.Size(941, 60);
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
            this.basepanel.Controls.Add(this.panel5);
            this.basepanel.Controls.Add(this.panel4);
            this.basepanel.Controls.Add(this.panel3);
            this.basepanel.Controls.Add(this.label1);
            this.basepanel.Controls.Add(this.panel1);
            this.basepanel.Controls.Add(this.panel2);
            this.basepanel.Size = new System.Drawing.Size(941, 454);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 316);
            this.panel2.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(13, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 73);
            this.panel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(404, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 316);
            this.panel3.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(172, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 29);
            this.panel4.TabIndex = 28;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Location = new System.Drawing.Point(623, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(306, 29);
            this.panel5.TabIndex = 29;
            // 
            // HorizonGridBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 536);
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(910, 575);
            this.Name = "HorizonGridBaseForm";
            this.Text = "HorizonGridBaseForm";
            this.Load += new System.EventHandler(this.HorizonGridBaseForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HorizonGridBaseForm_KeyUp);
            this.TopMenu.ResumeLayout(false);
            this.basepanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Panel panel4;
    }
}