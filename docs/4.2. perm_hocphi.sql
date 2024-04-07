GRANT EXECUTE ON OBJECT :: dbo.sp_get_login_info TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_hoc_phi_sv TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_ct_hoc_phi_sv TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_ds_ma_lop_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_hoc_ky_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_nien_khoa_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_report_hoc_phi_lop TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_ds_ma_sv TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_check_ma_sv_ton_tai TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_add_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_add_ct_dong_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_update_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_update_ct_dong_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_delete_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_delete_ct_dong_hoc_phi TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_tao_tai_khoan TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_xoa_tai_khoan TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_ds_giang_vien TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_check_tk_gv TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_doi_mk TO PKT
GRANT EXECUTE ON OBJECT :: dbo.sp_get_login_name TO PKT

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT :: dbo.HOCPHI TO PKT
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT :: dbo.CT_DONGHOCPHI TO PKT
GRANT SELECT ON OBJECT :: dbo.KHOA TO PKT
GRANT SELECT ON OBJECT :: dbo.GIANGVIEN TO PKT
GRANT SELECT ON OBJECT :: dbo.LOP TO PKT
GRANT SELECT ON OBJECT :: dbo.SINHVIEN TO PKT
