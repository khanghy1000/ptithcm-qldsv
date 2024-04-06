using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class NhapDiemForm : XtraForm {
        private string _maLtc = "";
        private DataTable _dtDsSvDangKy = new DataTable();

        public NhapDiemForm() {
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
            subscriberDataSet.EnforceConstraints = false;

            DSLTCTableAdapter.Connection.ConnectionString = Database.ConnectionString;

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            LoadNienKhoa();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e) {
           if (comboBoxKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();

            if (comboBoxKhoa.SelectedIndex != Database.InitialKhoaIndex) {
                Database.LoginName = Database.RemoteLoginName;
                Database.LoginPassword = Database.RemoteLoginPassword;
            }
            else {
                Database.LoginName = Database.UserInputLoginName;
                Database.LoginPassword = Database.UserInputLoginPassword;
            }

            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Lỗi kết nối với khoa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            DSLTCTableAdapter.Connection.ConnectionString = Database.ConnectionString;

            LoadNienKhoa();

            // Reset buttons
            gridViewDSSVDangKy.OptionsBehavior.ReadOnly = true;
            btnSaveDiem.Enabled = false;
            btnLoadLTC.Enabled = btnNhapDiem.Enabled = true;
            cmbNienKhoa.Enabled = cmbHocKy.Enabled = true;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            LoadHocKy(cmbNienKhoa.Text);
        }

        private void btnLoadLTC_Click(object sender, EventArgs e) {
            try {
                DSLTCTableAdapter.Fill(subscriberDataSet.sp_get_ds_ltc, cmbNienKhoa.Text,
                    int.Parse(cmbHocKy.Text));
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi tải thông tin lớp tín chỉ\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK);
            }
        }

        private void btnNhapDiem_Click(object sender, EventArgs e) {
            _maLtc = ((DataRowView)DSLTCBindingSource[DSLTCBindingSource.Position])["MALTC"].ToString();
            string smt = $"EXEC sp_get_dssv_dang_ky_ltc {_maLtc}";
            _dtDsSvDangKy = Database.ExecSqlDataTable(smt);
            DSSVDangKyGridControl.DataSource = _dtDsSvDangKy;

            gridViewDSSVDangKy.OptionsBehavior.ReadOnly = false;
            btnSaveDiem.Enabled = true;
            btnLoadLTC.Enabled = btnNhapDiem.Enabled = false;
            cmbNienKhoa.Enabled = cmbHocKy.Enabled = false;
            comboBoxKhoa.Enabled = false;
        }

        private void btnSaveDiem_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DIEM_CC", typeof(float));
            dt.Columns.Add("DIEM_GK", typeof(float));
            dt.Columns.Add("DIEM_CK", typeof(float));
            int intMaLtc = int.Parse(_maLtc);

            foreach (DataRow row in _dtDsSvDangKy.Rows) {
                dt.Rows.Add(intMaLtc, row["MASV"], row["DIEM_CC"], row["DIEM_GK"], row["DIEM_CK"]);
            }

            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.TYPE_DANGKY";
            param.ParameterName = "@diem_thi";
            param.Value = dt;

            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Lỗi kết nối tới CSDL", "Lỗi",
                    MessageBoxButtons.OK);
                return;
            }

            try {
                SqlCommand cmd = new SqlCommand("sp_update_diem", Database.Connection);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi ghi điểm\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK);
                return;
            }

            gridViewDSSVDangKy.OptionsBehavior.ReadOnly = true;
            btnSaveDiem.Enabled = false;
            btnLoadLTC.Enabled = btnNhapDiem.Enabled = true;
            cmbNienKhoa.Enabled = cmbHocKy.Enabled = true;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            MessageBox.Show("Ghi điểm thành công", "Thành công",
                MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e) {
            btnLoadLTC_Click(sender, e);
        }
    }
}