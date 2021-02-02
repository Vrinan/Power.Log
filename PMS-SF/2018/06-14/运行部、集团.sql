--����Һ��ˮ�����±���
CREATE TABLE SF_YX_MonthReportS(
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
CREATE TABLE SF_YX_MonthReportS_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,

	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DealAbility float null,--��Ŀ����Һ����ܴ���������t/d��
	AddWater float null,--����Һϵͳʵ�ʽ�ˮ����t)
	DealAmount float null,--ʵ������Һ��������t)
	OutAmount float null,--����Һ��������t)
	ProduceAmount float null,--����ҺŨҺ��������t��
	OutWater float null,--����ҺŨҺ��������t)
	DirAmount float null,--�������������t��
	Electric float null,--�ĵ�������kW.h)
	Water float null,--��ҵ��ˮ����t��
	PartyBName nvarchar(100) null,--���/������λ
	PunishCode nvarchar(100) null,--�����ĺ�
	PunishContent nvarchar(500) null,--���������/��������
	ProduceEvent nvarchar(500) null,--�����¼�
)
--�ɻҴ����±���
CREATE TABLE SF_YX_MonthReportF(
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
CREATE TABLE SF_YX_MonthReportF_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,

	DealAbility float null,--��Ŀ��Ʒɻ��ܴ���������t/d��
	AddWater float null,--ʵ�ʷɻҴ�������t)
	DealAmount float null,--���ϼ�������t)
	Electric float null,--�ĵ�������kW.h)
	Water float null,--��ҵ��ˮ����t��
	OnlyAmount float null,--�̻��������t)
	OutAmount float null,--�̻�����������t)	
	PartyBName nvarchar(100) null,--���/������λ
	PunishCode nvarchar(100) null,--�����ĺ�
	PunishContent nvarchar(500) null,--���������/��������
	ProduceEvent nvarchar(500) null,--�����¼�
)









--����ҺĤ�豸�����±���
CREATE TABLE SF_YX_MonthReportSL(
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
CREATE TABLE SF_YX_MonthReportSL_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DealAbility float null,--��Ŀ����Һ�ܴ���������t/d��
)	
CREATE TABLE SF_YX_MonthReportSL_dtlChild(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	[Memo] [nvarchar](500) NULL,
	UpdDate datetime null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	DeviceName nvarchar(100) null,--�豸����
	UnitAblity nvarchar(100) null,--��̨Ĥ����������t/d��
	DeviceAmount int null,--����ҺĤ������̨��	
)

select * from PB_BaseDataList a left join  PB_BaseData  b on a.BaseDataId=b.Id where b.DataType='PS_DesignStage'