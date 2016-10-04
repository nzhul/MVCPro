USE [SportsStore]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/5/2016 1:07:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (2, N'Kayak', N'Descripton of the kayal', N'Watersports', CAST(275.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (3, N'Lifejacket', N'lifejacked is cool thing', N'Watersports', CAST(48.95 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (4, N'Soccer ball', N'Some description', N'Soccer', CAST(19.50 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (5, N'Corner flags', N'another description', N'Soccer', CAST(34.95 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (6, N'Stadium', N'big stuff here', N'Soccer', CAST(79500.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (7, N'Thinking Cap', N'chess stuff description', N'Chess', CAST(16.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (8, N'Chess Board', N'It is cool chess board', N'Chess', CAST(75.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (9, N'Bling-Bling King', N'Gold-plated, diamond-studded King', N'Chess', CAST(1200.00 AS Decimal(16, 2)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
