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
--select * from SF_HSE_RewardsAndPunishments

--HSE周报
CREATE TABLE SF_HSE_WeekReport(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDate datetime null,
	OwnerDept nvarchar(100) null,--填报部门
	OwnerDeptId uniqueidentifier null,	
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
CREATE TABLE SF_HSE_WeekReport_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	OwnerDept nvarchar(100) null,--所属管理部门
	OwnerDeptId uniqueidentifier null,	
	TroubleType nvarchar(500) null,--隐患类别
	TroubleContent nvarchar(500) null,--隐患内容
	TroubleChange nvarchar(500) null,--整改措施
	ChangeTime datetime null,--期限完成时间
	ScheduleContent nvarchar(500) null,--进度情况
	ChangeDate datetime null,--完成整改时间
	NextRequest nvarchar(500) null,--下一步工作要求
	Memo nvarchar(500) null--备注说明
)

--HSE月报
CREATE TABLE SF_HSE_MonthReport(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDate datetime null,--填报时间
	OwnerDept nvarchar(100) null,--填报部门
	OwnerDeptId uniqueidentifier null,	
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

--安全会议
CREATE TABLE SF_HSE_SecurityMeeting(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MeetingDate datetime null,--会议时间
	MeetingContent nvarchar(500) null,--会议内容
	MeetingLocation nvarchar(100) null,--会议地址
	Host nvarchar(100) null,--主持人
	HostId uniqueidentifier null,	
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
CREATE TABLE SF_HSE_SecurityMeeting_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	HumanCode nvarchar(100) null,
	HumanName nvarchar(100) null,
	HumanId uniqueidentifier null,
	Memo nvarchar(500) null
)


--三级教育培训
CREATE TABLE SF_HSE_TertiaryEAT(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	TrainType nvarchar(100) null,--培训类别：专业技术人员培训、经营管理人员培训、
	--生产运行维护人员培训、新员工入职培训、特种作业持证培训、其他。
	TrainDate datetime null,--培训时间
	TrainContent nvarchar(500) null,--培训内容
	TrainHuman nvarchar(100) null,--培训人
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
CREATE TABLE SF_HSE_TertiaryEAT_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	HumanId uniqueidentifier null,
	HumanCode nvarchar(100) null,--工号
	HumanName nvarchar(100) null,--名称
	HumanGender nvarchar(100) null,--性别
	HumanAge datetime null,--年龄
	--alter table SF_HSE_TertiaryEAT_dtl alter column HumanAge datetime null
	HumanIdentity nvarchar(100) null,--身份证号码
	HumanDept nvarchar(100) null,--部门
	HumanDeptId uniqueidentifier null,
	HumanType nvarchar(100) null,--工种
	Score float null,--成绩
	TrainDate datetime null,--培训日期
	TeachHumanId uniqueidentifier null,
	TeachHuamn nvarchar(100) null,--教育人
	Memo nvarchar(500) null
)
--select * from PB_Human
--select * from PB_Widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'


--专项培训
CREATE TABLE SF_HSE_SpecialTraining(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	TrainDate datetime null,--培训时间
	TrainContent nvarchar(500) null,--培训主题
	TrainLocation nvarchar(100) null,--培训地点
	TrainHuamn nvarchar(100) null,--教育人
	TrainHuamnId uniqueidentifier null,
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
CREATE TABLE SF_HSE_SpecialTraining_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	OwnerDeptName nvarchar(100) null,
	OwnerDeptId uniqueidentifier null,
	HumanAmount int null,
	Memo nvarchar(500) null
)

alter view V_SF_HSE_Tertiarydtl
as
select a1.*,a2.Code,a2.Title,a2.TrainHuman,a2.TrainType,a2.TrainContent,a2.Id as TrainId from SF_HSE_TertiaryEAT_dtl a1 left join
SF_HSE_TertiaryEAT a2 on a1.MasterId=a2.Id
go

select * from PB_Widget where id='104a133f-8e1b-42ac-a80b-c2b774d04f65'
--重要环境因素清单SF_HSE_HazardResources
--/PowerPlat/FormXml/zh-CN/SF_HSE/Win_SF_HSE_HazardResources_Report.htm


--应急管理
--委托申请单（运行站常规监测）
CREATE TABLE SF_HSE_DelegateYAppy(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	DelegateDept nvarchar(100) null,--委托部门
    DelegateDeptId uniqueidentifier null,
	DelegateEPS nvarchar(100) null,--委托项目
    DelegateEPSId uniqueidentifier null,
	DelegateDate datetime null,--委托时间
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
CREATE TABLE SF_HSE_DelegateYAppy_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	MonitorSite nvarchar(100) null,--监测站点
	SampleCode nvarchar(100) null,--样品编号
	SampleWieght nvarchar(100) null,--样品重量
	DeliveryCode nvarchar(100) null,--快递及运单号
	DelegateIndex nvarchar(100) null,--监测指标
	Memo nvarchar(500) null
)

--委托申请单（其他部门临时监测）
CREATE TABLE SF_HSE_DelegateOAppy(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	DelegateDept nvarchar(100) null,--委托部门
    DelegateDeptId uniqueidentifier null,
	DelegateEPS nvarchar(100) null,--委托项目
    DelegateEPSId uniqueidentifier null,
	DelegateDate datetime null,--委托时间
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
CREATE TABLE SF_HSE_DelegateOAppy_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	MonitorSite nvarchar(100) null,--监测点
	MonitorPurpose nvarchar(100) null,--监测目的
	MonitorWay nvarchar(100) null,--监测方式
	MonitorFrequency nvarchar(100) null,--监测频次	
	MonitorAmount nvarchar(100) null,--监测数量
	MonitorIndex nvarchar(100) null,--监测指标
	Memo nvarchar(500) null
)

--监测报告存档及下发
CREATE TABLE SF_HSE_MonitorIssued(
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_MonitorIssued_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	Unit nvarchar(100) null,--单位
	Amount nvarchar(100) null,--数量
	ReportCode nvarchar(100) null,--检测报告编号
	ReportDate Datetime null,--报告日期	
	FailedIndex nvarchar(100) null,--不合格指标
	Memo nvarchar(500) null
)

--监测仪器定期检验、仪器检验报告存档
CREATE TABLE SF_HSE_MonitorRecord(
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
	[Memo] [nvarchar](1000) NULL
)
CREATE TABLE SF_HSE_MonitorRecord_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	Unit nvarchar(100) null,--单位
	EquipmentName nvarchar(100) null,--仪器名称
	SerialNumber nvarchar(100) null,--出厂编号
	ValidityPeriod datetime null, --使用有效期
	DeliveryDate Datetime null,--送检日期	
	NextDeliveryDate Datetime null,--下次送检日期
	DeliveryContent nvarchar(500) null,--检查内容
	DeliveryNumber nvarchar(100) null,--检测报告编号
	Memo nvarchar(500) null
)
--各岗位职业病危害因素
Create table SF_HSE_CareerSafe
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	SafeType nvarchar(100) null,--类型  车间/运行站
	PosiName nvarchar(100) null, --岗位名称
	PosiId uniqueidentifier null,
	Dangerous nvarchar(500) null,--可能接触的职业病危害因素
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

