using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLDSV.Forms.Reports;
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
    public partial class ReportFormBangDiemLop : DevExpress.XtraEditors.XtraForm {
        public ReportFormBangDiemLop() {
            InitializeComponent();
        }
        private void LoadMaLop() {
            string smt = "SELECT MALOP FROM LOP";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbMaLop.DataSource = dt;
            cmbMaLop.DisplayMember = "MALOP";
            cmbMaLop.ValueMember = "MALOP";
        }

        private void ReportFormBangDiemLop_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            LoadMaLop();
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

            LoadMaLop();
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            if (cmbMaLop.Text == "") {
                MessageBox.Show("Vui lòng nhập lớp", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            var tenLop = "";
            var khoaHoc = "";
            var smt = $"SELECT TENLOP, KHOAHOC FROM LOP WHERE MALOP='{cmbMaLop.Text}'";
            Database.DataReader = Database.ExecSqlDataReader(smt);
            if (Database.DataReader == null) return;
            Database.DataReader.Read();

            try {
                tenLop = Database.DataReader.GetString(0);
                khoaHoc = Database.DataReader.GetString(1);
                Database.DataReader.Close();
            }
            catch (Exception) {
                Database.DataReader.Close();
                MessageBox.Show("Không tìm thấy lớp", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            ReportBangDiemLop report = new ReportBangDiemLop(cmbMaLop.Text);

            report.labelLopKhoaHoc.Text = $"LỚP: {tenLop.ToUpper()} KHOÁ HỌC: {khoaHoc.ToUpper()}";
            report.labelKhoa.Text = $"KHOA: {comboBoxKhoa.Text.ToUpper()}";

            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}