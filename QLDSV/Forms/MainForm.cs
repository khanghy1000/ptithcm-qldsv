using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace QLDSV.Forms;

public partial class MainForm : RibbonForm {
    public MainForm() {
        InitializeComponent();
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
        Application.Exit();
    }

    private void barButtonLogout_ItemClick(object sender, ItemClickEventArgs e) {
        this.Dispose();
        Program.LoginForm.resetForm();
        Program.LoginForm.Show();
    }
}