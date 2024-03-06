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
    }
}