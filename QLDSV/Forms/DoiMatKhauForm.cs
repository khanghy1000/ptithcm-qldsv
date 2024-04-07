using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.Forms {
    public partial class DoiMatKhauForm : DevExpress.XtraEditors.XtraForm {
        public DoiMatKhauForm() {
            InitializeComponent();
        }

        private Result CheckInput() {
            if (textOldPass.Text.Trim() == "") {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textOldPass.Focus();
                return Result.Failure;
            }

            if (textNewPass.Text.Trim() == "") {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textNewPass.Focus();
                return Result.Failure;
            }

            if (textPassConfirm.Text.Trim() == "") {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassConfirm.Focus();
                return Result.Failure;
            }

            if (textNewPass.Text.Trim() != textPassConfirm.Text.Trim()) {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassConfirm.Focus();
                return Result.Failure;
            }

            return Result.Success;
        }

        private void DoiMatKhauForm_Load(object sender, EventArgs e) {

        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (CheckInput() == Result.Success) {
                string smt;
                if (Database.UserRole == "SV") {
                    smt = $"exec sp_doi_mk_sv '{Database.SinhVienInputMSSV}', '{textOldPass.Text}', '{textNewPass.Text}'";
                }

                else {
                    smt = $"exec sp_doi_mk '{Database.LoginName}', '{textOldPass.Text}', '{textNewPass.Text}'";
                }

                if (Database.ExecSqlNonQuery(smt) == 0) {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.MainForm.barButtonLogout_ItemClick(null, null);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}