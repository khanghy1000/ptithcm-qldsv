using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class LopForm : XtraForm {
        private string _maKhoa = "";
        private int _cursorPosition = 0;
        private FormState _lopFormState = FormState.None;
        private string _maLopBeforeEditing = "";


        public LopForm() {
            InitializeComponent();
        }

        private void LoadMaKhoa() {
            var getMaKhoaStatement = "EXEC sp_get_ma_khoa";
            Database.DataReader = Database.ExecSqlDataReader(getMaKhoaStatement);
            if (Database.DataReader == null) return;

            Database.DataReader.Read();
            try {
                _maKhoa = Database.DataReader.GetString(0);
                Database.DataReader.Close();
            }
            catch {
                MessageBox.Show("Lỗi lấy mã khoa", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private Result CheckLopInput() {
            if (MALOPTextEdit.Text.Trim() == "") {
                MessageBox.Show("Mã lớp không được để trống", "Lỗi", MessageBoxButtons.OK);
                MALOPTextEdit.Focus();
                return Result.Failure;
            }

            if (TENLOPTextEdit.Text.Trim() == "") {
                MessageBox.Show("Tên lớp không được để trống", "Lỗi", MessageBoxButtons.OK);
                TENLOPTextEdit.Focus();
                return Result.Failure;
            }

            if (KHOAHOCTextEdit.Text.Trim() == "") {
                MessageBox.Show("Khóa học không được để trống", "Lỗi", MessageBoxButtons.OK);
                KHOAHOCTextEdit.Focus();
                return Result.Failure;
            }

            if ((_lopFormState == FormState.Adding) ||
                (_lopFormState == FormState.Editing && MALOPTextEdit.Text.Trim() != _maLopBeforeEditing)) {
                var checkMaLopStatement = $"EXEC sp_check_ma_lop {MALOPTextEdit.Text.Trim()}";
                Database.DataReader = Database.ExecSqlDataReader(checkMaLopStatement);

                if (Database.DataReader == null) {
                    MessageBox.Show("Lỗi kiểm tra mã khoa", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }

                Database.DataReader.Read();
                try {
                    var result = Database.DataReader.GetInt32(0);
                    Database.DataReader.Close();

                    if (result == 1) {
                        MessageBox.Show("Mã lớp đã tồn tại.\nVui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK);
                        return Result.Failure;
                    }

                    if (result == 2) {
                        MessageBox.Show("Mã lớp đã tồn tại ở khoa khác.\nVui lòng nhập mã khác.", "Lỗi",
                            MessageBoxButtons.OK);
                        return Result.Failure;
                    }
                }
                catch {
                    MessageBox.Show("Lỗi kiểm tra mã khoa", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        private void LopForm_Load(object sender, EventArgs e) {
            subscriberDataSet.EnforceConstraints = false;

            LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialSelectedKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            LoadMaKhoa();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Database.ServerName = comboBoxKhoa.SelectedValue.ToString();

            if (comboBoxKhoa.SelectedIndex != Database.InitialSelectedKhoaIndex) {
                Database.LoginName = Database.RemoteLoginName;
                Database.LoginPassword = Database.RemoteLoginPassword;
            }
            else {
                Database.LoginName = Database.UserInputLoginName;
                Database.LoginPassword = Database.UserInputLoginPassword;
            }

            if (Database.Connect() == Result.Failure) {
                MessageBox.Show("Lỗi kết nối với khoa", "Lỗi", MessageBoxButtons.OK);
            }
            else {
                LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
                LOPTableAdapter.Fill(subscriberDataSet.LOP);
                SINHVIENTableAdapter.Connection.ConnectionString = Database.ConnectionString;
                SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);

                LoadMaKhoa();
            }
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _cursorPosition = LOPBindingSource.Position;
            LOPBindingSource.AddNew();
            _lopFormState = FormState.Adding;
            MAKHOATextEdit.Text = _maKhoa;

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLopInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            LOPGridControl.Enabled = false;
            comboBoxKhoa.Enabled = false;
            panelSinhVien.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            String maLop = ((DataRowView)LOPBindingSource[LOPBindingSource.Position])["MALOP"].ToString().Trim();

            if (SINHVIENBindingSource.Count > 0) {
                MessageBox.Show($"Không thể xoá lớp có mã {maLop} vì lớp đã có sinh viên", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa lớp có mã {maLop}?", "Xác nhận", MessageBoxButtons.OKCancel) ==
                DialogResult.OK) {
                try {
                    LOPBindingSource.RemoveCurrent();
                    LOPTableAdapter.Update(subscriberDataSet.LOP);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi xóa lớp có mã {maLop}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    LOPTableAdapter.Fill(subscriberDataSet.LOP);
                    LOPBindingSource.Position = LOPBindingSource.Find("MALOP", maLop);
                }
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            _cursorPosition = LOPBindingSource.Position;
            _lopFormState = FormState.Editing;
            _maLopBeforeEditing = MALOPTextEdit.Text.Trim();

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLopInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            LOPGridControl.Enabled = false;
            comboBoxKhoa.Enabled = false;
            panelSinhVien.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            if (CheckLopInput() == Result.Success) {
                try {
                    LOPBindingSource.EndEdit();
                    LOPTableAdapter.Update(subscriberDataSet.LOP);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi ghi lớp\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                _lopFormState = FormState.None;

                btnSave.Enabled = btnCancel.Enabled = false;
                panelLopInput.Enabled = false;

                btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                LOPGridControl.Enabled = true;
                comboBoxKhoa.Enabled = true;
                panelSinhVien.Enabled = true;
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
            LOPBindingSource.CancelEdit();
            LOPBindingSource.Position = _cursorPosition;

            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);

            _lopFormState = FormState.None;

            btnSave.Enabled = btnCancel.Enabled = false;
            panelLopInput.Enabled = false;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            LOPGridControl.Enabled = true;
            comboBoxKhoa.Enabled = true;
            panelSinhVien.Enabled = true;
        }

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }
    }
}