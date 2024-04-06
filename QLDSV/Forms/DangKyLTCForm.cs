using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class DangKyLTCForm : XtraForm {
        private DataTable _dtLtc = new DataTable();

        public DangKyLTCForm() {
            InitializeComponent();
        }

        private void LoadNienKhoa() {
            string smt = "EXEC sp_get_nien_khoa_ltc";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbNienKhoa.DataSource = dt;
            cmbNienKhoa.DisplayMember = "NIENKHOA";
            cmbNienKhoa.ValueMember = "NIENKHOA";
        }

        private void LoadHocKy(string nienKhoa) {
            string smt = $"EXEC sp_get_hoc_ky_ltc '{nienKhoa}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbHocKy.DataSource = dt;
            cmbHocKy.DisplayMember = "HOCKY";
            cmbHocKy.ValueMember = "HOCKY";
        }

        private void DangKyLTCForm_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialKhoaIndex;

            LoadNienKhoa();
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            LoadHocKy(cmbNienKhoa.Text.Trim());
        }

        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e) {
            btnLoadLTC_Click(sender, e);
        }

        private void btnLoadLTC_Click(object sender, EventArgs e) {
            string smt =
                $"EXEC sp_get_ds_ltc_dang_ky '{cmbNienKhoa.Text}', {cmbHocKy.Text}, '{Database.SinhVienInputMSSV}'";
            _dtLtc = Database.ExecSqlDataTable(smt);
            DSLTCGridControl.DataSource = _dtLtc;
        }

        private void btnDangKy_Click(object sender, EventArgs e) {
            colDANGKY.OptionsColumn.ReadOnly = false;
            cmbNienKhoa.Enabled = false;
            cmbHocKy.Enabled = false;
            btnSaveDK.Enabled = true;
            btnLoadLTC.Enabled = btnDangKy.Enabled = false;
        }

        private void btnSaveDK_Click(object sender, EventArgs e) {
            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Lỗi kết nối tới CSDL", "Lỗi",
                    MessageBoxButtons.OK);
                return;
            }

            var sqlTransaction = Database.Connection.BeginTransaction();
            try {
                foreach (DataRow row in _dtLtc.Rows) {
                    var smt =
                        $"EXEC sp_doi_trang_thai_dang_ky_ltc {row["MALTC"].ToString().Trim()}, N'{Database.SinhVienInputMSSV}', {(bool.Parse(row["DANGKY"].ToString()) ? 1 : 0)}";
                    var cmd = new SqlCommand(smt, Database.Connection, sqlTransaction);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
            }
            catch (Exception ex) {
                sqlTransaction.Rollback();
                MessageBox.Show("Lỗi đăng ký lớp tín chỉ\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }

            colDANGKY.OptionsColumn.ReadOnly = false;
            cmbNienKhoa.Enabled = true;
            cmbHocKy.Enabled = true;
            btnSaveDK.Enabled = false;
            btnLoadLTC.Enabled = btnDangKy.Enabled = true;
            MessageBox.Show("Đăng ký lớp tín chỉ thành công", "Thành công", MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}