using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class TemplateForm : XtraForm {
        private int _cursorPosision = 0;


        public TemplateForm() {
            InitializeComponent();
        }

        private void TemplateForm_Load(object sender, EventArgs e) {
            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.SelectedKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();

            if (comboBoxKhoa.SelectedIndex != Database.SelectedKhoaIndex) {
                Database.LoginName = Database.RemoteLoginName;
                Database.LoginPassword = Database.RemoteLoginPassword;
            }
            else {
                Database.LoginName = Database.UserLoginName;
                Database.LoginPassword = Database.UserLoginPassword;
            }

            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Lỗi kết nối với khoa", "Lỗi", MessageBoxButtons.OK);
            }
            else {
                // TODO
            }
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }
    }
}