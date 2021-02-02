--���񡢷���
--���ù����Ӵ�����
CREATE TABLE SF_FK_Reception(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ApplicantHuman nvarchar(100) null,--������
	ApplicantHumanId uniqueidentifier null,--������Id
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	ApplicantDate datetime null,
	ReceptionType nvarchar(100) null,--�Ӵ����ͣ�����/����
	ReceptionReason nvarchar(500) null,--�Ӵ�����
	Amount float null,
	MatterDescription nvarchar(500) null,--����˵��
	ReceptionObject nvarchar(100) null,--�Ӵ�����
	PeopleAmount int null,
	MeetingTime datetime null,--�ò�ʱ��
	MeetType nvarchar(100) null,--�ò�����
	MenuDtl nvarchar(100) null,--�˵���ϸ
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
--���ñ���
CREATE TABLE SF_FK_Reimbursement(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ApplicationHuman nvarchar(100) null,--������
	ApplicationHumanId uniqueidentifier null,--������Id
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	PartyBName nvarchar(500) null,--�Է���λ����
	PartyBBank nvarchar(500) null,--������
	PartyBBankCode nvarchar(500) null,--�ʺ�
	Amount float null,
	MatterDescription nvarchar(500) null,--����˵��
	IsHSAmount nvarchar(100) null,--�Ƿ�ȫ������
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
--��֤��(����)��ҵ��������
CREATE TABLE SF_FK_MarginOwnerApply(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ContractCode nvarchar(100) null,--��ͬ���
	ContractId uniqueidentifier null,
	ApplyHuamn nvarchar(100) null,--������
	ApplyHumanId uniqueidentifier null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	PartyBName nvarchar(500) null,--�Է���λ����
	PartyBBank nvarchar(500) null,--������
	PartyBBankCode nvarchar(500) null,--�ʺ�
	Amount float null,
	ApplyType nvarchar(100) null,--��������
	Clearing nvarchar(100) null,--���㷽ʽ
	MatterDescription nvarchar(500) null,--����˵��
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
alter table SF_FK_MarginOwnerApply add ContractName nvarchar(200) null
select * from SF_FK_MarginOwnerApply 
--��֤��(����)��ҵ�����˻�
alter table SF_FK_MarginOwnerReturn add ApplyType  nvarchar(100) null
CREATE TABLE SF_FK_MarginOwnerReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,

	MarginOwnerApplyId uniqueidentifier null,
	MarginOwnerApply nvarchar(100) null,--��������
	ContractId uniqueidentifier null,
	ContractName nvarchar(100) null,--��ͬ����
	ContractCode nvarchar(100) null,--��ͬ���
	ApplyAmount float null,--������
	PartyBName nvarchar(500) null,--�Է���λ����
	ApplyType nvarchar(100) null,--��������
	
	Manager nvarchar(100) null,--������
	ManagerId uniqueidentifier null,
	ReturnAmount float null,--�˻����
	ReturnDate datetime null,
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
--------------------------------------
--��֤��(����)���ְ����Ǽ�
CREATE TABLE SF_FK_MarginSubcontractorApply(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MarginType nvarchar(100) null,--��֤�����ͣ�Ͷ�걣֤�𣨲���ʾ��ͬ������Լ��֤����Լ������HSE��֤��
	ContractName nvarchar(100) null,--��ͬ����
	ContractCode nvarchar(100) null,--��ͬ���
	ContractId uniqueidentifier null,

	PartyBName nvarchar(100) null,--�Է���λ����
	PartyBHuman nvarchar(100) null,--��ϵ��
	PartyBPhone nvarchar(100) null,--��ϵ�绰
	ReturnAmount float null,
	Returndate datetime null,
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

--��֤��(����)���ְ����˻�
alter table SF_FK_MarginSubcontractorReturn drop column PartyBName
CREATE TABLE SF_FK_MarginSubcontractorReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MarginSubcontractorApplyId uniqueidentifier null,
	--���
	--MarginSubcontractorApplyCode��֤��ǼǱ��
	--MarginType��������
	--ContractName��ͬ����
	--ContractCode��ͬ���		
	ApplyHuman nvarchar(100) null,--������
	ApplyHumanId uniqueidentifier null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	--PartyBName nvarchar(500) null,--�Է���λ����
	PartyBBank nvarchar(500) null,--������
	PartyBBankCode nvarchar(500) null,--�ʺ�
	Amount float null,
	Clearing nvarchar(100) null,--���㷽ʽ
	MatterDescription nvarchar(500) null,--����˵��
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
