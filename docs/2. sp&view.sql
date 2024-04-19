ALTER VIEW view_get_subscriber
    AS
        SELECT PUBS.description AS ten_phan_manh, subscriber_server AS ten_server
        FROM dbo.sysmergepublications AS PUBS
                 CROSS JOIN
             dbo.sysmergesubscriptions AS SUBS
        WHERE (PUBS.pubid = SUBS.pubid)
          AND (publisher <> subscriber_server)
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

ALTER PROCEDURE sp_check_ten_lop @ten_lop NVARCHAR(200)
AS
BEGIN
    IF EXISTS(SELECT * FROM LOP WHERE LOP.TENLOP = @ten_lop)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    ELSE
        IF EXISTS(SELECT * FROM LINK1.QLDSV_TC.dbo.LOP AS LOP WHERE LOP.TENLOP = @ten_lop)
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
    FROM (SELECT MASV FROM DANGKY WHERE MALTC = @ma_ltc AND (HUYDANGKY = 0 OR HUYDANGKY IS NULL)) dk
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

ALTER PROC sp_report_bang_diem_ltc @nien_khoa NCHAR(9), @hoc_ky INT, @nhom INT, @ma_mh NCHAR(10)
AS
BEGIN
    DECLARE @ma_ltc INT
    SELECT @ma_ltc = MALTC
    FROM LOPTINCHI ltc
    WHERE ltc.NIENKHOA = @nien_khoa
      AND ltc.HOCKY = @hoc_ky
      AND ltc.NHOM = @nhom
      AND ltc.MAMH = @ma_mh

    SELECT dk.MASV, HO, TEN, DIEM_CC, DIEM_GK, DIEM_CK
    FROM (SELECT MASV, DIEM_CC, DIEM_GK, DIEM_CK
          FROM DANGKY
          WHERE MALTC = @ma_ltc
            AND (HUYDANGKY = 0 OR HUYDANGKY IS NULL)) dk
             JOIN (SELECT MASV, HO, TEN FROM SINHVIEN) sv
                  ON dk.MASV = sv.MASV
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

ALTER PROC sp_get_ds_ma_lop_hoc_phi @ma_khoa NCHAR(10) AS
BEGIN
    SELECT DISTINCT MALOP
    FROM (SELECT MASV, SINHVIEN.MALOP
          FROM (SELECT MALOP FROM LOP WHERE MAKHOA = @ma_khoa) l
                   JOIN SINHVIEN ON SINHVIEN.MALOP = l.MALOP) sv
             JOIN HOCPHI ON sv.MASV = HOCPHI.MASV
    ORDER BY MALOP
END
GO

ALTER PROC sp_get_nien_khoa_hoc_phi @ma_lop NCHAR(10) AS
BEGIN
    SELECT DISTINCT NIENKHOA
    FROM (SELECT MASV FROM SINHVIEN WHERE MALOP = @ma_lop) sv
             JOIN HOCPHI ON sv.MASV = HOCPHI.MASV
    ORDER BY NIENKHOA
END
GO

ALTER PROC sp_get_hoc_ky_hoc_phi @ma_lop NCHAR(10), @nien_khoa NCHAR(9) AS
BEGIN
    SELECT DISTINCT HOCKY
    FROM (SELECT MASV FROM SINHVIEN WHERE MALOP = @ma_lop) sv
             JOIN (SELECT MASV, HOCKY FROM HOCPHI WHERE NIENKHOA = @nien_khoa) hp
                  ON sv.MASV = hp.MASV
    ORDER BY HOCKY
END
GO

ALTER PROC sp_report_hoc_phi_lop @ma_lop NCHAR(10),
                                 @nien_khoa NCHAR(9),
                                 @hoc_ky INT
