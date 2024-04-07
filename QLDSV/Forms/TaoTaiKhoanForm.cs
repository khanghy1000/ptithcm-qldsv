using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class TaoTaiKhoanForm : XtraForm {
        public TaoTaiKhoanForm() {
            InitializeComponent();
        }

        private void LoadGV() {
            string smt = "EXEC sp_get_ds_giang_vien";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbGV.DataSource = dt;
            cmbGV.DisplayMember = "HOTEN";
            cmbGV.ValueMember = "MAGV";
        }

        private Result CheckInput() {
            if (textMaTK.Text.Trim() == "") {
                MessageBox.Show("Tên tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (textPass.Text.Trim() == "") {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (radioPGV.Checked == false && radioKHOA.Checked == false && radioPKT.Checked == false) {
                MessageBox.Show("Chưa chọn role", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            return Result.Success;
        }

        private void LoadRadioBtn() {
            if (Database.UserRole == "PGV") {
                radioPGV.Enabled = true;
                radioKHOA.Enabled = true;
                radioPKT.Enabled = false;
                radioPGV.Checked = true;
            }
            else if (Database.UserRole == "KHOA") {
                radioPGV.Enabled = false;
                radioKHOA.Enabled = true;
                radioPKT.Enabled = false;
                radioKHOA.Checked = true;
            }
            else if (Database.UserRole == "PKT") {
                radioPGV.Enabled = false;
                radioKHOA.Enabled = false;
                radioPKT.Enabled = true;
                radioPKT.Checked = true;
            }
        }

        private void LoadThongTinTK() {
            int result;
            var smt = $"sp_check_tk_gv N'{textMAGV.Text.Trim()}'";
            Database.DataReader = Database.ExecSqlDataReader(smt);
            if (Database.DataReader == null) return;
            Database.DataReader.Read();

            try {
                result = Database.DataReader.GetInt32(0);
                Database.DataReader.Close();
            }
            catch (Exception) {
                Database.DataReader.Close();
                MessageBox.Show("Lỗi kiểm tra thông tin giảng viên", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (result == 0) {
                btnTaoTK.Enabled = true;
                btnXoaTK.Enabled = false;
                textMaTK.Enabled = true;
                textPass.Enabled = true;
                LoadRadioBtn();
                return;
            }

            btnTaoTK.Enabled = false;
            btnXoaTK.Enabled = true;
            textMaTK.Enabled = false;
            textPass.Enabled = false;

            string loginName;
            string role;
            smt = $"sp_get_login_name N'{textMAGV.Text.Trim()}'";
            Database.DataReader = Database.ExecSqlDataReader(smt);
            if (Database.DataReader == null) return;
            Database.DataReader.Read();

            try {
                loginName = Database.DataReader.GetString(0);
                role = Database.DataReader.GetString(1);
                Database.DataReader.Close();
            }
            catch (Exception) {
                Database.DataReader.Close();
                MessageBox.Show("Lỗi kiểm tra thông tin giảng viên", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            textMaTK.Text = loginName;
            textPass.Text = "";
            radioPGV.Checked = role == "PGV";
            radioKHOA.Checked = role == "KHOA";
            radioPKT.Checked = role == "PKT";
            radioPGV.Enabled = radioPKT.Enabled = radioKHOA.Enabled = false;
        }

        private void TaoTaiKhoanForm_Load(object sender, EventArgs e) {
            LoadRadioBtn();
            LoadGV();
        }

        private void cmbGV_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbGV.SelectedValue.ToString() == "System.Data.DataRowView") return;
            textMAGV.Text = cmbGV.SelectedValue.ToString().Trim();

            LoadThongTinTK();
        }

        private void btnTaoTK_Click(object sender, EventArgs e) {
            if (CheckInput() == Result.Success) {
                var smt =
                    $"exec sp_tao_tai_khoan '{textMaTK.Text.Trim()}', '{textPass.Text.Trim()}', '{textMAGV.Text.Trim()}', '{(radioPGV.Checked ? "PGV" : radioKHOA.Checked ? "KHOA" : "PKT")}'";

                if (Database.ExecSqlNonQuery(smt) == 0) {
                    MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadThongTinTK();
                    return;
                }
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e) {
            var smt = $"exec sp_xoa_tai_khoan '{textMaTK.Text.Trim()}', {textMAGV.Text.Trim()}";
            if (Database.ExecSqlNonQuery(smt) == 0) {
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                LoadThongTinTK();
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}