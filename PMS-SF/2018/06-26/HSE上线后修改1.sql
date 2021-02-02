select * from PB_Widget where id='cc37f703-0ff1-45c8-91cf-5a729a7793f3'
--/PowerPlat/FormXml/zh-CN/SF_HSE/Win_SF_HSE_HazardResourcesA.htm

select * from PB_Widget where id='03ab6241-1502-4434-bdfa-3a372bab688c'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_SafetySpecial.htm
--安全专项方案
select * from SF_HSE_SafetySpecial

--隐患排查SF_HSE_Investigation
select * from PB_Widget where id='8c922126-09b3-43bb-b267-750858dcceee'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_Investigation.htm

--整改通知SF_HSE_RectificationNotice
select * from PB_Widget where id='a3eb726e-ffa3-47d3-b364-98ae345060cd'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_RectificationNotice.htm

alter table SF_HSE_Investigation add CheckType nvarchar(100) null--检查类型
alter table SF_HSE_Investigation add InProjName nvarchar(100) null--项目
alter table SF_HSE_Investigation add InProjId uniqueidentifier null
alter table SF_HSE_Investigation add InDeptName nvarchar(100) null--隐患部门
alter table SF_HSE_Investigation add InDeptId uniqueidentifier null

alter table SF_HSE_Investigation_dtl add UpdDate datetime null

alter table SF_HSE_RewardsAndPunishments add RorP nvarchar(100) null--奖励/惩罚
alter table SF_HSE_RewardsAndPunishments add IsLeaderFlow nvarchar(100) null--是否需分管领导审批


select * from SF_HSE_SpecialTraining_dtl
select * from SF_HSE_TertiaryEAT_dtl

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

CREATE TABLE SF_HSE_UnNature_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[HumanId] [uniqueidentifier] NULL,
	[HumanCode] [nvarchar](100) NULL,
	[HumanName] [nvarchar](100) NULL,
	[HumanGender] [nvarchar](100) NULL,
	[HumanIdentity] [nvarchar](100) NULL,
	[HumanDept] [nvarchar](100) NULL,
	[HumanDeptId] [uniqueidentifier] NULL,
	[HumanType] [nvarchar](100) NULL,
	[DangerReason] [nvarchar](500) NULL,
	[CheckWay] [nvarchar](100) NULL,
	[CheckDate] [datetime] NULL,
	[CheckReport] [nvarchar](500) NULL,
	[Memo] [nvarchar](500) NULL,
	[CheckOpinion] [nvarchar](500) NULL,
	[HSEOpinion] [nvarchar](500) NULL,
	[IsTerr] [int] NULL,
	[CareeHumanId] [uniqueidentifier] NULL
)
alter table SF_HSE_UnNature_dtl add Sequ int null
alter table SF_HSE_UnNature_dtl add UpdDate datetime null

alter view View_SF_Delegate
as
select Id,Code,Title,RegHumName,RegHumId,'运行站常规检测' as type from SF_HSE_DelegateYAppy
union
select Id,Code,Title,RegHumName,RegHumId,'其他部门临时监测' as type from SF_HSE_DelegateOAppy



select * from PB_Widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'
--/PowerPlat/FormXml/zh-CN/StdSystem/HumanPage.htm

select * from PB_Human

alter table PB_Human add HumanWorkType nvarchar(100) null

--隐患排查SF_HSE_Investigation
select * from PB_Widget where Id='8c922126-09b3-43bb-b267-750858dcceee'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_Investigation.htm
alter table SF_HSE_Investigation add CheckDepart nvarchar(200) null
alter table SF_HSE_Investigation add CheckDepartId uniqueidentifier null
alter table SF_HSE_Investigation add SignHuman nvarchar(200) null
alter table SF_HSE_Investigation add SignHumanId uniqueidentifier null
alter table SF_HSE_Investigation_dtl add TroubleChange nvarchar(200) null
alter table SF_HSE_Investigation_dtl add ChangeTime nvarchar(200) null



delete from SF_HSE_Investigation
delete from SF_HSE_Investigation_dtl
delete from SF_HSE_RectificationNotice
delete from SF_HSE_RectificationNotice_dtl
delete from SF_HSE_RectificationReturn
delete from SF_HSE_RectificationReturn_dtl
alter table SF_HSE_RectificationReturn_dtl add NoticeDtlId uniqueidentifier
alter table SF_HSE_RectificationReturn_dtl add NoticeMasterId uniqueidentifier
--整改通知SF_HSE_RectificationNotice
select * from PB_Widget where Id='a3eb726e-ffa3-47d3-b364-98ae345060cd'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_RectificationNotice.htm

select * from SF_HSE_RectificationNotice_dtl where isnull(Id,'00000000-0000-0000-0000-000000000000') not in(select aa.NoticeDtlId from SF_HSE_RectificationReturn_dtl aa)
select * from SF_HSE_RectificationReturn_dtl

alter table SF_HSE_RectificationNotice add IsChoose nvarchar(100) null


select * from SF_HSE_RectificationNotice