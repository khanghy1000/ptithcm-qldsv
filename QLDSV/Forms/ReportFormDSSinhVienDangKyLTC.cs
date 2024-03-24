using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLDSV.Forms.Reports;

namespace QLDSV.Forms {
    public partial class ReportFormDSSinhVienDangKyLTC : XtraForm {
        public ReportFormDSSinhVienDangKyLTC() {
            InitializeComponent();
        }

        void loadNienKhoa() {
            string smt = "EXEC sp_get_nien_khoa_ltc";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbNienKhoa.DataSource = dt;
            cmbNienKhoa.DisplayMember = "NIENKHOA";
            cmbNienKhoa.ValueMember = "NIENKHOA";
        }

        void loadHocKy(string nienKhoa) {
            string smt = $"EXEC sp_get_hoc_ky_ltc '{nienKhoa}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbHocKy.DataSource = dt;
            cmbHocKy.DisplayMember = "HOCKY";
            cmbHocKy.ValueMember = "HOCKY";
        }

        void loadMonHoc(string nienKhoa, string hocKy) {
            string smt = $"EXEC sp_get_mon_hoc '{nienKhoa}', {hocKy}";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbMonHoc.DataSource = dt;
            cmbMonHoc.DisplayMember = "TENMH";
            cmbMonHoc.ValueMember = "MAMH";
        }

        void loadNhom(string nienKhoa, string hocKy, string maMonHoc) {
            string smt = $"EXEC sp_get_nhom_ltc '{nienKhoa}', {hocKy}, '{maMonHoc}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbNhom.DataSource = dt;
            cmbNhom.DisplayMember = "NHOM";
            cmbNhom.ValueMember = "NHOM";
        }

        private void ReportFormDSSinhVienDangKyLTC_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            loadNienKhoa();
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


            loadNienKhoa();
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            loadHocKy(cmbNienKhoa.Text);
        }

        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e) {
            loadMonHoc(cmbNienKhoa.Text, cmbHocKy.Text);
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e) {
            loadNhom(cmbNienKhoa.Text, cmbHocKy.Text, cmbMonHoc.SelectedValue.ToString());
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            if (cmbNienKhoa.Text == "" || cmbHocKy.Text == "" || cmbMonHoc.Text == "" || cmbNhom.Text == "") {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            ReportDSSinhVienDangKyLTC report = new ReportDSSinhVienDangKyLTC(cmbNienKhoa.Text, int.Parse(cmbHocKy.Text),
                int.Parse(cmbNhom.Text), cmbMonHoc.SelectedValue.ToString());

            report.labelKhoa.Text = "KHOA " + comboBoxKhoa.Text.ToUpper();
            report.labelNienKhoaHocKy.Text = $"Niên khoá: {cmbNienKhoa.Text} Học kỳ: {cmbHocKy.Text}";
            report.labelMonHocNhom.Text = $"Môn học: {cmbMonHoc.Text} - Nhóm: {cmbNhom.Text}";

            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}