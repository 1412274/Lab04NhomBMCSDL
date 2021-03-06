﻿/*----------------------------------------------------------
MASV: 1412274, 1412282, 1412414
HO TEN CAC THANH VIEN NHOM: 
	1412274 - Nguyen Hoang Kim 
	1412282 - Nguyen Hoang Lan
	1412414 - Vuong Thien Phu
LAB: 04 - NHOM
NGAY: 13/6/2018
----------------------------------------------------------*/
USE QLSVNhom
GO

--i) Stored dùng để thêm mới dữ liệu (Insert) vào table SINHVIEN, trong đó
--• Thuộc tính MATKHAU được mã hóa (HASH) sử dụng SHA1
--• Thuộc tính LUONG sẽ được mã hóa từ tham số LUONGCB sử dụng thuật toán RSA
--512, với khóa bí mật là tham số MK được truyền vào.
--• Thuộc tính PUBKEY sẽ lưu trữ tên khóa công khai được tạo ra ứng với nhân viên
--này, giá trị này sẽ lưu thông tin khóa công khai được tạo từ client.
CREATE PROCEDURE SP_INS_PUBLIC_ENCRYPT_NHANVIEN @MANV VARCHAR(20), 
												@HOTEN NVARCHAR(100), 
												@EMAIL VARCHAR(20),
												@LUONG VARCHAR(2048), 
												@TENDN NVARCHAR(100), 
												@MATKHAU VARCHAR(2048),
												@PUB VARCHAR(2048)
AS 
BEGIN
	DECLARE @LUONG_HASH VARBINARY(2048), @MATKHAU_HASH VARBINARY(2048)
	SET @LUONG_HASH = CONVERT(VARBINARY(2048), @LUONG)
	SET @MATKHAU_HASH = CONVERT(VARBINARY(2048), @MATKHAU)

	INSERT INTO NHANVIEN VALUES (@MANV, @HOTEN, @EMAIL, @LUONG_HASH, @TENDN, @MATKHAU_HASH, @PUB)
END
GO

DROP PROCEDURE SP_INS_PUBLIC_ENCRYPT_NHANVIEN
GO

--ii. Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN)
CREATE PROCEDURE SP_SEL_PUBLIC_ENCRYPT_NHANVIEN @MANV VARCHAR(20), 
												@MATKHAU VARCHAR(2048)
AS
BEGIN
	DECLARE @MATKHAU_BINARY VARBINARY(2048)
	SET @MATKHAU_BINARY = CONVERT(VARBINARY(2048), @MATKHAU)

	SELECT MANV, HOTEN, EMAIL, CONVERT(VARCHAR(2048), LUONG) AS LUONG
	FROM NHANVIEN 
	WHERE MANV = @MANV AND MATKHAU = @MATKHAU_BINARY
END
GO

DROP PROCEDURE SP_SEL_PUBLIC_ENCRYPT_NHANVIEN
GO

--Stored dùng để lấy mã nhân viên lớn nhất trong CSDL
CREATE PROCEDURE SP_MAX_MANV @MANV VARCHAR(20) OUT
AS
BEGIN
	SELECT @MANV = MAX(MANV)
	FROM NHANVIEN
END
GO

DROP PROCEDURE SP_MAX_MANV
GO