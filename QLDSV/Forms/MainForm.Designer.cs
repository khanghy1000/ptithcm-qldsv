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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.statusBarUsername = new DevExpress.XtraBars.BarStaticItem();
            this.statusBarFullName = new DevExpress.XtraBars.BarStaticItem();
            this.statusBarRole = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonLogout = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLop = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormDSLopTinChi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormSVDKLTC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormPhieuDiem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormBangDiemLTC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormDSDongHocPhi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFormBangDiemLop = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLTC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonNhapDiem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDKLTC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDongHocPhi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonTaoTK = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(62, 72, 62, 72);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.statusBarUsername,
            this.statusBarFullName,
            this.statusBarRole,
            this.barButtonLogout,
            this.barButtonLop,
            this.barButtonFormDSLopTinChi,
            this.barButtonFormSVDKLTC,
            this.barButtonFormPhieuDiem,
            this.barButtonFormBangDiemLTC,
            this.barButtonFormDSDongHocPhi,
            this.barButtonFormBangDiemLop,
            this.barButtonMonHoc,
            this.barButtonLTC,
            this.barButtonNhapDiem,
            this.barButtonDKLTC,
            this.barButtonDongHocPhi,
            this.barButtonTaoTK,
            this.barButtonChangePass});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(8);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 687;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPageSystem});
            this.ribbonControl1.Size = new System.Drawing.Size(1438, 203);
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
            // barButtonLop
            // 
            this.barButtonLop.Caption = "Lớp";
            this.barButtonLop.Id = 6;
            this.barButtonLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonLop.ImageOptions.Image")));
            this.barButtonLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonLop.ImageOptions.LargeImage")));
            this.barButtonLop.Name = "barButtonLop";
            this.barButtonLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLop_ItemClick);
            // 
            // barButtonFormDSLopTinChi
            // 
            this.barButtonFormDSLopTinChi.Caption = "DS Lớp Tín Chỉ";
            this.barButtonFormDSLopTinChi.Id = 8;
            this.barButtonFormDSLopTinChi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormDSLopTinChi.ImageOptions.SvgImage")));
            this.barButtonFormDSLopTinChi.Name = "barButtonFormDSLopTinChi";
            this.barButtonFormDSLopTinChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSLopTinChi_ItemClick);
            // 
            // barButtonFormSVDKLTC
            // 
            this.barButtonFormSVDKLTC.Caption = "DS Sinh Viên DK LTC";
            this.barButtonFormSVDKLTC.Id = 9;
            this.barButtonFormSVDKLTC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormSVDKLTC.ImageOptions.SvgImage")));
            this.barButtonFormSVDKLTC.Name = "barButtonFormSVDKLTC";
            this.barButtonFormSVDKLTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonFormPhieuDiem
            // 
            this.barButtonFormPhieuDiem.Caption = "Phiếu điểm SV";
            this.barButtonFormPhieuDiem.Id = 10;
            this.barButtonFormPhieuDiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormPhieuDiem.ImageOptions.SvgImage")));
            this.barButtonFormPhieuDiem.Name = "barButtonFormPhieuDiem";
            this.barButtonFormPhieuDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonPhieuDiem_ItemClick);
            // 
            // barButtonFormBangDiemLTC
            // 
            this.barButtonFormBangDiemLTC.Caption = "Bảng điểm lớp tín chỉ";
            this.barButtonFormBangDiemLTC.Id = 11;
            this.barButtonFormBangDiemLTC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormBangDiemLTC.ImageOptions.SvgImage")));
            this.barButtonFormBangDiemLTC.Name = "barButtonFormBangDiemLTC";
            this.barButtonFormBangDiemLTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonFormDSDongHocPhi
            // 
            this.barButtonFormDSDongHocPhi.Caption = "DS đóng học phí của lớp";
            this.barButtonFormDSDongHocPhi.Id = 12;
            this.barButtonFormDSDongHocPhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormDSDongHocPhi.ImageOptions.SvgImage")));
            this.barButtonFormDSDongHocPhi.Name = "barButtonFormDSDongHocPhi";
            this.barButtonFormDSDongHocPhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonFormBangDiemLop
            // 
            this.barButtonFormBangDiemLop.Caption = "Bảng điểm của lớp";
            this.barButtonFormBangDiemLop.Id = 13;
            this.barButtonFormBangDiemLop.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonFormBangDiemLop.ImageOptions.SvgImage")));
            this.barButtonFormBangDiemLop.Name = "barButtonFormBangDiemLop";
            this.barButtonFormBangDiemLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonMonHoc
            // 
            this.barButtonMonHoc.Caption = "Môn học";
            this.barButtonMonHoc.Id = 14;
            this.barButtonMonHoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonMonHoc.ImageOptions.SvgImage")));
            this.barButtonMonHoc.Name = "barButtonMonHoc";
            this.barButtonMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonLTC
            // 
            this.barButtonLTC.Caption = "Lớp tín chỉ";
            this.barButtonLTC.Id = 15;
            this.barButtonLTC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonLTC.ImageOptions.SvgImage")));
            this.barButtonLTC.Name = "barButtonLTC";
            this.barButtonLTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonNhapDiem
            // 
            this.barButtonNhapDiem.Caption = "Nhập điểm";
            this.barButtonNhapDiem.Id = 16;
            this.barButtonNhapDiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonNhapDiem.ImageOptions.SvgImage")));
            this.barButtonNhapDiem.Name = "barButtonNhapDiem";
            this.barButtonNhapDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonDKLTC
            // 
            this.barButtonDKLTC.Caption = "Đăng ký lớp tín chỉ";
            this.barButtonDKLTC.Id = 17;
            this.barButtonDKLTC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonDKLTC.ImageOptions.SvgImage")));
            this.barButtonDKLTC.Name = "barButtonDKLTC";
            this.barButtonDKLTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonDongHocPhi
            // 
            this.barButtonDongHocPhi.Caption = "Đóng học phí";
            this.barButtonDongHocPhi.Id = 18;
            this.barButtonDongHocPhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonDongHocPhi.ImageOptions.SvgImage")));
            this.barButtonDongHocPhi.Name = "barButtonDongHocPhi";
            this.barButtonDongHocPhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonTaoTK
            // 
            this.barButtonTaoTK.Caption = "Tạo tài khoản";
            this.barButtonTaoTK.Id = 19;
            this.barButtonTaoTK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonTaoTK.Name = "barButtonTaoTK";
            this.barButtonTaoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonTaoTK_ItemClick);
            // 
            // barButtonChangePass
            // 
            this.barButtonChangePass.Caption = "Đổi mật khẩu";
            this.barButtonChangePass.Id = 20;
            this.barButtonChangePass.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonChangePass.ImageOptions.SvgImage")));
            this.barButtonChangePass.Name = "barButtonChangePass";
            this.barButtonChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonChangePass_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Nhập xuất";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonLop);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonMonHoc);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonLTC);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonNhapDiem);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDKLTC);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDongHocPhi);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Nhập xuất";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormDSLopTinChi);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormSVDKLTC);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormBangDiemLTC);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormPhieuDiem);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormBangDiemLop);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonFormDSDongHocPhi);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Báo cáo";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonTaoTK);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonChangePass);
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
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 663);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(6);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1438, 30);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 693);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "QLDSV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barButtonLop;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonFormDSLopTinChi;
        private DevExpress.XtraBars.BarButtonItem barButtonFormSVDKLTC;
        private DevExpress.XtraBars.BarButtonItem barButtonFormPhieuDiem;
        private DevExpress.XtraBars.BarButtonItem barButtonFormBangDiemLTC;
        private DevExpress.XtraBars.BarButtonItem barButtonFormDSDongHocPhi;
        private DevExpress.XtraBars.BarButtonItem barButtonFormBangDiemLop;
        private DevExpress.XtraBars.BarButtonItem barButtonMonHoc;
        private DevExpress.XtraBars.BarButtonItem barButtonLTC;
        private DevExpress.XtraBars.BarButtonItem barButtonNhapDiem;
        private DevExpress.XtraBars.BarButtonItem barButtonDKLTC;
        private DevExpress.XtraBars.BarButtonItem barButtonDongHocPhi;
        private DevExpress.XtraBars.BarButtonItem barButtonTaoTK;
        private DevExpress.XtraBars.BarButtonItem barButtonChangePass;
    }
}

