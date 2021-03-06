USE [PharmacyDataBases]
GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 6/10/2021 1:30:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffTable](
	[Name] [nvarchar](50) NULL,
	[CNICnmbr] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Salary] [int] NULL,
	[Bonus] [int] NULL,
	[WorkingHrs] [int] NULL,
	[ContactNmbr] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Job] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
