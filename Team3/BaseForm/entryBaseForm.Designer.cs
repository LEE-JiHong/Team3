﻿namespace Team3
{
    partial class entryBaseForm
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
            this.SuspendLayout();
            // 
            // entryBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(900, 873);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "entryBaseForm";
            this.Text = "entryBaseForm";
            this.Load += new System.EventHandler(this.entryBaseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}