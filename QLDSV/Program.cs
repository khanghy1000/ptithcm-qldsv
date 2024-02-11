using System;
using System.Windows.Forms;
using QLDSV.Forms;

namespace QLDSV;

internal static class Program {
    public static MainForm MainForm;
    public static LoginForm LoginForm;

    [STAThread]
    private static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Program.LoginForm = new LoginForm();
        Application.Run(Program.LoginForm);
    }
}