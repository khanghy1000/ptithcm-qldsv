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

        public void ReloadMdiChildExcept(Type ftype) {
            foreach (var form in this.MdiChildren ) {
                if (form.GetType() == ftype) continue;
                ((CustomForm)form).Reload();
            }
        }

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void barButtonLogout_ItemClick(object sender, ItemClickEventArgs e) {
            this.Dispose();
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
    }
}