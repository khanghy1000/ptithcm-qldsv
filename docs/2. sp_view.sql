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
    SELECT TENMH=(SELECT TENMH FROM MONHOC mh WHERE mh.MAMH = ltc.MAMH),
           ltc.NHOM,
           HOTENGV=(SELECT gv.HO + ' ' + gv.TEN FROM GIANGVIEN gv WHERE gv.MAGV = ltc.MAGV),
           ltc.SOSVTOITHIEU,
           SOSVDADANGKY=(SELECT COUNT(*)
                         FROM DANGKY dk
                         WHERE dk.MALTC = ltc.MALTC
                           AND (dk.HUYDANGKY = 0 OR dk.HUYDANGKY IS NULL))
    FROM LOPTINCHI ltc
    WHERE ltc.NIENKHOA = @nien_khoa
      AND ltc.HOCKY = @hoc_ky
      AND ltc.HUYLOP = 0
    ORDER BY TENMH, NHOM
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

ALTER PROC sp_get_mon_hoc @nien_khoa VARCHAR(9), @hoc_ky INT
AS
BEGIN
    SELECT ltc.MAMH, mh.TENMH
    FROM (SELECT DISTINCT MAMH FROM LOPTINCHI ltc WHERE ltc.NIENKHOA = @nien_khoa AND ltc.HOCKY = @hoc_ky) ltc
             JOIN (SELECT MAMH, TENMH FROM MONHOC) mh ON ltc.MAMH = mh.MAMH
END
GO

ALTER PROC sp_get_nhom_ltc @nien_khoa VARCHAR(9), @hoc_ky INT, @ma_mh NCHAR(10)
AS
BEGIN
    SELECT DISTINCT NHOM
    FROM LOPTINCHI
    WHERE NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
      AND MAMH = @ma_mh
END
GO

ALTER PROC sp_report_ds_sv_dang_ky_ltc @nien_khoa NCHAR(9), @hoc_ky INT, @nhom INT, @ma_mh NCHAR(10)
AS
BEGIN
    DECLARE @ma_ltc INT
    SELECT @ma_ltc = MALTC
    FROM LOPTINCHI ltc
    WHERE ltc.NIENKHOA = @nien_khoa
      AND ltc.HOCKY = @hoc_ky
      AND ltc.NHOM = @nhom
      AND ltc.MAMH = @ma_mh

    SELECT dk.MASV, HO, TEN, PHAI, MALOP
    FROM (SELECT MASV FROM DANGKY WHERE MALTC = @ma_ltc) dk
             JOIN (SELECT MASV, HO, TEN, IIF(PHAI = '0', 'Nam', N'Nữ') AS PHAI, MALOP FROM SINHVIEN) sv
                  ON dk.MASV = sv.MASV
    ORDER BY TEN, HO
END
GO

ALTER PROC sp_get_ds_ma_sv AS
BEGIN
    SELECT MASV FROM dbo.SINHVIEN ORDER BY MASV
END
GO

ALTER PROC sp_report_phieu_diem @MASV NCHAR(20) AS
BEGIN
    SELECT ltcmh.TENMH, MAX(dk.DIEM_CC * 0.1 + dk.DIEM_GK * 0.3 + dk.DIEM_CK * 0.6) AS DIEM
    FROM (SELECT MALTC, DIEM_CC, DIEM_CK, DIEM_GK
          FROM dbo.DANGKY
          WHERE MASV = @MASV
            AND (HUYDANGKY = 0 OR HUYDANGKY IS NULL)) dk
             JOIN(SELECT mh.MAMH, mh.TENMH, ltc.MALTC
                  FROM (SELECT MAMH, TENMH FROM dbo.MONHOC) mh
                           JOIN(SELECT MALTC, MAMH FROM dbo.LOPTINCHI) ltc ON ltc.MAMH = mh.MAMH) ltcmh
                 ON dk.MALTC = ltcmh.MALTC
    GROUP BY ltcmh.TENMH
    ORDER BY ltcmh.TENMH
END
GO