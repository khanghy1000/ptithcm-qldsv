namespace QLDSV.Forms {
    partial class DoiMatKhauForm {
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textOldPass = new DevExpress.XtraEditors.TextEdit();
            this.textNewPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textPassConfirm = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textOldPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNewPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassConfirm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(416, 118);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mật khẩu cũ";
            // 
            // textOldPass
            // 
            this.textOldPass.Location = new System.Drawing.Point(502, 115);
            this.textOldPass.Name = "textOldPass";
            this.textOldPass.Properties.UseSystemPasswordChar = true;
            this.textOldPass.Size = new System.Drawing.Size(293, 26);
            this.textOldPass.TabIndex = 1;
            // 
            // textNewPass
            // 
            this.textNewPass.Location = new System.Drawing.Point(502, 164);
            this.textNewPass.Name = "textNewPass";
            this.textNewPass.Properties.UseSystemPasswordChar = true;
            this.textNewPass.Size = new System.Drawing.Size(293, 26);
            this.textNewPass.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(405, 167);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu mới";
            // 
            // textPassConfirm
            // 
            this.textPassConfirm.Location = new System.Drawing.Point(502, 214);
            this.textPassConfirm.Name = "textPassConfirm";
            this.textPassConfirm.Properties.UseSystemPasswordChar = true;
            this.textPassConfirm.Size = new System.Drawing.Size(293, 26);
            this.textPassConfirm.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(375, 217);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Nhập lại mật khẩu";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(516, 285);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 29);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Location = new System.Drawing.Point(642, 285);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DoiMatKhauForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 621);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textPassConfirm);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textNewPass);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textOldPass);
            this.Controls.Add(this.labelControl1);
            this.Name = "DoiMatKhauForm";
            this.Text = "DoiMatKhauForm";
            this.Load += new System.EventHandler(this.DoiMatKhauForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textOldPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNewPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassConfirm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textOldPass;
        private DevExpress.XtraEditors.TextEdit textNewPass;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textPassConfirm;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}