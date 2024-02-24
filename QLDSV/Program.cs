using System;
using System.Windows.Forms;
using QLDSV.Forms;

namespace QLDSV {
    internal static class Program {
        public static MainForm MainForm;
        public static LoginForm LoginForm;

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm = new LoginForm();
            Application.Run(LoginForm);
        }
    }
}