--职业病危害因素定期检测
Create table SF_HSE_CareerCheck
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	HumanName nvarchar(100) null, --检测人
	HumanId uniqueidentifier null,
	CheckType nvarchar(100) null,
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
alter table SF_HSE_CareerCheck_dtl add CheckOpinion nvarchar(500) null --体检结论与处理意见
alter table SF_HSE_CareerCheck_dtl add HSEOpinion nvarchar(500) null --安全环保部建议
Create table SF_HSE_CareerCheck_dtl
(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	HumanId uniqueidentifier null,
	HumanCode nvarchar(100) null,--工号
	HumanName nvarchar(100) null,--姓名
	HumanGender nvarchar(100) null,--性别
	HumanIdentity nvarchar(100) null,--身份证号码
	HumanDept nvarchar(100) null,--部门
	HumanDeptId uniqueidentifier null,
	HumanType nvarchar(100) null,--工种
	DangerReason nvarchar(500) null, --职业病危害因素
	CheckWay nvarchar(100) null, --体检类别
	CheckDate datetime null,--体检日期
	CheckReport nvarchar(500) null,--体检报告
	Memo nvarchar(500) null
)




select * from PB_Widget where id='1702f11d-8856-4f8c-b0b1-42365ce8175b'

--各岗位职业病危害因素
Create table SF_HSE_CareerSafe
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	ParentId uniqueidentifier null,
	LongCode nvarchar(200) null,
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
Create table SF_HSE_CareerSafe_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	Dangerous nvarchar(100) null,
	Memo nvarchar(500) null
)
select * from PB_Widget where id='2eaeb378-d28c-4d70-a556-59128bf02381'

select * from SF_HSE_CareerCheck
alter table SF_HSE_CareerCheck add CheckDate datetime null



--事故快报
Create table SF_HSE_AccidentReport
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	PartyBaName nvarchar(100) null,--事故单位
	PartyBId uniqueidentifier null,
	DeptName nvarchar(100) null,--事故部门
	DeptId uniqueidentifier null,
	HumanName nvarchar(100) null,--报告人
	HumanId uniqueidentifier null,
	AccidentDate datetime null,--事故事件
	AccidentLocation
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
Create table SF_HSE_CareerSafe_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	Dangerous nvarchar(100) null,
	Memo nvarchar(500) null
)

select * from PB_Widget where id='df9e26a1-14a3-4070-adfb-e48f00f96ca3'
--事故等级AccidentLeave

--alter table PS_HSE_AccidentsExpress add DeptName nvarchar(100) null
--alter table PS_HSE_AccidentsExpress add DeptId uniqueidentifier null
--alter table PS_HSE_AccidentsExpress add AccidentLeave nvarchar(100) null

select * from PB_BaseDataList where BaseDataId = (select id from PB_BaseData where DataType='PS_AccidentType')
--update PB_BaseDataList set Name='车辆伤害' where id='47045354-0FCC-248D-6789-E6BBA4D9C2B3'
select * from SF_CustomerSatisfaction
select * from SF_CustomerSatisfaction_dtl
alter table SF_CustomerSatisfaction add PartyAName nvarchar(100) null--承接单位名称
alter table SF_CustomerSatisfaction add PartyAId uniqueidentifier null--承接单位名称Id
alter table SF_CustomerSatisfaction add PartyBName nvarchar(100) null--业主单位名称
alter table SF_CustomerSatisfaction add PartyBId uniqueidentifier null--业主单位名称Id
alter table SF_CustomerSatisfaction add DesignMemo nvarchar(500) null--设计
alter table SF_CustomerSatisfaction add EquipmentMemo nvarchar(500) null--设备
alter table SF_CustomerSatisfaction add RunMemo nvarchar(500) null--运行
alter table SF_CustomerSatisfaction add IndexMemo nvarchar(500) null--指标
alter table SF_CustomerSatisfaction add AskMemo nvarchar(500) null--要求
alter table SF_CustomerSatisfaction add ReplyMemo nvarchar(500) null--承接单位回复意见

