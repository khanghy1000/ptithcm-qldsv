namespace QLDSV.Forms {
    partial class DangKyLTCForm {
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
            System.Windows.Forms.Label label1;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveDK = new DevExpress.XtraEditors.SimpleButton();
            this.btnDangKy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadLTC = new DevExpress.XtraEditors.SimpleButton();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.subscriberDataSet = new QLDSV.subscriberDataSet();
            this.DSLTCGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSVDADANGKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDANGKY = new DevExpress.XtraGrid.Columns.GridColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 20);
            label1.TabIndex = 25;
            label1.Text = "Khoa";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnSaveDK);
            this.panelControl1.Controls.Add(this.btnDangKy);
            this.panelControl1.Controls.Add(this.btnLoadLTC);
            this.panelControl1.Controls.Add(this.cmbHocKy);
            this.panelControl1.Controls.Add(this.cmbNienKhoa);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(label1);
            this.panelControl1.Controls.Add(this.comboBoxKhoa);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1325, 55);
            this.panelControl1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Location = new System.Drawing.Point(1167, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveDK
            // 
            this.btnSaveDK.Enabled = false;
            this.btnSaveDK.Location = new System.Drawing.Point(1044, 15);
            this.btnSaveDK.Name = "btnSaveDK";
            this.btnSaveDK.Size = new System.Drawing.Size(94, 29);
            this.btnSaveDK.TabIndex = 32;
            this.btnSaveDK.Text = "Ghi";
            this.btnSaveDK.Click += new System.EventHandler(this.btnSaveDK_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(923, 15);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(94, 29);
            this.btnDangKy.TabIndex = 31;
            this.btnDangKy.Text = "Bắt đầu";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnLoadLTC
            // 
            this.btnLoadLTC.Location = new System.Drawing.Point(790, 15);
            this.btnLoadLTC.Name = "btnLoadLTC";
            this.btnLoadLTC.Size = new System.Drawing.Size(106, 29);
            this.btnLoadLTC.TabIndex = 30;
            this.btnLoadLTC.Text = "Tải lớp tín chỉ";
            this.btnLoadLTC.Click += new System.EventHandler(this.btnLoadLTC_Click);
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Location = new System.Drawing.Point(682, 15);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(79, 28);
            this.cmbHocKy.TabIndex = 29;
            this.cmbHocKy.SelectedIndexChanged += new System.EventHandler(this.cmbHocKy_SelectedIndexChanged);
            // 
            // cmbNienKhoa
            // 
            this.cmbNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNienKhoa.FormattingEnabled = true;
            this.cmbNienKhoa.Location = new System.Drawing.Point(470, 14);
            this.cmbNienKhoa.Name = "cmbNienKhoa";
            this.cmbNienKhoa.Size = new System.Drawing.Size(121, 28);
            this.cmbNienKhoa.TabIndex = 28;
            this.cmbNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbNienKhoa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Niên khoá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Học kỳ";
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhoa.Enabled = false;
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Location = new System.Drawing.Point(79, 13);
            this.comboBoxKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(287, 28);
            this.comboBoxKhoa.TabIndex = 24;
            // 
            // subscriberDataSet
            // 
            this.subscriberDataSet.DataSetName = "subscriberDataSet";
            this.subscriberDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DSLTCGridControl
            // 
            this.DSLTCGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DSLTCGridControl.Location = new System.Drawing.Point(0, 55);
            this.DSLTCGridControl.MainView = this.gridView1;
            this.DSLTCGridControl.Name = "DSLTCGridControl";
            this.DSLTCGridControl.Size = new System.Drawing.Size(1325, 522);
            this.DSLTCGridControl.TabIndex = 2;
            this.DSLTCGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colMAMH,
            this.colTENMH,
            this.colNHOM,
            this.colHOTENGV,
            this.colSOSVDADANGKY,
            this.colDANGKY});
            this.gridView1.GridControl = this.DSLTCGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMALTC
            // 
            this.colMALTC.Caption = "MALTC";
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.MinWidth = 25;
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.OptionsColumn.ReadOnly = true;
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            this.colMALTC.Width = 94;
            // 
            // colMAMH
            // 
            this.colMAMH.Caption = "MAMH";
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 25;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.OptionsColumn.ReadOnly = true;
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            this.colMAMH.Width = 94;
            // 
            // colTENMH
            // 
            this.colTENMH.Caption = "TENMH";
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 25;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.OptionsColumn.ReadOnly = true;
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 2;
            this.colTENMH.Width = 94;
            // 
            // colNHOM
            // 
            this.colNHOM.Caption = "NHOM";
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.MinWidth = 25;
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.OptionsColumn.ReadOnly = true;
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 3;
            this.colNHOM.Width = 94;
            // 
            // colHOTENGV
            // 
            this.colHOTENGV.Caption = "HOTENGV";
            this.colHOTENGV.FieldName = "HOTENGV";
            this.colHOTENGV.MinWidth = 25;
            this.colHOTENGV.Name = "colHOTENGV";
            this.colHOTENGV.OptionsColumn.ReadOnly = true;
            this.colHOTENGV.Visible = true;
            this.colHOTENGV.VisibleIndex = 4;
            this.colHOTENGV.Width = 94;
            // 
            // colSOSVDADANGKY
            // 
            this.colSOSVDADANGKY.Caption = "SOSVDADANGKY";
            this.colSOSVDADANGKY.FieldName = "SOSVDADANGKY";
            this.colSOSVDADANGKY.MinWidth = 25;
            this.colSOSVDADANGKY.Name = "colSOSVDADANGKY";
            this.colSOSVDADANGKY.OptionsColumn.ReadOnly = true;
            this.colSOSVDADANGKY.Visible = true;
            this.colSOSVDADANGKY.VisibleIndex = 5;
            this.colSOSVDADANGKY.Width = 94;
            // 
            // colDANGKY
            // 
            this.colDANGKY.Caption = "DANGKY";
            this.colDANGKY.FieldName = "DANGKY";
            this.colDANGKY.MinWidth = 25;
            this.colDANGKY.Name = "colDANGKY";
            this.colDANGKY.OptionsColumn.ReadOnly = true;
            this.colDANGKY.Visible = true;
            this.colDANGKY.VisibleIndex = 6;
            this.colDANGKY.Width = 94;
            // 
            // DangKyLTCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 577);
            this.Controls.Add(this.DSLTCGridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "DangKyLTCForm";
            this.Text = "Đăng ký lớp tín chỉ";
            this.Load += new System.EventHandler(this.DangKyLTCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnSaveDK;
        private DevExpress.XtraEditors.SimpleButton btnDangKy;
        private DevExpress.XtraEditors.SimpleButton btnLoadLTC;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private subscriberDataSet subscriberDataSet;
        private DevExpress.XtraGrid.GridControl DSLTCGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENGV;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSVDADANGKY;
        private DevExpress.XtraGrid.Columns.GridColumn colDANGKY;
    }
}