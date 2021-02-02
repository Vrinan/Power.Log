--渗滤液污水处理月报表
CREATE TABLE SF_YX_MonthReportS(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDateTime datetime null,--填报年月
	ReportDept nvarchar(100) null,--所属运行站
	ReportDeptId uniqueidentifier null,
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
CREATE TABLE SF_YX_MonthReportS_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,

	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DealAbility float null,--项目渗滤液设计总处理能力（t/d）
	AddWater float null,--渗滤液系统实际接水量（t)
	DealAmount float null,--实际渗滤液处理量（t)
	OutAmount float null,--渗滤液外运量（t)
	ProduceAmount float null,--渗滤液浓液产生量（t）
	OutWater float null,--渗滤液浓液外运量（t)
	DirAmount float null,--干污泥产生量（t）
	Electric float null,--耗电量（万kW.h)
	Water float null,--工业用水量（t）
	PartyBName nvarchar(100) null,--检查/处罚单位
	PunishCode nvarchar(100) null,--处罚文号
	PunishContent nvarchar(500) null,--不达标事项/处罚内容
	ProduceEvent nvarchar(500) null,--生产事件
)
--飞灰处理月报表
CREATE TABLE SF_YX_MonthReportF(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDateTime datetime null,--填报年月
	ReportDept nvarchar(100) null,--所属运行站
	ReportDeptId uniqueidentifier null,
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
CREATE TABLE SF_YX_MonthReportF_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,

	DealAbility float null,--项目设计飞灰总处理能力（t/d）
	AddWater float null,--实际飞灰处理量（t)
	DealAmount float null,--螯合剂耗量（t)
	Electric float null,--耗电量（万kW.h)
	Water float null,--工业用水量（t）
	OnlyAmount float null,--固化物产量（t)
	OutAmount float null,--固化物外运量（t)	
	PartyBName nvarchar(100) null,--检查/处罚单位
	PunishCode nvarchar(100) null,--处罚文号
	PunishContent nvarchar(500) null,--不达标事项/处罚内容
	ProduceEvent nvarchar(500) null,--生产事件
)









--渗滤液膜设备供货月报表
CREATE TABLE SF_YX_MonthReportSL(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDateTime datetime null,--填报年月
	ReportDept nvarchar(100) null,--所属运行站
	ReportDeptId uniqueidentifier null,
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
CREATE TABLE SF_YX_MonthReportSL_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DealAbility float null,--项目渗滤液总处理能力（t/d）
)	
CREATE TABLE SF_YX_MonthReportSL_dtlChild(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DeviceName nvarchar(100) null,--设备名称
	UnitAblity nvarchar(100) null,--单台膜处理能力（t/d）
	DeviceAmount int null,--渗滤液膜数量（台）	
)

select * from PB_BaseDataList a left join  PB_BaseData  b on a.BaseDataId=b.Id where b.DataType='PS_DesignStage'