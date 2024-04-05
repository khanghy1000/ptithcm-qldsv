using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class MonHocForm : XtraForm {
        private int _cursorPosision = 0;
        private FormState _formState = FormState.None;

        private string _maMonHocBeforeEditing = "";
        private string _tenMonHocBeforeEditing = "";
        private string _soTietLTBeforeEditing = "";
        private string _soTietTHBeforeEditing = "";

        private Stack<string> _undoStack = new Stack<string>();

        public MonHocForm() {
            InitializeComponent();
        }

        private Result CheckMonHocInput() {
            if (MAMHTextEdit.Text.Trim() == "") {
                MessageBox.Show("Mã môn học không được để trống", "Lỗi", MessageBoxButtons.OK);
                MAMHTextEdit.Focus();
                return Result.Failure;
            }

            if (TENMHTextEdit.Text.Trim() == "") {
                MessageBox.Show("Tên môn học không được để trống", "Lỗi", MessageBoxButtons.OK);
                TENMHTextEdit.Focus();
                return Result.Failure;
            }

            if (SOTIET_LTSpinEdit.Text.Trim() == "") {
                MessageBox.Show("Số tiết LT không được để trống", "Lỗi", MessageBoxButtons.OK);
                SOTIET_LTSpinEdit.Focus();
                return Result.Failure;
            }

            if (SOTIET_THSpinEdit.Text.Trim() == "") {
                MessageBox.Show("Số tiết TH không được để trống", "Lỗi", MessageBoxButtons.OK);
                SOTIET_THSpinEdit.Focus();
                return Result.Failure;
            }

            if ((_formState == FormState.Adding) ||
                (_formState == FormState.Editing && MAMHTextEdit.Text.Trim() != _maMonHocBeforeEditing)) {
                var smt = $"EXEC sp_check_ma_mon_hoc N'{MAMHTextEdit.Text.Trim()}'";
                Database.DataReader = Database.ExecSqlDataReader(smt);

                if (Database.DataReader == null) {
                    MessageBox.Show("Lỗi kiểm tra mã môn học", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }

                Database.DataReader.Read();
                try {
                    var result = Database.DataReader.GetInt32(0);
                    Database.DataReader.Close();

                    if (result == 1) {
                        MessageBox.Show("Mã môn học đã tồn tại.\nVui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK);
                        return Result.Failure;
                    }
                }
                catch {
                    Database.DataReader.Close();
                    MessageBox.Show("Lỗi kiểm tra mã môn học", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            if ((_formState == FormState.Adding) ||
                (_formState == FormState.Editing && TENMHTextEdit.Text.Trim() != _tenMonHocBeforeEditing)) {
                var smt = $"EXEC sp_check_ten_mon_hoc N'{TENMHTextEdit.Text.Trim()}'";
                Database.DataReader = Database.ExecSqlDataReader(smt);

                if (Database.DataReader == null) {
                    MessageBox.Show("Lỗi kiểm tra tên môn học", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }

                Database.DataReader.Read();
                try {
                    var result = Database.DataReader.GetInt32(0);
                    Database.DataReader.Close();

                    if (result == 1) {
                        MessageBox.Show("Tên môn học đã tồn tại.\nVui lòng nhập tên khác.", "Lỗi", MessageBoxButtons.OK);
                        return Result.Failure;
                    }
                }
                catch {
                    Database.DataReader.Close();
                    MessageBox.Show("Lỗi kiểm tra tên môn học", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        private void TemplateForm_Load(object sender, EventArgs e) {
            subscriberDataSet.EnforceConstraints = false;

            MONHOCTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
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

            MONHOCTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);

            // Reset buttons
            _formState = FormState.None;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            btnSave.Enabled = btnCancel.Enabled = false;
            panelMonHocInput.Enabled = false;
            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;

            _undoStack = new Stack<string>();
            btnUndo.Enabled = false;
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _cursorPosision = MONHOCBindingSource.Position;
            MONHOCBindingSource.AddNew();
            _formState = FormState.Adding;

            btnSave.Enabled = btnCancel.Enabled = true;
            panelMonHocInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            comboBoxKhoa.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (MONHOCBindingSource.Count <= 0) return;

            var dr = ((DataRowView)MONHOCBindingSource[MONHOCBindingSource.Position]);

            var maMonHoc = dr["MAMH"].ToString().Trim();
            var tenMonHoc = dr["TENMH"].ToString().Trim();
            var soTietLt = dr["SOTIET_LT"].ToString().Trim();
            var soTietTh = dr["SOTIET_TH"].ToString().Trim();

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa môn học có mã {maMonHoc}?", "Xác nhận", MessageBoxButtons.OKCancel) ==
                DialogResult.OK) {
                try {
                    MONHOCBindingSource.RemoveCurrent();
                    MONHOCTableAdapter.Update(subscriberDataSet.MONHOC);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi xóa môn học có mã {maMonHoc}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
                    MONHOCBindingSource.Position = MONHOCBindingSource.Find("MAMH", maMonHoc);
                    return;
                }

                var undoStatement =
                    $"INSERT INTO MONHOC (MAMH, TENMH, SOTIET_LT, SOTIET_TH) VALUES (N'{maMonHoc}', N'{tenMonHoc}', {soTietLt}, {soTietTh})";
                _undoStack.Push(undoStatement);
                btnUndo.Enabled = true;
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
                if (MONHOCBindingSource.Count <= 0) return;

                _cursorPosision = MONHOCBindingSource.Position;
                _formState = FormState.Editing;

                _maMonHocBeforeEditing = MAMHTextEdit.Text.Trim();
                _tenMonHocBeforeEditing = TENMHTextEdit.Text.Trim();
                _soTietLTBeforeEditing = SOTIET_LTSpinEdit.Text.Trim();
                _soTietTHBeforeEditing = SOTIET_THSpinEdit.Text.Trim();

                btnSave.Enabled = btnCancel.Enabled = true;
                panelMonHocInput.Enabled = true;

                btnAdd.Enabled = btnDelete.Enabled =
                    btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
                comboBoxKhoa.Enabled = false;

                btnUndo.Enabled = false;
            }

            private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
                var maMonHoc = MAMHTextEdit.Text.Trim();
                if (CheckMonHocInput() == Result.Success) {
                    try {
                        MONHOCBindingSource.EndEdit();
                        MONHOCTableAdapter.Update(subscriberDataSet.MONHOC);
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Lỗi ghi môn học\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }

                    if (_formState == FormState.Adding) {
                        var undoStatement = $"DELETE FROM MONHOC WHERE MAMH=N'{maMonHoc}'";
                        _undoStack.Push(undoStatement);
                    }

                    if (_formState == FormState.Editing) {
                        var undoStatement =
                            $"UPDATE MONHOC SET MAMH=N'{_maMonHocBeforeEditing}', TENMH=N'{_tenMonHocBeforeEditing}', SOTIET_LT={_soTietLTBeforeEditing}, SOTIET_TH={_soTietTHBeforeEditing} WHERE MAMH=N'{maMonHoc}'";
                        _undoStack.Push(undoStatement);
                    }

                    btnUndo.Enabled = true;

                    _formState = FormState.None;

                    btnSave.Enabled = btnCancel.Enabled = false;
                    panelMonHocInput.Enabled = false;

                    btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                    comboBoxKhoa.Enabled = Database.UserRole == "PGV";

                    btnUndo.Enabled = _undoStack.Count > 0;
                }
            }

            private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
                MONHOCBindingSource.CancelEdit();

                MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);

                MONHOCBindingSource.Position = _cursorPosision;

                _formState = FormState.None;

                btnSave.Enabled = btnCancel.Enabled = false;
                panelMonHocInput.Enabled = false;

                btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                comboBoxKhoa.Enabled = Database.UserRole == "PGV";

                btnUndo.Enabled = _undoStack.Count > 0;
            }

            private void btnUndo_ItemClick(object sender, ItemClickEventArgs e) {
                var undoStatement = _undoStack.Pop();
                if (_undoStack.Count <= 0) btnUndo.Enabled = false;
                Database.ExecSqlNonQuery(undoStatement);

                MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            }

            private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
                MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            }

            private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
                Close();
            }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e) {
            if (_formState == FormState.Adding) {
                MONHOCBindingSource.Position = MONHOCBindingSource.Count - 1;
                return;
            }

            if (_formState == FormState.Editing) {
                MONHOCBindingSource.Position = _cursorPosision;
            }
        }
    }
    }