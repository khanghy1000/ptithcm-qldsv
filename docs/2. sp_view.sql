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