AS
BEGIN
    SELECT sv.MASV, sv.HOTEN, hp.HOCPHI, cthp.SOTIENDADONG
    FROM (SELECT MASV, HO + ' ' + TEN AS HOTEN FROM SINHVIEN WHERE MALOP = @ma_lop) sv
             JOIN (SELECT HOCPHI, MASV
                   FROM HOCPHI
                   WHERE NIENKHOA = @nien_khoa
                     AND HOCKY = @hoc_ky) hp
                  ON sv.MASV = hp.MASV
             LEFT JOIN (SELECT MASV, SUM(SOTIENDONG) AS SOTIENDADONG
                        FROM CT_DONGHOCPHI
                        WHERE NIENKHOA = @nien_khoa
                          AND HOCKY = @hoc_ky
                        GROUP BY MASV) cthp ON cthp.MASV = sv.MASV
    ORDER BY MASV
END
GO

ALTER PROC sp_report_bang_diem_lop @ma_lop NCHAR(10)
AS
SELECT sv.MASV, HOTEN, TENMH, MAX((DIEM_CC * 0.1 + DIEM_GK * 0.3 + DIEM_CK * 0.6)) AS DIEM
FROM (SELECT MASV, HO + ' ' + TEN AS HOTEN FROM dbo.SINHVIEN WHERE MALOP = @ma_lop) sv
         JOIN (SELECT MASV, MALTC, DIEM_CC, DIEM_GK, DIEM_CK
               FROM dbo.DANGKY
               WHERE HUYDANGKY IS NULL
                  OR HUYDANGKY = 0) dk ON dk.MASV = sv.MASV
         JOIN (SELECT MALTC, MAMH FROM dbo.LOPTINCHI) ltc ON ltc.MALTC = dk.MALTC
         JOIN (SELECT MAMH, TENMH FROM dbo.MONHOC) mh ON mh.MAMH = ltc.MAMH
GROUP BY sv.MASV, HOTEN, TENMH

GO

ALTER PROC sp_check_ma_mon_hoc @ma_mon_hoc NCHAR(10)
AS
BEGIN
    IF EXISTS(SELECT * FROM MONHOC WHERE MONHOC.MAMH = @ma_mon_hoc)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    SELECT 0 AS result
    RETURN
END
GO

ALTER PROCEDURE sp_check_ten_mon_hoc @ten_mon_hoc NVARCHAR(200)
AS
BEGIN
    IF EXISTS(SELECT * FROM MONHOC WHERE MONHOC.TENMH = @ten_mon_hoc)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    SELECT 0 AS result
    RETURN
END
GO

ALTER PROC sp_check_lop_tin_chi @nien_khoa NCHAR(9), @hoc_ky INT, @ma_mh NCHAR(10), @nhom INT
AS
BEGIN
    IF EXISTS(SELECT *
              FROM LOPTINCHI
              WHERE NIENKHOA = @nien_khoa
                AND HOCKY = @hoc_ky
                AND MAMH = @ma_mh
                AND NHOM = @nhom)
        BEGIN
            SELECT 1 AS result
            RETURN
        END

    IF EXISTS(SELECT *
              FROM LINK1.QLDSV_TC.dbo.LOPTINCHI
              WHERE NIENKHOA = @nien_khoa
                AND HOCKY = @hoc_ky
                AND MAMH = @ma_mh
                AND NHOM = @nhom)
        BEGIN
            SELECT 2 AS result
            RETURN
        END

    SELECT 0 AS result
    RETURN
END
GO

ALTER PROC sp_get_ds_ltc @nien_khoa NCHAR(9), @hoc_ky INT
AS
BEGIN
    SELECT MALTC, TENMH, NHOM, HO + ' ' + TEN AS HOTENGV
    FROM (SELECT MALTC, MAMH, NHOM, MAGV
          FROM LOPTINCHI
          WHERE NIENKHOA = @nien_khoa
            AND HOCKY = @hoc_ky
            AND HUYLOP = 'FALSE') ltc
             JOIN (SELECT MAMH, TENMH FROM MONHOC) mh ON ltc.MAMH = mh.MAMH
             JOIN (SELECT MAGV, HO, TEN FROM GIANGVIEN) gv ON ltc.MAGV = gv.MAGV
    ORDER BY TENMH, NHOM
END
GO

