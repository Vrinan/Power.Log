--���в��±����칫�ᣩ
--alter table SF_YX_MonthReportBGH_dtlFirst add UpdDate datetime null
--alter table SF_YX_MonthReportBGH_dtlSecond add UpdDate datetime null
--alter table SF_YX_MonthReportBGH_dtlThird add UpdDate datetime null

CREATE TABLE SF_YX_MonthReportBGH(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDateTime datetime null,--�����
	ReportDept nvarchar(100) null,--��������վ
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
--����Һ����ϵͳ����ͳ�Ʊ�
CREATE TABLE SF_YX_MonthReportBGH_dtlFirst(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	SysAddPlan float null,--ϵͳ��ˮ �ƻ�ֵ��t��
	SysAddInfact float null,--ϵͳ��ˮ ʵ��ֵ��t��

	SysReturnAmount float null,--ϵͳ��ˮ ��ˮ����t��
	SysReturnDeal float null,--ϵͳ��ˮ �����ʣ�%��

	SysInoryAmount float null,--ϵͳδ������ ʵ��ֵ��t��
	SysInoryHP float null,--ϵͳδ������ ���ȣ�t��
	SysInoryOut float null,--ϵͳδ������ ��������t��

	SysClearPlan float null,--��Һ �ƻ�ֵ��t��
	SysClearFact float null,--��Һ ʵ��ֵ��t��
	SysClearRatePlan float null,--��Һ ����͸��˰ˮ�� �ƻ�ֵ��%��
	SysClearRateFinish float null,--��Һ ����͸��˰ˮ�� ���ֵ��%��
	SysClearHB float null,--��Һ ����͸��˰ˮ�� ���ȣ�%��

	SysDirPlanRange float null,--ŨҺ ������ ����ֵ��t��
	SysDirPlanAmount float null,--ŨҺ ������ ��ֵ��t��
	SysDirPlanAmountNoPlan float null,--ŨҺ ������ �Ǽƻ�������ֵ��t��
	SysDirDelAmount float null,--ŨҺ ������ ��������t��
	SysDirOutAmount float null,--ŨҺ ������ ��������t��

	SysDirmDra float null,--���� ������ ��������t��
	SysDirmDraDel float null,--���� ������ ����/����������t��
	SysDirmDraOut float null,--���� ��ˮ����� ��ί��������t��

	SysSourceLimit float null,--��Դ���� �õ��� �޶�ֵ��kwh��
	SysSourceFact float null,--��Դ���� �õ��� ʵ��ֵ��kwh��
	SysSourceUnit float null,--��Դ���� �õ��� ��λ��ģ�kwh��
	SysPSourceLimit float null,--��Դ���� ��ҵ��ˮ�� �޶�ֵ��t��
	SysPSourceUnitFact float null,--��Դ���� ��ҵ��ˮ�� ʵ��ֵ��t��
	SysPSourceUnitUse float null,--��Դ���� ��ҵ��ˮ�� ��λˮ�ģ�t��
)

--����Һ����ϵͳˮ�ʼ��ͳ�Ʊ�
CREATE TABLE SF_YX_MonthReportBGH_dtlSecond(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	TJCCODOut float null,--���ڳس�ˮ COD��mg/L��
	TJCAD float null,--���ڳس�ˮ ������mg/L��

	UASBMLSS float null,--UASB�س�ˮ 1# MLSS��mg/L��
	UASBAD float null,--UASB�س�ˮ 1# ������mg/L��
	UASBCOD float null,--UASB�س�ˮ 1# COD��mg/L��
	UASBMLSS2 float null,--UASB�س�ˮ 2# MLSS��mg/L��
	UASBAD2 float null,--UASB�س�ˮ 2# ������mg/L��
	UASBCOD2 float null,--UASB�س�ˮ 2# COD��mg/L��

	FXHCAD float null,--�������س�ˮ 1# ������mg/L��
	FXHCMLSS float null,--�������س�ˮ 1# MLSS��mg/L��
	FXHCAD2 float null,--�������س�ˮ 2# ������mg/L��
	FXHCMLSS2 float null,--�������س�ˮ 2# MLSS��mg/L��

	XHCMLSS float null,--�����س�ˮ 1# MLSS��mg/L��
	XHCAD float null,--�����س�ˮ 1# ������mg/L��
	XHCCOD float null,--�����س�ˮ 1# COD��mg/L��
	XHCT float null,--�����س�ˮ 1# �¶ȣ���C��
	XHCMLSS2 float null,--�����س�ˮ 2# MLSS��mg/L��
	XHCAD2 float null,--�����س�ˮ 2# ������mg/Lt��
	XHCCOD2 float null,--�����س�ˮ 2# COD��mg/L��
	XHCT2 float null,--�����س�ˮ 2# �¶ȣ���C��

	DTROCOD float null,--DTRO 1# COD(mg/L)
	DTROAD float null,--DTRO 1# ����(mg/L)
	DTROCOD2 float null,--DTRO 2# COD(mg/L)
	DTROAD2 float null,--DTRO 2# ����(mg/L)

	ZPCOD float null,--���� COD(mg/L)
	ZPAD float null,--���� ����(mg/L)
	ZPZD float null,--���� �ܵ�(mg/L)
)

--�ɻҴ���ϵͳ����ͳ�Ʊ�
CREATE TABLE SF_YX_MonthReportBGH_dtlThird(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	YHCLL float null,--ԭ�Ҵ�������t��

	THJuse float null,--�ϼ� ʹ������t��
	THJleft float null,--�ϼ� ʣ������t��

	WaterUse float null,--��ˮ����t��
	ElectricUse float null,--�õ�����kwh��
	GHWYield float null,--�̻��������t��
	OutYield float null,--��������t��
	MatYield float null,--�������t��
	PassRate float null,--��Ʒ�ϸ��ʣ�%��
)

