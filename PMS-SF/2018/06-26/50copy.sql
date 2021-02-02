alter table SF_HSE_SafetySpecial add SafeProjName nvarchar(200) null
alter table SF_HSE_SafetySpecial add SafeProjId uniqueidentifier null
alter table SF_HSE_SafetySpecial add SafeDeptName nvarchar(200) null
alter table SF_HSE_SafetySpecial add SafeDeptId uniqueidentifier null


alter table SF_HSE_Investigation add CheckType nvarchar(100) null--检查类型
alter table SF_HSE_Investigation add InProjName nvarchar(100) null--项目
alter table SF_HSE_Investigation add InProjId uniqueidentifier null
alter table SF_HSE_Investigation add InDeptName nvarchar(100) null--隐患部门
alter table SF_HSE_Investigation add InDeptId uniqueidentifier null

------
alter table SF_HSE_Investigation_dtl add UpdDate datetime null

alter table SF_HSE_RewardsAndPunishments add RorP nvarchar(100) null--奖励/惩罚
alter table SF_HSE_RewardsAndPunishments add IsLeaderFlow nvarchar(100) null--是否需分管领导审批

drop table SF_HSE_SpecialTraining_dtl
CREATE TABLE SF_HSE_SpecialTraining_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	UpdDate datetime null,
	Sequ int null,
	[HumanId] [uniqueidentifier] NULL,
	[HumanCode] [nvarchar](100) NULL,
	[HumanName] [nvarchar](100) NULL,
	[HumanGender] [nvarchar](100) NULL,
	[HumanAge] [datetime] NULL,
	[HumanIdentity] [nvarchar](100) NULL,
	[HumanDept] [nvarchar](100) NULL,
	[HumanDeptId] [uniqueidentifier] NULL,
	[HumanType] [nvarchar](100) NULL,
	[Score] [float] NULL,
	[TrainDate] [datetime] NULL,
	[TeachHumanId] [uniqueidentifier] NULL,
	[TeachHuamn] [nvarchar](100) NULL,
	[Memo] [nvarchar](500) NULL
) 

create view View_SF_Delegate
as
select Id,Code,Title,RegHumName,RegHumId from SF_HSE_DelegateYAppy
union
select Id,Code,Title,RegHumName,RegHumId from SF_HSE_DelegateOAppy

alter table SF_HSE_MonitorIssued add DelegateId uniqueidentifier null
alter table SF_HSE_MonitorIssued add DelegateCode nvarchar(200) null
alter table SF_HSE_MonitorIssued add DelegateTitle nvarchar(200) null
alter table SF_HSE_MonitorIssued add DelegateRegHuman nvarchar(200) null
alter table SF_HSE_MonitorIssued add DelegateRegHumanId uniqueidentifier null

alter table SF_HSE_MonitorRecord_dtl add BornPartyB nvarchar(200) null
alter table SF_HSE_MonitorRecord drop column BornPartyB

alter table SF_HSE_CareerCheck add CheckDept nvarchar(200) null
alter table SF_HSE_CareerCheck add CheckDeptId uniqueidentifier null

alter table SF_HSE_CareerCheck_dtl add IsTerr int null

alter table PS_HSE_AccidentsExpress add SignMemo nvarchar(1000) null