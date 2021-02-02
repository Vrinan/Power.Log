--费控
--设备成本计划表
create table SF_FK_EquipmentCostSchedule
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	EpsId uniqueidentifier null,
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)
create table SF_FK_EquipmentCostSchedule_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Specifications nvarchar(100) null,--规格型号
	unit nvarchar(100) null,--单位
	Quantity float null,--数量
	UnitPrice float null,--单价
	Price float null,--合计
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--建筑成本计划表
create table SF_FK_EstablishCostSchedule
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	EpsId uniqueidentifier null,
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)
create table SF_FK_EstablishCostSchedule_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Specifications nvarchar(100) null,--规格型号
	unit nvarchar(100) null,--单位
	Quantity float null,--数量
	UnitPrice float null,--单价
	Price float null,--合计
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--安装成本计划表
create table SF_FK_InstallCostSchedule
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	EpsId uniqueidentifier null,
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)
create table SF_FK_InstallCostSchedule_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Specifications nvarchar(100) null,--规格型号
	unit nvarchar(100) null,--单位
	Quantity float null,--数量
	UnitPrice float null,--单价
	Price float null,--合计
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--其他成本计划表
create table SF_FK_OtherCostSchedule
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	EpsId uniqueidentifier null,
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)
create table SF_FK_OtherCostSchedule_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Specifications nvarchar(100) null,--规格型号
	unit nvarchar(100) null,--单位
	Quantity float null,--数量
	UnitPrice float null,--单价
	Price float null,--合计
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--管理费用成本计划表
create table SF_FK_ManageCostSchedule
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	EpsId uniqueidentifier null,
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)
create table SF_FK_ManageCostSchedule_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Specifications nvarchar(100) null,--规格型号
	unit nvarchar(100) null,--单位
	Quantity float null,--数量
	UnitPrice float null,--单价
	Price float null,--合计
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

