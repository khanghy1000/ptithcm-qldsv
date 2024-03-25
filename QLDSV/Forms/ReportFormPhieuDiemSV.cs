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
    public partial class ReportFormPhieuDiemSV : DevExpress.XtraEditors.XtraForm {
        public ReportFormPhieuDiemSV() {
            InitializeComponent();
        }

        private void LoadMaSV() {
            string smt = "EXEC sp_get_ds_ma_sv";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbMaSV.DataSource = dt;
            cmbMaSV.DisplayMember = "MASV";
            cmbMaSV.ValueMember = "MASV";
        }
        private void ReportFormPhieuDiemSV_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            LoadMaSV();
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

            LoadMaSV();
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            if (cmbMaSV.Text == "") {
                MessageBox.Show("Vui lòng nhập mã sinh viên", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            var hoTen = "";
            var smt = $"SELECT HO + ' ' + TEN FROM SINHVIEN WHERE MASV='{cmbMaSV.Text}'";
            Database.DataReader = Database.ExecSqlDataReader(smt);
            if (Database.DataReader == null) return;
            Database.DataReader.Read();

            try {
                hoTen = Database.DataReader.GetString(0);
                Database.DataReader.Close();
            }
            catch (Exception) {
                Database.DataReader.Close();
                MessageBox.Show("Không tìm thấy sinh viên", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            ReportPhieuDiemSV report = new ReportPhieuDiemSV(cmbMaSV.Text);

            report.labelHoTen.Text = $"Họ tên: {hoTen}";
            report.labelMaSV.Text = $"Mã sinh viên: {cmbMaSV.Text}";

            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }


    }
}