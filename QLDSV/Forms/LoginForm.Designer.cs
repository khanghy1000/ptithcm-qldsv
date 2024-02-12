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
            labelTitle = new DevExpress.XtraEditors.LabelControl();
            labelUsername = new DevExpress.XtraEditors.LabelControl();
            labelPassword = new DevExpress.XtraEditors.LabelControl();
            labelKhoa = new DevExpress.XtraEditors.LabelControl();
            textUsername = new DevExpress.XtraEditors.TextEdit();
            textPassword = new DevExpress.XtraEditors.TextEdit();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            checkIsSinhVien = new DevExpress.XtraEditors.CheckEdit();
            comboBoxKhoa = new System.Windows.Forms.ComboBox();
            panelComboBoxKhoaWrapper = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)textUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkIsSinhVien.Properties).BeginInit();
            panelComboBoxKhoaWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8000011F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.Appearance.Options.UseFont = true;
            labelTitle.Location = new System.Drawing.Point(137, 34);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(184, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Đăng nhập";
            labelTitle.Click += labelTitle_Click;
            // 
            // labelUsername
            // 
            labelUsername.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelUsername.Appearance.Options.UseFont = true;
            labelUsername.Location = new System.Drawing.Point(48, 182);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(72, 21);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Tài khoản";
            // 
            // labelPassword
            // 
            labelPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelPassword.Appearance.Options.UseFont = true;
            labelPassword.Location = new System.Drawing.Point(48, 261);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(68, 21);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Mật khẩu";
            // 
            // labelKhoa
            // 
            labelKhoa.Appearance.BackColor = System.Drawing.Color.White;
            labelKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelKhoa.Appearance.Options.UseBackColor = true;
            labelKhoa.Appearance.Options.UseFont = true;
            labelKhoa.Location = new System.Drawing.Point(48, 107);
            labelKhoa.Name = "labelKhoa";
            labelKhoa.Size = new System.Drawing.Size(37, 21);
            labelKhoa.TabIndex = 3;
            labelKhoa.Text = "Khoa";
            // 
            // textUsername
            // 
            textUsername.Location = new System.Drawing.Point(48, 209);
            textUsername.Name = "textUsername";
            textUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textUsername.Properties.Appearance.Options.UseFont = true;
            textUsername.Size = new System.Drawing.Size(366, 28);
            textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            textPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            textPassword.Location = new System.Drawing.Point(48, 288);
            textPassword.Name = "textPassword";
            textPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textPassword.Properties.Appearance.Options.UseFont = true;
            textPassword.Properties.UseSystemPasswordChar = true;
            textPassword.Size = new System.Drawing.Size(366, 28);
            textPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnLogin.Appearance.Options.UseBackColor = true;
            btnLogin.Appearance.Options.UseFont = true;
            btnLogin.Location = new System.Drawing.Point(48, 386);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(366, 62);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Location = new System.Drawing.Point(48, 466);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(366, 62);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Thoát";
            btnCancel.Click += btnCancel_Click;
            // 
            // checkIsSinhVien
            // 
            checkIsSinhVien.Location = new System.Drawing.Point(305, 339);
            checkIsSinhVien.Name = "checkIsSinhVien";
            checkIsSinhVien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkIsSinhVien.Properties.Appearance.Options.UseFont = true;
            checkIsSinhVien.Properties.Caption = "Là sinh viên";
            checkIsSinhVien.Size = new System.Drawing.Size(146, 25);
            checkIsSinhVien.TabIndex = 9;
            checkIsSinhVien.CheckedChanged += checkIsSinhVien_CheckedChanged;
            // 
            // comboBoxKhoa
            // 
            comboBoxKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBoxKhoa.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxKhoa.FormattingEnabled = true;
            comboBoxKhoa.IntegralHeight = false;
            comboBoxKhoa.Location = new System.Drawing.Point(0, 0);
            comboBoxKhoa.Name = "comboBoxKhoa";
            comboBoxKhoa.Size = new System.Drawing.Size(364, 29);
            comboBoxKhoa.TabIndex = 10;
            comboBoxKhoa.SelectedIndexChanged += comboBoxKhoa_SelectedIndexChanged;
            // 
            // panelComboBoxKhoaWrapper
            // 
            panelComboBoxKhoaWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelComboBoxKhoaWrapper.Controls.Add(comboBoxKhoa);
            panelComboBoxKhoaWrapper.Location = new System.Drawing.Point(48, 134);
            panelComboBoxKhoaWrapper.Name = "panelComboBoxKhoaWrapper";
            panelComboBoxKhoaWrapper.Size = new System.Drawing.Size(366, 29);
            panelComboBoxKhoaWrapper.TabIndex = 11;
            // 
            // LoginForm
            // 
            Appearance.BackColor = System.Drawing.Color.White;
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(460, 577);
            Controls.Add(panelComboBoxKhoaWrapper);
            Controls.Add(checkIsSinhVien);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(textPassword);
            Controls.Add(textUsername);
            Controls.Add(labelKhoa);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(labelTitle);
            Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IconOptions.ImageUri.Uri = "icon%20builder/security_key";
            Margin = new System.Windows.Forms.Padding(4);
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)textUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkIsSinhVien.Properties).EndInit();
            panelComboBoxKhoaWrapper.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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