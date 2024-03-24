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
    public partial class ReportFormDSLopTinChi : DevExpress.XtraEditors.XtraForm, CustomForm {
        public ReportFormDSLopTinChi() {
            InitializeComponent();
        }

        public void Reload() {
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

        private void ReportFormDSLopTinChi_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.CurrentKhoaIndex;
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

            Database.CurrentKhoaIndex = comboBoxKhoa.SelectedIndex;

            loadNienKhoa();

            Program.MainForm.ReloadMdiChildExcept(typeof(ReportFormDSLopTinChi));
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            loadHocKy(cmbNienKhoa.Text);
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            if (cmbNienKhoa.Text == "" || cmbHocKy.Text == "") {
                MessageBox.Show("Vui lòng nhập niên khoá hoặc học kỳ", "Lỗi", MessageBoxButtons.OK);
            }
            else {
                ReportDSLopTinChi report = new ReportDSLopTinChi(cmbNienKhoa.Text, int.Parse(cmbHocKy.Text));

                report.labelKhoa.Text = "KHOA " + comboBoxKhoa.Text.ToUpper();
                report.labelNienKhoaHocKy.Text = $"Niên khoá {cmbNienKhoa.Text} Học kỳ {cmbHocKy.Text}";

                ReportPrintTool print = new ReportPrintTool(report);
                print.ShowPreviewDialog();
            }
        }
    }
}