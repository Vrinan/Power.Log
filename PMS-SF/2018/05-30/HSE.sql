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
--select * from SF_HSE_RewardsAndPunishments

--HSE�ܱ�
CREATE TABLE SF_HSE_WeekReport(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDate datetime null,
	OwnerDept nvarchar(100) null,--�����
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
	OwnerDept nvarchar(100) null,--����������
	OwnerDeptId uniqueidentifier null,	
	TroubleType nvarchar(500) null,--�������
	TroubleContent nvarchar(500) null,--��������
	TroubleChange nvarchar(500) null,--���Ĵ�ʩ
	ChangeTime datetime null,--�������ʱ��
	ScheduleContent nvarchar(500) null,--�������
	ChangeDate datetime null,--�������ʱ��
	NextRequest nvarchar(500) null,--��һ������Ҫ��
	Memo nvarchar(500) null--��ע˵��
)

--HSE�±�
CREATE TABLE SF_HSE_MonthReport(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ReportDate datetime null,--�ʱ��
	OwnerDept nvarchar(100) null,--�����
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

--��ȫ����
CREATE TABLE SF_HSE_SecurityMeeting(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MeetingDate datetime null,--����ʱ��
	MeetingContent nvarchar(500) null,--��������
	MeetingLocation nvarchar(100) null,--�����ַ
	Host nvarchar(100) null,--������
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


--����������ѵ
CREATE TABLE SF_HSE_TertiaryEAT(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	TrainType nvarchar(100) null,--��ѵ���רҵ������Ա��ѵ����Ӫ������Ա��ѵ��
	--��������ά����Ա��ѵ����Ա����ְ��ѵ��������ҵ��֤��ѵ��������
	TrainDate datetime null,--��ѵʱ��
	TrainContent nvarchar(500) null,--��ѵ����
	TrainHuman nvarchar(100) null,--��ѵ��
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
	HumanCode nvarchar(100) null,--����
	HumanName nvarchar(100) null,--����
	HumanGender nvarchar(100) null,--�Ա�
	HumanAge datetime null,--����
	--alter table SF_HSE_TertiaryEAT_dtl alter column HumanAge datetime null
	HumanIdentity nvarchar(100) null,--���֤����
	HumanDept nvarchar(100) null,--����
	HumanDeptId uniqueidentifier null,
	HumanType nvarchar(100) null,--����
	Score float null,--�ɼ�
	TrainDate datetime null,--��ѵ����
	TeachHumanId uniqueidentifier null,
	TeachHuamn nvarchar(100) null,--������
	Memo nvarchar(500) null
)
--select * from PB_Human
--select * from PB_Widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'


--ר����ѵ
CREATE TABLE SF_HSE_SpecialTraining(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	TrainDate datetime null,--��ѵʱ��
	TrainContent nvarchar(500) null,--��ѵ����
	TrainLocation nvarchar(100) null,--��ѵ�ص�
	TrainHuamn nvarchar(100) null,--������
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
--��Ҫ���������嵥SF_HSE_HazardResources
--/PowerPlat/FormXml/zh-CN/SF_HSE/Win_SF_HSE_HazardResources_Report.htm


--Ӧ������
--ί�����뵥������վ�����⣩
CREATE TABLE SF_HSE_DelegateYAppy(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	DelegateDept nvarchar(100) null,--ί�в���
    DelegateDeptId uniqueidentifier null,
	DelegateEPS nvarchar(100) null,--ί����Ŀ
    DelegateEPSId uniqueidentifier null,
	DelegateDate datetime null,--ί��ʱ��
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
	MonitorSite nvarchar(100) null,--���վ��
	SampleCode nvarchar(100) null,--��Ʒ���
	SampleWieght nvarchar(100) null,--��Ʒ����
	DeliveryCode nvarchar(100) null,--��ݼ��˵���
	DelegateIndex nvarchar(100) null,--���ָ��
	Memo nvarchar(500) null
)

--ί�����뵥������������ʱ��⣩
CREATE TABLE SF_HSE_DelegateOAppy(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	DelegateDept nvarchar(100) null,--ί�в���
    DelegateDeptId uniqueidentifier null,
	DelegateEPS nvarchar(100) null,--ί����Ŀ
    DelegateEPSId uniqueidentifier null,
	DelegateDate datetime null,--ί��ʱ��
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
	MonitorSite nvarchar(100) null,--����
	MonitorPurpose nvarchar(100) null,--���Ŀ��
	MonitorWay nvarchar(100) null,--��ⷽʽ
	MonitorFrequency nvarchar(100) null,--���Ƶ��	
	MonitorAmount nvarchar(100) null,--�������
	MonitorIndex nvarchar(100) null,--���ָ��
	Memo nvarchar(500) null
)

--��ⱨ��浵���·�
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
	Unit nvarchar(100) null,--��λ
	Amount nvarchar(100) null,--����
	ReportCode nvarchar(100) null,--��ⱨ����
	ReportDate Datetime null,--��������	
	FailedIndex nvarchar(100) null,--���ϸ�ָ��
	Memo nvarchar(500) null
)

--����������ڼ��顢�������鱨��浵
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
	Unit nvarchar(100) null,--��λ
	EquipmentName nvarchar(100) null,--��������
	SerialNumber nvarchar(100) null,--�������
	ValidityPeriod datetime null, --ʹ����Ч��
	DeliveryDate Datetime null,--�ͼ�����	
	NextDeliveryDate Datetime null,--�´��ͼ�����
	DeliveryContent nvarchar(500) null,--�������
	DeliveryNumber nvarchar(100) null,--��ⱨ����
	Memo nvarchar(500) null
)
--����λְҵ��Σ������
Create table SF_HSE_CareerSafe
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	SafeType nvarchar(100) null,--����  ����/����վ
	PosiName nvarchar(100) null, --��λ����
	PosiId uniqueidentifier null,
	Dangerous nvarchar(500) null,--���ܽӴ���ְҵ��Σ������
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

--ְҵ��Σ�����ض��ڼ��
Create table SF_HSE_CareerCheck
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	HumanName nvarchar(100) null, --�����
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
alter table SF_HSE_CareerCheck_dtl add CheckOpinion nvarchar(500) null --�������봦�����
alter table SF_HSE_CareerCheck_dtl add HSEOpinion nvarchar(500) null --��ȫ����������
Create table SF_HSE_CareerCheck_dtl
(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NOT NULL,
	HumanId uniqueidentifier null,
	HumanCode nvarchar(100) null,--����
	HumanName nvarchar(100) null,--����
	HumanGender nvarchar(100) null,--�Ա�
	HumanIdentity nvarchar(100) null,--���֤����
	HumanDept nvarchar(100) null,--����
	HumanDeptId uniqueidentifier null,
	HumanType nvarchar(100) null,--����
	DangerReason nvarchar(500) null, --ְҵ��Σ������
	CheckWay nvarchar(100) null, --������
	CheckDate datetime null,--�������
	CheckReport nvarchar(500) null,--��챨��
	Memo nvarchar(500) null
)




select * from PB_Widget where id='1702f11d-8856-4f8c-b0b1-42365ce8175b'

--����λְҵ��Σ������
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



--�¹ʿ챨
Create table SF_HSE_AccidentReport
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	Title [nvarchar](200) NULL,
	PartyBaName nvarchar(100) null,--�¹ʵ�λ
	PartyBId uniqueidentifier null,
	DeptName nvarchar(100) null,--�¹ʲ���
	DeptId uniqueidentifier null,
	HumanName nvarchar(100) null,--������
	HumanId uniqueidentifier null,
	AccidentDate datetime null,--�¹��¼�
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
--�¹ʵȼ�AccidentLeave

--alter table PS_HSE_AccidentsExpress add DeptName nvarchar(100) null
--alter table PS_HSE_AccidentsExpress add DeptId uniqueidentifier null
--alter table PS_HSE_AccidentsExpress add AccidentLeave nvarchar(100) null

select * from PB_BaseDataList where BaseDataId = (select id from PB_BaseData where DataType='PS_AccidentType')
--update PB_BaseDataList set Name='�����˺�' where id='47045354-0FCC-248D-6789-E6BBA4D9C2B3'
select * from SF_CustomerSatisfaction
select * from SF_CustomerSatisfaction_dtl
alter table SF_CustomerSatisfaction add PartyAName nvarchar(100) null--�нӵ�λ����
alter table SF_CustomerSatisfaction add PartyAId uniqueidentifier null--�нӵ�λ����Id
alter table SF_CustomerSatisfaction add PartyBName nvarchar(100) null--ҵ����λ����
alter table SF_CustomerSatisfaction add PartyBId uniqueidentifier null--ҵ����λ����Id
alter table SF_CustomerSatisfaction add DesignMemo nvarchar(500) null--���
alter table SF_CustomerSatisfaction add EquipmentMemo nvarchar(500) null--�豸
alter table SF_CustomerSatisfaction add RunMemo nvarchar(500) null--����
alter table SF_CustomerSatisfaction add IndexMemo nvarchar(500) null--ָ��
alter table SF_CustomerSatisfaction add AskMemo nvarchar(500) null--Ҫ��
alter table SF_CustomerSatisfaction add ReplyMemo nvarchar(500) null--�нӵ�λ�ظ����

