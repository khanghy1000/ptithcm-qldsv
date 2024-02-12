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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            statusBarUsername = new DevExpress.XtraBars.BarStaticItem();
            statusBarFullName = new DevExpress.XtraBars.BarStaticItem();
            statusBarRole = new DevExpress.XtraBars.BarStaticItem();
            barButtonLogout = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, statusBarUsername, statusBarFullName, statusBarRole, barButtonLogout });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageSystem });
            ribbonControl1.Size = new System.Drawing.Size(884, 193);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // statusBarUsername
            // 
            statusBarUsername.Caption = "Tài khoản";
            statusBarUsername.Id = 1;
            statusBarUsername.Name = "statusBarUsername";
            // 
            // statusBarFullName
            // 
            statusBarFullName.Caption = "Họ tên";
            statusBarFullName.Id = 2;
            statusBarFullName.Name = "statusBarFullName";
            // 
            // statusBarRole
            // 
            statusBarRole.Caption = "Vai trò";
            statusBarRole.Id = 3;
            statusBarRole.Name = "statusBarRole";
            // 
            // barButtonLogout
            // 
            barButtonLogout.Caption = "Đăng xuất";
            barButtonLogout.Id = 5;
            barButtonLogout.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonLogout.ImageOptions.Image");
            barButtonLogout.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonLogout.ImageOptions.LargeImage");
            barButtonLogout.Name = "barButtonLogout";
            barButtonLogout.ItemClick += barButtonLogout_ItemClick;
            // 
            // ribbonPageSystem
            // 
            ribbonPageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPageSystem.Name = "ribbonPageSystem";
            ribbonPageSystem.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonLogout);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Hệ thống";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.BackColor = System.Drawing.Color.White;
            ribbonStatusBar1.ItemLinks.Add(statusBarUsername);
            ribbonStatusBar1.ItemLinks.Add(statusBarFullName);
            ribbonStatusBar1.ItemLinks.Add(statusBarRole);
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 413);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(884, 30);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 443);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MainForm";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "QLDSV";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

