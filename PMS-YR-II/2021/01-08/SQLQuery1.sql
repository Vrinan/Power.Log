CREATE TABLE XLX_PUR_InquiryOnline(
	[TableName] [varchar](50) NOT NULL,
	[BizAreaId] [uniqueidentifier] NULL,
	[Sequ] [int] NULL,
	[Status] [tinyint] NULL,
	[RegHumId] [uniqueidentifier] NULL,
	[RegHumName] [varchar](80) NULL,
	[RegDate] [datetime] NULL,
	[RegPosiId] [uniqueidentifier] NULL,
	[RegDeptId] [uniqueidentifier] NULL,
	[EpsProjId] [uniqueidentifier] NULL,
	[RecycleHumId] [uniqueidentifier] NULL,
	[UpdHumId] [uniqueidentifier] NULL,
	[UpdHumName] [varchar](80) NULL,
	[UpdDate] [datetime] NULL,
	[ApprHumId] [uniqueidentifier] NULL,
	[ApprHumName] [varchar](80) NULL,
	[ApprDate] [datetime] NULL,
	[Memo] [varchar](max) NULL,
	[OwnProjId] [uniqueidentifier] NULL,
	[OwnProjName] [varchar](255) NULL,
	[Title] [nvarchar](100) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[PlanCode] [nvarchar](200) NULL,
	[InquiryCode] [nvarchar](200) NULL,
	[InquiryDate] [varchar](10) NULL,
	[BuyerId] [uniqueidentifier] NULL,
	[BuyerName] [nvarchar](20) NULL,
	[Phone] [nvarchar](200) NULL,
	[InquirySupplieStatus] [nvarchar](20) NULL,
	[InquirySupplieTime] [datetime] NULL,
	[OrderStatus] [nvarchar](20) NULL,
	[OrderTime] [datetime] NULL,
	[XLX_PUR_Order_Id] [uniqueidentifier] NULL,
	[XLX_PUR_Order_Code] [nvarchar](200) NULL,
	[XLX_PUR_Order_Name] [nvarchar](200) NULL,
	[SupplieId] [uniqueidentifier] NULL,
	[ContractId] [uniqueidentifier] NULL,
	[SupplieName] [nvarchar](200) NULL,
	[Overseas] [nvarchar](10) NULL,
	[BuyerType] [nvarchar](10) NULL,
	[Virtual] [nvarchar](10) NULL,
	[ContractCode] [nvarchar](50) NULL,
	[TotalPrice] [float] NULL,
	[TaskStatus] [nvarchar](50) NULL,
	[InquiryEndDate] [datetime] NULL,
) 