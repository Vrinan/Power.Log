--�ѿ�
--�豸�ɱ��ƻ���
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
	Specifications nvarchar(100) null,--����ͺ�
	unit nvarchar(100) null,--��λ
	Quantity float null,--����
	UnitPrice float null,--����
	Price float null,--�ϼ�
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--�����ɱ��ƻ���
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
	Specifications nvarchar(100) null,--����ͺ�
	unit nvarchar(100) null,--��λ
	Quantity float null,--����
	UnitPrice float null,--����
	Price float null,--�ϼ�
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--��װ�ɱ��ƻ���
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
	Specifications nvarchar(100) null,--����ͺ�
	unit nvarchar(100) null,--��λ
	Quantity float null,--����
	UnitPrice float null,--����
	Price float null,--�ϼ�
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--�����ɱ��ƻ���
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
	Specifications nvarchar(100) null,--����ͺ�
	unit nvarchar(100) null,--��λ
	Quantity float null,--����
	UnitPrice float null,--����
	Price float null,--�ϼ�
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

--������óɱ��ƻ���
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
	Specifications nvarchar(100) null,--����ͺ�
	unit nvarchar(100) null,--��λ
	Quantity float null,--����
	UnitPrice float null,--����
	Price float null,--�ϼ�
	EpsName nvarchar(100) null,
	EpsCode nvarchar(100) null
)

