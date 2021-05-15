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

	INSERT TaiKhoan(UserName,Password,Type) VALUES (@UserName, @Password, @Type)
	
	SET @Result = 0
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
		@Password = ''
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
	-3	LOAI PHONG THI KHONG TON TAI
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_PT_Them'))
	DROP PROC proc_PT_Them
GO

CREATE PROC proc_PT_Them (
	@MaPhongThi nvarchar(50)
	,@MaLoaiPhongThi nvarchar(50)
	,@SoChoNgoi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaPhongThi IS NULL OR @MaPhongThi = '' OR
		@MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = '' OR
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

	IF NOT(EXISTS(SELECT * FROM LoaiPhongThi WHERE MaLoaiPhongThi = @MaLoaiPhongThi))

	INSERT INTO PhongThi(MaPhongThi,MaLoaiPhongThi,SoChoNgoi) VALUES (@MaPhongThi, @MaLoaiPhongThi, @SoChoNgoi)
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
	,@MaLoaiPhongThi nvarchar(50)
	,@SoChoNgoi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaPhongThi IS NULL OR @MaPhongThi = '' OR
		@MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = '' OR
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
	SET	MaLoaiPhongThi = @MaLoaiPhongThi
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
		SELECT MaPhongThi, LoaiPhongThi.LoaiPhongThi, SoChoNgoi
		FROM PhongThi JOIN LoaiPhongThi ON PhongThi.MaLoaiPhongThi = LoaiPhongThi.MaLoaiPhongThi
		WHERE MaPhongThi LIKE CONCAT('%',@In,'%') OR LoaiPhongThi LIKE CONCAT('%',@In,'%')
	)
GO

