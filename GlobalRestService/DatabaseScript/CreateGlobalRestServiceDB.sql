USE [GlobalAssetRestServiceDB]

CREATE TABLE [dbo].[AssetCounter](
	[AssetCounterID] [int] IDENTITY(1,1) NOT NULL,
	[AssetType] [int] NOT NULL,
	[AssetSubType] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[ClientID] [nvarchar](255) NULL,
 CONSTRAINT [PK_CI] PRIMARY KEY CLUSTERED 
(
	[AssetCounterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[GlobalAsset](
	[AssetID] [int] NOT NULL,
	[AssetType] [int] NOT NULL,
	[AssetSubType] [int] NOT NULL,
	[SerialNumber] [nvarchar](255) NULL,
	[ClientID] [nvarchar](255) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[LastServiceDate] [date] NULL,
	[NextServiceDate] [date] NULL
) ON [PRIMARY]
GO

