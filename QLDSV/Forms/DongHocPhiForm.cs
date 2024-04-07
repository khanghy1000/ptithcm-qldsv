using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;

namespace QLDSV.Forms {
    public partial class DongHocPhiForm : XtraForm {
        private int _hocPhiCursorPosision = 0;
        private int _ctHocPhiCursorPosision = 0;
        private FormState _formState = FormState.None;

        private int _hocPhiBeforeEditing = 0;
        private int _soTienDongBeforeEditing = 0;

        public DongHocPhiForm() {
            InitializeComponent();
        }

        private void LoadMaSV() {
            string smt = "EXEC sp_get_ds_ma_sv";
            DataTable dt = Database.ExecSqlDataTable(smt);
            cmbMaSV.DataSource = dt;
            cmbMaSV.DisplayMember = "MASV";
            cmbMaSV.ValueMember = "MASV";
        }

        private Result CheckMaSV() {
            var smt = $"EXEC sp_check_ma_sv_ton_tai N'{cmbMaSV.Text.Trim()}'";
            Database.DataReader = Database.ExecSqlDataReader(smt);

            if (Database.DataReader == null) {
                MessageBox.Show("Lỗi kiểm tra mã sinh viên", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            Database.DataReader.Read();
            try {
                var result = Database.DataReader.GetInt32(0);
                Database.DataReader.Close();

                if (result == 1) {
                    MessageBox.Show("Mã sinh viên không tồn tại.\nVui lòng nhập mã khác.", "Lỗi",
                        MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }
            catch {
                Database.DataReader.Close();
                MessageBox.Show("Lỗi kiểm tra mã sinh viên", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            return Result.Success;
        }

        private Result CheckHocPhiInput() {
            if (NIENKHOATextEdit.Text.Trim().Length == 0) {
                MessageBox.Show("Niên khóa không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (HOCKYSpinEdit.Text.Trim().Length == 0) {
                MessageBox.Show("Học kỳ không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (HOCPHISpinEdit.Text.Trim().Length == 0) {
                MessageBox.Show("Học phí không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (!Regex.IsMatch(NIENKHOATextEdit.Text.Trim(), @"^\d{4}-\d{4}$")) {
                MessageBox.Show("Niên khoá phải có format ####-####\nVí dụ: 2021-2022", "Lỗi", MessageBoxButtons.OK);
                NIENKHOATextEdit.Focus();
                return Result.Failure;
            }

            if (Convert.ToInt32(HOCKYSpinEdit.Value) < 1 || Convert.ToInt32(HOCKYSpinEdit.Value) > 4) {
                MessageBox.Show("1 <= học kỳ <= 4", "Lỗi", MessageBoxButtons.OK);
                HOCKYSpinEdit.Focus();
                return Result.Failure;
            }

            if (Convert.ToInt32(HOCPHISpinEdit.Value) <= 0) {
                MessageBox.Show("Học phí phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK);
                HOCPHISpinEdit.Focus();
                return Result.Failure;
            }

            if (_formState == FormState.Editing && CT_HOCPHIBindingSource.Count > 0 &&
                Convert.ToInt32(HOCKYSpinEdit.Value) != _hocPhiBeforeEditing) {
                var dr = (DataRowView)HOCPHIBindingSource[HOCPHIBindingSource.Position];
                var daDong = Convert.ToInt32(dr["DADONG"]);
                if (Convert.ToInt32(HOCPHISpinEdit.Value) < daDong) {
                    MessageBox.Show("Học phí không thể nhỏ hơn số tiền đã đóng", "Lỗi", MessageBoxButtons.OK);
                    HOCPHISpinEdit.Focus();
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        private Result CheckCtHocPhiInput() {
            var dr = (DataRowView)CT_HOCPHIBindingSource[
                _formState == FormState.Adding ? CT_HOCPHIBindingSource.Count - 1 : _ctHocPhiCursorPosision];

            if (dr["NGAYDONG"] == DBNull.Value) {
                MessageBox.Show("Ngày đóng không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (dr["SOTIENDONG"].ToString().Trim() == "") {
                MessageBox.Show("Số tiền đóng không được để trống", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (Convert.ToInt32(dr["SOTIENDONG"]) <= 0) {
                MessageBox.Show("Số tiền đóng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK);
                return Result.Failure;
            }

            if (_formState == FormState.Adding) {
                var hpDr = (DataRowView)HOCPHIBindingSource[HOCPHIBindingSource.Position];
                var canDong = Convert.ToInt32(hpDr["HOCPHI"]) - Convert.ToInt32(hpDr["DADONG"]);

                if (Convert.ToInt32(dr["SOTIENDONG"]) > canDong) {
                    MessageBox.Show($"Số tiền đóng phải <= {canDong:n0}", "Lỗi",
                        MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            if (_formState == FormState.Editing && Convert.ToInt32(dr["SOTIENDONG"]) > _soTienDongBeforeEditing) {
                var hpDr = (DataRowView)HOCPHIBindingSource[HOCPHIBindingSource.Position];
                var canDong = Convert.ToInt32(hpDr["HOCPHI"]) - Convert.ToInt32(hpDr["DADONG"]);

                if ((Convert.ToInt32(dr["SOTIENDONG"]) - _soTienDongBeforeEditing) > canDong) {
                    MessageBox.Show(
                        $"Số tiền đóng phải <= {(canDong + _soTienDongBeforeEditing):n0}",
                        "Lỗi", MessageBoxButtons.OK);
                    return Result.Failure;
                }
            }

            return Result.Success;
        }

        private void TemplateForm_Load(object sender, EventArgs e) {
            LoadMaSV();
        }

        private void btnSubmitMASV_Click(object sender, EventArgs e) {
            if (CheckMaSV() == Result.Success) {
                try {
                    HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());

                    var smt =
                        $"SELECT MASV, HO + ' ' + TEN AS HOTEN, MALOP FROM SINHVIEN WHERE MASV = '{cmbMaSV.Text.Trim()}'";
                    Database.DataReader = Database.ExecSqlDataReader(smt);
                    if (Database.DataReader == null) return;
                    Database.DataReader.Read();
                    textMASV.Text = Database.DataReader.GetString(0);
                    textHOTEN.Text = Database.DataReader.GetString(1);
                    textMALOP.Text = Database.DataReader.GetString(2);
                    Database.DataReader.Close();
                    Database.Connection.Close();
                }
                catch (Exception ex) {
                    if (Database.DataReader != null) Database.DataReader.Close();
                    MessageBox.Show("Lỗi tải thông tin học phí\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK);
                    return;
                }

                MessageBox.Show($"Tải thông tin học phí của sinh viên {cmbMaSV.Text.Trim()} thành công.", "Thành công",
                    MessageBoxButtons.OK);

                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;
                panelInputHocPhi.Enabled = false;
                btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = true;
                btnCtSave.Enabled = btnCtCancel.Enabled = false;
                gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
                CT_HOCPHIGridControl.Enabled = true;
                btnSubmitMASV.Enabled = cmbMaSV.Enabled = true;
                btnExit.Enabled = true;
            }
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e) {
            _hocPhiCursorPosision = HOCPHIBindingSource.Position;
            _ctHocPhiCursorPosision = CT_HOCPHIBindingSource.Position;

            // gridViewHOCPHI.AddNewRow();
            HOCPHIBindingSource.AddNew();
            _formState = FormState.Adding;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;
            panelInputHocPhi.Enabled = true;
            NIENKHOATextEdit.Enabled = true;
            HOCKYSpinEdit.Enabled = true;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = false;
            btnCtSave.Enabled = btnCtCancel.Enabled = false;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
            CT_HOCPHIGridControl.Enabled = false;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = false;
            btnExit.Enabled = false;

            NIENKHOATextEdit.Text = "";
            HOCKYSpinEdit.Value = 0;
            HOCPHISpinEdit.Value = 0;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (HOCPHIBindingSource.Count <= 0) return;

            var smt =
                $"EXEC sp_delete_hoc_phi N'{textMASV.Text.Trim()}', N'{NIENKHOATextEdit.Text.Trim()}', {HOCKYSpinEdit.Value}";
            if (Database.ExecSqlNonQuery(smt) != 0) {
                MessageBox.Show("Lỗi xóa học phí", "Lỗi", MessageBoxButtons.OK);
            }

            HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            if (HOCPHIBindingSource.Count <= 0) return;

            _hocPhiCursorPosision = HOCPHIBindingSource.Position;
            _ctHocPhiCursorPosision = CT_HOCPHIBindingSource.Position;
            _formState = FormState.Editing;

            _hocPhiBeforeEditing = Convert.ToInt32(HOCPHISpinEdit.Value);

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;
            panelInputHocPhi.Enabled = true;
            NIENKHOATextEdit.Enabled = false;
            HOCKYSpinEdit.Enabled = false;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = false;
            btnCtSave.Enabled = btnCtCancel.Enabled = false;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
            CT_HOCPHIGridControl.Enabled = false;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = false;
            btnExit.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            if (CheckHocPhiInput() == Result.Success) {
                if (_formState == FormState.Adding) {
                    var smt =
                        $"EXEC sp_add_hoc_phi N'{textMASV.Text.Trim()}', N'{NIENKHOATextEdit.Text.Trim()}', {HOCKYSpinEdit.Value}, {HOCPHISpinEdit.Value}";
                    if (Database.ExecSqlNonQuery(smt) != 0) {
                        MessageBox.Show("Lỗi thêm học phí", "Lỗi", MessageBoxButtons.OK);
                    }
                }

                if (_formState == FormState.Editing) {
                    var smt =
                        $"EXEC sp_update_hoc_phi N'{textMASV.Text.Trim()}', N'{NIENKHOATextEdit.Text.Trim()}', {HOCKYSpinEdit.Value}, {HOCPHISpinEdit.Value}";
                    if (Database.ExecSqlNonQuery(smt) != 0) {
                        MessageBox.Show("Lỗi cập nhật học phí", "Lỗi", MessageBoxButtons.OK);
                    }
                }
                HOCPHIBindingSource.EndEdit();

                HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
                CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                    NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));

                HOCPHIBindingSource.Position = _hocPhiCursorPosision;
                CT_HOCPHIBindingSource.Position = _ctHocPhiCursorPosision;

                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;
                panelInputHocPhi.Enabled = false;
                btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = true;
                btnCtSave.Enabled = btnCtCancel.Enabled = false;
                gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
                CT_HOCPHIGridControl.Enabled = true;
                btnSubmitMASV.Enabled = cmbMaSV.Enabled = true;
                btnExit.Enabled = true;
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e) {
            HOCPHIBindingSource.CancelEdit();
            _formState = FormState.None;

            HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));

            HOCPHIBindingSource.Position = _hocPhiCursorPosision;
            CT_HOCPHIBindingSource.Position = _ctHocPhiCursorPosision;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            panelInputHocPhi.Enabled = false;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = true;
            btnCtSave.Enabled = btnCtCancel.Enabled = false;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
            CT_HOCPHIGridControl.Enabled = true;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = true;
            btnExit.Enabled = true;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }

        private void gridViewHOCPHI_InvalidRowException(object sender,
            InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewCT_HOCPHI_InvalidRowException(object sender,
            InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void btnCtAdd_ItemClick(object sender, ItemClickEventArgs e) {
            var hpDr = (DataRowView)HOCPHIBindingSource[HOCPHIBindingSource.Position];
            var canDong = Convert.ToInt32(hpDr["HOCPHI"]) - Convert.ToInt32(hpDr["DADONG"]);
            if (canDong == 0) {
                MessageBox.Show("Học phí đã đóng đủ", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            CT_HOCPHIBindingSource.AddNew();
            _formState = FormState.Adding;

            _hocPhiCursorPosision = HOCPHIBindingSource.Position;
            _ctHocPhiCursorPosision = CT_HOCPHIBindingSource.Position;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = false;
            panelInputHocPhi.Enabled = false;
            HOCPHIGridControl.Enabled = false;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = false;
            btnCtSave.Enabled = btnCtCancel.Enabled = true;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = false;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = false;
            btnExit.Enabled = false;
        }

        private void btnCtDelete_ItemClick(object sender, ItemClickEventArgs e) {
            if (CT_HOCPHIBindingSource.Count <= 0) return;

            var dr = (DataRowView)CT_HOCPHIBindingSource[CT_HOCPHIBindingSource.Position];
            var maSv = textMASV.Text.Trim();
            var nienKhoa = NIENKHOATextEdit.Text.Trim();
            var hocKy = Convert.ToInt32(HOCKYSpinEdit.Value);
            var ngayDong = (DateTime)dr["NGAYDONG"];

            var smt = $"EXEC sp_delete_ct_dong_hoc_phi N'{maSv}', N'{nienKhoa}', {hocKy}, '{ngayDong:yyyy-MM-dd}'";

            if (Database.ExecSqlNonQuery(smt) != 0) {
                MessageBox.Show("Lỗi xóa chi tiết học phí", "Lỗi", MessageBoxButtons.OK);
            }

            _hocPhiCursorPosision = HOCPHIBindingSource.Position;

            HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));

            HOCPHIBindingSource.Position = _hocPhiCursorPosision;
        }

        private void btnCtEdit_ItemClick(object sender, ItemClickEventArgs e) {
            if (CT_HOCPHIBindingSource.Count <= 0) return;

            _formState = FormState.Editing;

            _soTienDongBeforeEditing =
                Convert.ToInt32(((DataRowView)CT_HOCPHIBindingSource[CT_HOCPHIBindingSource.Position])["SOTIENDONG"]);

            _hocPhiCursorPosision = HOCPHIBindingSource.Position;
            _ctHocPhiCursorPosision = CT_HOCPHIBindingSource.Position;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = false;
            panelInputHocPhi.Enabled = false;
            HOCPHIGridControl.Enabled = false;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = false;
            btnCtSave.Enabled = btnCtCancel.Enabled = true;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = false;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = false;
            btnExit.Enabled = false;
        }

        private void btnCtSave_ItemClick(object sender, ItemClickEventArgs e) {
            if (CheckCtHocPhiInput() == Result.Success) {
                var dr = (DataRowView)CT_HOCPHIBindingSource[CT_HOCPHIBindingSource.Position];
                var maSv = textMASV.Text.Trim();
                var nienKhoa = NIENKHOATextEdit.Text.Trim();
                var hocKy = Convert.ToInt32(HOCKYSpinEdit.Value);
                var ngayDong = (DateTime)dr["NGAYDONG"];
                var soTienDong = Convert.ToInt32(dr["SOTIENDONG"]);

                if (_formState == FormState.Adding) {
                    var smt =
                        $"EXEC sp_add_ct_dong_hoc_phi N'{maSv}', N'{nienKhoa}', {hocKy}, '{ngayDong:yyyy-MM-dd}', {soTienDong}";
                    if (Database.ExecSqlNonQuery(smt) != 0) {
                        MessageBox.Show("Lỗi thêm chi tiết học phí", "Lỗi", MessageBoxButtons.OK);
                    }
                }

                if (_formState == FormState.Editing) {
                    var smt =
                        $"EXEC sp_update_ct_dong_hoc_phi N'{maSv}', N'{nienKhoa}', {hocKy}, '{ngayDong:yyyy-MM-dd}', {soTienDong}";
                    if (Database.ExecSqlNonQuery(smt) != 0) {
                        MessageBox.Show("Lỗi cập nhật chi tiết học phí", "Lỗi", MessageBoxButtons.OK);
                    }
                }

                _formState = FormState.None;

                HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
                CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                    NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));

                HOCPHIBindingSource.Position = _hocPhiCursorPosision;
                CT_HOCPHIBindingSource.Position = _ctHocPhiCursorPosision;

                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;
                panelInputHocPhi.Enabled = false;
                HOCPHIGridControl.Enabled = true;
                btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = true;
                btnCtSave.Enabled = btnCtCancel.Enabled = false;
                gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
                btnSubmitMASV.Enabled = cmbMaSV.Enabled = true;
                btnExit.Enabled = true;
            }
        }

        private void btnCtCancel_ItemClick(object sender, ItemClickEventArgs e) {
            CT_HOCPHIBindingSource.CancelEdit();
            _formState = FormState.None;

            HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_hoc_phi_sv, cmbMaSV.Text.Trim());
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                NIENKHOATextEdit.Text.Trim(), Convert.ToInt32(HOCKYSpinEdit.Value));

            HOCPHIBindingSource.Position = _hocPhiCursorPosision;
            CT_HOCPHIBindingSource.Position = _ctHocPhiCursorPosision;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            panelInputHocPhi.Enabled = false;
            HOCPHIGridControl.Enabled = true;
            btnCtAdd.Enabled = btnCtEdit.Enabled = btnCtDelete.Enabled = true;
            btnCtSave.Enabled = btnCtCancel.Enabled = false;
            gridViewCT_HOCPHI.OptionsBehavior.ReadOnly = true;
            btnSubmitMASV.Enabled = cmbMaSV.Enabled = true;
            btnExit.Enabled = true;
        }

        private void gridViewHOCPHI_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var dr = (DataRowView)HOCPHIBindingSource[HOCPHIBindingSource.Position];
            CT_HOCPHITableAdapter.Fill(hocPhiDataSet.sp_get_ct_hoc_phi_sv, cmbMaSV.Text.Trim(),
                dr["NIENKHOA"].ToString().Trim(), int.Parse(dr["HOCKY"].ToString().Trim()));

            if (_formState == FormState.Adding) {
                HOCPHIBindingSource.Position = HOCPHIBindingSource.Count - 1;
                return;
            }

            if (_formState == FormState.Editing) {
                HOCPHIBindingSource.Position = _hocPhiCursorPosision;
            }

        }

        private void gridViewCT_HOCPHI_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (_formState == FormState.Adding) {
                CT_HOCPHIBindingSource.Position = CT_HOCPHIBindingSource.Count - 1;
                return;
            }

            if (_formState == FormState.Editing) {
                CT_HOCPHIBindingSource.Position = _ctHocPhiCursorPosision;
            }
        }
    }
}