/*
THEM LOAI PHONG THI

RETURN Result
	0	THEM THANH CONG
	-1	DU LIEU TRONG
	-2	TRUNG MA LOAI PHONG THI
	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_LPT_Them'))
	DROP PROC proc_LPT_Them
GO

CREATE PROC proc_LPT_Them (
	@MaLoaiPhongThi nvarchar(50)
	,@LoaiPhongThi nvarchar(50)
	,@ChiTiet nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = '' OR
		@LoaiPhongThi IS NULL OR @LoaiPhongThi = '' 
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM LoaiPhongThi WHERE MaLoaiPhongThi = @MaLoaiPhongThi)
	BEGIN
		SET @Result = -2
		RETURN
	END

	INSERT INTO LoaiPhongThi(MaLoaiPhongThi,LoaiPhongThi,ChiTiet) VALUES (@MaLoaiPhongThi, @LoaiPhongThi, @ChiTiet)
	SET @Result = 0
	RETURN
END
GO

/*
SUA PHONG THI

RETURN Result
	0: sửa thành công
	-1: dữ liệu trống
	-2: không có mã loại phòng thi

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_PT_Sua'))
	DROP PROC proc_PT_Sua
GO

CREATE PROC proc_PT_Sua (
	@MaLoaiPhongThi nvarchar(50)
	,@LoaiPhongThi nvarchar(50)
	,@ChiTiet nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = '' OR
		@MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LoaiPhongThi WHERE MaLoaiPhongThi = @MaLoaiPhongThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE LoaiPhongThi
	SET	LoaiPhongThi = @LoaiPhongThi
		,ChiTiet = @ChiTiet
	WHERE MaLoaiPhongThi = @MaLoaiPhongThi
	SET @Result = 0
END
GO

/*
XOA PHONG THI

RETURN Result
	0: xóa thành công
	-1: dữ liệu trống
	-2: không có mã loại phòng thi

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_LPT_Xoa'))
	DROP PROC proc_LPT_Xoa
GO

CREATE PROC proc_LPT_Xoa (
	@MaLoaiPhongThi nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLoaiPhongThi IS NULL OR @MaLoaiPhongThi = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LoaiPhongThi WHERE MaLoaiPhongThi = @MaLoaiPhongThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM LoaiPhongThi
	WHERE MaLoaiPhongThi = @MaLoaiPhongThi
	SET @Result = 0
END
GO

/*
TIM KIEM PHONG THI

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_LPT_Tim_Kiem'))
	DROP FUNCTION func_PT_Tim_Kiem
GO

CREATE FUNCTION func_PT_Tim_Kiem (
	@In nvarchar(50)
)
RETURNS TABLE
AS
	RETURN(
		SELECT	*
		FROM	LoaiPhongThi
		WHERE	MaLoaiPhongThi LIKE CONCAT('%',@In,'%')
			OR LoaiPhongThi LIKE CONCAT('%',@In,'%')
			OR ChiTiet LIKE CONCAT('%',@In,'%') 
	)
GO

/*
THEM DIEU KIEN

RETURN Result
	0: thêm thành công
	-1: dữ liệu trống
	-2: trùng mã điều kiện
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DK_Them'))
	DROP PROC proc_DK_Them
GO

CREATE PROC proc_DK_Them (
	@MaDieuKien nvarchar(50)
	,@TenDieuKien nvarchar(50)
	,@SoBuoiNghi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaDieuKien IS NULL OR @MaDieuKien = '' OR
		@TenDieuKien IS NULL OR @TenDieuKien = '' OR
		@SoBuoiNghi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM DieuKien WHERE MaDieuKien = @MaDieuKien)
	BEGIN
		SET @Result = -2
		RETURN
	END

	INSERT INTO DieuKien (MaDieuKien, TenDieuKien, SoBuoiNghi) VALUES (@MaDieuKien, @TenDieuKien, @SoBuoiNghi)
	SET @Result = 0
	RETURN
END
GO

/*
SUA DIEU KIEN

RETURN Result
	0: thêm thành công
	-1: dữ liệu trống
	-2: không tìm thấy mã điều kiện

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DK_Sua'))
	DROP PROC proc_DK_Sua
GO

CREATE PROC proc_DK_Sua (
	@MaDieuKien nvarchar(50)
	,@TenDieuKien nvarchar(50)
	,@SoBuoiNghi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaDieuKien IS NULL OR @MaDieuKien = '' OR
		@TenDieuKien IS NULL OR @TenDieuKien = '' OR
		@SoBuoiNghi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM DieuKien WHERE MaDieuKien = @MaDieuKien))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE DieuKien
	SET	TenDieuKien = @TenDieuKien
		,SoBuoiNghi = @SoBuoiNghi
	WHERE MaDieuKien = @MaDieuKien
	SET @Result = 0
END


GO

/*
XOA DIEU KIEN

RETURN Result
	0: thêm thành công
	-1: dữ liệu trống
	-2: không tìm thấy mã điều kiện

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DK_Xoa'))
	DROP PROC proc_DK_Xoa
GO

CREATE PROC proc_DK_Xoa (
	@MaDieuKien nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaDieuKien IS NULL OR @MaDieuKien = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM DieuKien WHERE MaDieuKien = @MaDieuKien))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM DieuKien
	WHERE MaDieuKien = @MaDieuKien
	SET @Result = 0
END
GO

/*
TIM KIEM PHONG THI

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_DK_Tim_Kiem'))
	DROP FUNCTION func_DK_Tim_Kiem
GO

CREATE FUNCTION func_DK_Tim_Kiem (
	@MaDieuKien nvarchar(50)
	,@TenDieuKien nvarchar(50)
)
RETURNS TABLE
AS
	RETURN(
		SELECT * 
		FROM DieuKien
		WHERE MaDieuKien LIKE CONCAT('%',@MaDieuKien,'%') OR TenDieuKien LIKE CONCAT('%',@TenDieuKien,'%')
	)
GO

/*
THEM LOP HOC PHAN

RETURN Result
	0: thêm thành công
	-1: dữ liệu trống
	-2: trùng mã lớp học phần

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_LopHP_Them'))
	DROP PROC proc_LopHP_Them
GO

CREATE PROC proc_LopHP_Them (
	@MaLopHocPhan nvarchar(50)
	,@TenLopHocPhan nvarchar(50)
	,@SoTinChi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLopHocPhan IS NULL OR @MaLopHocPhan = '' OR
		@TenLopHocPhan IS NULL OR @TenLopHocPhan = '' OR 
		@SoTinChi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM LopHocPhan WHERE MaLopHocPhan = @MaLopHocPhan)
	BEGIN
		SET @Result = -2
		RETURN
	END

	INSERT LopHocPhan (MaLopHocPhan, TenLopHocPhan, SoTinChi) VALUES (@MaLopHocPhan, @TenLopHocPhan, @SoTinChi)
	SET @Result = 0
END
GO

/*
SUA LOP HOC PHAN

RETURN Result
	0: sửa thành công
	-1: dữ liệu trống
	-2: không có mã lớp học phần
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_LopHP_Sua'))
	DROP PROC proc_LopHP_Sua
GO

CREATE PROC proc_LopHP_Sua (
	@MaLopHocPhan nvarchar(50)
	,@TenLopHocPhan nvarchar(50)
	,@SoTinChi int
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLopHocPhan IS NULL OR @MaLopHocPhan = '' OR
		@TenLopHocPhan IS NULL OR @TenLopHocPhan = '' OR 
		@SoTinChi IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LopHocPhan WHERE MaLopHocPhan = @MaLopHocPhan))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE LopHocPhan
	SET	TenLopHocPhan = @TenLopHocPhan
		,SoTinChi = @SoTinChi
	WHERE MaLopHocPhan = @MaLopHocPhan
	SET @Result = 0 
END
GO

/*
XOA LOP HOC PHAN

RETURN Result
	0: sửa thành công
	-1: dữ liệu trống
	-2: không có mã lớp học phần
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_LopHP_Xoa'))
	DROP PROC proc_LopHP_Xoa
GO

CREATE PROC proc_LopHP_Xoa (
	@MaLopHocPhan nvarchar(50)
	,@Result int OUT
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLopHocPhan IS NULL OR @MaLopHocPhan = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LopHocPhan WHERE MaLopHocPhan = @MaLopHocPhan))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM LopHocPhan
	WHERE MaLopHocPhan = @MaLopHocPhan
	SET @Result = 0
END
GO

/*
TIM KIEM LOP HOC PHAN

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_LopHP_Tim_Kiem'))
	DROP FUNCTION func_LopHP_Tim_Kiem
GO

CREATE FUNCTION func_LopHP_Tim_Kiem (
	@MaLopHocPhan nvarchar(50)
	,@TenLopHocPhan nvarchar(50)
)
RETURNS TABLE
AS
	RETURN(
		SELECT *
		FROM	LopHocPhan
		WHERE	MaLopHocPhan LIKE CONCAT('%',@MaLopHocPhan,'%') OR TenLopHocPhan LIKE CONCAT('%',@TenLopHocPhan,'%')
	)
GO

/*
THEM DSSV LOP HP

RETURN Result
	0: thêm dữ liệu thành công
	-1: dữ liệu trống
	-2: mã sinh viên không tồn tại
	-3: mã lớp học phần không tồn tại
	-4: mối quan hệ đã tồn tại
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DSSV_LHP_Them'))
	DROP PROC proc_DSSV_LHP_Them
GO

CREATE PROC proc_DSSV_LHP_Them (
	@MaSinhVien nvarchar(50)
	,@MaLopHocPhan nvarchar(50)
	,@LanHoc int
	,@ThuocKHDT bit
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaSinhVien IS NULL OR @MaSinhVien = '' OR
		@MaLopHocPhan IS NULL OR @MaLopHocPhan = '' OR
		@LanHoc IS NULL OR
		@ThuocKHDT IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM SinhVien WHERE MaSinhVien = @MaSinhVien))
	BEGIN
		SET @Result = -2
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LopHocPhan WHERE MaLopHocPhan = @MaLopHocPhan))
	BEGIN
		SET @Result = -3
		RETURN
	END

	IF EXISTS(SELECT * 
				FROM DanhSachSVLopHP 
				WHERE MaSinhVien = @MaSinhVien AND
					MaLopHocPhan = @MaLopHocPhan AND
					LanHoc = @LanHoc)
	BEGIN
		SET @Result = -4
		RETURN
	END

	INSERT INTO DanhSachSVLopHP (MaSinhVien, MaLopHocPhan, LanHoc, ThuocKHDT)
	VALUES (@MaSinhVien, @MaLopHocPhan, @LanHoc, @ThuocKHDT)
	SET @Result = 0
END
GO

/*
SUA DSSV LOP HP

RETURN Result
	0: sửa dữ liệu thành công
	-1: dữ liệu trống
	-2: mã sinh viên, mã lớp học, lần học phần không tồn tại
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DSSV_LHP_Sua'))
	DROP PROC proc_DSSV_LHP_Sua
GO

CREATE PROC proc_DSSV_LHP_Sua (
	@MaSinhVien nvarchar(50)
	,@MaLopHocPhan nvarchar(50)
	,@LanHoc int
	,@ThuocKHDT bit
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaSinhVien IS NULL OR @MaSinhVien = '' OR
		@MaLopHocPhan IS NULL OR @MaLopHocPhan = '' OR
		@LanHoc IS NULL OR
		@ThuocKHDT IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT *
					FROM DanhSachSVLopHP 
					WHERE MaSinhVien = @MaSinhVien AND 
						MaLopHocPhan = @MaLopHocPhan AND
						LanHoc = @LanHoc))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE DanhSachSVLopHP
	SET	ThuocKHDT = @ThuocKHDT
	WHERE MaSinhVien = @MaSinhVien AND
		MaLopHocPhan = @MaLopHocPhan AND
		LanHoc = @LanHoc
	SET @Result = 0
END
GO

/*
XOA DSSV LOP HP

RETURN Result
	0: xóa dữ liệu thành công
	-1: dữ liệu trống
	-2: mã sinh viên, mã lớp học phần, lần học không tồn tại
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_DSSV_LHP_Xoa'))
	DROP PROC proc_DSSV_LHP_Xoa
GO

CREATE PROC proc_DSSV_LHP_Xoa (
	@MaSinhVien nvarchar(50)
	,@MaLopHocPhan nvarchar(50)
	,@LanHoc int
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaSinhVien IS NULL OR @MaSinhVien = '' OR
		@MaLopHocPhan IS NULL OR @MaLopHocPhan = '' OR
		@LanHoc IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT *
					FROM DanhSachSVLopHP
					WHERE	MaSinhVien = @MaSinhVien
						AND MaLopHocPhan = @MaLopHocPhan
						AND	LanHoc = @LanHoc))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE DanhSachSVLopHP
	WHERE	MaSinhVien = @MaSinhVien
		AND MaLopHocPhan = @MaLopHocPhan
		AND LanHoc = @LanHoc
	SET @Result = 0
END
GO

/*
TIM KIEM DSSV LOP HP

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_DSSV_LHP_Tim_Kiem'))
	DROP FUNCTION func_DSSV_LHP_Tim_Kiem
GO

CREATE FUNCTION func_DSSV_LHP_Tim_Kiem (
	@MaSinhVien nvarchar(50)
	,@MaLopHocPhan nvarchar(50)
)
RETURNS TABLE
AS
	RETURN (
			SELECT *
			FROM	DanhSachSVLopHP
			WHERE	MaSinhVien LIKE CONCAT('%',@MaSinhVien,'%')
				OR MaLopHocPhan LIKE CONCAT('%',@MaLopHocPhan,'%')
			)
GO

/*
THEM LICH THI

RETURN Result
	0: Thêm dữ liệu thành công
	-1: dữ liệu trống
	-2: Mã lịch thi đã tồn tại
	-3: Mã lớp học phần không tồn tại
	-4: Mã phòng thi không tồn tại
	-5: Định dạng hình thức sai
	-6: Phòng thi sai hình thức thi
	-7: Dữ liệu đã tồn tại

*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_Lich_Thi_Them'))
	DROP PROC proc_Lich_Thi_Them
GO

CREATE PROC proc_Lich_Thi_Them (
	@MaLichThi nvarchar(50)
	,@MaLopHocPhan nvarchar(50)
	,@NgayThi datetime
	,@Thoigian int
	,@MaPhongThi nvarchar(50)
	,@HinhThuc nvarchar(50)
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLichThi IS NULL OR @MaLichThi = '' OR
		@MaLopHocPhan IS NULL OR @MaLichThi = '' OR
		@NgayThi IS NULL OR
		@Thoigian IS NULL OR
		@MaPhongThi IS NULL OR @MaPhongThi = '' OR
		@HinhThuc IS NULL OR @HinhThuc = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF EXISTS(SELECT * FROM LichThi WHERE MaLichThi = @MaLichThi)
	BEGIN
		SET @Result = -2
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LopHocPhan WHERE MaLopHocPhan = @MaLopHocPhan))
	BEGIN
		SET @Result = -3
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM PhongThi WHERE MaPhongThi = @MaPhongThi))
	BEGIN
		SET @Result = -4
		RETURN
	END
	
	IF NOT(@HinhThuc IN ('LT','TH','VD'))
	BEGIN
		SET @Result = -5
		RETURN
	END

	DECLARE @LoaiPhongThi nvarchar(50)
	SELECT	@LoaiPhongThi = LoaiPhongThi
	FROM	PhongThi AS PT
		JOIN LoaiPhongThi AS LPT ON PT.MaLoaiPhongThi = LPT.MaLoaiPhongThi
	WHERE	MaPhongThi = @MaPhongThi
	IF CHARINDEX(@HinhThuc, @LoaiPhongThi) = 0
	BEGIN
		SET @Result = -6
		RETURN
	END

	IF EXISTS(SELECT	*
				FROM	LichThi
				WHERE	MaLichThi = @MaLichThi
					AND	MaLopHocPhan = @MaLopHocPhan
					AND MaPhongThi = @MaPhongThi
					AND ThoiGian = @Thoigian
			)
	BEGIN
		SET @Result = -7
		RETURN
	END

	INSERT INTO LichThi (MaLichThi, MaLopHocPhan, NgayThi, ThoiGian, MaPhongThi, HinhThuc)
	VALUES (@MaLichThi, @MaLopHocPhan, @NgayThi, @Thoigian, @MaPhongThi, @HinhThuc)
	SET @Result = 0
END
GO

/*
SUA LICH THI

RETURN Result
	0: Sửa dữ liệu thành công
	-1: dữ liệu trống
	-2: Mã lịch thi không tồn tại
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_Lich_Thi_Sua'))
	DROP PROC proc_Lich_Thi_Sua
GO

CREATE PROC proc_Lich_Thi_Sua (
	@MaLichThi nvarchar(50)
	,@NgayThi datetime
	,@Thoigian int
	,@Result int
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLichThi IS NULL OR @MaLichThi = '' OR
		@NgayThi IS NULL OR
		@Thoigian IS NULL
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LichThi WHERE MaLichThi = @MaLichThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	UPDATE	LichThi
	SET		NgayThi = @NgayThi
			,ThoiGian = @Thoigian
	WHERE	MaLichThi = @MaLichThi
	SET @Result = 0
END
GO

/*
XOA LICH THI

RETURN Result
	0: Sửa dữ liệu thành công
	-1: dữ liệu trống
	-2: Mã lịch thi không tồn tại
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'proc_Lich_Thi_Xoa'))
	DROP PROC proc_Lich_Thi_Xoa
GO

CREATE PROC proc_Lich_Thi_Xoa (
	@MaLichThi nvarchar(50)
	,@Result int	
)
AS
BEGIN
	SET NOCOUNT ON

	IF @MaLichThi IS NULL OR @MaLichThi = ''
	BEGIN
		SET @Result = -1
		RETURN
	END

	IF NOT(EXISTS(SELECT * FROM LichThi WHERE MaLichThi = @MaLichThi))
	BEGIN
		SET @Result = -2
		RETURN
	END

	DELETE FROM	LichThi
	WHERE		MaLichThi = @MaLichThi
	SET			@Result = 0
END
GO

/*
TIM KIEM LICH THI THEO MA

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_Lich_Thi_TK_Ma'))
	DROP FUNCTION func_Lich_Thi_TK_Ma
GO

CREATE FUNCTION func_Lich_Thi_TK_Ma (
	@MaLichThi nvarchar(50)
	,@FromDate datetime
	,@ToDate datetime
)
RETURNS @Res TABLE (
	MaLichThi	nvarchar(50)
	,MaLopHocPhan	nvarchar(50)
	,NgayThi	datetime
	,ThoiGian	int
	,MaPhongThi	nvarchar(50)
	,HinhThuc	nvarchar(50)
)
AS
BEGIN
	IF @FromDate IS NULL
		SET @FromDate = DATEFROMPARTS(1900,1,1)

	IF @ToDate IS NULL
		SET @ToDate = DATEADD(YEAR, 1, GETDATE())
	
	INSERT INTO @Res
	SELECT	*
	FROM	LichThi
	WHERE	MaLichThi LIKE CONCAT('%',@MaLichThi,'%')
		AND NgayThi > @FromDate
		AND	NgayThi < @ToDate
	RETURN
END
GO

/*
TIM KIEM LICH THI THEO LOP HOC PHAN

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_Lich_Thi_TK_LHP'))
	DROP FUNCTION func_Lich_Thi_TK_LHP
GO

CREATE FUNCTION func_Lich_Thi_TK_LHP (
	@MaLopHocPhan nvarchar(50)
	,@FromDate datetime
	,@ToDate datetime
)
RETURNS @Res TABLE (
	MaLichThi	nvarchar(50)
	,MaLopHocPhan	nvarchar(50)
	,NgayThi	datetime
	,ThoiGian	int
	,MaPhongThi	nvarchar(50)
	,HinhThuc	nvarchar(50)
)
AS
BEGIN
	IF @FromDate IS NULL
		SET @FromDate = DATEFROMPARTS(1900,1,1)

	IF @ToDate IS NULL
		SET @ToDate = DATEADD(YEAR, 1, GETDATE())
	
	INSERT INTO @Res
	SELECT	*
	FROM	LichThi
	WHERE	MaLopHocPhan LIKE CONCAT('%',@MaLopHocPhan,'%')
		AND NgayThi > @FromDate
		AND	NgayThi < @ToDate
	RETURN
END
GO

/*
TIM KIEM LICH THI THEO LOP PHONG THI

RETURN TABLE
	KET QUA TRA VE	
*/
IF (EXISTS(SELECT * FROM sys.objects WHERE name = 'func_Lich_Thi_TK_PT'))
	DROP FUNCTION func_Lich_Thi_TK_PT
GO

CREATE FUNCTION func_Lich_Thi_TK_PT (
	@MaPhongThi nvarchar(50)
	,@FromDate datetime
	,@ToDate datetime
)
RETURNS @Res TABLE (
	MaLichThi	nvarchar(50)
	,MaLopHocPhan	nvarchar(50)
	,NgayThi	datetime
	,ThoiGian	int
	,MaPhongThi	nvarchar(50)
	,HinhThuc	nvarchar(50)
)
AS
BEGIN
	IF @FromDate IS NULL
		SET @FromDate = DATEFROMPARTS(1900,1,1)

	IF @ToDate IS NULL
		SET @ToDate = DATEADD(YEAR, 1, GETDATE())
	
	INSERT INTO @Res
	SELECT	*
	FROM	LichThi
	WHERE	MaPhongThi LIKE CONCAT('%',@MaPhongThi,'%')
		AND NgayThi > @FromDate
		AND	NgayThi < @ToDate
	RETURN
END
GO