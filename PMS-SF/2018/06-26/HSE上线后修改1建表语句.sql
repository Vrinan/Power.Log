--重要环境因素清单
CREATE TABLE SF_HSE_Hazard(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,--涉及部门/工序
	[HazardSource] [nvarchar](200) NULL,
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
	[ParentId] [uniqueidentifier] NULL
)

CREATE TABLE SF_HSE_Hazard_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	[Memo] [nvarchar](500) NULL,
	Sequ int null,
	[MainReason] [nvarchar](500) NULL,--重要环境因素
	[MainDamage] [nvarchar](500) NULL,--环境影响
	[MayDamage] [nvarchar](500) NULL,--控制措施
	[MainDel] [nvarchar](500) NULL--优先等级
) 

create view View_SF_Hazard
as
select al.Code,al.Title,ald.* from SF_HSE_Hazard al left join SF_HSE_Hazard_dtl ald on al.Id = ald.MasterId


alter table SF_HSE_SafetySpecial add SafeProjName nvarchar(200) null
alter table SF_HSE_SafetySpecial add SafeProjId uniqueidentifier null
alter table SF_HSE_SafetySpecial add SafeDeptName nvarchar(200) null
alter table SF_HSE_SafetySpecial add SafeDeptId uniqueidentifier null

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

select * from SF_HSE_CareerCheck_dtl where IsTerr = 1 

alter table PS_HSE_AccidentsExpress add SignMemo nvarchar(1000) null
