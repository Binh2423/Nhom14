USE [QuanLySV1]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 24/07/2023 9:05:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [char](3) NOT NULL,
	[TenLop] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 24/07/2023 9:05:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [char](6) NOT NULL,
	[HoTenSV] [nvarchar](40) NULL,
	[NgaySinh] [datetime] NULL,
	[MaLop] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Lop] ([MaLop], [TenLop]) VALUES (N'CN1', N'Công Nghệ Thông Tin')
INSERT [dbo].[Lop] ([MaLop], [TenLop]) VALUES (N'KT1', N'Kế Toán')
INSERT [dbo].[Lop] ([MaLop], [TenLop]) VALUES (N'NNA', N'Ngôn Ngữ Anh')
GO
INSERT [dbo].[SinhVien] ([MaSV], [HoTenSV], [NgaySinh], [MaLop]) VALUES (N'SV0001', N'Kiều Nguyễn Thanh Bình', CAST(N'2003-12-14T00:00:00.000' AS DateTime), N'CN1')
INSERT [dbo].[SinhVien] ([MaSV], [HoTenSV], [NgaySinh], [MaLop]) VALUES (N'SV0002', N'Nguyễn Phạm Diễm Quỳnh', CAST(N'2003-06-06T00:00:00.000' AS DateTime), N'CN1')
INSERT [dbo].[SinhVien] ([MaSV], [HoTenSV], [NgaySinh], [MaLop]) VALUES (N'SV0003', N'Nguyễn Thanh Tùng', CAST(N'2003-07-07T00:00:00.000' AS DateTime), N'CN1')
INSERT [dbo].[SinhVien] ([MaSV], [HoTenSV], [NgaySinh], [MaLop]) VALUES (N'SV0004', N'Huỳnh Thanh Tuấn', CAST(N'2003-08-08T00:00:00.000' AS DateTime), N'NNA')
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
