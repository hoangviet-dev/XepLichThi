USE [master]
GO
/****** Object:  Database [XepLichThi]    Script Date: 13/05/2021 4:15:50 PM ******/
CREATE DATABASE [XepLichThi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XepLichThi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\XepLichThi.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XepLichThi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\XepLichThi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XepLichThi] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XepLichThi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XepLichThi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XepLichThi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XepLichThi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XepLichThi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XepLichThi] SET ARITHABORT OFF 
GO
ALTER DATABASE [XepLichThi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XepLichThi] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [XepLichThi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XepLichThi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XepLichThi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XepLichThi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XepLichThi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XepLichThi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XepLichThi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XepLichThi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XepLichThi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XepLichThi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XepLichThi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XepLichThi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XepLichThi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XepLichThi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XepLichThi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XepLichThi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XepLichThi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XepLichThi] SET  MULTI_USER 
GO
ALTER DATABASE [XepLichThi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XepLichThi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XepLichThi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XepLichThi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [XepLichThi]
GO
/****** Object:  Table [dbo].[DanhSachSVLopHP]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachSVLopHP](
	[MaSinhVien] [nvarchar](50) NOT NULL,
	[MaLopHocPhan] [nvarchar](50) NOT NULL,
	[ThuocKHDT] [bit] NOT NULL,
 CONSTRAINT [PK_DanhSachSVLopHP] PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC,
	[MaLopHocPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DieuKien]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DieuKien](
	[MaDieuKien] [nvarchar](50) NOT NULL,
	[TenDieuKien] [nvarchar](50) NOT NULL,
	[SoBuoiNghi] [int] NOT NULL,
 CONSTRAINT [PK_DieuKien] PRIMARY KEY CLUSTERED 
(
	[MaDieuKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichThi]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichThi](
	[MaLichThi] [nvarchar](50) NOT NULL,
	[MaLopHocPhan] [nvarchar](50) NOT NULL,
	[NgayThi] [datetime] NOT NULL,
	[ThoiGian] [int] NOT NULL,
	[MaPhongThi] [nvarchar](50) NOT NULL,
	[HinhThuc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LichThi] PRIMARY KEY CLUSTERED 
(
	[MaLichThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[MaLopHocPhan] [nvarchar](50) NOT NULL,
	[TenLopHocPhan] [nvarchar](50) NOT NULL,
	[SoTinChi] [int] NOT NULL,
 CONSTRAINT [PK_LopHocPhan] PRIMARY KEY CLUSTERED 
(
	[MaLopHocPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongThi]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongThi](
	[MaPhongThi] [nvarchar](50) NOT NULL,
	[LoaiPhongThi] [nvarchar](50) NOT NULL,
	[SoChoNgoi] [int] NOT NULL,
 CONSTRAINT [PK_PhongThi] PRIMARY KEY CLUSTERED 
(
	[MaPhongThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSinhVien] [nvarchar](50) NOT NULL,
	[TenSinhVien] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 13/05/2021 4:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DanhSachSVLopHP]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachSVLopHP_LopHocPhan] FOREIGN KEY([MaLopHocPhan])
REFERENCES [dbo].[LopHocPhan] ([MaLopHocPhan])
GO
ALTER TABLE [dbo].[DanhSachSVLopHP] CHECK CONSTRAINT [FK_DanhSachSVLopHP_LopHocPhan]
GO
ALTER TABLE [dbo].[DanhSachSVLopHP]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachSVLopHP_SinhVien] FOREIGN KEY([MaSinhVien])
REFERENCES [dbo].[SinhVien] ([MaSinhVien])
GO
ALTER TABLE [dbo].[DanhSachSVLopHP] CHECK CONSTRAINT [FK_DanhSachSVLopHP_SinhVien]
GO
ALTER TABLE [dbo].[LichThi]  WITH CHECK ADD  CONSTRAINT [FK_LichThi_LopHocPhan] FOREIGN KEY([MaLopHocPhan])
REFERENCES [dbo].[LopHocPhan] ([MaLopHocPhan])
GO
ALTER TABLE [dbo].[LichThi] CHECK CONSTRAINT [FK_LichThi_LopHocPhan]
GO
ALTER TABLE [dbo].[LichThi]  WITH CHECK ADD  CONSTRAINT [FK_LichThi_PhongThi] FOREIGN KEY([MaPhongThi])
REFERENCES [dbo].[PhongThi] ([MaPhongThi])
GO
ALTER TABLE [dbo].[LichThi] CHECK CONSTRAINT [FK_LichThi_PhongThi]
GO
USE [master]
GO
ALTER DATABASE [XepLichThi] SET  READ_WRITE 
GO
