ALTER VIEW view_get_subscriber
    AS
        SELECT PUBS.description AS ten_phan_manh, subscriber_server AS ten_server
        FROM dbo.sysmergepublications AS PUBS
                 CROSS JOIN
             dbo.sysmergesubscriptions AS SUBS
        WHERE (PUBS.pubid = SUBS.pubid)
          AND (publisher <> subscriber_server)
          AND (PUBS.description <> N'Học phí')
GO

ALTER PROC sp_get_login_info @login_name NVARCHAR(50)
AS
BEGIN
    DECLARE @username NVARCHAR(50)
    SELECT @username = NAME FROM sys.sysusers WHERE sid = SUSER_SID(@login_name)
    SELECT username = @username,
           fullname = (SELECT HO + ' ' + TEN FROM GIANGVIEN WHERE MAGV = @username),
           role= (SELECT NAME
                  FROM sys.sysusers
                  WHERE UID = (SELECT GROUPUID
                               FROM SYS.SYSMEMBERS
                               WHERE MEMBERUID = (SELECT UID
                                                  FROM sys.sysusers
                                                  WHERE NAME = @username)))
END
GO

ALTER PROC sp_get_sinh_vien_info @MSSV NCHAR(10), @password NVARCHAR(40)
AS
BEGIN
    IF EXISTS(SELECT * FROM SINHVIEN SV WHERE SV.MASV = @MSSV AND SV.PASSWORD = @password)
        BEGIN
            DECLARE @username NVARCHAR(50)
            SELECT @username = NAME FROM sys.sysusers WHERE sid = SUSER_SID('sinhvien')

            SELECT MSSV=@MSSV,
                   fullname=(SELECT HO + ' ' + TEN FROM SINHVIEN WHERE MASV = @MSSV),
                   role =(SELECT NAME
                          FROM sys.sysusers
                          WHERE UID = (SELECT GROUPUID
                                       FROM SYS.SYSMEMBERS
                                       WHERE MEMBERUID = (SELECT UID
                                                          FROM sys.sysusers
                                                          WHERE NAME = @username)))
        END
END
GO

ALTER PROCEDURE sp_get_ma_khoa
AS
BEGIN
    SELECT MAKHOA FROM KHOA
END
GO

ALTER PROC sp_check_ma_lop @ma_lop NCHAR(10)
AS
BEGIN
    IF EXISTS(SELECT * FROM LOP WHERE LOP.MALOP = @ma_lop)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    IF EXISTS(SELECT * FROM LINK1.QLDSV_TC.dbo.LOP AS LOP WHERE LOP.MALOP = @ma_lop)
        BEGIN
            SELECT 2 AS result
            RETURN
        END
    SELECT 0 AS result
    RETURN
END
GO

ALTER PROC sp_check_ma_sinh_vien @ma_sinh_vien NCHAR(10)
AS
BEGIN
    IF EXISTS(SELECT * FROM SINHVIEN WHERE SINHVIEN.MASV = @ma_sinh_vien)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    IF EXISTS(SELECT * FROM LINK1.QLDSV_TC.dbo.SINHVIEN AS SINHVIEN WHERE SINHVIEN.MASV = @ma_sinh_vien)
        BEGIN
            SELECT 2 AS result
            RETURN
        END
    SELECT 0 AS result
    RETURN
END
GO

ALTER PROC sp_report_ds_lop_tin_chi @nien_khoa NCHAR(9),
                                    @hoc_ky INT
AS
BEGIN
    SELECT ten_mh=(SELECT TENMH FROM MONHOC mh WHERE mh.MAMH = ltc.MAMH),
           nhom=ltc.NHOM,
           ho_ten_giang_vien=(SELECT gv.HO + ' ' + gv.TEN FROM GIANGVIEN gv WHERE gv.MAGV = ltc.MAGV),
           so_sv_toi_thieu=ltc.SOSVTOITHIEU,
           so_sv_da_dang_ky=(SELECT COUNT(*)
                             FROM DANGKY dk
                             WHERE dk.MALTC = ltc.MALTC
                               AND (dk.HUYDANGKY = 0 OR dk.HUYDANGKY IS NULL))
    FROM LOPTINCHI ltc
    WHERE ltc.NIENKHOA = @nien_khoa
      AND ltc.HOCKY = @hoc_ky
      AND ltc.HUYLOP = 0
    ORDER BY ten_mh, nhom
END
GO

ALTER PROC sp_get_nien_khoa_ltc AS
BEGIN
    SELECT DISTINCT NIENKHOA
    FROM LOPTINCHI
    ORDER BY NIENKHOA
END
GO

ALTER PROC sp_get_hoc_ky_ltc @nien_khoa NCHAR(9) AS
BEGIN
    SELECT DISTINCT HOCKY
    FROM LOPTINCHI
    WHERE NIENKHOA = @nien_khoa
    ORDER BY HOCKY
END
GO