ALTER PROC sp_get_dssv_dang_ky_ltc @ma_ltc INT
AS
BEGIN
    SELECT sv.MASV, HO + ' ' + TEN AS HOTENSV, DIEM_CC, DIEM_GK, DIEM_CK
    FROM (SELECT MASV, DIEM_CC, DIEM_GK, DIEM_CK
          FROM DANGKY
          WHERE MALTC = @ma_ltc
            AND (HUYDANGKY = 0 OR HUYDANGKY IS NULL)) dk
             JOIN (SELECT MASV, HO, TEN FROM SINHVIEN) sv
                  ON dk.MASV = sv.MASV
END
GO

ALTER PROC sp_update_diem @diem_thi TYPE_DANGKY READONLY
AS
BEGIN
    MERGE INTO DANGKY AS Target
    USING (SELECT MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK
           FROM @diem_thi) AS Source
    ON Target.MALTC = Source.MALTC AND Target.MASV = Source.MASV
    WHEN MATCHED THEN
        UPDATE
        SET Target.DIEM_CC = Source.DIEM_CC,
            Target.DIEM_GK = Source.DIEM_GK,
            Target.DIEM_CK = Source.DIEM_CK
    WHEN NOT MATCHED THEN
        INSERT (MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK)
        VALUES (Source.MALTC, Source.MASV, Source.DIEM_CC, Source.DIEM_GK, Source.DIEM_CK);
END
GO

ALTER PROC sp_get_ds_ltc_dang_ky @nien_khoa NCHAR(9), @hoc_ky INT, @ma_sinh_vien NCHAR(10)
AS
BEGIN
    SELECT ltc.MALTC,
           mh.MAMH,
           TENMH,
           NHOM,
           HO + ' ' + TEN                             AS HOTENGV,
           IIF(SOSVDADANGKY IS NULL, 0, SOSVDADANGKY) AS SOSVDADANGKY,
           CAST(IIF(HUYDANGKY IS NOT NULL AND HUYDANGKY = 0, 1, 0) AS BIT)  AS DANGKY
    FROM (SELECT MALTC, MAMH, NHOM, MAGV
          FROM LOPTINCHI
          WHERE NIENKHOA = @nien_khoa
            AND HOCKY = @hoc_ky
            AND HUYLOP = 0) ltc
             JOIN (SELECT MAMH, TENMH FROM MONHOC) mh ON ltc.MAMH = mh.MAMH
             JOIN (SELECT MAGV, HO, TEN FROM GIANGVIEN) gv ON ltc.MAGV = gv.MAGV
             LEFT JOIN (SELECT COUNT(*) AS SOSVDADANGKY, MALTC
                        FROM DANGKY
                        WHERE (HUYDANGKY = 0 OR HUYDANGKY IS NULL)
                        GROUP BY MALTC) dk ON ltc.MALTC = dk.MALTC
             LEFT JOIN (SELECT MALTC, HUYDANGKY
                        FROM DANGKY
                        WHERE MASV = @ma_sinh_vien) svdk ON ltc.MALTC = svdk.MALTC
--     WHERE HUYDANGKY IS NULL
--        OR HUYDANGKY = 0

END
GO

ALTER PROC sp_doi_trang_thai_dang_ky_ltc @ma_ltc INT, @ma_sinh_vien NCHAR(10), @dang_ky BIT
AS
BEGIN
    IF @dang_ky = 1
        BEGIN
            IF EXISTS(SELECT * FROM DANGKY WHERE MALTC = @ma_ltc AND MASV = @ma_sinh_vien)
                BEGIN
                    UPDATE DANGKY
                    SET HUYDANGKY = 0
                    WHERE MALTC = @ma_ltc
                      AND MASV = @ma_sinh_vien
                END
            ELSE
                BEGIN
                    INSERT INTO DANGKY (MALTC, MASV, HUYDANGKY)
                    VALUES (@ma_ltc, @ma_sinh_vien, 0)
                END
        END
    ELSE
        BEGIN
            UPDATE DANGKY
            SET HUYDANGKY = 1
            WHERE MALTC = @ma_ltc
              AND MASV = @ma_sinh_vien
        END
