--通信费报销建表语句
CREATE TABLE SF_FK_CommunicateReimburse(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	[ApplicationHuman] [nvarchar](100) NULL,
	[ApplicationHumanId] [uniqueidentifier] NULL,
	[DeptName] [nvarchar](100) NULL,
	[DeptId] [uniqueidentifier] NULL,
	ApplicationTrafficAmount numeric(18,2) NULL,
	ApplicationComAmount numeric(18,2) NULL,
	ApproveTrafficAmount numeric(18,2) NULL,
	ApproveComAmount numeric(18,2) NULL,
	AddYearMonth datetime null,
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


CREATE TABLE SF_FK_CommunicateReimburse_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	[Remark] [nvarchar](2500) NULL,
	[Sequ] [int] NULL,
	HumanId uniqueidentifier null,
	HumanCode nvarchar(500) null,
	HumanName nvarchar(500) null,
	DeptId uniqueidentifier null,
	DeptName nvarchar(500) null,
	AllTrafficAmount numeric(18,2) null,
	AllComAmount numeric(18,2) null,
	UsedTrafficAmount numeric(18,2) null,
	UsedComAmount numeric(18,2) null,
	RemainTrafficAmount numeric(18,2) null,
	RemainComAmount numeric(18,2) null,
	ApplicationTrafficAmount numeric(18,2) null,
	ApplicationComAmount numeric(18,2) null,
	ApproveTrafficAmount numeric(18,2) null,
	ApproveComAmount numeric(18,2) null,
	CardNum nvarchar(500) null
)


--alter table SF_FK_CommunicateReimburse_dtl drop column HumanCode

--alter table SF_FK_CommunicateReimburse add ApplicationTrafficAmount numeric(18,2) NULL
--alter table SF_FK_CommunicateReimburse add ApplicationComAmount numeric(18,2) NULL
--alter table SF_FK_CommunicateReimburse add ApproveTrafficAmount numeric(18,2) NULL
--alter table SF_FK_CommunicateReimburse add ApproveComAmount numeric(18,2) NULL
	

--alter table SF_FK_CommunicateReimburse drop column ApplicationAmount
--alter table SF_FK_CommunicateReimburse drop column ApproveAmount
	
	