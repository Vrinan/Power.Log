--运行部月报（办公会）
--alter table SF_YX_MonthReportBGH_dtlFirst add UpdDate datetime null
--alter table SF_YX_MonthReportBGH_dtlSecond add UpdDate datetime null
--alter table SF_YX_MonthReportBGH_dtlThird add UpdDate datetime null

CREATE TABLE SF_YX_MonthReportBGH(
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
--渗滤液处理系统生产统计表
CREATE TABLE SF_YX_MonthReportBGH_dtlFirst(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	SysAddPlan float null,--系统接水 计划值（t）
	SysAddInfact float null,--系统接水 实际值（t）

	SysReturnAmount float null,--系统进水 进水量（t）
	SysReturnDeal float null,--系统进水 处理率（%）

	SysInoryAmount float null,--系统未处理量 实际值（t）
	SysInoryHP float null,--系统未处理量 环比（t）
	SysInoryOut float null,--系统未处理量 外运量（t）

	SysClearPlan float null,--清液 计划值（t）
	SysClearFact float null,--清液 实际值（t）
	SysClearRatePlan float null,--清液 反渗透产税水率 计划值（%）
	SysClearRateFinish float null,--清液 反渗透产税水率 完成值（%）
	SysClearHB float null,--清液 反渗透产税水率 环比（%）

	SysDirPlanRange float null,--浓液 产生量 控制值（t）
	SysDirPlanAmount float null,--浓液 产生量 产值（t）
	SysDirPlanAmountNoPlan float null,--浓液 产生量 非计划生产量值（t）
	SysDirDelAmount float null,--浓液 处理量 回喷量（t）
	SysDirOutAmount float null,--浓液 处理量 外运量（t）

	SysDirmDra float null,--污泥 干污泥 产生量（t）
	SysDirmDraDel float null,--污泥 干污泥 焚烧/填埋处置量（t）
	SysDirmDraOut float null,--污泥 泥水泥合物 外委处置量（t）

	SysSourceLimit float null,--能源消耗 用电量 限定值（kwh）
	SysSourceFact float null,--能源消耗 用电量 实际值（kwh）
	SysSourceUnit float null,--能源消耗 用电量 单位电耗（kwh）
	SysPSourceLimit float null,--能源消耗 工业用水量 限定值（t）
	SysPSourceUnitFact float null,--能源消耗 工业用水量 实际值（t）
	SysPSourceUnitUse float null,--能源消耗 工业用水量 单位水耗（t）
)

--渗滤液处理系统水质监测统计表
CREATE TABLE SF_YX_MonthReportBGH_dtlSecond(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	TJCCODOut float null,--调节池出水 COD（mg/L）
	TJCAD float null,--调节池出水 氨氮（mg/L）

	UASBMLSS float null,--UASB池出水 1# MLSS（mg/L）
	UASBAD float null,--UASB池出水 1# 氨氮（mg/L）
	UASBCOD float null,--UASB池出水 1# COD（mg/L）
	UASBMLSS2 float null,--UASB池出水 2# MLSS（mg/L）
	UASBAD2 float null,--UASB池出水 2# 氨氮（mg/L）
	UASBCOD2 float null,--UASB池出水 2# COD（mg/L）

	FXHCAD float null,--反硝化池出水 1# 氨氮（mg/L）
	FXHCMLSS float null,--反硝化池出水 1# MLSS（mg/L）
	FXHCAD2 float null,--反硝化池出水 2# 氨氮（mg/L）
	FXHCMLSS2 float null,--反硝化池出水 2# MLSS（mg/L）

	XHCMLSS float null,--硝化池出水 1# MLSS（mg/L）
	XHCAD float null,--硝化池出水 1# 氨氮（mg/L）
	XHCCOD float null,--硝化池出水 1# COD（mg/L）
	XHCT float null,--硝化池出水 1# 温度（°C）
	XHCMLSS2 float null,--硝化池出水 2# MLSS（mg/L）
	XHCAD2 float null,--硝化池出水 2# 氨氮（mg/Lt）
	XHCCOD2 float null,--硝化池出水 2# COD（mg/L）
	XHCT2 float null,--硝化池出水 2# 温度（°C）

	DTROCOD float null,--DTRO 1# COD(mg/L)
	DTROAD float null,--DTRO 1# 氨氮(mg/L)
	DTROCOD2 float null,--DTRO 2# COD(mg/L)
	DTROAD2 float null,--DTRO 2# 氨氮(mg/L)

	ZPCOD float null,--总排 COD(mg/L)
	ZPAD float null,--总排 氨氮(mg/L)
	ZPZD float null,--总排 总氮(mg/L)
)

--飞灰处理系统生产统计表
CREATE TABLE SF_YX_MonthReportBGH_dtlThird(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	YHCLL float null,--原灰处理量（t）

	THJuse float null,--螫合剂 使用量（t）
	THJleft float null,--螫合剂 剩余量（t）

	WaterUse float null,--用水量（t）
	ElectricUse float null,--用电量（kwh）
	GHWYield float null,--固化物产量（t）
	OutYield float null,--外运量（t）
	MatYield float null,--库存量（t）
	PassRate float null,--产品合格率（%）
)