END
GO

ALTER PROC sp_get_hoc_phi_sv @ma_sv NCHAR(10)
AS
BEGIN
    SELECT hp.NIENKHOA, hp.HOCKY, HOCPHI, IIF(DADONG IS NULL, 0, DADONG) AS DADONG
    FROM (SELECT * FROM HOCPHI WHERE MASV = @ma_sv) hp
             LEFT JOIN
         (SELECT MASV, NIENKHOA, HOCKY, SUM(SOTIENDONG) AS DADONG
          FROM CT_DONGHOCPHI
          WHERE MASV = @ma_sv
          GROUP BY MASV, NIENKHOA, HOCKY) cthp
         ON hp.MASV = cthp.MASV AND hp.NIENKHOA = cthp.NIENKHOA AND hp.HOCKY = cthp.HOCKY
    ORDER BY NIENKHOA, HOCKY
END
GO

ALTER PROC sp_get_ct_hoc_phi_sv @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT
AS
BEGIN
    SELECT NGAYDONG, SOTIENDONG
    FROM CT_DONGHOCPHI
    WHERE MASV = @ma_sv
      AND NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
    ORDER BY NGAYDONG
END
GO

ALTER PROC sp_check_ma_sv_ton_tai @ma_sv NCHAR(10)
AS
BEGIN
    IF EXISTS(SELECT * FROM SINHVIEN WHERE MASV = @ma_sv)
        BEGIN
            SELECT 0 AS result
            RETURN
        END
    SELECT 1 AS result
    RETURN
END
GO

ALTER PROC sp_add_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT, @hoc_phi INT
AS
BEGIN
    IF EXISTS(SELECT * FROM HOCPHI WHERE MASV = @ma_sv AND NIENKHOA = @nien_khoa AND HOCKY = @hoc_ky)
        BEGIN
            RAISERROR ('Thông tin học phí bị trùng',16,1)
        END
    ELSE
        BEGIN
            INSERT INTO HOCPHI(MASV, NIENKHOA, HOCKY, HOCPHI)
            VALUES (@ma_sv, @nien_khoa, @hoc_ky, @hoc_phi)
        END
END
GO

ALTER PROC sp_update_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT, @hoc_phi INT
AS
BEGIN
    UPDATE HOCPHI
    SET HOCPHI=@hoc_phi
    WHERE MASV = @ma_sv
      AND NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
END
GO

ALTER PROC sp_delete_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT
AS
BEGIN
    DELETE
    FROM HOCPHI
    WHERE MASV = @ma_sv
      AND NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
END
GO

ALTER PROC sp_add_ct_dong_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT,
                                  @ngay_dong DATE, @so_tien_dong INT
AS
BEGIN
    IF EXISTS (SELECT 1
               FROM CT_DONGHOCPHI
               WHERE MASV = @ma_sv
                 AND NIENKHOA = @nien_khoa
                 AND HOCKY = @hoc_ky
                 AND @ngay_dong = NGAYDONG)
        RAISERROR ('Vui lòng đổi ngày đóng',16,1)
    ELSE
        BEGIN
            INSERT INTO CT_DONGHOCPHI(MASV, NIENKHOA, HOCKY, NGAYDONG, SOTIENDONG)
            VALUES (@ma_sv, @nien_khoa, @hoc_ky, @ngay_dong, @so_tien_dong)
        END
END
GO

ALTER PROC sp_update_ct_dong_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT,
                                     @ngay_dong DATE, @so_tien_dong INT
AS
BEGIN
    UPDATE CT_DONGHOCPHI
    SET SOTIENDONG=@so_tien_dong
    WHERE MASV = @ma_sv
      AND NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
      AND NGAYDONG = @ngay_dong
END
GO

ALTER PROC sp_delete_ct_dong_hoc_phi @ma_sv NCHAR(10), @nien_khoa NCHAR(9), @hoc_ky INT, @ngay_dong DATE
AS
BEGIN
    DELETE
    FROM CT_DONGHOCPHI
    WHERE MASV = @ma_sv
      AND NIENKHOA = @nien_khoa
      AND HOCKY = @hoc_ky
      AND NGAYDONG = @ngay_dong
