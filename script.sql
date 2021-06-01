USE [PharmacyDataBases]
GO
/****** Object:  Table [dbo].[MedTable]    Script Date: 6/1/2021 9:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedTable](
	[MedicineName] [nvarchar](50) NOT NULL,
	[MedicineID] [nvarchar](50) NOT NULL,
	[ChemicalName] [nvarchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[ManufacturingDate] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[MarketPrice] [int] NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
