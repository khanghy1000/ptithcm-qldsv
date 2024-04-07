namespace QLDSV.Forms {
    partial class LopForm {
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
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label kHOAHOCLabel;
            System.Windows.Forms.Label mAKHOALabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LopForm));
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.subscriberDataSet = new QLDSV.subscriberDataSet();
            this.LOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LOPTableAdapter = new QLDSV.subscriberDataSetTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new QLDSV.subscriberDataSetTableAdapters.TableAdapterManager();
            this.LOPGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewLOP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENLOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHOAHOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SINHVIENGridControl = new DevExpress.XtraGrid.GridControl();
            this.SINHVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewSINHVIEN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDANGHIHOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAKHOATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.KHOAHOCTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TENLOPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MALOPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSvAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.SINHVIENTableAdapter = new QLDSV.subscriberDataSetTableAdapters.SINHVIENTableAdapter();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelSinhVien = new DevExpress.XtraEditors.PanelControl();
            this.panelLopInput = new DevExpress.XtraEditors.PanelControl();
            this.DANGKYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DANGKYTableAdapter = new QLDSV.subscriberDataSetTableAdapters.DANGKYTableAdapter();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            mALOPLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            kHOAHOCLabel = new System.Windows.Forms.Label();
            mAKHOALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOPGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSINHVIEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MAKHOATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHOAHOCTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENLOPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MALOPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSinhVien)).BeginInit();
            this.panelSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLopInput)).BeginInit();
            this.panelLopInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DANGKYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(30, 68);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(60, 20);
            mALOPLabel.TabIndex = 0;
            mALOPLabel.Text = "MALOP:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Location = new System.Drawing.Point(24, 102);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(64, 20);
            tENLOPLabel.TabIndex = 2;
            tENLOPLabel.Text = "TENLOP:";
            // 
            // kHOAHOCLabel
            // 
            kHOAHOCLabel.AutoSize = true;
            kHOAHOCLabel.Location = new System.Drawing.Point(10, 138);
            kHOAHOCLabel.Name = "kHOAHOCLabel";
            kHOAHOCLabel.Size = new System.Drawing.Size(84, 20);
            kHOAHOCLabel.TabIndex = 4;
            kHOAHOCLabel.Text = "KHOAHOC:";
            // 
            // mAKHOALabel
            // 
            mAKHOALabel.AutoSize = true;
            mAKHOALabel.Location = new System.Drawing.Point(18, 172);
            mAKHOALabel.Name = "mAKHOALabel";
            mAKHOALabel.Size = new System.Drawing.Size(76, 20);
            mAKHOALabel.TabIndex = 6;
            mAKHOALabel.Text = "MAKHOA:";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1417, 30);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 649);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnEdit,
            this.btnSave,
            this.btnUndo,
            this.btnExit,
            this.btnCancel,
            this.btnRefresh});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = global::QLDSV.Properties.Resources.Add;
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xoá";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = global::QLDSV.Properties.Resources.Delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 3;
            this.btnEdit.ImageOptions.Image = global::QLDSV.Properties.Resources.Edit;
            this.btnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.LargeImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Ghi";
            this.btnSave.Enabled = false;
            this.btnSave.Id = 4;
            this.btnSave.ImageOptions.Image = global::QLDSV.Properties.Resources.Save;
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Huỷ";
            this.btnCancel.Enabled = false;
            this.btnCancel.Id = 7;
            this.btnCancel.ImageOptions.Image = global::QLDSV.Properties.Resources.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Phục hồi";
            this.btnUndo.Enabled = false;
            this.btnUndo.Id = 5;
            this.btnUndo.ImageOptions.Image = global::QLDSV.Properties.Resources.Undo;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 8;
            this.btnRefresh.ImageOptions.Image = global::QLDSV.Properties.Resources.Refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Thoát";
            this.btnExit.Id = 6;
            this.btnExit.ImageOptions.Image = global::QLDSV.Properties.Resources.Exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1417, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 679);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1417, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 649);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1417, 30);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControl1.Size = new System.Drawing.Size(0, 649);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(2, 2);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(902, 35);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxKhoa);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1417, 48);
            this.panelControl1.TabIndex = 5;
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhoa.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Location = new System.Drawing.Point(96, 9);
            this.comboBoxKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(377, 29);
            this.comboBoxKhoa.TabIndex = 1;
            this.comboBoxKhoa.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoa_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Khoa";
            // 
            // subscriberDataSet
            // 
            this.subscriberDataSet.DataSetName = "subscriberDataSet";
            this.subscriberDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LOPBindingSource
            // 
            this.LOPBindingSource.DataMember = "LOP";
            this.LOPBindingSource.DataSource = this.subscriberDataSet;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DANGKYTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = this.LOPTableAdapter;
            this.tableAdapterManager.LOPTINCHITableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV.subscriberDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // LOPGridControl
            // 
            this.LOPGridControl.DataSource = this.LOPBindingSource;
            this.LOPGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.LOPGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LOPGridControl.Location = new System.Drawing.Point(0, 78);
            this.LOPGridControl.MainView = this.gridViewLOP;
            this.LOPGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LOPGridControl.MenuManager = this.barManager1;
            this.LOPGridControl.Name = "LOPGridControl";
            this.LOPGridControl.Size = new System.Drawing.Size(1417, 336);
            this.LOPGridControl.TabIndex = 7;
            this.LOPGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLOP});
            // 
            // gridViewLOP
            // 
            this.gridViewLOP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALOP,
            this.colTENLOP,
            this.colKHOAHOC,
            this.colMAKHOA});
            this.gridViewLOP.DetailHeight = 437;
            this.gridViewLOP.GridControl = this.LOPGridControl;
            this.gridViewLOP.Name = "gridViewLOP";
            this.gridViewLOP.OptionsBehavior.ReadOnly = true;
            this.gridViewLOP.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewLOP_SelectionChanged);
            // 
            // colMALOP
            // 
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.MinWidth = 29;
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 0;
            this.colMALOP.Width = 107;
            // 
            // colTENLOP
            // 
            this.colTENLOP.FieldName = "TENLOP";
            this.colTENLOP.MinWidth = 29;
            this.colTENLOP.Name = "colTENLOP";
            this.colTENLOP.Visible = true;
            this.colTENLOP.VisibleIndex = 1;
            this.colTENLOP.Width = 107;
            // 
            // colKHOAHOC
            // 
            this.colKHOAHOC.FieldName = "KHOAHOC";
            this.colKHOAHOC.MinWidth = 29;
            this.colKHOAHOC.Name = "colKHOAHOC";
            this.colKHOAHOC.Visible = true;
            this.colKHOAHOC.VisibleIndex = 2;
            this.colKHOAHOC.Width = 107;
            // 
            // colMAKHOA
            // 
            this.colMAKHOA.FieldName = "MAKHOA";
            this.colMAKHOA.MinWidth = 29;
            this.colMAKHOA.Name = "colMAKHOA";
            this.colMAKHOA.Visible = true;
            this.colMAKHOA.VisibleIndex = 3;
            this.colMAKHOA.Width = 107;
            // 
            // SINHVIENGridControl
            // 
            this.SINHVIENGridControl.DataSource = this.SINHVIENBindingSource;
            this.SINHVIENGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SINHVIENGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SINHVIENGridControl.Location = new System.Drawing.Point(2, 37);
            this.SINHVIENGridControl.MainView = this.gridViewSINHVIEN;
            this.SINHVIENGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SINHVIENGridControl.MenuManager = this.barManager1;
            this.SINHVIENGridControl.Name = "SINHVIENGridControl";
            this.SINHVIENGridControl.Size = new System.Drawing.Size(902, 196);
            this.SINHVIENGridControl.TabIndex = 1;
            this.SINHVIENGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSINHVIEN});
            // 
            // SINHVIENBindingSource
            // 
            this.SINHVIENBindingSource.DataMember = "FK_SINHVIEN_LOP";
            this.SINHVIENBindingSource.DataSource = this.LOPBindingSource;
            // 
            // gridViewSINHVIEN
            // 
            this.gridViewSINHVIEN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMASV,
            this.colHO,
            this.colTEN,
            this.colPHAI,
            this.colDIACHI,
            this.colNGAYSINH,
            this.colMALOP1,
            this.colDANGHIHOC,
            this.colPASSWORD});
            this.gridViewSINHVIEN.DetailHeight = 437;
            this.gridViewSINHVIEN.GridControl = this.SINHVIENGridControl;
            this.gridViewSINHVIEN.Name = "gridViewSINHVIEN";
            this.gridViewSINHVIEN.OptionsBehavior.ReadOnly = true;
            this.gridViewSINHVIEN.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewSINHVIEN_SelectionChanged);
            // 
            // colMASV
            // 
            this.colMASV.FieldName = "MASV";
            this.colMASV.MinWidth = 25;
            this.colMASV.Name = "colMASV";
            this.colMASV.Visible = true;
            this.colMASV.VisibleIndex = 0;
            this.colMASV.Width = 94;
            // 
            // colHO
            // 
            this.colHO.FieldName = "HO";
            this.colHO.MinWidth = 25;
            this.colHO.Name = "colHO";
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 94;
            // 
            // colTEN
            // 
            this.colTEN.FieldName = "TEN";
            this.colTEN.MinWidth = 25;
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 94;
            // 
            // colPHAI
            // 
            this.colPHAI.FieldName = "PHAI";
            this.colPHAI.MinWidth = 25;
            this.colPHAI.Name = "colPHAI";
            this.colPHAI.Visible = true;
            this.colPHAI.VisibleIndex = 3;
            this.colPHAI.Width = 94;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 94;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.MinWidth = 25;
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 5;
            this.colNGAYSINH.Width = 94;
            // 
            // colMALOP1
            // 
            this.colMALOP1.FieldName = "MALOP";
            this.colMALOP1.MinWidth = 25;
            this.colMALOP1.Name = "colMALOP1";
            this.colMALOP1.OptionsColumn.AllowEdit = false;
            this.colMALOP1.Visible = true;
            this.colMALOP1.VisibleIndex = 6;
            this.colMALOP1.Width = 94;
            // 
            // colDANGHIHOC
            // 
            this.colDANGHIHOC.FieldName = "DANGHIHOC";
            this.colDANGHIHOC.MinWidth = 25;
            this.colDANGHIHOC.Name = "colDANGHIHOC";
            this.colDANGHIHOC.Visible = true;
            this.colDANGHIHOC.VisibleIndex = 7;
            this.colDANGHIHOC.Width = 94;
            // 
            // colPASSWORD
            // 
            this.colPASSWORD.FieldName = "PASSWORD";
            this.colPASSWORD.MinWidth = 25;
            this.colPASSWORD.Name = "colPASSWORD";
            this.colPASSWORD.Width = 94;
            // 
            // MAKHOATextEdit
            // 
            this.MAKHOATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LOPBindingSource, "MAKHOA", true));
            this.MAKHOATextEdit.Enabled = false;
            this.MAKHOATextEdit.Location = new System.Drawing.Point(96, 169);
            this.MAKHOATextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MAKHOATextEdit.MenuManager = this.barManager1;
            this.MAKHOATextEdit.Name = "MAKHOATextEdit";
            this.MAKHOATextEdit.Size = new System.Drawing.Size(254, 26);
            this.MAKHOATextEdit.TabIndex = 7;
            // 
            // KHOAHOCTextEdit
            // 
            this.KHOAHOCTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LOPBindingSource, "KHOAHOC", true));
            this.KHOAHOCTextEdit.Location = new System.Drawing.Point(96, 134);
            this.KHOAHOCTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KHOAHOCTextEdit.MenuManager = this.barManager1;
            this.KHOAHOCTextEdit.Name = "KHOAHOCTextEdit";
            this.KHOAHOCTextEdit.Size = new System.Drawing.Size(254, 26);
            this.KHOAHOCTextEdit.TabIndex = 5;
            // 
            // TENLOPTextEdit
            // 
            this.TENLOPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LOPBindingSource, "TENLOP", true));
            this.TENLOPTextEdit.Location = new System.Drawing.Point(96, 99);
            this.TENLOPTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TENLOPTextEdit.MenuManager = this.barManager1;
            this.TENLOPTextEdit.Name = "TENLOPTextEdit";
            this.TENLOPTextEdit.Size = new System.Drawing.Size(254, 26);
            this.TENLOPTextEdit.TabIndex = 3;
            // 
            // MALOPTextEdit
            // 
            this.MALOPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LOPBindingSource, "MALOP", true));
            this.MALOPTextEdit.Location = new System.Drawing.Point(96, 64);
            this.MALOPTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MALOPTextEdit.MenuManager = this.barManager1;
            this.MALOPTextEdit.Name = "MALOPTextEdit";
            this.MALOPTextEdit.Size = new System.Drawing.Size(254, 26);
            this.MALOPTextEdit.TabIndex = 1;
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.DockControls.Add(this.barDockControl5);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSvAdd,
            this.btnSvDelete,
            this.btnSvEdit,
            this.btnSvSave,
            this.btnSvCancel});
            this.barManager2.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSvAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSvDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSvEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSvSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSvCancel)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Tools";
            // 
            // btnSvAdd
            // 
            this.btnSvAdd.Caption = "Thêm";
            this.btnSvAdd.Id = 0;
            this.btnSvAdd.ImageOptions.Image = global::QLDSV.Properties.Resources.Add;
            this.btnSvAdd.Name = "btnSvAdd";
            this.btnSvAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSvAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvAdd_ItemClick);
            // 
            // btnSvDelete
            // 
            this.btnSvDelete.Caption = "Xoá";
            this.btnSvDelete.Id = 1;
            this.btnSvDelete.ImageOptions.Image = global::QLDSV.Properties.Resources.Delete;
            this.btnSvDelete.Name = "btnSvDelete";
            this.btnSvDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSvDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvDelete_ItemClick);
            // 
            // btnSvEdit
            // 
            this.btnSvEdit.Caption = "Sửa";
            this.btnSvEdit.Id = 2;
            this.btnSvEdit.ImageOptions.Image = global::QLDSV.Properties.Resources.Edit;
            this.btnSvEdit.Name = "btnSvEdit";
            this.btnSvEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSvEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvEdit_ItemClick);
            // 
            // btnSvSave
            // 
            this.btnSvSave.Caption = "Ghi";
            this.btnSvSave.Enabled = false;
            this.btnSvSave.Id = 3;
            this.btnSvSave.ImageOptions.Image = global::QLDSV.Properties.Resources.Save;
            this.btnSvSave.Name = "btnSvSave";
            this.btnSvSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSvSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvSave_ItemClick);
            // 
            // btnSvCancel
            // 
            this.btnSvCancel.Caption = "Huỷ";
            this.btnSvCancel.Enabled = false;
            this.btnSvCancel.Id = 4;
            this.btnSvCancel.ImageOptions.Image = global::QLDSV.Properties.Resources.Cancel;
            this.btnSvCancel.Name = "btnSvCancel";
            this.btnSvCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSvCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvCancel_ItemClick);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl2.Location = new System.Drawing.Point(0, 0);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControl2.Size = new System.Drawing.Size(1417, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 679);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControl3.Size = new System.Drawing.Size(1417, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl4.Location = new System.Drawing.Point(0, 0);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControl4.Size = new System.Drawing.Size(0, 679);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl5.Location = new System.Drawing.Point(1417, 0);
            this.barDockControl5.Manager = this.barManager2;
            this.barDockControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControl5.Size = new System.Drawing.Size(0, 679);
            // 
            // SINHVIENTableAdapter
            // 
            this.SINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelSinhVien);
            this.groupControl1.Controls.Add(this.panelLopInput);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 414);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1417, 265);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Lớp";
            // 
            // panelSinhVien
            // 
            this.panelSinhVien.Controls.Add(this.SINHVIENGridControl);
            this.panelSinhVien.Controls.Add(this.standaloneBarDockControl1);
            this.panelSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSinhVien.Location = new System.Drawing.Point(509, 28);
            this.panelSinhVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSinhVien.Name = "panelSinhVien";
            this.panelSinhVien.Size = new System.Drawing.Size(906, 235);
            this.panelSinhVien.TabIndex = 1;
            // 
            // panelLopInput
            // 
            this.panelLopInput.Controls.Add(mALOPLabel);
            this.panelLopInput.Controls.Add(mAKHOALabel);
            this.panelLopInput.Controls.Add(this.MALOPTextEdit);
            this.panelLopInput.Controls.Add(this.MAKHOATextEdit);
            this.panelLopInput.Controls.Add(this.TENLOPTextEdit);
            this.panelLopInput.Controls.Add(kHOAHOCLabel);
            this.panelLopInput.Controls.Add(tENLOPLabel);
            this.panelLopInput.Controls.Add(this.KHOAHOCTextEdit);
            this.panelLopInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLopInput.Enabled = false;
            this.panelLopInput.Location = new System.Drawing.Point(2, 28);
            this.panelLopInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLopInput.Name = "panelLopInput";
            this.panelLopInput.Size = new System.Drawing.Size(507, 235);
            this.panelLopInput.TabIndex = 0;
            // 
            // DANGKYBindingSource
            // 
            this.DANGKYBindingSource.DataMember = "FK_CTLTC_SINHVIEN";
            this.DANGKYBindingSource.DataSource = this.SINHVIENBindingSource;
            // 
            // DANGKYTableAdapter
            // 
            this.DANGKYTableAdapter.ClearBeforeFill = true;
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.Location = new System.Drawing.Point(573, 313);
            this.gridLookUpEdit1.MenuManager = this.barManager1;
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(125, 26);
            this.gridLookUpEdit1.TabIndex = 28;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // LopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1417, 679);
            this.Controls.Add(this.gridLookUpEdit1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.LOPGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LopForm";
            this.Text = "Lớp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LopForm_FormClosing);
            this.Load += new System.EventHandler(this.LopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscriberDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOPGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SINHVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSINHVIEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MAKHOATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHOAHOCTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENLOPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MALOPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSinhVien)).EndInit();
            this.panelSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLopInput)).EndInit();
            this.panelLopInput.ResumeLayout(false);
            this.panelLopInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DANGKYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource LOPBindingSource;
        private subscriberDataSet subscriberDataSet;
        private subscriberDataSetTableAdapters.LOPTableAdapter LOPTableAdapter;
        private subscriberDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl LOPGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLOP;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTENLOP;
        private DevExpress.XtraGrid.Columns.GridColumn colKHOAHOC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHOA;
        private DevExpress.XtraEditors.TextEdit MAKHOATextEdit;
        private DevExpress.XtraEditors.TextEdit KHOAHOCTextEdit;
        private DevExpress.XtraEditors.TextEdit TENLOPTextEdit;
        private DevExpress.XtraEditors.TextEdit MALOPTextEdit;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSvAdd;
        private DevExpress.XtraBars.BarButtonItem btnSvDelete;
        private DevExpress.XtraBars.BarButtonItem btnSvEdit;
        private DevExpress.XtraBars.BarButtonItem btnSvSave;
        private DevExpress.XtraBars.BarButtonItem btnSvCancel;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private System.Windows.Forms.BindingSource SINHVIENBindingSource;
        private subscriberDataSetTableAdapters.SINHVIENTableAdapter SINHVIENTableAdapter;
        private DevExpress.XtraGrid.GridControl SINHVIENGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSINHVIEN;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelSinhVien;
        private DevExpress.XtraEditors.PanelControl panelLopInput;
        private DevExpress.XtraGrid.Columns.GridColumn colMASV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colPHAI;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP1;
        private DevExpress.XtraGrid.Columns.GridColumn colDANGHIHOC;
        private DevExpress.XtraGrid.Columns.GridColumn colPASSWORD;
        private System.Windows.Forms.BindingSource DANGKYBindingSource;
        private subscriberDataSetTableAdapters.DANGKYTableAdapter DANGKYTableAdapter;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}