/****** Object:  Table [dbo].[XLX_PUR_Need_CBS]    Script Date: 2017-11-10 14:11:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[XLX_PUR_Need_CBS](
	[Id] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[XLX_PUR_Need_Id] [uniqueidentifier] NULL,
	[XLX_PUR_Need_List_Id] [uniqueidentifier] NULL,
	[Sequ] [int] NULL,
	[LongCode] [nvarchar](200) NULL,
	[CbsClassCode] [nvarchar](200) NULL,
	[CbsClassName] [nvarchar](200) NULL,
	[CbsClassType] [nvarchar](50) NULL,
	[BudgetPrice] [numeric](18, 2) null,
	[EpsProjId] [uniqueidentifier] NULL,
	[Memo] [nvarchar](1000) NULL,
 CONSTRAINT [PK_XLX_PUR_Need_CBS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

select * into XLX_PUR_Need_List from XLX_PUR_BOM_List 

select * into XLX_PUR_Need from XLX_PUR_BOM_List 

select * from XLX_PUR_Need_List