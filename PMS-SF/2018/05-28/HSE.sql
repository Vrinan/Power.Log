--��ҪΣ��Դ���㣩ʶ�����嵥
CREATE TABLE SF_HSE_HazardResources(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	HazardSource nvarchar(200) null,--Σ��Դ���㣩
	MainHazardReason nvarchar(500) null,--��ҪΣ������
	MainHazardHarm nvarchar(500) null,--��ҪΣ��
	PossibleAccidents nvarchar(500) null,--���ܵ��µ��¹�
	MainControlMeasures nvarchar(500) null,--��Ҫ���ƴ�ʩ
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

--��Ҫ���������嵥

--�ճ���ҵ����
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

--��ȫר���
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

--HSE��������飨�£�
CREATE TABLE SF_HSE_FireInspectionM(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ProjName nvarchar(100) null,
	ProjId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--�����Ա
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--�������
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
	DepartmentName nvarchar(500) null,--Υ�µ�λ/����
	DepartmentId uniqueidentifier null,
	ConstructionAarea nvarchar(500) null,--ʩ������
	UnqualifiedType nvarchar(500) null,--���ϸ�����
	Question nvarchar(500) null,--��������
	leave nvarchar(100) null,--�ȼ�
	CorrectiveAction nvarchar(500) null--������ʩ
)
--alter table SF_HSE_FireInspectionM_dtl add Memo nvarchar(500) null

--HSE��������飨ר�
CREATE TABLE SF_HSE_FireInspectionE(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectContent nvarchar(100) null,--�������
	PartyBName nvarchar(100) null,--�ܼ쵥λ
	PartyBId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--�����Ա
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--�������
	ExistQuestion nvarchar(500) null,--��������
	CorrectiveAction nvarchar(500) null,--������ʩ
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

--�����Ų�
CREATE TABLE SF_HSE_Investigation(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectHuman nvarchar(100) null,--�����Ա
	InspectHumanId uniqueidentifier null,
	InspectDate datetime null,--�������
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
	PartyBName nvarchar(100) null,--������λ
	PartyBId uniqueidentifier null,
	TroubleType nvarchar(100) null,--�������
	Content nvarchar(500) null,--��������
	Memo nvarchar(500) null--��ע˵��
)

--���ͨ��
CREATE TABLE SF_HSE_InspectionNotice(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	InspectDepart nvarchar(100) null,--�ܼ첿��
	InspectDepartId uniqueidentifier null,
	InspectArea nvarchar(100) null,--�ܼ�����
	InspectManager nvarchar(100) null,--�ܼ���������
	InspectManagerId uniqueidentifier null,
	InspectDate datetime null,--�������
	TotalStatus nvarchar(100) null,--�������
	ProcessingAdvice nvarchar(100) null,--�������
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
	HuamnCode  nvarchar(100) null,--����
	HuamnName  nvarchar(100) null,--����
	HumanId uniqueidentifier null,
	DeptName nvarchar(100) null,--����
	DeptId uniqueidentifier null,
	Position nvarchar(100) null,--��λ
	PositionId uniqueidentifier null
)
--alter table SF_HSE_InspectionNotice_dtl add Memo nvarchar(500) null
select * from PB_Human
--select * from SF_HSE_InspectionNotice

--����֪ͨ
--alter table SF_HSE_RectificationNotice add IsReturn nvarchar(100) null 
CREATE TABLE SF_HSE_RectificationNotice(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	SignDate datetime null,--ǩ��ʱ��
	SignHuman nvarchar(100) null,--ǩ����
	SignHumanId uniqueidentifier null,
	CheckDate  datetime null,--���ʱ��
	CheckDepart nvarchar(100) null,--��鲿��
	CheckDepartId uniqueidentifier null,
	TroubleDepart nvarchar(100) null,--�������β���
	TroubleDepartId uniqueidentifier null,
	InspectHuman nvarchar(100) null,--�����Ա
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
	TroubleType nvarchar(500) null,--�������
	TroubleName nvarchar(500) null,--��������
	TroubleChange nvarchar(500) null,--���������໤��ʩ
	ChangeTime nvarchar(500) null,--��������
	Memo nvarchar(500) null--��ע˵��
)

--���Ļظ�
CREATE TABLE SF_HSE_RectificationReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReNoticeCode nvarchar(100) null,--����֪ͨ�����
	ReNoticeName nvarchar(100) null,--����֪ͨ������
	ReNoticeId uniqueidentifier null,
	TroubleDepart nvarchar(100) null,--�������β���
	TroubleDepartId uniqueidentifier null,
	RectificationReturnDate datetime null,--ʱ��
	RectificationManager nvarchar(100) null,--���ĸ�����
	RectificationManagerId uniqueidentifier null,
	ReviewHuamn nvarchar(100) null,--������
	ReviewHuamnId uniqueidentifier null,
	ReviewDate datetime null, --����ʱ��
	ChangeContent nvarchar(500) null,--�������
	Review nvarchar(500) null,--�������
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
	TroubleType nvarchar(500) null,--�������
	TroubleName nvarchar(500) null,--��������
	TroubleChange nvarchar(500) null,--���������໤��ʩ
	ChangeTime nvarchar(500) null,--��������
	ChangeContent nvarchar(500) null,--�������
	ChangeDate datetime null,--����ʱ��
	Memo nvarchar(500) null--��ע˵��
)

--HSE����
CREATE TABLE SF_HSE_RewardsAndPunishments(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	PartyBName nvarchar(100) null,--��λ
	PartyBId uniqueidentifier null,
	OwnerDept nvarchar(100) null,--����������
	OwnerDeptId uniqueidentifier null,
	RAPDate datetime null,--����ʱ��
	RAPType nvarchar(100) null,--�������
	RAPReason nvarchar(500) null,--��������
	RAPAmount float null,--���ͽ��
	ImplementationHuman nvarchar(100) null,--ʵʩ��
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