using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using QLDSV.Forms.Reports;

namespace QLDSV.Forms {
    public partial class MainForm : RibbonForm {
        private Form CheckExists(Type ftype) {
            foreach (Form f in this.MdiChildren) {
                if (f.GetType() == ftype) {
                    return f;
                }
            }

            return null;
        }

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (Database.UserRole == "PGV" || Database.UserRole == "KHOA") {
                barButtonLop.Visibility =
                    barButtonMonHoc.Visibility = barButtonLTC.Visibility =
                        barButtonNhapDiem.Visibility = BarItemVisibility.Always;
                barButtonFormDSLopTinChi.Visibility = barButtonFormSVDKLTC.Visibility =
                    barButtonFormBangDiemLTC.Visibility =
                        barButtonFormBangDiemLop.Visibility = BarItemVisibility.Always;
                barButtonDongHocPhi.Visibility = barButtonFormDSDongHocPhi.Visibility = BarItemVisibility.Never;
                barButtonFormPhieuDiem.Visibility = BarItemVisibility.Always;
                barButtonDKLTC.Visibility = BarItemVisibility.Never;
                barButtonTaoTK.Visibility = BarItemVisibility.Always;
                barButtonChangePass.Visibility = BarItemVisibility.Always;
            }

            if (Database.UserRole == "PKT") {
                barButtonLop.Visibility =
                    barButtonMonHoc.Visibility =
                        barButtonLTC.Visibility = barButtonNhapDiem.Visibility = BarItemVisibility.Never;
                barButtonFormDSLopTinChi.Visibility = barButtonFormSVDKLTC.Visibility =
                    barButtonFormBangDiemLTC.Visibility = barButtonFormBangDiemLop.Visibility = BarItemVisibility.Never;
                barButtonDongHocPhi.Visibility = barButtonFormDSDongHocPhi.Visibility = BarItemVisibility.Always;
                barButtonFormPhieuDiem.Visibility = BarItemVisibility.Always;
                barButtonDKLTC.Visibility = BarItemVisibility.Never;
                barButtonTaoTK.Visibility = BarItemVisibility.Always;
                barButtonChangePass.Visibility = BarItemVisibility.Always;
            }

            if (Database.UserRole == "SV") {
                barButtonLop.Visibility =
                    barButtonMonHoc.Visibility =
                        barButtonLTC.Visibility = barButtonNhapDiem.Visibility = BarItemVisibility.Never;
                barButtonFormDSLopTinChi.Visibility = barButtonFormSVDKLTC.Visibility =
                    barButtonFormBangDiemLTC.Visibility = barButtonFormBangDiemLop.Visibility = BarItemVisibility.Never;
                barButtonDongHocPhi.Visibility = barButtonFormDSDongHocPhi.Visibility = BarItemVisibility.Never;
                barButtonFormPhieuDiem.Visibility = BarItemVisibility.Always;
                barButtonDKLTC.Visibility = BarItemVisibility.Always;
                barButtonTaoTK.Visibility = BarItemVisibility.Never;
                barButtonChangePass.Visibility = BarItemVisibility.Always;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        public void barButtonLogout_ItemClick(object sender, ItemClickEventArgs e) {
            foreach (Form f in this.MdiChildren) {
                f.Close();
            }

            this.Dispose();
            Database.BindingSourcePhanManh.RemoveFilter();
            Program.LoginForm.ResetForm();
            Program.LoginForm.Show();
        }

        private void barButtonLop_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(LopForm));
            if (form != null) form.Activate();
            else {
                LopForm newForm = new LopForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonDSLopTinChi_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(ReportFormDSLopTinChi));
            if (form != null) form.Activate();
            else {
                ReportFormDSLopTinChi newForm = new ReportFormDSLopTinChi();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(ReportFormDSSinhVienDangKyLTC));
            if (form != null) form.Activate();
            else {
                ReportFormDSSinhVienDangKyLTC newForm = new ReportFormDSSinhVienDangKyLTC();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonPhieuDiem_ItemClick(object sender, ItemClickEventArgs e) {
            if (Database.UserRole == "SV") {
                ReportPhieuDiemSV report = new ReportPhieuDiemSV(Database.SinhVienInputMSSV);

                report.labelHoTen.Text = $"Họ tên: {Database.UserFullName}";
                report.labelMaSV.Text = $"Mã sinh viên: {Database.SinhVienInputMSSV}";

                ReportPrintTool print = new ReportPrintTool(report);
                print.ShowPreviewDialog();
                return;
            }

            Form form = CheckExists(typeof(ReportFormPhieuDiemSV));
            if (form != null) form.Activate();
            else {
                ReportFormPhieuDiemSV newForm = new ReportFormPhieuDiemSV();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(ReportFormBangDiemLTC));
            if (form != null) form.Activate();
            else {
                ReportFormBangDiemLTC newForm = new ReportFormBangDiemLTC();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(ReportFormHocPhiLop));
            if (form != null) form.Activate();
            else {
                ReportFormHocPhiLop newForm = new ReportFormHocPhiLop();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(ReportFormBangDiemLop));
            if (form != null) form.Activate();
            else {
                ReportFormBangDiemLop newForm = new ReportFormBangDiemLop();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(MonHocForm));
            if (form != null) form.Activate();
            else {
                MonHocForm newForm = new MonHocForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(LopTinChiForm));
            if (form != null) form.Activate();
            else {
                LopTinChiForm newForm = new LopTinChiForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(NhapDiemForm));
            if (form != null) form.Activate();
            else {
                NhapDiemForm newForm = new NhapDiemForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(DangKyLTCForm));
            if (form != null) form.Activate();
            else {
                DangKyLTCForm newForm = new DangKyLTCForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(DongHocPhiForm));
            if (form != null) form.Activate();
            else {
                DongHocPhiForm newForm = new DongHocPhiForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonTaoTK_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(TaoTaiKhoanForm));
            if (form != null) form.Activate();
            else {
                TaoTaiKhoanForm newForm = new TaoTaiKhoanForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void barButtonChangePass_ItemClick(object sender, ItemClickEventArgs e) {
            Form form = CheckExists(typeof(DoiMatKhauForm));
            if (form != null) form.Activate();
            else {
                DoiMatKhauForm newForm = new DoiMatKhauForm();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }
    }
}