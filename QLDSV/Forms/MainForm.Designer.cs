namespace QLDSV.Forms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.statusBarUsername = new DevExpress.XtraBars.BarStaticItem();
            this.statusBarFullName = new DevExpress.XtraBars.BarStaticItem();
            this.statusBarRole = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonLogout = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.statusBarUsername,
            this.statusBarFullName,
            this.statusBarRole,
            this.barButtonLogout});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageSystem});
            this.ribbonControl1.Size = new System.Drawing.Size(884, 193);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // statusBarUsername
            // 
            this.statusBarUsername.Caption = "Tài khoản";
            this.statusBarUsername.Id = 1;
            this.statusBarUsername.Name = "statusBarUsername";
            // 
            // statusBarFullName
            // 
            this.statusBarFullName.Caption = "Họ tên";
            this.statusBarFullName.Id = 2;
            this.statusBarFullName.Name = "statusBarFullName";
            // 
            // statusBarRole
            // 
            this.statusBarRole.Caption = "Vai trò";
            this.statusBarRole.Id = 3;
            this.statusBarRole.Name = "statusBarRole";
            // 
            // barButtonLogout
            // 
            this.barButtonLogout.Caption = "Đăng xuất";
            this.barButtonLogout.Id = 5;
            this.barButtonLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonLogout.ImageOptions.Image")));
            this.barButtonLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonLogout.ImageOptions.LargeImage")));
            this.barButtonLogout.Name = "barButtonLogout";
            this.barButtonLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLogout_ItemClick);
            // 
            // ribbonPageSystem
            // 
            this.ribbonPageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageSystem.Name = "ribbonPageSystem";
            this.ribbonPageSystem.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonLogout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Hệ thống";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.BackColor = System.Drawing.Color.White;
            this.ribbonStatusBar1.ItemLinks.Add(this.statusBarUsername);
            this.ribbonStatusBar1.ItemLinks.Add(this.statusBarFullName);
            this.ribbonStatusBar1.ItemLinks.Add(this.statusBarRole);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 413);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(884, 30);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 443);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "QLDSV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        public DevExpress.XtraBars.BarStaticItem statusBarUsername;
        public DevExpress.XtraBars.BarStaticItem statusBarFullName;
        public DevExpress.XtraBars.BarStaticItem statusBarRole;
        private DevExpress.XtraBars.BarButtonItem barButtonLogout;
    }
}