END
GO

ALTER PROC sp_tao_tai_khoan @LGNAME VARCHAR(50), @PASS VARCHAR(50),
                            @USERNAME VARCHAR(50), @ROLE VARCHAR(50)
AS
BEGIN
    DECLARE @RET INT
    EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS, 'QLDSV_TC'
    IF (@RET = 1) -- LOGIN NAME BI TRUNG
        BEGIN
            RAISERROR ('Mã tài khoản bị trùng', 16,1)
            RETURN
        END
    EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
    IF (@RET = 1) -- USER  NAME BI TRUNG
        BEGIN
            EXEC SP_DROPLOGIN @LGNAME
            RAISERROR ('Giảng viên đã có tài khoản', 16,2)
            RETURN
        END
    EXEC sp_addrolemember @ROLE, @USERNAME
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
END
GO

ALTER PROC sp_xoa_tai_khoan @LGNAME VARCHAR(50),
                            @USRNAME VARCHAR(50)
AS
BEGIN
    DECLARE @SID INT
    SELECT @SID = session_id
    FROM sys.dm_exec_sessions
    WHERE login_name = @LGNAME

    DECLARE @cmd NVARCHAR(200)
    SET @cmd = 'KILL ' + CAST(@SID AS VARCHAR(10))
    EXEC (@cmd)

    EXEC SP_DROPUSER @USRNAME
    EXEC SP_DROPLOGIN @LGNAME
END
GO

ALTER PROC sp_get_ds_giang_vien
AS
BEGIN
    SELECT MAGV, HO + ' ' + TEN + ' - ' + MAGV AS HOTEN
    FROM GIANGVIEN
END
GO

ALTER PROC sp_check_tk_gv @ma_gv NCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT SUSER_SNAME(sid)
                  FROM sys.sysusers
                  WHERE name = @ma_gv)
        BEGIN
            SELECT 0 AS result
            RETURN
        END
    SELECT 1 AS result
    RETURN
END
GO

ALTER PROC sp_doi_mk @LOGIN NCHAR(10), @OLDPASS NVARCHAR(40), @NEWPASS NVARCHAR(40)
AS
BEGIN
    BEGIN TRY
        DECLARE @cmd NVARCHAR(200)
        SET @cmd =
            'ALTER LOGIN ' + @LOGIN + ' WITH PASSWORD= ' + QUOTENAME(@NEWPASS, '''') + ' OLD_PASSWORD = ' +
            QUOTENAME(@OLDPASS, '''')
        EXEC (@cmd)
    END TRY
    BEGIN CATCH
        RAISERROR ('Sai mật khẩu',16,1)
    END CATCH
END
GO

ALTER PROC sp_doi_mk_sv @LOGIN NCHAR(10), @OLDPASS NVARCHAR(40), @NEWPASS NVARCHAR(40)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM SINHVIEN WHERE SINHVIEN.MASV = @LOGIN AND SINHVIEN.PASSWORD = @OLDPASS)
        BEGIN
            UPDATE SINHVIEN
            SET SINHVIEN.PASSWORD = @NEWPASS
            WHERE SINHVIEN.MASV = @LOGIN
            RETURN;
        END
    ELSE
        RAISERROR ('Sai mật khẩu', 16, 1)
END
GO

ALTER PROC sp_get_login_name @USERNAME NVARCHAR(50)
AS
BEGIN
    DECLARE @uname SYSNAME = @USERNAME;
    SELECT     SUSER_SNAME(user_sid(USER_ID(@uname))) AS LOGIN,
        ROLE = (SELECT NAME
                FROM sys.sysusers
                WHERE UID = (SELECT GROUPUID
                             FROM SYS.SYSMEMBERS
                             WHERE MEMBERUID = (SELECT UID
                                                FROM sys.sysusers
                                                WHERE NAME = @USERNAME)))
END
GO
