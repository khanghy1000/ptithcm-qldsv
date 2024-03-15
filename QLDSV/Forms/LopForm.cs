using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace QLDSV.Forms {
    public partial class LopForm : XtraForm, CustomForm {
        private string _maKhoa = "";
        private int _lopCursorPosition = 0;
        private int _sinhVienCursorPosition = 0;
        private FormState _formState = FormState.None;

        private string _maLopBeforeEditing = "";
        private string _tenLopBeforeEditing = "";
        private string _khoaHocBeforeEditing = "";

        private string _maSinhVienBeforeEditing = "";
        private string _hoBeforeEditing = "";
        private string _tenBeforeEditing = "";
        private bool _phaiBeforeEditing = false;
        private string _diaChiBeforeEditing = "";
        private DateTime _ngaySinhBeforeEditing;
        private bool _daNghiHocBeforeEditing = false;

        private Stack<string> _undoStack = new Stack<string>();

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

            if ((_formState == FormState.Adding) ||
                (_formState == FormState.Editing && MALOPTextEdit.Text.Trim() != _maLopBeforeEditing)) {
                var checkMaLopStatement = $"EXEC sp_check_ma_lop N'{MALOPTextEdit.Text.Trim()}'";
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


        private Result CheckSinhVienInput() {
            var dr = (DataRowView)SINHVIENBindingSource[
                _formState == FormState.Adding ? SINHVIENBindingSource.Count - 1 : _sinhVienCursorPosition];

            if (dr["MASV"].ToString().Trim() == "") {
                MessageBox.Show("Mã sinh viên không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (dr["HO"].ToString().Trim() == "") {
                MessageBox.Show("Họ không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (dr["TEN"].ToString().Trim() == "") {
                MessageBox.Show("Tên không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (dr["NGAYSINH"] == DBNull.Value) {
                MessageBox.Show("Ngày sinh không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }


            if ((_formState == FormState.Adding) ||
                (_formState == FormState.Editing && dr["MASV"].ToString().Trim() != _maSinhVienBeforeEditing)) {
                var checkMaSinhVienStatement = $"EXEC sp_check_ma_sinh_vien N'{dr["MASV"].ToString().Trim()}'";
                Database.DataReader = Database.ExecSqlDataReader(checkMaSinhVienStatement);

                if (Database.DataReader == null) {
                    MessageBox.Show("Lỗi kiểm tra mã sinh viên", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }

                Database.DataReader.Read();
                try {
                    var result = Database.DataReader.GetInt32(0);
                    Database.DataReader.Close();

                    if (result == 1) {
                        MessageBox.Show("Mã sinh viên đã tồn tại.\nVui lòng nhập mã khác.", "Lỗi",
                            MessageBoxButtons.OK);
                        return Result.Failure;
                    }

                    if (result == 2) {
                        MessageBox.Show("Mã sinh viên đã tồn tại ở khoa khác.\nVui lòng nhập mã khác.", "Lỗi",
                            MessageBoxButtons.OK);
                        return Result.Failure;
                    }
                }
                catch {
                    MessageBox.Show("Lỗi kiểm tra mã sinh viên", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        public void Reload() {
            comboBoxKhoa.SelectedIndex = Database.CurrentKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            btnSave.Enabled = btnCancel.Enabled = false;
            panelLopInput.Enabled = false;
            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            panelSinhVien.Enabled = true;

            gridViewSINHVIEN.OptionsBehavior.ReadOnly = true;
            LOPGridControl.Enabled = true;
            btnSvAdd.Enabled = btnSvDelete.Enabled = btnSvEdit.Enabled = true;
            btnSvSave.Enabled = btnSvCancel.Enabled = false;

            _undoStack = new Stack<string>();
            btnUndo.Enabled = false;
        }

        private void LopForm_Load(object sender, EventArgs e) {
            subscriberDataSet.EnforceConstraints = false;

            LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.CurrentKhoaIndex;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            LoadMaKhoa();
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

            LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);

            LoadMaKhoa();

            Program.MainForm.ReloadMdiChildExcept(typeof(LopForm));

            _undoStack = new Stack<string>();
            btnUndo.Enabled = false;
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _lopCursorPosition = LOPBindingSource.Position;
            _sinhVienCursorPosition = SINHVIENBindingSource.Position;
            LOPBindingSource.AddNew();
            _formState = FormState.Adding;
            MAKHOATextEdit.Text = _maKhoa;

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLopInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            comboBoxKhoa.Enabled = false;
            panelSinhVien.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (LOPBindingSource.Count <= 0) return;

            var dr = ((DataRowView)LOPBindingSource[LOPBindingSource.Position]);

            var maLop = dr["MALOP"].ToString().Trim();
            var tenLop = dr["TENLOP"].ToString().Trim();
            var khoaHoc = dr["KHOAHOC"].ToString().Trim();
            var maKhoa = dr["MAKHOA"].ToString().Trim();


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
                    return;
                }

                var undoStatement =
                    $"INSERT INTO LOP (MALOP, TENLOP, KHOAHOC, MAKHOA) VALUES (N'{maLop}', N'{tenLop}', N'{khoaHoc}', N'{maKhoa}')";
                _undoStack.Push(undoStatement);
                btnUndo.Enabled = true;
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            if (LOPBindingSource.Count <= 0) return;

            _lopCursorPosition = LOPBindingSource.Position;
            _sinhVienCursorPosition = SINHVIENBindingSource.Position;
            _formState = FormState.Editing;

            _maLopBeforeEditing = MALOPTextEdit.Text.Trim();
            _tenLopBeforeEditing = TENLOPTextEdit.Text.Trim();
            _khoaHocBeforeEditing = KHOAHOCTextEdit.Text.Trim();

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLopInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            comboBoxKhoa.Enabled = false;
            panelSinhVien.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            var maLop = MALOPTextEdit.Text.Trim();
            if (CheckLopInput() == Result.Success) {
                try {
                    LOPBindingSource.EndEdit();
                    LOPTableAdapter.Update(subscriberDataSet.LOP);
                    SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi ghi lớp\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                if (_formState == FormState.Adding) {
                    var undoStatement = $"DELETE FROM LOP WHERE MALOP=N'{maLop}'";
                    _undoStack.Push(undoStatement);
                }

                if (_formState == FormState.Editing) {
                    var undoStatement =
                        $"UPDATE LOP SET MALOP=N'{_maLopBeforeEditing}', TENLOP=N'{_tenLopBeforeEditing}', KHOAHOC=N'{_khoaHocBeforeEditing}' WHERE MALOP=N'{maLop}'";
                    _undoStack.Push(undoStatement);
                }

                btnUndo.Enabled = true;

                _formState = FormState.None;

                btnSave.Enabled = btnCancel.Enabled = false;
                panelLopInput.Enabled = false;

                btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                comboBoxKhoa.Enabled = Database.UserRole == "PGV";
                panelSinhVien.Enabled = true;

                btnUndo.Enabled = _undoStack.Count > 0;
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
            LOPBindingSource.CancelEdit();

            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);

            LOPBindingSource.Position = _lopCursorPosition;
            SINHVIENBindingSource.Position = _sinhVienCursorPosition;

            _formState = FormState.None;

            btnSave.Enabled = btnCancel.Enabled = false;
            panelLopInput.Enabled = false;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            panelSinhVien.Enabled = true;

            btnUndo.Enabled = _undoStack.Count > 0;
        }

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e) {
            var undoStatement = _undoStack.Pop().ToString();
            if (_undoStack.Count <= 0) btnUndo.Enabled = false;
            Database.ExecSqlNonQuery(undoStatement);

            LOPTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }

        private void btnSvAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _lopCursorPosition = LOPBindingSource.Position;
            _sinhVienCursorPosition = SINHVIENBindingSource.Position;
            subscriberDataSet.SINHVIEN.DANGHIHOCColumn.DefaultValue = false;
            subscriberDataSet.SINHVIEN.PHAIColumn.DefaultValue = false;
            subscriberDataSet.SINHVIEN.PASSWORDColumn.DefaultValue = "123456";

            SINHVIENBindingSource.AddNew();
            gridViewSINHVIEN.OptionsBehavior.ReadOnly = false;

            var de = new RepositoryItemDateEdit();
            de.MaxValue = DateTime.Now.AddYears(-10);
            colNGAYSINH.ColumnEdit = de;

            _formState = FormState.Adding;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnSave.Enabled =
                btnCancel.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            LOPGridControl.Enabled = false;
            comboBoxKhoa.Enabled = false;
            btnSvAdd.Enabled = btnSvDelete.Enabled = btnSvEdit.Enabled = false;
            btnSvSave.Enabled = btnSvCancel.Enabled = true;

            btnUndo.Enabled = false;
        }

        private void btnSvDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (SINHVIENBindingSource.Count <= 0) return;

            var dr = ((DataRowView)SINHVIENBindingSource[SINHVIENBindingSource.Position]);
            var maSinhVien = dr["MASV"].ToString().Trim();
            var ho = dr["HO"].ToString().Trim();
            var ten = dr["TEN"].ToString().Trim();
            var phai = bool.Parse(dr["PHAI"].ToString().Trim());
            var diaChi = dr["DIACHI"].ToString().Trim();
            var ngaySinh = (DateTime)dr["NGAYSINH"];
            var maLop = dr["MALOP"].ToString().Trim();
            var daNghiHoc = bool.Parse(dr["DANGHIHOC"].ToString().Trim());
            var password = dr["PASSWORD"].ToString().Trim();

            if (DANGKYBindingSource.Count > 0) {
                MessageBox.Show($"Không thể xoá sinh viên có mã {maSinhVien} vì sinh viên đã đăng ký lớp tín chỉ.",
                    "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa sinh viên có mã {maSinhVien}?", "Xác nhận",
                    MessageBoxButtons.OKCancel) ==
                DialogResult.OK) {
                try {
                    SINHVIENBindingSource.RemoveCurrent();
                    SINHVIENTableAdapter.Update(subscriberDataSet.SINHVIEN);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi xóa sinh viên có mã {maSinhVien}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
                    SINHVIENBindingSource.Position = SINHVIENBindingSource.Find("MASV", maSinhVien);
                }

                var undoStatement =
                    $"INSERT INTO SINHVIEN(MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, MALOP, DANGHIHOC, PASSWORD) VALUES (N'{maSinhVien}', N'{ho}', N'{ten}', {(phai ? 1 : 0)}, N'{diaChi}', '{ngaySinh:yyyy-MM-dd}', N'{maLop}', {(daNghiHoc ? 1 : 0)}, N'{password}')";
                _undoStack.Push(undoStatement);
                btnUndo.Enabled = true;
            }
        }

        private void btnSvEdit_ItemClick(object sender, ItemClickEventArgs e) {
            if (SINHVIENBindingSource.Count <= 0) return;

            _lopCursorPosition = LOPBindingSource.Position;
            _sinhVienCursorPosition = SINHVIENBindingSource.Position;

            gridViewSINHVIEN.OptionsBehavior.ReadOnly = false;

            var de = new RepositoryItemDateEdit();
            de.MaxValue = DateTime.Now.AddYears(-10);
            colNGAYSINH.ColumnEdit = de;

            _formState = FormState.Editing;
            var dr = ((DataRowView)SINHVIENBindingSource[SINHVIENBindingSource.Position]);
            _maSinhVienBeforeEditing = dr["MASV"].ToString().Trim();
            _hoBeforeEditing = dr["HO"].ToString().Trim();
            _tenBeforeEditing = dr["TEN"].ToString().Trim();
            _phaiBeforeEditing = bool.Parse(dr["PHAI"].ToString().Trim());
            _diaChiBeforeEditing = dr["DIACHI"].ToString().Trim();
            _ngaySinhBeforeEditing = (DateTime)dr["NGAYSINH"];
            _daNghiHocBeforeEditing = bool.Parse(dr["DANGHIHOC"].ToString().Trim());

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnSave.Enabled =
                btnCancel.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            LOPGridControl.Enabled = false;
            comboBoxKhoa.Enabled = false;
            btnSvAdd.Enabled = btnSvDelete.Enabled = btnSvEdit.Enabled = false;
            btnSvSave.Enabled = btnSvCancel.Enabled = true;

            btnUndo.Enabled = false;
        }

        private void btnSvSave_ItemClick(object sender, ItemClickEventArgs e) {
            var maSinhVien = ((DataRowView)SINHVIENBindingSource[SINHVIENBindingSource.Position])["MASV"];
            if (CheckSinhVienInput() == Result.Success) {
                try {
                    SINHVIENBindingSource.EndEdit();
                    SINHVIENTableAdapter.Update(subscriberDataSet.SINHVIEN);
                    DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi ghi sinh viên\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                if (_formState == FormState.Adding) {
                    var undoStatement = $"DELETE FROM SINHVIEN WHERE MASV=N'{maSinhVien}'";
                    _undoStack.Push(undoStatement);
                }

                if (_formState == FormState.Editing) {
                    var undoStatement =
                        $"UPDATE SINHVIEN SET MASV=N'{_maSinhVienBeforeEditing}', HO=N'{_hoBeforeEditing}', TEN=N'{_tenBeforeEditing}', PHAI={(_phaiBeforeEditing ? 1 : 0)}, DIACHI=N'{_diaChiBeforeEditing}', NGAYSINH='{_ngaySinhBeforeEditing:yyyy-MM-dd}', DANGHIHOC={(_daNghiHocBeforeEditing ? 1 : 0)} WHERE MASV=N'{maSinhVien}'";
                    _undoStack.Push(undoStatement);
                }

                btnUndo.Enabled = true;

                gridViewSINHVIEN.OptionsBehavior.ReadOnly = true;
                _formState = FormState.None;

                btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;
                LOPGridControl.Enabled = true;
                comboBoxKhoa.Enabled = Database.UserRole == "PGV";
                btnSvAdd.Enabled = btnSvDelete.Enabled = btnSvEdit.Enabled = true;
                btnSvSave.Enabled = btnSvCancel.Enabled = false;

                btnUndo.Enabled = _undoStack.Count > 0;
            }
        }

        private void btnSvCancel_ItemClick(object sender, ItemClickEventArgs e) {
            SINHVIENBindingSource.CancelEdit();
            gridViewSINHVIEN.OptionsBehavior.ReadOnly = true;

            LOPTableAdapter.Fill(subscriberDataSet.LOP);
            SINHVIENTableAdapter.Fill(subscriberDataSet.SINHVIEN);
            DANGKYTableAdapter.Fill(subscriberDataSet.DANGKY);

            LOPBindingSource.Position = _lopCursorPosition;
            SINHVIENBindingSource.Position = _sinhVienCursorPosition;

            _formState = FormState.None;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            LOPGridControl.Enabled = true;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            btnSvAdd.Enabled = btnSvDelete.Enabled = btnSvEdit.Enabled = true;
            btnSvSave.Enabled = btnSvCancel.Enabled = false;

            btnUndo.Enabled = _undoStack.Count > 0;
        }

        private void gridViewLOP_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (_formState == FormState.Adding) {
                LOPBindingSource.Position = LOPBindingSource.Count - 1;
                return;
            }

            if (_formState == FormState.Editing) {
                LOPBindingSource.Position = _lopCursorPosition;
            }
        }

        private void gridViewSINHVIEN_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (_formState == FormState.Adding) {
                SINHVIENBindingSource.Position = SINHVIENBindingSource.Count - 1;
                return;
            }

            if (_formState == FormState.Editing) {
                SINHVIENBindingSource.Position = _sinhVienCursorPosition;
            }
        }
    }
}