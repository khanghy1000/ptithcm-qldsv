namespace QLDSV.Forms {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelUsername = new DevExpress.XtraEditors.LabelControl();
            this.labelPassword = new DevExpress.XtraEditors.LabelControl();
            this.labelKhoa = new DevExpress.XtraEditors.LabelControl();
            this.textUsername = new DevExpress.XtraEditors.TextEdit();
            this.textPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.checkIsSinhVien = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.panelComboBoxKhoaWrapper = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.textUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSinhVien.Properties)).BeginInit();
            this.panelComboBoxKhoaWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Appearance.Options.UseFont = true;
            this.labelTitle.Location = new System.Drawing.Point(137, 34);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(181, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Đăng nhập";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelUsername.Appearance.Options.UseFont = true;
            this.labelUsername.Location = new System.Drawing.Point(48, 182);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(72, 21);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Tài khoản";
            // 
            // labelPassword
            // 
            this.labelPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelPassword.Appearance.Options.UseFont = true;
            this.labelPassword.Location = new System.Drawing.Point(48, 257);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(68, 21);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Mật khẩu";
            // 
            // labelKhoa
            // 
            this.labelKhoa.Appearance.BackColor = System.Drawing.Color.White;
            this.labelKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelKhoa.Appearance.Options.UseBackColor = true;
            this.labelKhoa.Appearance.Options.UseFont = true;
            this.labelKhoa.Location = new System.Drawing.Point(48, 107);
            this.labelKhoa.Name = "labelKhoa";
            this.labelKhoa.Size = new System.Drawing.Size(37, 21);
            this.labelKhoa.TabIndex = 3;
            this.labelKhoa.Text = "Khoa";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(48, 209);
            this.textUsername.Name = "textUsername";
            this.textUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.textUsername.Properties.Appearance.Options.UseFont = true;
            this.textUsername.Size = new System.Drawing.Size(366, 28);
            this.textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            this.textPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPassword.Location = new System.Drawing.Point(48, 278);
            this.textPassword.Name = "textPassword";
            this.textPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.textPassword.Properties.Appearance.Options.UseFont = true;
            this.textPassword.Properties.UseSystemPasswordChar = true;
            this.textPassword.Size = new System.Drawing.Size(366, 28);
            this.textPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F);
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(48, 379);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(366, 62);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(48, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(366, 62);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkIsSinhVien
            // 
            this.checkIsSinhVien.Location = new System.Drawing.Point(302, 318);
            this.checkIsSinhVien.Name = "checkIsSinhVien";
            this.checkIsSinhVien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.checkIsSinhVien.Properties.Appearance.Options.UseFont = true;
            this.checkIsSinhVien.Properties.Caption = "Là sinh viên";
            this.checkIsSinhVien.Size = new System.Drawing.Size(146, 25);
            this.checkIsSinhVien.TabIndex = 9;
            this.checkIsSinhVien.CheckedChanged += new System.EventHandler(this.checkIsSinhVien_CheckedChanged);
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxKhoa.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.IntegralHeight = false;
            this.comboBoxKhoa.Location = new System.Drawing.Point(0, 0);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(364, 29);
            this.comboBoxKhoa.TabIndex = 10;
            this.comboBoxKhoa.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoa_SelectedIndexChanged);
            // 
            // panelComboBoxKhoaWrapper
            // 
            this.panelComboBoxKhoaWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComboBoxKhoaWrapper.Controls.Add(this.comboBoxKhoa);
            this.panelComboBoxKhoaWrapper.Location = new System.Drawing.Point(48, 134);
            this.panelComboBoxKhoaWrapper.Name = "panelComboBoxKhoaWrapper";
            this.panelComboBoxKhoaWrapper.Size = new System.Drawing.Size(366, 29);
            this.panelComboBoxKhoaWrapper.TabIndex = 11;
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 565);
            this.Controls.Add(this.panelComboBoxKhoaWrapper);
            this.Controls.Add(this.checkIsSinhVien);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelKhoa);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.IconOptions.ImageUri.Uri = "icon%20builder/security_key";
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSinhVien.Properties)).EndInit();
            this.panelComboBoxKhoaWrapper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelTitle;
        private DevExpress.XtraEditors.LabelControl labelUsername;
        private DevExpress.XtraEditors.LabelControl labelPassword;
        private DevExpress.XtraEditors.LabelControl labelKhoa;
        private DevExpress.XtraEditors.TextEdit textUsername;
        private DevExpress.XtraEditors.TextEdit textPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit checkIsSinhVien;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private System.Windows.Forms.Panel panelComboBoxKhoaWrapper;
    }
}
