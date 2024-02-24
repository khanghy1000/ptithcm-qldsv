using System;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class LopForm : XtraForm {
        public LopForm() {
            InitializeComponent();
        }

        private void LopForm_Load(object sender, EventArgs e) {
            subscriberDataSet.EnforceConstraints = false;

            LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTableAdapter.Fill(this.subscriberDataSet.LOP);

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.SelectedKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
        }
    }
}