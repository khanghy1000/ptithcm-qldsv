namespace QLDSV.Forms {
    partial class ReportFormPhieuDiemSV {
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
            System.Windows.Forms.Label hOCKYLabel;
            System.Windows.Forms.Label label1;
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.cmbMaSV = new System.Windows.Forms.ComboBox();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            hOCKYLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Location = new System.Drawing.Point(799, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Location = new System.Drawing.Point(799, 75);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 29);
            this.btnPreview.TabIndex = 15;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // hOCKYLabel
            // 
            hOCKYLabel.AutoSize = true;
            hOCKYLabel.Location = new System.Drawing.Point(260, 136);
            hOCKYLabel.Name = "hOCKYLabel";
            hOCKYLabel.Size = new System.Drawing.Size(91, 20);
            hOCKYLabel.TabIndex = 12;
            hOCKYLabel.Text = "Mã sinh viên";
            // 
            // cmbMaSV
            // 
            this.cmbMaSV.FormattingEnabled = true;
            this.cmbMaSV.Location = new System.Drawing.Point(366, 131);
            this.cmbMaSV.Name = "cmbMaSV";
            this.cmbMaSV.Size = new System.Drawing.Size(378, 28);
            this.cmbMaSV.TabIndex = 14;
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Location = new System.Drawing.Point(366, 75);
            this.comboBoxKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(377, 28);
            this.comboBoxKhoa.TabIndex = 10;
            this.comboBoxKhoa.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(308, 80);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 20);
            label1.TabIndex = 17;
            label1.Text = "Khoa";
            // 
            // ReportFormPhieuDiemSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 599);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(hOCKYLabel);
            this.Controls.Add(this.cmbMaSV);
            this.Controls.Add(this.comboBoxKhoa);
            this.Name = "ReportFormPhieuDiemSV";
            this.Text = "ReportFormPhieuDiemSV";
            this.Load += new System.EventHandler(this.ReportFormPhieuDiemSV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.ComboBox cmbMaSV;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
    }
}