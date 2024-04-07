namespace QLDSV.Forms {
    partial class TaoTaiKhoanForm {
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
            this.cmbGV = new System.Windows.Forms.ComboBox();
            this.textMAGV = new DevExpress.XtraEditors.TextEdit();
            this.textPass = new DevExpress.XtraEditors.TextEdit();
            this.radioPGV = new System.Windows.Forms.RadioButton();
            this.radioKHOA = new System.Windows.Forms.RadioButton();
            this.radioPKT = new System.Windows.Forms.RadioButton();
            this.btnTaoTK = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaTK = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.textMaTK = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textMAGV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaTK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGV
            // 
            this.cmbGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGV.FormattingEnabled = true;
            this.cmbGV.Location = new System.Drawing.Point(461, 64);
            this.cmbGV.Name = "cmbGV";
            this.cmbGV.Size = new System.Drawing.Size(369, 28);
            this.cmbGV.TabIndex = 0;
            this.cmbGV.SelectedIndexChanged += new System.EventHandler(this.cmbGV_SelectedIndexChanged);
            // 
            // textMAGV
            // 
            this.textMAGV.Enabled = false;
            this.textMAGV.Location = new System.Drawing.Point(861, 64);
            this.textMAGV.Name = "textMAGV";
            this.textMAGV.Size = new System.Drawing.Size(125, 26);
            this.textMAGV.TabIndex = 1;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(461, 166);
            this.textPass.Name = "textPass";
            this.textPass.Properties.UseSystemPasswordChar = true;
            this.textPass.Size = new System.Drawing.Size(525, 26);
            this.textPass.TabIndex = 2;
            // 
            // radioPGV
            // 
            this.radioPGV.AutoSize = true;
            this.radioPGV.Location = new System.Drawing.Point(791, 220);
            this.radioPGV.Name = "radioPGV";
            this.radioPGV.Size = new System.Drawing.Size(57, 24);
            this.radioPGV.TabIndex = 3;
            this.radioPGV.Text = "PGV";
            this.radioPGV.UseVisualStyleBackColor = true;
            // 
            // radioKHOA
            // 
            this.radioKHOA.AutoSize = true;
            this.radioKHOA.Location = new System.Drawing.Point(854, 220);
            this.radioKHOA.Name = "radioKHOA";
            this.radioKHOA.Size = new System.Drawing.Size(71, 24);
            this.radioKHOA.TabIndex = 4;
            this.radioKHOA.Text = "KHOA";
            this.radioKHOA.UseVisualStyleBackColor = true;
            // 
            // radioPKT
            // 
            this.radioPKT.AutoSize = true;
            this.radioPKT.Location = new System.Drawing.Point(931, 220);
            this.radioPKT.Name = "radioPKT";
            this.radioPKT.Size = new System.Drawing.Size(55, 24);
            this.radioPKT.TabIndex = 5;
            this.radioPKT.Text = "PKT";
            this.radioPKT.UseVisualStyleBackColor = true;
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Location = new System.Drawing.Point(519, 273);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(101, 29);
            this.btnTaoTK.TabIndex = 6;
            this.btnTaoTK.Text = "Tạo tài khoản";
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(649, 273);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(106, 29);
            this.btnXoaTK.TabIndex = 7;
            this.btnXoaTK.Text = "Xoá tài khoản";
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Location = new System.Drawing.Point(787, 273);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textMaTK
            // 
            this.textMaTK.Location = new System.Drawing.Point(461, 115);
            this.textMaTK.Name = "textMaTK";
            this.textMaTK.Size = new System.Drawing.Size(525, 26);
            this.textMaTK.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(385, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 20);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Giảng viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(369, 118);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 20);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Mã tài khoản";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(394, 169);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 20);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // TaoTaiKhoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 518);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textMaTK);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.radioPKT);
            this.Controls.Add(this.radioKHOA);
            this.Controls.Add(this.radioPGV);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textMAGV);
            this.Controls.Add(this.cmbGV);
            this.Name = "TaoTaiKhoanForm";
            this.Text = "Tạo tài khoản";
            this.Load += new System.EventHandler(this.TaoTaiKhoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textMAGV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaTK.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGV;
        private DevExpress.XtraEditors.TextEdit textMAGV;
        private DevExpress.XtraEditors.TextEdit textPass;
        private System.Windows.Forms.RadioButton radioPGV;
        private System.Windows.Forms.RadioButton radioKHOA;
        private System.Windows.Forms.RadioButton radioPKT;
        private DevExpress.XtraEditors.SimpleButton btnTaoTK;
        private DevExpress.XtraEditors.SimpleButton btnXoaTK;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.TextEdit textMaTK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}