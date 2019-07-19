
USE [Autoweigh]
GO
/****** Object:  Table [dbo].[Crops]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Crops]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Crops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Crop Name] [nvarchar](50) NOT NULL,
	[Open Date] [datetime] NULL,
	[Close Date] [datetime] NULL,
 CONSTRAINT [PK_Crops] PRIMARY KEY CLUSTERED 
(
	[Crop Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Daily Collections Details]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Daily Collections Details]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Daily Collections Details](
	[Farmers Number] [varchar](30) NOT NULL,
	[Collections Date] [datetime] NOT NULL,
	[Collection Number] [varchar](30) NOT NULL,
	[Coffee Type] [varchar](30) NULL,
	[No_] [int] IDENTITY(1,1) NOT NULL,
	[Farmers Name] [varchar](60) NULL,
	[Kg_ Collected] [float] NULL,
	[Cancelled] [nvarchar](50) NULL,
	[Paid] [tinyint] NULL,
	[ID Number] [varchar](30) NULL,
	[Factory] [varchar](30) NULL,
	[Sent] [bit] NULL,
	[Comments] [nvarchar](200) NULL,
	[Cumm] [float] NULL,
	[User] [nvarchar](50) NULL,
	[Can] [varchar](30) NULL,
	[Collection time] [datetime] NULL,
	[Collect type] [nvarchar](50) NULL,
	[Crop] [nvarchar](50) NULL,
 CONSTRAINT [PK_Daily Collections Details] PRIMARY KEY CLUSTERED 
(
	[Collection Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Farmers]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Farmers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Farmers](
	[No] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[ID No] [nvarchar](50) NULL,
	[Cum Cherry] [float] NULL,
	[Cum Mbuni] [float] NULL,
	[Updated] [bit] NULL,
	[Account Category] [int] NULL,
	[Factory] [nvarchar](50) NULL,
	[Comments] [nvarchar](100) NULL,
 CONSTRAINT [PK_Farmers] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Item Variants]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item Variants]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Item Variants](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[No] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Item Variants] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Items]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Items](
	[No] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Base Unit of Measure] [nvarchar](50) NULL,
	[Last Direct Cost] [float] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Routes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Routes](
	[Route] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED 
(
	[Route] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Com Port] [nvarchar](50) NULL,
	[BaudRate] [int] NULL,
	[Coffe type] [int] NULL,
	[Branch] [nvarchar](50) NULL,
	[Printer] [nvarchar](50) NULL,
	[Server url] [nvarchar](100) NULL,
	[Factory] [nvarchar](50) NULL,
	[Current crop] [nvarchar](50) NULL,
	[Pick factory farmers] [bit] NULL,
	[Bag weight] [float] NULL,
	[Stores receipts copies] [int] NULL,
	[Motto] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stocks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stocks](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Document No] [nvarchar](50) NULL,
	[Item] [nvarchar](50) NULL,
	[Variant] [nvarchar](50) NULL,
	[Date Added] [date] NULL,
	[Quantity] [float] NULL,
	[Unit Price] [float] NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Entry] [nvarchar](50) NULL,
	[Client] [nvarchar](50) NULL,
	[Item] [nvarchar](50) NULL,
	[Variant] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[Quantity] [float] NULL,
	[Time] [datetime] NULL,
	[Date] [date] NULL,
	[Served By] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Factory] [nvarchar](50) NULL,
	[Sent] [bit] NULL,
	[Comments] [nvarchar](100) NULL,
	[Line total] [float] NULL,
	[Stock] [nvarchar](50) NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Stores header]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stores header]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stores header](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Client] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Entry] [nvarchar](50) NULL,
	[Total] [float] NULL,
	[Posted] [bit] NULL,
 CONSTRAINT [PK_Stores header] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/12/2017 7:13:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Date Created] [datetime] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
USE [master]
GO
ALTER DATABASE [Autoweigh] SET  READ_WRITE 
GO

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Person]') 
         AND name = 'ColumnName'
)
