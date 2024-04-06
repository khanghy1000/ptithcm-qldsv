namespace QLDSV.Forms {
    partial class NhapDiemForm {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveDiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhapDiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadLTC = new DevExpress.XtraEditors.SimpleButton();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.subscriberDataSet = new QLDSV.subscriberDataSet();
            this.DSLTCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSLTCTableAdapter = new QLDSV.subscriberDataSetTableAdapters.sp_get_ds_ltcTableAdapter();
            this.tableAdapterManager = new QLDSV.subscriberDataSetTableAdapters.TableAdapterManager();
            this.DSLTCGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DSSVDangKyGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSSVDangKy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTenSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemGK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemCK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTK = new DevExpress.XtraGrid.Columns.GridColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSVDangKyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSSVDangKy)).BeginInit();
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
            this.panelControl1.Controls.Add(this.btnSaveDiem);
            this.panelControl1.Controls.Add(this.btnNhapDiem);
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
            this.panelControl1.Size = new System.Drawing.Size(1355, 55);
            this.panelControl1.TabIndex = 0;
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
            // btnSaveDiem
            // 
            this.btnSaveDiem.Enabled = false;
            this.btnSaveDiem.Location = new System.Drawing.Point(1044, 15);
            this.btnSaveDiem.Name = "btnSaveDiem";
            this.btnSaveDiem.Size = new System.Drawing.Size(94, 29);
            this.btnSaveDiem.TabIndex = 32;
            this.btnSaveDiem.Text = "Ghi điểm";
            this.btnSaveDiem.Click += new System.EventHandler(this.btnSaveDiem_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Location = new System.Drawing.Point(923, 15);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(94, 29);
            this.btnNhapDiem.TabIndex = 31;
            this.btnNhapDiem.Text = "Nhập điểm";
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
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
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Location = new System.Drawing.Point(79, 13);
            this.comboBoxKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(287, 28);
            this.comboBoxKhoa.TabIndex = 24;
            this.comboBoxKhoa.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoa_SelectedIndexChanged);
            // 
            // subscriberDataSet
            // 
            this.subscriberDataSet.DataSetName = "subscriberDataSet";
            this.subscriberDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DSLTCBindingSource
            // 
            this.DSLTCBindingSource.DataMember = "sp_get_ds_ltc";
            this.DSLTCBindingSource.DataSource = this.subscriberDataSet;
            // 
            // DSLTCTableAdapter
            // 
            this.DSLTCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DANGKYTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.LOPTINCHITableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV.subscriberDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DSLTCGridControl
            // 
            this.DSLTCGridControl.DataSource = this.DSLTCBindingSource;
            this.DSLTCGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DSLTCGridControl.Location = new System.Drawing.Point(0, 55);
            this.DSLTCGridControl.MainView = this.gridView1;
            this.DSLTCGridControl.Name = "DSLTCGridControl";
            this.DSLTCGridControl.Size = new System.Drawing.Size(1355, 340);
            this.DSLTCGridControl.TabIndex = 3;
            this.DSLTCGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colTENMH,
            this.colNHOM,
            this.colHOTENGV});
            this.gridView1.GridControl = this.DSLTCGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colMALTC
            // 
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.MinWidth = 25;
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            this.colMALTC.Width = 94;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 25;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            this.colTENMH.Width = 94;
            // 
            // colNHOM
            // 
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.MinWidth = 25;
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 2;
            this.colNHOM.Width = 94;
            // 
            // colHOTENGV
            // 
            this.colHOTENGV.FieldName = "HOTENGV";
            this.colHOTENGV.MinWidth = 25;
            this.colHOTENGV.Name = "colHOTENGV";
            this.colHOTENGV.Visible = true;
            this.colHOTENGV.VisibleIndex = 3;
            this.colHOTENGV.Width = 94;
            // 
            // DSSVDangKyGridControl
            // 
            this.DSSVDangKyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DSSVDangKyGridControl.Location = new System.Drawing.Point(0, 395);
            this.DSSVDangKyGridControl.MainView = this.gridViewDSSVDangKy;
            this.DSSVDangKyGridControl.Name = "DSSVDangKyGridControl";
            this.DSSVDangKyGridControl.Size = new System.Drawing.Size(1355, 348);
            this.DSSVDangKyGridControl.TabIndex = 4;
            this.DSSVDangKyGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSSVDangKy});
            // 
            // gridViewDSSVDangKy
            // 
            this.gridViewDSSVDangKy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSV,
            this.colHoTenSV,
            this.colDiemCC,
            this.colDiemGK,
            this.colDiemCK,
            this.colDiemTK});
            this.gridViewDSSVDangKy.GridControl = this.DSSVDangKyGridControl;
            this.gridViewDSSVDangKy.Name = "gridViewDSSVDangKy";
            this.gridViewDSSVDangKy.OptionsBehavior.ReadOnly = true;
            // 
            // colMaSV
            // 
            this.colMaSV.Caption = "Mã SV";
            this.colMaSV.FieldName = "MASV";
            this.colMaSV.MinWidth = 25;
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.OptionsColumn.ReadOnly = true;
            this.colMaSV.Visible = true;
            this.colMaSV.VisibleIndex = 0;
            this.colMaSV.Width = 94;
            // 
            // colHoTenSV
            // 
            this.colHoTenSV.Caption = "Họ tên SV";
            this.colHoTenSV.FieldName = "HOTENSV";
            this.colHoTenSV.MinWidth = 25;
            this.colHoTenSV.Name = "colHoTenSV";
            this.colHoTenSV.OptionsColumn.ReadOnly = true;
            this.colHoTenSV.Visible = true;
            this.colHoTenSV.VisibleIndex = 1;
            this.colHoTenSV.Width = 94;
            // 
            // colDiemCC
            // 
            this.colDiemCC.Caption = "Điểm CC";
            this.colDiemCC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemCC.FieldName = "DIEM_CC";
            this.colDiemCC.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemCC.MinWidth = 25;
            this.colDiemCC.Name = "colDiemCC";
            this.colDiemCC.Visible = true;
            this.colDiemCC.VisibleIndex = 2;
            this.colDiemCC.Width = 94;
            // 
            // colDiemGK
            // 
            this.colDiemGK.Caption = "Điểm GK";
            this.colDiemGK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemGK.FieldName = "DIEM_GK";
            this.colDiemGK.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemGK.MinWidth = 25;
            this.colDiemGK.Name = "colDiemGK";
            this.colDiemGK.Visible = true;
            this.colDiemGK.VisibleIndex = 3;
            this.colDiemGK.Width = 94;
            // 
            // colDiemCK
            // 
            this.colDiemCK.Caption = "Điểm CK";
            this.colDiemCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemCK.FieldName = "DIEM_CK";
            this.colDiemCK.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemCK.MinWidth = 25;
            this.colDiemCK.Name = "colDiemCK";
            this.colDiemCK.Visible = true;
            this.colDiemCK.VisibleIndex = 4;
            this.colDiemCK.Width = 94;
            // 
            // colDiemTK
            // 
            this.colDiemTK.Caption = "Điểm TK";
            this.colDiemTK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemTK.FieldName = "colDiemTK";
            this.colDiemTK.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiemTK.MinWidth = 25;
            this.colDiemTK.Name = "colDiemTK";
            this.colDiemTK.OptionsColumn.ReadOnly = true;
            this.colDiemTK.UnboundDataType = typeof(double);
            this.colDiemTK.UnboundExpression = "0.1 * [DIEM_CC] + 0.3 * [DIEM_GK] + 0.6 * [DIEM_CK]";
            this.colDiemTK.Visible = true;
            this.colDiemTK.VisibleIndex = 5;
            this.colDiemTK.Width = 94;
            // 
            // NhapDiemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 743);
            this.Controls.Add(this.DSSVDangKyGridControl);
            this.Controls.Add(this.DSLTCGridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "NhapDiemForm";
            this.Text = "Nhập điểm";
            this.Load += new System.EventHandler(this.DangKyLTCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLTCGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSVDangKyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSSVDangKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private DevExpress.XtraEditors.SimpleButton btnLoadLTC;
        private DevExpress.XtraEditors.SimpleButton btnNhapDiem;
        private DevExpress.XtraEditors.SimpleButton btnSaveDiem;
        private subscriberDataSet subscriberDataSet;
        private System.Windows.Forms.BindingSource DSLTCBindingSource;
        private subscriberDataSetTableAdapters.sp_get_ds_ltcTableAdapter DSLTCTableAdapter;
        private subscriberDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl DSLTCGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENGV;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.GridControl DSSVDangKyGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSSVDangKy;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSV;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTenSV;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemCC;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemGK;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTK;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemCK;
    }
}