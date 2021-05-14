USE XepLichThi
GO
/*
TAO TAI KHOAN

RETURN
	0	THANH CONG
	1	TRUNG USERNAME
	-1	DU LIEU TRONG
*/


IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_TK_Tao'))
	DROP PROC proc_TK_Tao
GO

CREATE PROC proc_TK_Tao (
	@UserName nvarchar(50)
	,@Password nvarchar(50)
	,@Type int
	,@Result int OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @UserName IS NULL OR
		@UserName = '' OR
		@Password IS NULL OR
		@Password = '' OR
		@Type IS NULL OR
		@Type = ''
	BEGIN
		SET @Result = -1
		RETURN
	END
	
	IF EXISTS(SELECT UserName FROM TaiKhoan WHERE UserName = @UserName)
	BEGIN
		SET @Result = 1
		RETURN
	END

	INSERT [dbo].[TaiKhoan](UserName,Password,Type) VALUES (@UserName, @Password, @Type)
	
	SET @Result = 1
END
GO

/*
XOA TAI KHOAN

RETURN
	0	THANH CONG
	1	KHONG TIM THAY USERNAME
	-1	DU LIEU TRONG
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_TK_Xoa'))
	DROP PROC proc_TK_Xoa
GO

CREATE PROC proc_TK_Xoa(
	@UserName nvarchar(50)
	,@Result int OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @UserName IS NULL OR
		@UserName = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT UserName FROM TaiKhoan WHERE UserName = @UserName))
	BEGIN
		SET @Result = 1
		RETURN
	END

	DELETE FROM TaiKhoan WHERE UserName = @UserName
	SET @Result = 0
END
GO
/*
SUA QUYEN TAI KHOAN

RETURN
	0	THANH CONG
	1	KHONG TIM THAY USERNAME
	-1	DU LIEU TRONG
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_TK_Sua_Quyen'))
	DROP PROC proc_TK_Sua_Quyen
GO

CREATE PROC proc_TK_Sua_Quyen (
	@UserName nvarchar(50)
	,@Type int
	,@Result int OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @UserName IS NULL OR
		@UserName = '' OR
		@Type IS NULL OR
		@Type = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM TaiKhoan WHERE UserName = @UserName))
	BEGIN
		SET @Result = 1
		RETURN
	END

	UPDATE TaiKhoan
	SET Type = @Type
	WHERE UserName = @UserName
	SET @Result = 0
END
GO
/*
DOI MAT KHAU TAI KHOAN

RETURN
	0	THANH CONG
	1	KHONG TIM THAY USERNAME
	-1	DU LIEU TRONG
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_TK_Doi_Mat_Khau'))
	DROP PROC proc_TK_Doi_Mat_Khau
GO

CREATE PROC proc_TK_Doi_Mat_Khau (
	@UserName nvarchar(50)
	,@Password nvarchar(50)
	,@Result int OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @UserName IS NULL OR
		@UserName = '' OR
		@Password IS NULL OR
		@Password = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM TaiKhoan WHERE UserName = @UserName))
	BEGIN
		SET @Result = 1
		RETURN
	END

	UPDATE TaiKhoan
	SET Password = @Password
	WHERE UserName = @UserName
	SET @Result = 0
END
GO
/*
KIEM TRA DANG NHAP

RETURN type
	-1	DU LIEU TRONG
	-2	SAI USERNAME
	-3	SAI PASSWORD
	>=0 LOAI TAI KHOAN
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_TK_Dang_Nhap'))
	DROP PROC proc_TK_Dang_Nhap
GO

CREATE PROC proc_TK_Dang_Nhap (
	@UserName nvarchar(50)
	,@Password nvarchar(50)
	,@Type int output
)
AS
BEGIN
	SET NOCOUNT ON

	IF @UserName IS NULL OR
		@UserName = '' OR
		@Password IS NULL OR
		@Password = '' OR
		@Type IS NULL OR
		@Type = ''
	BEGIN
		SET @Type = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM TaiKhoan WHERE UserName = @UserName))
	BEGIN
		SET @Type = -2
		RETURN
	END

	IF @Password != (SELECT Password FROM TaiKhoan WHERE UserName = @UserName)
	BEGIN
		SET @Type = -3
		RETURN
	END

	SELECT @Type = Type FROM TaiKhoan WHERE UserName = @UserName
END
GO
/*
TIM KIEM TAI KHOAN

RETURN TABLE KET QUA
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_TK_Tim_Kiem'))
	DROP FUNCTION func_TK_Tim_Kiem
GO

CREATE FUNCTION func_TK_Tim_Kiem (
	@UserName	nvarchar(50)
)
RETURNS TABLE
AS
	RETURN (
		SELECT	*
		FROM	TaiKhoan
		WHERE	UserName LIKE CONCAT('%',@UserName,'%')
	)
GO
/*
THEM SINH VIEN

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	TRUNG MA SINH VIEN
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_SV_Them'))
	DROP PROC proc_SV_Them
GO

CREATE PROC proc_SV_Them (
	@MaSinhVien	nvarchar(50)
	,@TenSinhVien	nvarchar(50)
	,@NgaySinh	date = NULL
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaSinhVien IS NULL OR @MaSinhVien = '' OR @TenSinhVien IS NULL OR @TenSinhVien = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM SinhVien WHERE MaSinhVien = @MaSinhVien)
	BEGIN
		SET @Result = -2
		RETURN
	END

	INSERT INTO SinhVien(MaSinhVien, TenSinhVien, NgaySinh) VALUES (@MaSinhVien, @TenSinhVien, @NgaySinh)
	SET @Result = 0
	RETURN
END
GO

/*
SUA SINH VIEN

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	KHONG TIM THAY MA SINH VIEN
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_SV_Sua'))
	DROP PROC proc_SV_Sua
GO

CREATE PROC proc_SV_Sua (
	@MaSinhVien	nvarchar(50)
	,@TenSinhVien	nvarchar(50)
	,@NgaySinh	date = NULL
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON
	
	IF @MaSinhVien IS NULL OR @MaSinhVien = '' OR @TenSinhVien IS NULL OR @TenSinhVien = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM SinhVien WHERE MaSinhVien = @MaSinhVien))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE SinhVien
	SET	TenSinhVien = @TenSinhVien
		,NgaySinh = @NgaySinh
	WHERE MaSinhVien = @MaSinhVien
	SET @Result = 0
END
GO

/*
XOA SINH VIEN

RETURN Result
	0	XOA THANH CONG
	-1	DU LIEU TRONG
	-2	KHONG TIM THAY MA SINH VIEN
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_SV_Xoa'))
	DROP PROC proc_SV_Xoa
GO

CREATE PROC proc_SV_Xoa (
	@MaSinhVien nvarchar(50)
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaSinhVien IS NULL OR @MaSinhVien = ''
	BEGIN
		SET  @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM SinhVien WHERE MaSinhVien = @MaSinhVien))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM SinhVien
	WHERE MaSinhVien = @MaSinhVien
	SET @Result = 0
END
GO

/*
TIM KIEM SINH VIEN

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_SV_Tim_Kiem'))
	DROP FUNCTION func_SV_Tim_Kiem
GO

CREATE FUNCTION func_SV_Tim_Kiem(
	@In nvarchar(50)
)
RETURNS TABLE
AS
	RETURN(
		SELECT *
		FROM SinhVien
		WHERE MaSinhVien LIKE CONCAT('%',@In,'%') OR TenSinhVien LIKE CONCAT('%',@In,'%')
	)
GO

/*
THEM PHONG THI

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	TRUNG MA PHONG THI
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_PT_Them'))
	DROP PROC proc_PT_Them
GO

CREATE PROC proc_PT_Them (
	@MaPhongThi nvarchar(50)
	,@LoaiPhongThi nvarchar(50)
	,@SoChoNgoi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaPhongThi IS NULL OR @MaPhongThi = '' OR
		@LoaiPhongThi IS NULL OR @LoaiPhongThi = '' OR
		@SoChoNgoi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi)
	BEGIN
		SET @Result = -2
		RETURN
	END

	INSERT INTO PhongThi(MaPhongThi,LoaiPhongThi,SoChoNgoi) VALUES (@MaPhongThi, @LoaiPhongThi, @SoChoNgoi)
	SET @Result = 0
	RETURN
END
GO

/*
SUA PHONG THI

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	KHONG TIM THAY MA PHONG THI
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_PT_Sua'))
	DROP PROC proc_PT_Sua
GO

CREATE PROC proc_PT_Sua (
	@MaPhongThi nvarchar(50)
	,@LoaiPhongThi nvarchar(50)
	,@SoChoNgoi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaPhongThi IS NULL OR @MaPhongThi = '' OR
		@LoaiPhongThi IS NULL OR @LoaiPhongThi = '' OR
		@SoChoNgoi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE PhongThi
	SET	LoaiPhongThi = @LoaiPhongThi
		,SoChoNgoi = @SoChoNgoi
	WHERE MaPhongThi = @MaPhongThi
	SET @Result = 0
END
GO

/*
XOA PHONG THI

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	KHONG TIM THAY MA PHONG THI
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_PT_Xoa'))
	DROP PROC proc_PT_Xoa
GO

CREATE PROC proc_PT_Xoa (
	@MaPhongThi nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaPhongThi IS NULL OR @MaPhongThi = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM PhongThi
	WHERE MaPhongThi = @MaPhongThi
	SET @Result = 0
END
GO

/*
TIM KIEM PHONG THI

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_PT_Tim_Kiem'))
	DROP FUNCTION func_PT_Tim_Kiem
GO

CREATE FUNCTION func_PT_Tim_Kiem (
	@In nvarchar(50)
)
RETURNS TABLE
AS
	RETURN(
		SELECT * FROM PhongThi
		WHERE MaPhongThi LIKE CONCAT('%',@In,'%') OR LoaiPhongThi LIKE CONCAT('%',@In,'%')
	)
GO