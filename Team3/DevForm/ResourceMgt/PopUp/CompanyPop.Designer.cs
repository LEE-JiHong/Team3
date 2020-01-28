namespace Team3
{
    partial class CompanyPop
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
            this.txtCodeCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCEO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGtype = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNameCompany = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCnum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbtype = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cboYN = new System.Windows.Forms.ComboBox();
            this.txtUdate = new System.Windows.Forms.TextBox();
            this.cboCompanyType = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrder_code = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(315, 401);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.TabIndex = 20;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.Text = "업체정보";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(762, 36);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboUser);
            this.panel2.Controls.Add(this.cboCompanyType);
            this.panel2.Controls.Add(this.txtUdate);
            this.panel2.Controls.Add(this.cboYN);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtAdmin);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtOrder_code);
            this.panel2.Controls.Add(this.txtFax);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtGtype);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtbtype);
            this.panel2.Controls.Add(this.txtCnum);
            this.panel2.Controls.Add(this.txtCEO);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtNameCompany);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCodeCompany);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(761, 310);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(727, 7);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(45, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "업체코드";
            // 
            // txtCodeCompany
            // 
            this.txtCodeCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCodeCompany.Location = new System.Drawing.Point(103, 22);
            this.txtCodeCompany.Name = "txtCodeCompany";
            this.txtCodeCompany.Size = new System.Drawing.Size(130, 21);
            this.txtCodeCompany.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "대표자명";
            // 
            // txtCEO
            // 
            this.txtCEO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCEO.Location = new System.Drawing.Point(103, 55);
            this.txtCEO.Name = "txtCEO";
            this.txtCEO.Size = new System.Drawing.Size(130, 21);
            this.txtCEO.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "업태";
            // 
            // txtGtype
            // 
            this.txtGtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtGtype.Location = new System.Drawing.Point(103, 88);
            this.txtGtype.Name = "txtGtype";
            this.txtGtype.Size = new System.Drawing.Size(130, 21);
            this.txtGtype.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "전화번호";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPhone.Location = new System.Drawing.Point(103, 121);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(130, 21);
            this.txtPhone.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(265, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "수정시간";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(265, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "업체명";
            // 
            // txtNameCompany
            // 
            this.txtNameCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNameCompany.Location = new System.Drawing.Point(362, 22);
            this.txtNameCompany.Name = "txtNameCompany";
            this.txtNameCompany.Size = new System.Drawing.Size(130, 21);
            this.txtNameCompany.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(265, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "사업자등록번호";
            // 
            // txtCnum
            // 
            this.txtCnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCnum.Location = new System.Drawing.Point(362, 55);
            this.txtCnum.Name = "txtCnum";
            this.txtCnum.Size = new System.Drawing.Size(130, 21);
            this.txtCnum.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(265, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "담당자명";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(265, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "팩스";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtFax.Location = new System.Drawing.Point(362, 121);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(130, 21);
            this.txtFax.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(528, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "사용유무";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Orange;
            this.label16.Location = new System.Drawing.Point(528, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "업체타입";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(528, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "업종";
            // 
            // txtbtype
            // 
            this.txtbtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtbtype.Location = new System.Drawing.Point(589, 55);
            this.txtbtype.Name = "txtbtype";
            this.txtbtype.Size = new System.Drawing.Size(130, 21);
            this.txtbtype.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(528, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "이메일";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtEmail.Location = new System.Drawing.Point(589, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(130, 21);
            this.txtEmail.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(45, 157);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "수정자";
            // 
            // txtAdmin
            // 
            this.txtAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAdmin.Location = new System.Drawing.Point(103, 154);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(130, 21);
            this.txtAdmin.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(45, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "업체정보";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtComment.Location = new System.Drawing.Point(103, 197);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(626, 87);
            this.txtComment.TabIndex = 19;
            // 
            // cboYN
            // 
            this.cboYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboYN.FormattingEnabled = true;
            this.cboYN.Location = new System.Drawing.Point(589, 121);
            this.cboYN.Name = "cboYN";
            this.cboYN.Size = new System.Drawing.Size(130, 23);
            this.cboYN.TabIndex = 16;
            // 
            // txtUdate
            // 
            this.txtUdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUdate.Location = new System.Drawing.Point(362, 154);
            this.txtUdate.Name = "txtUdate";
            this.txtUdate.ReadOnly = true;
            this.txtUdate.Size = new System.Drawing.Size(130, 21);
            this.txtUdate.TabIndex = 23;
            // 
            // cboCompanyType
            // 
            this.cboCompanyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboCompanyType.FormattingEnabled = true;
            this.cboCompanyType.Location = new System.Drawing.Point(589, 22);
            this.cboCompanyType.Name = "cboCompanyType";
            this.cboCompanyType.Size = new System.Drawing.Size(130, 23);
            this.cboCompanyType.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(750, 64);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 4;
            this.lblID.Visible = false;
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(361, 88);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(130, 23);
            this.cboUser.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(528, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "발주코드";
            // 
            // txtOrder_code
            // 
            this.txtOrder_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtOrder_code.Location = new System.Drawing.Point(589, 157);
            this.txtOrder_code.Name = "txtOrder_code";
            this.txtOrder_code.ReadOnly = true;
            this.txtOrder_code.Size = new System.Drawing.Size(130, 21);
            this.txtOrder_code.TabIndex = 13;
            // 
            // CompanyPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(808, 451);
            this.Controls.Add(this.lblID);
            this.Name = "CompanyPop";
            this.Load += new System.EventHandler(this.CompanyPop_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodeCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCEO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtbtype;
        private System.Windows.Forms.TextBox txtCnum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNameCompany;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCompanyType;
        private System.Windows.Forms.TextBox txtUdate;
        private System.Windows.Forms.ComboBox cboYN;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.TextBox txtOrder_code;
        private System.Windows.Forms.Label label5;
    }
}
