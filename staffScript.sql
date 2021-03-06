USE [PharmacyDataBases]
GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 6/2/2021 9:16:03 PM ******/
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
