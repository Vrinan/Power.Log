-- ©π§Õº‘§À„
create table SF_DrawingBudget(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[UpdHumId] [uniqueidentifier] NULL,
	[UpdHuman] [nvarchar](80) NULL,
	[UpdDate] [datetime] NULL,
	[RegDate] [datetime] NULL,
	[RegHumName] [nvarchar](80) NULL,
	[RegHumId] [uniqueidentifier] NULL,
	[OwnProjName] [nvarchar](255) NULL,
	[OwnProjId] [uniqueidentifier] NULL,
	[EpsProjId] [uniqueidentifier] NULL,
	[ApprHumId] [uniqueidentifier] NULL,
	[ApprHumName] [nvarchar](80) NULL,
	[ApprDate] [datetime] NULL,
	[Status] [tinyint] NULL,
	[Memo] [nvarchar](1000) NULL,

	[EpsId] [uniqueidentifier] NULL,
	[EpsName] [nvarchar](100) NULL,
	[EpsCode] [nvarchar](100) NULL,
	[Total] [float] NULL,
	EstablishId uniqueidentifier null,
	EstablishCode nvarchar(100) null,
	EstablishName nvarchar(100) null
)

create TABLE SF_DrawingBudget_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
    [Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](max) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	[MemoDtl] [nvarchar](500) NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Sequ] [int] NULL,
	ListId uniqueidentifier null,
	UpdDate datetime null
)