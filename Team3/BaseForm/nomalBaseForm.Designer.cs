﻿namespace Team3
{
    partial class nomalBaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nomalBaseForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.basepanel = new System.Windows.Forms.Panel();
            this.TopMenu = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutButton = new System.Windows.Forms.Button();
            this.닫기 = new System.Windows.Forms.Button();
            this.TopMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "layout.png");
            this.imageList1.Images.SetKeyName(2, "closeBlue.png");
            // 
            // basepanel
            // 
            this.basepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basepanel.Location = new System.Drawing.Point(0, 60);
            this.basepanel.Name = "basepanel";
            this.basepanel.Size = new System.Drawing.Size(900, 763);
            this.basepanel.TabIndex = 14;
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.Color.LightBlue;
            this.TopMenu.Controls.Add(this.layoutButton);
            this.TopMenu.Controls.Add(this.닫기);
            this.TopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(900, 60);
            this.TopMenu.TabIndex = 13;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 823);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // layoutButton
            // 
            this.layoutButton.FlatAppearance.BorderSize = 0;
            this.layoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.layoutButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.layoutButton.ImageIndex = 1;
            this.layoutButton.ImageList = this.imageList1;
            this.layoutButton.Location = new System.Drawing.Point(118, 12);
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.Size = new System.Drawing.Size(125, 38);
            this.layoutButton.TabIndex = 12;
            this.layoutButton.Text = "화면병합";
            this.layoutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.layoutButton.UseVisualStyleBackColor = true;
            this.layoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // 닫기
            // 
            this.닫기.BackColor = System.Drawing.Color.Transparent;
            this.닫기.FlatAppearance.BorderSize = 0;
            this.닫기.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.닫기.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.닫기.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.닫기.ImageIndex = 0;
            this.닫기.ImageList = this.imageList1;
            this.닫기.Location = new System.Drawing.Point(12, 12);
            this.닫기.Name = "닫기";
            this.닫기.Size = new System.Drawing.Size(100, 38);
            this.닫기.TabIndex = 4;
            this.닫기.Text = "닫기";
            this.닫기.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.닫기.UseVisualStyleBackColor = false;
            this.닫기.Click += new System.EventHandler(this.닫기_Click);
            // 
            // nomalBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(900, 845);
            this.Controls.Add(this.basepanel);
            this.Controls.Add(this.TopMenu);
            this.Controls.Add(this.statusStrip1);
            this.Name = "nomalBaseForm";
            this.Text = "nomalBaseForm";
            this.TopMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        protected System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Panel TopMenu;
        protected System.Windows.Forms.Button layoutButton;
        protected System.Windows.Forms.Button 닫기;
        protected System.Windows.Forms.Panel basepanel;
    }
}