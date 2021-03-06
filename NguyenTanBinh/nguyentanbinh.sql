USE [NguyenTanBinhDB]
GO
/****** Object:  Table [dbo].[HangSX]    Script Date: 6/20/2021 2:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangSX](
	[IdHang] [int] IDENTITY(1,1) NOT NULL,
	[HangSX] [nvarchar](50) NULL,
 CONSTRAINT [PK_HangSX] PRIMARY KEY CLUSTERED 
(
	[IdHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeDH]    Script Date: 6/20/2021 2:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeDH](
	[IdHdh] [int] IDENTITY(1,1) NOT NULL,
	[HeDieuHanh] [nvarchar](50) NULL,
 CONSTRAINT [PK_HeDH] PRIMARY KEY CLUSTERED 
(
	[IdHdh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/20/2021 2:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[GiaTien] [decimal](18, 0) NULL,
	[BoNho] [int] NULL,
	[Ram] [int] NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[IdHang] [int] NULL,
	[IdHDH] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 6/20/2021 2:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[IdTT] [int] IDENTITY(1,1) NOT NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[IdTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/20/2021 2:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HangSX] ON 

INSERT [dbo].[HangSX] ([IdHang], [HangSX]) VALUES (1, N'SamSung ')
INSERT [dbo].[HangSX] ([IdHang], [HangSX]) VALUES (2, N'Apple')
INSERT [dbo].[HangSX] ([IdHang], [HangSX]) VALUES (3, N'Xiaomi')
SET IDENTITY_INSERT [dbo].[HangSX] OFF
GO
SET IDENTITY_INSERT [dbo].[HeDH] ON 

INSERT [dbo].[HeDH] ([IdHdh], [HeDieuHanh]) VALUES (1, N'Android')
INSERT [dbo].[HeDH] ([IdHdh], [HeDieuHanh]) VALUES (2, N'IOS')
SET IDENTITY_INSERT [dbo].[HeDH] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (2, N'Samsung Galaxy S20 Ultra Chính Hãng', 12, CAST(16790000 AS Decimal(18, 0)), 128, 12, N's20-ultra-black.png', N'Điện thoại Samsung Cao cấp', 1, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (3, N'Samsung Galaxy Note 20 Ultra 5G', 9, CAST(29990000 AS Decimal(18, 0)), 256, 12, N'note-20-utra-5g.png', N'Điện thoại Samsung Cao cấp', 1, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (4, N'Samsung Galaxy M20', 5, CAST(4290000 AS Decimal(18, 0)), 32, 3, N'galaxy-M20-xanh.png', N'Điện thoại Samsung tầm trung', 1, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (5, N'Samsung Galaxy A72', 10, CAST(10120000 AS Decimal(18, 0)), 256, 8, N'A52-White.png', N'Điện thoại Samsung tầm trung', 1, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (6, N'iPhone 12 Pro Max', 6, CAST(28950000 AS Decimal(18, 0)), 128, 6, N'iPhone_12_pro_vang.jpg', N'Iphone chính hãng -  nguyên Seal', 2, 2)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (7, N'iPhone 11 Chính Hãng VN/A', 3, CAST(15650000 AS Decimal(18, 0)), 64, 4, N'iphone-11-red.png', N'iPhone 11 chính hãng - Hàng mới, nguyên Seal', 2, 2)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (8, N'iPhone 12 64GB Chính Hãng', 8, CAST(19750000 AS Decimal(18, 0)), 64, 4, N'iPhone-12-moi.jpg', N'iPhone chính hãng. Hàng mới nguyên Seal', 2, 2)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (9, N'Xiaomi Redmi Note 10 chính hãng', 12, CAST(3990000 AS Decimal(18, 0)), 128, 6, N'xiaomi-redmi-note-10-xanh2.png', N'Điện thoại pin khủng 5000 mAh', 3, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (10, N'Xiaomi Redmi Note 10 5G', 20, CAST(4590000 AS Decimal(18, 0)), 128, 4, N'xiaomi-redmi-note-10-5g.png', N'Điện thoại Xiaomi công nghệ 5G', 3, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (11, N'Samsung Galaxy S21', 12, CAST(21790000 AS Decimal(18, 0)), 128, 12, N's21-ultra-den.png', N'Samsung Galaxy S21 Ultra 12Gb/128Gb Chính Hãng Camera 108MP, Zoom 100x', 1, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (12, N'iPhone XS Cũ 64Gb', 4, CAST(9690000 AS Decimal(18, 0)), 64, 4, N'xs-max-grey.png', N'iPhone XS Cũ 64Gb Nguyên Bản Đẹp Như Mới', 2, 2)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (13, N'iPhone 8 Plus Cũ 64Gb', 6, CAST(6990000 AS Decimal(18, 0)), 64, 3, N'iphone-8-plus-cu.png', N'iPhone 8 Plus Cũ 64Gb Nguyên Bản Đẹp Như Mới', 2, 2)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (14, N'Xiaomi Mi 10T Pro 5G', 12, CAST(10190000 AS Decimal(18, 0)), 256, 8, N'xiaomi-mi-10t.png', N'Xiaomi Mi 10T Pro 5G 8G/128G Chính Hãng DGW', 3, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (15, N'POCO X3 Pro', 23, CAST(5990000 AS Decimal(18, 0)), 128, 6, N'poco-x3-pro-1.png', N'POCO X3 Pro 6GB/128GB Chính Hãng', 3, 1)
INSERT [dbo].[SanPham] ([IdSP], [TenSP], [SoLuong], [GiaTien], [BoNho], [Ram], [HinhAnh], [MoTa], [IdHang], [IdHDH]) VALUES (16, N'Samsung Galaxy Note 10', 14, CAST(22990000 AS Decimal(18, 0)), 256, 8, N'samsung-galaxy-note-10-pink.png', N'Galaxy Note 10 smartphone nhỏ gọn, màn hình tràn viền tuyệt đẹp, Công nghệ Dynamic AMOLED ', 1, 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

INSERT [dbo].[TrangThai] ([IdTT], [TrangThai]) VALUES (1, N'admin')
INSERT [dbo].[TrangThai] ([IdTT], [TrangThai]) VALUES (2, N'member')
INSERT [dbo].[TrangThai] ([IdTT], [TrangThai]) VALUES (3, N'khóa')
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (1, N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (2, N'BinhJK', N'21232f297a57a5a743894a0e4a801fc3', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (3, N'TanBinh', N'c4ca4238a0b923820dcc509a6f75849b', 2)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (4, N'Duy', N'c4ca4238a0b923820dcc509a6f75849b', 2)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (5, N'Nam', N'c4ca4238a0b923820dcc509a6f75849b', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (6, N'Huy', N'c4ca4238a0b923820dcc509a6f75849b', 2)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (7, N'Hien', N'c4ca4238a0b923820dcc509a6f75849b', 2)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (8, N'Hieu', N'c4ca4238a0b923820dcc509a6f75849b', 3)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [IDStatus]) VALUES (9, N'anhtu', N'c4ca4238a0b923820dcc509a6f75849b', 2)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_HangSX] FOREIGN KEY([IdHang])
REFERENCES [dbo].[HangSX] ([IdHang])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_HangSX]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_HeDH] FOREIGN KEY([IdHDH])
REFERENCES [dbo].[HeDH] ([IdHdh])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_HeDH]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_TrangThai] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[TrangThai] ([IdTT])
GO
ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [FK_UserAccount_TrangThai]
GO
