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