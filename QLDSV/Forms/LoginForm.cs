using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class LoginForm : XtraForm {
        private SqlConnection _publisherConnection = new SqlConnection();

        private Result _connectPublisherServer() {
            if (_publisherConnection != null && _publisherConnection.State == ConnectionState.Open) {
                _publisherConnection.Close();
            }

            try {
                _publisherConnection ??= new SqlConnection();
                _publisherConnection.ConnectionString = Database.PublisherConnectionString;
                _publisherConnection.Open();
                return Result.Success;
            }
            catch (Exception e) {
                MessageBox.Show($"Lỗi kết nối tới server gốc\n{e.Message}");
                return Result.Failure;
            }
        }

        public LoginForm() {
            InitializeComponent();
        }

        private void labelTitle_Click(object sender, EventArgs e) {
        }

        private void checkIsSinhVien_CheckedChanged(object sender, EventArgs e) {
            labelUsername.Text = checkIsSinhVien.Checked ? "MSSV" : "Tài khoản";
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (textUsername.Text.Trim() == "" || textPassword.Text.Trim() == "") {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống.", "", MessageBoxButtons.OK);
                return;
            }

            Database.LoginName = textUsername.Text;
            Database.LoginPassword = textPassword.Text;

            if (checkIsSinhVien.Checked) {
                Database.LoginName = Database.SinhVienLoginName;
                Database.LoginPassword = Database.SinhVienLoginPassword;
                Database.MSSV = textUsername.Text;
                Database.SinhVienPassword = textPassword.Text;
            }

            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng\nVui lòng kiểm tra lại.", "Lỗi",
                    MessageBoxButtons.OK);
                return;
            }

            var getUserInfoStatement = checkIsSinhVien.Checked
                ? $"EXEC sp_get_sinh_vien_info {Database.MSSV}, {Database.SinhVienPassword}"
                : $"EXEC sp_get_login_info {Database.LoginName}";

            Database.DataReader = Database.ExecSqlDataReader(getUserInfoStatement);

            if (Database.DataReader == null) return;

            Database.KhoaId = comboBoxKhoa.SelectedIndex;
            Database.CurrentLoginName = Database.LoginName;
            Database.CurrentLoginPassword = Database.LoginPassword;

            Database.DataReader.Read();
            try {
                Database.Username = Database.DataReader.GetString(0);
                Database.UserFullName = Database.DataReader.GetString(1);
                Database.UserRole = Database.DataReader.GetString(2);
                Database.DataReader.Close();
                Database.Connection.Close();

                Program.MainForm = new MainForm();
                Program.MainForm.statusBarUsername.Caption = $"MÃ: {Database.Username}";
                Program.MainForm.statusBarFullName.Caption = $"HỌ TÊN: {Database.UserFullName}";
                Program.MainForm.statusBarRole.Caption = $"VAI TRÒ: {Database.UserRole}";
                this.Visible = false;
                Program.MainForm.Show();
            }
            catch (Exception exception) {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng\nVui lòng kiểm tra lại.", "Lỗi",
                    MessageBoxButtons.OK);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            if (_connectPublisherServer() == Result.Failure) return;

            var dataTable = new DataTable();

            if (_publisherConnection.State == ConnectionState.Closed)
                _publisherConnection.Open();

            var getSubscriberStatement = "SELECT * FROM view_get_subscriber";
            var dataAdapter = new SqlDataAdapter(getSubscriberStatement, _publisherConnection);
            dataAdapter.Fill(dataTable);

            _publisherConnection.Close();
            Database.BindingSourcePhanManh.DataSource = dataTable;
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = 0;

            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        public void resetForm() {
            comboBoxKhoa.SelectedIndex = Database.KhoaId;
            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();
            textUsername.Text = "";
            textPassword.Text = "";
            textUsername.Focus();
        }
    }
}