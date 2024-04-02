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
    public partial class ReportFormHocPhiLop : DevExpress.XtraEditors.XtraForm {
        public ReportFormHocPhiLop() {
            InitializeComponent();
        }

        private void LoadKhoa() {
            string smt = "SELECT MAKHOA, TENKHOA FROM KHOA";
            DataTable dt = Database.ExecSqlDataTable(smt);
            comboBoxKhoa.DataSource = dt;
            comboBoxKhoa.DisplayMember = "TENKHOA";
            comboBoxKhoa.ValueMember = "MAKHOA";
            LoadMaLop(comboBoxKhoa.SelectedValue.ToString());
        }

        private void LoadMaLop(string maKhoa) {
            string smt = $"EXEC sp_get_ds_ma_lop_hoc_phi '{maKhoa}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbMaLop.DataSource = dt;
            cmbMaLop.DisplayMember = "MALOP";
            cmbMaLop.ValueMember = "MALOP";
        }

        private void LoadNienKhoa(string maLop) {
            string smt = $"EXEC sp_get_nien_khoa_hoc_phi '{maLop}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbNienKhoa.DataSource = dt;
            cmbNienKhoa.DisplayMember = "NIENKHOA";
            cmbNienKhoa.ValueMember = "NIENKHOA";
        }

        private void LoadHocKy(string maLop, string nienKhoa) {
            string smt = $"EXEC sp_get_hoc_ky_hoc_phi '{maLop}', '{nienKhoa}'";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbHocKy.DataSource = dt;
            cmbHocKy.DisplayMember = "HOCKY";
            cmbHocKy.ValueMember = "HOCKY";
        }

        private void ReportFormHocPhiLop_Load(object sender, EventArgs e) {
            LoadKhoa();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            LoadMaLop(comboBoxKhoa.SelectedValue.ToString());
        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e) {
            LoadNienKhoa(cmbMaLop.Text);
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            LoadHocKy(cmbMaLop.Text, cmbNienKhoa.Text);
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            if (cmbMaLop.Text == "" ||cmbNienKhoa.Text == "" || cmbHocKy.Text == "") {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            ReportHocPhiLop report = new ReportHocPhiLop(cmbMaLop.Text, cmbNienKhoa.Text, int.Parse(cmbHocKy.Text));

            report.labelKhoa.Text = "KHOA " + comboBoxKhoa.Text.ToUpper();
            report.labelMaLop.Text = "MÃ LỚP " + cmbMaLop.Text.ToUpper();
            report.labelNienKhoaHocKy.Text = $"Niên khoá: {cmbNienKhoa.Text} Học kỳ: {cmbHocKy.Text}";

            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}