--生产经营计划
CREATE TABLE SF_Market_ProductionManagement(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
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
)
CREATE TABLE SF_Market_ProductionManagement_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	ProjctName nvarchar(100) null,
	PlanBeginDate datetime null,
	PlanEndDate datetime null,
	RealBeginDate datetime null,
	RealEndDate datetime null,
	Schedule numeric(18,2) null,
	FinishRemark nvarchar(max) null,
	FailRemark nvarchar(max) null,
	DutyHuman nvarchar(100) null,
	[UpdDate] [datetime] NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] int null,
	[MainReason] [nvarchar](500) NULL,
	[MainDamage] [nvarchar](500) NULL,
	[MayDamage] [nvarchar](500) NULL,
	[MainDel] [nvarchar](500) NULL
) 


select * from SF_FK_ContractBudget
select * from SF_FK_ContractBudget_CBS
