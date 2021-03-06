USE [PharmacyDataBases]
GO
/****** Object:  Table [dbo].[AdminLogin_Table]    Script Date: 6/3/2021 8:16:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogin_Table](
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineTable]    Script Date: 6/3/2021 8:16:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineTable](
	[MedicineName] [nvarchar](50) NOT NULL,
	[MedicineID] [nvarchar](50) NOT NULL,
	[ChemicalName] [nvarchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[ManufacturingDate] [nvarchar](50) NOT NULL,
	[ExpiryDate] [nvarchar](50) NOT NULL,
	[MarketPrice] [nvarchar](50) NOT NULL,
	[SellingPrice] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffLoginTable]    Script Date: 6/3/2021 8:16:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffLoginTable](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 6/3/2021 8:16:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffTable](
	[Name] [nvarchar](50) NOT NULL,
	[CNICnmbr] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
	[Bonus] [int] NULL,
	[WorkingHrs] [int] NULL,
	[ContactNmbr] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Job] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[MedicineTable] ([MedicineName], [MedicineID], [ChemicalName], [Stock], [ManufacturingDate], [ExpiryDate], [MarketPrice], [SellingPrice], [Company], [Status]) VALUES (N'Panadol', N'P123', N'Paracetamol', 10, N'Jun  3 2021  5:51PM', N'Oct 14 2021  5:51PM', N'15', N'12', N'gsk', N'Public Medicine')
INSERT [dbo].[MedicineTable] ([MedicineName], [MedicineID], [ChemicalName], [Stock], [ManufacturingDate], [ExpiryDate], [MarketPrice], [SellingPrice], [Company], [Status]) VALUES (N'Disprin', N'D123', N'Aspirin', 5, N'Jun  3 2021  5:51PM', N'Apr 15 2022  5:51PM', N'20', N'8', N'gsk', N'Public Medicine')
INSERT [dbo].[MedicineTable] ([MedicineName], [MedicineID], [ChemicalName], [Stock], [ManufacturingDate], [ExpiryDate], [MarketPrice], [SellingPrice], [Company], [Status]) VALUES (N'Brufen', N'B123', N'ibuprofen', 10, N'Jun  3 2021  6:31PM', N'Sep 25 2021  6:31PM', N'10', N'13', N'Boots Health International', N'Public Medicine')
GO
INSERT [dbo].[StaffTable] ([Name], [CNICnmbr], [Email], [Salary], [Bonus], [WorkingHrs], [ContactNmbr], [DOB], [Job]) VALUES (N'Laiba', N'', N'Laiba@gmail.com', 12366, 5, 6, N'0321-4565-488', CAST(N'2021-06-10' AS Date), N'Pharmacist')
INSERT [dbo].[StaffTable] ([Name], [CNICnmbr], [Email], [Salary], [Bonus], [WorkingHrs], [ContactNmbr], [DOB], [Job]) VALUES (N'Fizza Akram', N'98745-6321987-4', N'fizza@gmail.com', 5620, 5, 5, N'0321-4565-488', CAST(N'2021-06-10' AS Date), N'Accountant')
GO
