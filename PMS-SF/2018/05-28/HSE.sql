--重要危险源（点）识别与清单
CREATE TABLE SF_HSE_HazardResources(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	HazardSource nvarchar(200) null,--危险源（点）
	MainHazardReason nvarchar(500) null,--主要危险因素
	MainHazardHarm nvarchar(500) null,--主要危害
	PossibleAccidents nvarchar(500) null,--可能导致的事故
	MainControlMeasures nvarchar(500) null,--主要控制措施
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
	[Memo] [nvarchar](1000) NULL
)
--exec sp_rename 'SF_HazardResources','SF_HSE_HazardResources'
select * from SF_HSE_HazardResources

--重要环境因素清单

--日常作业分析
CREATE TABLE SF_HSE_DailyWork(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	WorkContent nvarchar(500) null,
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
	[Memo] [nvarchar](1000) NULL
)

--安全专项方案
CREATE TABLE SF_HSE_SafetySpecial(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	PlanDescription nvarchar(500) null,
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
	[Memo] [nvarchar](1000) NULL
)

--HSE及消防检查（月）
CREATE TABLE SF_HSE_FireInspectionM(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ProjName nvarchar(100) null,
	ProjId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--检测人员
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--检查日期
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_FireInspectionM_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	MasterId uniqueidentifier null,
	DepartmentName nvarchar(500) null,--违章单位/部门
	DepartmentId uniqueidentifier null,
	ConstructionAarea nvarchar(500) null,--施工区域
	UnqualifiedType nvarchar(500) null,--不合格类型
	Question nvarchar(500) null,--问题描述
	leave nvarchar(100) null,--等级
	CorrectiveAction nvarchar(500) null--纠正措施
)
--alter table SF_HSE_FireInspectionM_dtl add Memo nvarchar(500) null

--HSE及消防检查（专项）
CREATE TABLE SF_HSE_FireInspectionE(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectContent nvarchar(100) null,--检查内容
	PartyBName nvarchar(100) null,--受检单位
	PartyBId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--检测人员
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--检查日期
	ExistQuestion nvarchar(500) null,--存在问题
	CorrectiveAction nvarchar(500) null,--纠正措施
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
	[Memo] [nvarchar](1000) NULL
)

--隐患排查
CREATE TABLE SF_HSE_Investigation(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectHuman nvarchar(100) null,--检测人员
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--检查日期
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_Investigation_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	PartyBName nvarchar(100) null,--隐患单位
	PartyBId uniqueidentifier null,
	TroubleType nvarchar(100) null,--隐患类别
	Content nvarchar(500) null,--隐患内容
	Memo nvarchar(500) null--备注说明
)

--检查通报
CREATE TABLE SF_HSE_InspectionNotice(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectDepart nvarchar(100) null,--受检部门
	InspectDepartId uniqueidentifier null,
	InspectArea nvarchar(100) null,--受检区域
	InspectManager nvarchar(100) null,--受检区域负责人
	InspectManagerId uniqueidentifier null,
	InspectDate datetime null,--检查日期
	TotalStatus nvarchar(100) null,--总体情况
	ProcessingAdvice nvarchar(100) null,--处理意见
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_InspectionNotice_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	HuamnCode  nvarchar(100) null,--工号
	HuamnName  nvarchar(100) null,--姓名
	HumanId uniqueidentifier null,
	DeptName nvarchar(100) null,--部门
	DeptId uniqueidentifier null,
	Position nvarchar(100) null,--岗位
	PositionId uniqueidentifier null
)
--alter table SF_HSE_InspectionNotice_dtl add Memo nvarchar(500) null
select * from PB_Human
--select * from SF_HSE_InspectionNotice

--整改通知
--alter table SF_HSE_RectificationNotice add IsReturn nvarchar(100) null 
CREATE TABLE SF_HSE_RectificationNotice(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	SignDate datetime null,--签发时间
	SignHuman nvarchar(100) null,--签发人
	SignHumanId uniqueidentifier null,
	CheckDate  datetime null,--检查时间
	CheckDepart nvarchar(100) null,--检查部门
	CheckDepartId uniqueidentifier null,
	TroubleDepart nvarchar(100) null,--隐患责任部门
	TroubleDepartId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--检查人员
	InspectHumanId uniqueidentifier null,
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_RectificationNotice_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	TroubleType nvarchar(500) null,--隐患类别
	TroubleName nvarchar(500) null,--隐患名称
	TroubleChange nvarchar(500) null,--整改意见或监护措施
	ChangeTime nvarchar(500) null,--整改期限
	Memo nvarchar(500) null--备注说明
)

--整改回复
CREATE TABLE SF_HSE_RectificationReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReNoticeCode nvarchar(100) null,--整改通知单编号
	ReNoticeName nvarchar(100) null,--整改通知单名称
	ReNoticeId uniqueidentifier null,
	TroubleDepart nvarchar(100) null,--隐患责任部门
	TroubleDepartId uniqueidentifier null,
	RectificationReturnDate datetime null,--时间
	RectificationManager nvarchar(100) null,--整改负责人
	RectificationManagerId uniqueidentifier null,
	ReviewHuamn nvarchar(100) null,--复查人
	ReviewHuamnId uniqueidentifier null,
	ReviewDate datetime null, --复查时间
	ChangeContent nvarchar(500) null,--整改情况
	Review nvarchar(500) null,--复查情况
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_RectificationReturn_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	TroubleType nvarchar(500) null,--隐患类别
	TroubleName nvarchar(500) null,--隐患名称
	TroubleChange nvarchar(500) null,--整改意见或监护措施
	ChangeTime nvarchar(500) null,--整改期限
	ChangeContent nvarchar(500) null,--整改情况
	ChangeDate datetime null,--整改时间
	Memo nvarchar(500) null--备注说明
)

--HSE奖惩
CREATE TABLE SF_HSE_RewardsAndPunishments(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	PartyBName nvarchar(100) null,--单位
	PartyBId uniqueidentifier null,
	OwnerDept nvarchar(100) null,--所属管理部门
	OwnerDeptId uniqueidentifier null,
	RAPDate datetime null,--奖惩时间
	RAPType nvarchar(100) null,--奖惩类别
	RAPReason nvarchar(500) null,--奖惩事由
	RAPAmount float null,--奖惩金额
	ImplementationHuman nvarchar(100) null,--实施人
	ImplementationId uniqueidentifier null,
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
	[Memo] [nvarchar](1000) NULL
)