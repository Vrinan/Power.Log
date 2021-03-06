CREATE TABLE XLX_PUR_InquiryOnline_SupplieList(
	[Id] [uniqueidentifier] NOT NULL,
	[FK] [uniqueidentifier] NULL,
	[Sequ] [int] NULL,
	[SupplieId] [uniqueidentifier] NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[EName] [nvarchar](200) NULL,
	[ShortName] [nvarchar](100) NULL,
	[TypeName] [nvarchar](50) NULL,
	[ClassName] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[PostCode] [nvarchar](50) NULL,
	[Linkman] [nvarchar](100) NULL,
	[Phone] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[UpdDate] [datetime] NULL,
	[TaxRate] [int] NULL,
	[Invoice] [nvarchar](50) NULL,
	[CurrencyType] [nvarchar](50) NULL,
	[Method] [nvarchar](max) NULL,
	[Delivery] [nvarchar](max) NULL,
	[condition] [nvarchar](max) NULL,
	[Warranty] [nvarchar](max) NULL,
	[other] [nvarchar](max) NULL,
	[InquiryHumanId] [uniqueidentifier] NULL,
	[InquiryHumanName] [nvarchar](max) NULL,
	[InquiryStatus] [nvarchar](max) NULL,
)