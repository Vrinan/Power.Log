--导入完成后调用保存算出金额

alter table SF_FK_EquipmentCostSchedule_dtl add CostReport nvarchar(max) null
alter table SF_FK_EquipmentCostSchedule_dtl add FeedBackReport nvarchar(max) null
alter table SF_FK_EstablishCostSchedule_dtl add CostReport nvarchar(max) null
alter table SF_FK_EstablishCostSchedule_dtl add FeedBackReport nvarchar(max) null
alter table SF_FK_InstallCostSchedule_dtl add CostReport nvarchar(max) null
alter table SF_FK_InstallCostSchedule_dtl add FeedBackReport nvarchar(max) null
alter table SF_FK_ManageCostSchedule_dtl add CostReport nvarchar(max) null
alter table SF_FK_ManageCostSchedule_dtl add FeedBackReport nvarchar(max) null
alter table SF_FK_OtherCostSchedule_dtl add CostReport nvarchar(max) null
alter table SF_FK_OtherCostSchedule_dtl add FeedBackReport nvarchar(max) null


--设备成本季度反馈
CREATE TABLE SF_FK_EquipmentCostFeedback(
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
	CostId uniqueidentifier null,
	CostCode nvarchar(200) null,
	CostName nvarchar(200) null,
	EpsProjectId uniqueidentifier null,
	EpsProjectCode nvarchar(200) null,
	EpsProjectName nvarchar(200) null,
	CostType nvarchar(100) null,
	SeasonNum nvarchar(200) null,
)
CREATE TABLE SF_FK_EquipmentCostFeedback_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](100) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	ListId uniqueidentifier null,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	UpdDate datetime null,
	SeasonReport  nvarchar(max) null
) 

--建筑成本季度反馈
CREATE TABLE SF_FK_EstablishCostFeedback(
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
	CostId uniqueidentifier null,
	CostCode nvarchar(200) null,
	CostName nvarchar(200) null,
	EpsProjectId uniqueidentifier null,
	EpsProjectCode nvarchar(200) null,
	EpsProjectName nvarchar(200) null,
	CostType nvarchar(100) null,
	SeasonNum nvarchar(200) null,
)
CREATE TABLE SF_FK_EstablishCostFeedback_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](100) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	ListId uniqueidentifier null,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	UpdDate datetime null,
	SeasonReport  nvarchar(max) null
) 

--安装成本季度反馈
CREATE TABLE SF_FK_InstallCostFeedback(
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
	CostId uniqueidentifier null,
	CostCode nvarchar(200) null,
	CostName nvarchar(200) null,
	EpsProjectId uniqueidentifier null,
	EpsProjectCode nvarchar(200) null,
	EpsProjectName nvarchar(200) null,
	CostType nvarchar(100) null,
	SeasonNum nvarchar(200) null,
)
CREATE TABLE SF_FK_InstallCostFeedback_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](100) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	ListId uniqueidentifier null,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	UpdDate datetime null,
	SeasonReport  nvarchar(max) null
) 

--管理成本季度反馈
CREATE TABLE SF_FK_ManageCostFeedback(
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
	CostId uniqueidentifier null,
	CostCode nvarchar(200) null,
	CostName nvarchar(200) null,
	EpsProjectId uniqueidentifier null,
	EpsProjectCode nvarchar(200) null,
	EpsProjectName nvarchar(200) null,
	CostType nvarchar(100) null,
	SeasonNum nvarchar(200) null,
)
CREATE TABLE SF_FK_ManageCostFeedback_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](100) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	ListId uniqueidentifier null,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	UpdDate datetime null,
	SeasonReport  nvarchar(max) null
) 

--其他成本季度反馈
CREATE TABLE SF_FK_OtherCostFeedback(
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
	CostId uniqueidentifier null,
	CostCode nvarchar(200) null,
	CostName nvarchar(200) null,
	EpsProjectId uniqueidentifier null,
	EpsProjectCode nvarchar(200) null,
	EpsProjectName nvarchar(200) null,
	CostType nvarchar(100) null,
	SeasonNum nvarchar(200) null,
)
CREATE TABLE SF_FK_OtherCostFeedback_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Specifications] [nvarchar](100) NULL,
	[unit] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[UnitPrice] [float] NULL,
	[Price] [float] NULL,
	ListId uniqueidentifier null,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	UpdDate datetime null,
	SeasonReport  nvarchar(max) null
) 



