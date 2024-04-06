using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void barButtonLogout_ItemClick(object sender, ItemClickEventArgs e) {
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
    }
}