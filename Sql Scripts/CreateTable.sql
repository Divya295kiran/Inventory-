USE [Inventory]
GO

/****** Object:  Table [dbo].[Product_Inventory]    Script Date: 1/6/2025 3:26:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Inventory](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Product Name] [nvarchar](500) NOT NULL,
	[ProductDescription] [nvarchar](500) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[ProductType] [nvarchar](500) NOT NULL,
	[ShipmentStatus] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Product_Inventory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


