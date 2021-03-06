USE [master]
GO
/****** Object:  Database [SportsStore]    Script Date: 10/15/2016 11:14:53 AM ******/
CREATE DATABASE [SportsStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SportsStore', FILENAME = N'C:\Users\nzhul\SportsStore.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SportsStore_log', FILENAME = N'C:\Users\nzhul\SportsStore_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SportsStore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportsStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportsStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SportsStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SportsStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SportsStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SportsStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [SportsStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SportsStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SportsStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SportsStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SportsStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SportsStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SportsStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SportsStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SportsStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SportsStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SportsStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SportsStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SportsStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SportsStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SportsStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SportsStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SportsStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SportsStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SportsStore] SET  MULTI_USER 
GO
ALTER DATABASE [SportsStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SportsStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SportsStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SportsStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SportsStore]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/15/2016 11:14:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[ImageData] [varbinary](max) NULL,
	[ImageMimeType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (2, N'Kayak', N'Descripton of the kayal', N'Watersports', CAST(275.00 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (3, N'Lifejacket', N'lifejacked is cool thing', N'Watersports', CAST(48.95 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (4, N'Soccer ball', N'Some description', N'Soccer', CAST(19.50 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (5, N'Corner flags', N'another description', N'Soccer', CAST(34.95 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (6, N'Stadium', N'big stuff here', N'Soccer', CAST(79500.00 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (7, N'Thinking Cap', N'chess stuff description', N'Chess', CAST(16.00 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (8, N'Chess Board', N'It is cool chess board', N'Chess', CAST(75.00 AS Decimal(16, 2)), NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType]) VALUES (9, N'Bling-Bling King', N'Gold-plated, diamond-studded King', N'Chess', CAST(1200.00 AS Decimal(16, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
USE [master]
GO
ALTER DATABASE [SportsStore] SET  READ_WRITE 
GO
