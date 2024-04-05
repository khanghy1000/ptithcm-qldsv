using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QLDSV.Forms {
    public partial class LopTinChiForm : XtraForm {
        private int _cursorPosision = 0;
        private string _maKhoa = "";
        private FormState _formState = FormState.None;

        private string _nienKhoaBeforeEditing = "";
        private string _hocKyBeforeEditing = "";
        private string _maMhBeforeEditing = "";
        private string _nhomBeforeEditing = "";
        private string _maGvBeforeEditing = "";
        private string _maKhoaBeforeEditing = "";
        private string _soSvToiThieuBeforeEditing = "";
        private bool _huyLopBeforeEditing = false;

        private Stack<string> _undoStack = new Stack<string>();

        public LopTinChiForm() {
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
                Database.DataReader.Close();
                MessageBox.Show("Lỗi lấy mã khoa", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private Result CheckLtcInput() {
            if (NIENKHOATextEdit.Text.Trim() == "") {
                MessageBox.Show("Niên khóa không được trống", "Lỗi", MessageBoxButtons.OK);
                NIENKHOATextEdit.Focus();
                return Result.Failure;
            }

            if (HOCKYSpinEdit.Text.Trim() == "") {
                MessageBox.Show("Học kỳ không được trống", "Lỗi", MessageBoxButtons.OK);
                HOCKYSpinEdit.Focus();
                return Result.Failure;
            }

            if (NHOMSpinEdit.Text.Trim() == "") {
                MessageBox.Show("Nhóm không được trống", "Lỗi", MessageBoxButtons.OK);
                NHOMSpinEdit.Focus();
                return Result.Failure;
            }

            if (MAMHTextEdit.Text.Trim() == "") {
                MessageBox.Show("Mã môn học không được trống", "Lỗi", MessageBoxButtons.OK);
                MAMHTextEdit.Focus();
                return Result.Failure;
            }

            if (MAGVTextEdit.Text.Trim() == "") {
                MessageBox.Show("Mã giảng viên không được trống", "Lỗi", MessageBoxButtons.OK);
                MAGVTextEdit.Focus();
                return Result.Failure;
            }

            if (SOSVTOITHIEUSpinEdit.Text.Trim() == "") {
                MessageBox.Show("Số sinh viên tối thiểu không được trống", "Lỗi", MessageBoxButtons.OK);
                SOSVTOITHIEUSpinEdit.Focus();
                return Result.Failure;
            }

            if (int.Parse(HOCKYSpinEdit.Text.Trim()) < 1 || int.Parse(HOCKYSpinEdit.Text.Trim()) > 4){
                MessageBox.Show("1 <= học kỳ <= 4", "Lỗi", MessageBoxButtons.OK);
                HOCKYSpinEdit.Focus();
                return Result.Failure;
            }

            if (int.Parse(NHOMSpinEdit.Text.Trim()) < 1) {
                MessageBox.Show("Nhóm phải >= 1", "Lỗi", MessageBoxButtons.OK);
                NHOMSpinEdit.Focus();
                return Result.Failure;
            }

            if (int.Parse(SOSVTOITHIEUSpinEdit.Text.Trim()) <= 0) {
                MessageBox.Show("Số sinh viên tối thiểu phải > 0", "Lỗi", MessageBoxButtons.OK);
                SOSVTOITHIEUSpinEdit.Focus();
                return Result.Failure;
            }

            if (!Regex.IsMatch(NIENKHOATextEdit.Text.Trim(), @"^\d{4}-\d{4}$")) {
                MessageBox.Show("Niên khoá phải có format ####-####\nVí dụ: 2021-2022", "Lỗi", MessageBoxButtons.OK);
                NIENKHOATextEdit.Focus();
                return Result.Failure;
            }

            if ((_formState == FormState.Adding) ||
                (_formState == FormState.Editing && (NIENKHOATextEdit.Text.Trim() != _nienKhoaBeforeEditing ||
                                                     HOCKYSpinEdit.Text.Trim() != _hocKyBeforeEditing ||
                                                     MAMHTextEdit.Text.Trim() != _maMhBeforeEditing ||
                                                     NHOMSpinEdit.Text.Trim() != _nhomBeforeEditing))) {
                var checkMaLopStatement =
                    $"EXEC sp_check_lop_tin_chi N'{NIENKHOATextEdit.Text.Trim()}', {HOCKYSpinEdit.Text.Trim()}, N'{MAMHTextEdit.Text.Trim()}', {NHOMSpinEdit.Text.Trim()}";
                Database.DataReader = Database.ExecSqlDataReader(checkMaLopStatement);

                if (Database.DataReader == null) {
                    MessageBox.Show("Lỗi kiểm tra lớp tín chỉ", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }

                Database.DataReader.Read();
                try {
                    var result = Database.DataReader.GetInt32(0);
                    Database.DataReader.Close();

                    if (result == 1) {
                        MessageBox.Show(
                            "Niên khoá + học kỳ + mã môn học + nhóm bị trùng với ltc khác.\nVui lòng đổi thông tin.",
                            "Lỗi", MessageBoxButtons.OK);
                        return Result.Failure;
                    }

                    if (result == 2) {
                        MessageBox.Show(
                            "Niên khoá + học kỳ + mã môn học + nhóm bị trùng với ltc của khoa khác.\nVui lòng đổi thông tin.",
                            "Lỗi", MessageBoxButtons.OK);
                        return Result.Failure;
                    }
                }
                catch {
                    Database.DataReader.Close();
                    MessageBox.Show("Lỗi kiểm tra mã lớp", "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        private void TemplateForm_Load(object sender, EventArgs e) {
            subscriberDataSet.EnforceConstraints = false;

            MONHOCTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            DSGVTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            DSGVTableAdapter.Fill(subscriberDataSet.DSGV);
            LOPTINCHITableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);

            comboBoxKhoa.DataSource = Database.BindingSourcePhanManh;
            comboBoxKhoa.DisplayMember = "ten_phan_manh";
            comboBoxKhoa.ValueMember = "ten_server";
            comboBoxKhoa.SelectedIndex = Database.InitialKhoaIndex;
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

            MONHOCTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            DSGVTableAdapter.Connection.ConnectionString = Database.ConnectionString;
            DSGVTableAdapter.Fill(subscriberDataSet.DSGV);
            LOPTINCHITableAdapter.Connection.ConnectionString = Database.ConnectionString;
            LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);

            LoadMaKhoa();

            // Reset buttons
            _formState = FormState.None;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";
            btnSave.Enabled = btnCancel.Enabled = false;
            panelLTCInput.Enabled = false;
            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;

            _undoStack = new Stack<string>();
            btnUndo.Enabled = false;
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _cursorPosision = LOPTINCHIBindingSource.Position;
            subscriberDataSet.LOPTINCHI.HUYLOPColumn.DefaultValue = false;
            LOPTINCHIBindingSource.AddNew();
            _formState = FormState.Adding;
            MAKHOATextEdit.Text = _maKhoa;

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLTCInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            comboBoxKhoa.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (LOPTINCHIBindingSource.Count <= 0) return;

            var dr = (DataRowView)LOPTINCHIBindingSource[LOPTINCHIBindingSource.Position];

            var maLtc = dr["MALTC"].ToString().Trim();
            var nienKhoa = dr["NIENKHOA"].ToString().Trim();
            var hocKy = dr["HOCKY"].ToString().Trim();
            var maMh = dr["MAMH"].ToString().Trim();
            var nhom = dr["NHOM"].ToString().Trim();
            var maGv = dr["MAGV"].ToString().Trim();
            var maKhoa = dr["MAKHOA"].ToString().Trim();
            var soSvToiThieu = dr["SOSVTOITHIEU"].ToString().Trim();
            var huyLop = bool.Parse(dr["HUYLOP"].ToString().Trim());


            if (MessageBox.Show($"Bạn chắc chắn muốn xóa lớp tín chỉ này không??", "Xác nhận",
                    MessageBoxButtons.OKCancel) ==
                DialogResult.OK) {
                try {
                    LOPTINCHIBindingSource.RemoveCurrent();
                    LOPTINCHITableAdapter.Update(subscriberDataSet.LOPTINCHI);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi xóa lớp tín chỉ\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);
                    LOPTINCHIBindingSource.Position = LOPTINCHIBindingSource.Find("MALTC", maLtc);
                    return;
                }

                var undoStatement =
                    $"INSERT INTO LOPTINCHI (NIENKHOA, HOCKY, MAMH, NHOM, MAGV, MAKHOA, SOSVTOITHIEU, HUYLOP) VALUES (N'{nienKhoa}', {hocKy}, N'{maMh}', {nhom}, N'{maGv}', N'{maKhoa}', {soSvToiThieu}, {(huyLop ? 1 : 0)})";
                _undoStack.Push(undoStatement);
                btnUndo.Enabled = true;
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            if (LOPTINCHIBindingSource.Count <= 0) return;

            _cursorPosision = LOPTINCHIBindingSource.Position;
            _formState = FormState.Editing;

            _nienKhoaBeforeEditing = NIENKHOATextEdit.Text.Trim();
            _hocKyBeforeEditing = HOCKYSpinEdit.Text.Trim();
            _maMhBeforeEditing = MAMHTextEdit.Text.Trim();
            _nhomBeforeEditing = NHOMSpinEdit.Text.Trim();
            _maGvBeforeEditing = MAGVTextEdit.Text.Trim();
            _maKhoaBeforeEditing = MAKHOATextEdit.Text.Trim();
            _soSvToiThieuBeforeEditing = SOSVTOITHIEUSpinEdit.Text.Trim();
            _huyLopBeforeEditing = HUYLOPCheckEdit.Checked;

            btnSave.Enabled = btnCancel.Enabled = true;
            panelLTCInput.Enabled = true;

            btnAdd.Enabled = btnDelete.Enabled =
                btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            comboBoxKhoa.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            if (CheckLtcInput() == Result.Success) {
                string maLtc;
                try {
                    LOPTINCHIBindingSource.EndEdit();
                    LOPTINCHITableAdapter.Update(subscriberDataSet.LOPTINCHI);

                    var dr = (DataRowView)LOPTINCHIBindingSource[LOPTINCHIBindingSource.Position];
                    maLtc = dr["MALTC"].ToString().Trim();
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lỗi ghi lớp tín chỉ\n{ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                if (_formState == FormState.Adding) {
                    var undoStatement = $"DELETE FROM LOPTINCHI WHERE MALTC={maLtc}";
                    _undoStack.Push(undoStatement);
                }

                if (_formState == FormState.Editing) {
                    var undoStatement =
                        $"UPDATE LOPTINCHI SET NIENKHOA=N'{_nienKhoaBeforeEditing}', HOCKY={_hocKyBeforeEditing}, MAMH=N'{_maMhBeforeEditing}', NHOM={_nhomBeforeEditing}, MAGV=N'{_maGvBeforeEditing}', MAKHOA=N'{_maKhoaBeforeEditing}', SOSVTOITHIEU={_soSvToiThieuBeforeEditing}, HUYLOP={(_huyLopBeforeEditing ? 1 : 0)} WHERE MALTC=N'{maLtc}'";

                    _undoStack.Push(undoStatement);
                }

                btnUndo.Enabled = true;

                _formState = FormState.None;

                btnSave.Enabled = btnCancel.Enabled = false;
                panelLTCInput.Enabled = false;

                btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                comboBoxKhoa.Enabled = Database.UserRole == "PGV";

                btnUndo.Enabled = _undoStack.Count > 0;
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
            LOPTINCHIBindingSource.CancelEdit();

            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            DSGVTableAdapter.Fill(subscriberDataSet.DSGV);
            LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);

            LOPTINCHIBindingSource.Position = _cursorPosision;

            _formState = FormState.None;

            btnSave.Enabled = btnCancel.Enabled = false;
            panelLTCInput.Enabled = false;

            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            comboBoxKhoa.Enabled = Database.UserRole == "PGV";

            btnUndo.Enabled = _undoStack.Count > 0;
        }

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e) {
            var undoStatement = _undoStack.Pop();
            if (_undoStack.Count <= 0) btnUndo.Enabled = false;
            Database.ExecSqlNonQuery(undoStatement);

            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            DSGVTableAdapter.Fill(subscriberDataSet.DSGV);
            LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            MONHOCTableAdapter.Fill(subscriberDataSet.MONHOC);
            DSGVTableAdapter.Fill(subscriberDataSet.DSGV);
            LOPTINCHITableAdapter.Fill(subscriberDataSet.LOPTINCHI);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }

        private void cmbTENMH_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbTENMH.SelectedValue == null) return;
            MAMHTextEdit.Text = cmbTENMH.SelectedValue.ToString().Trim();
        }

        private void cmbHOTENGV_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbHOTENGV.SelectedValue == null) return;
            MAGVTextEdit.Text = cmbHOTENGV.SelectedValue.ToString().Trim();
        }
    }
}