--��Ŀʵʩ������
CREATE TABLE SF_FK_ProjCarryOut(
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
	[Memo] [nvarchar](1000) NULL,
	ContractId uniqueidentifier null,
	ContractCode nvarchar(200) null,
	ContractName nvarchar(200) null,
	ContractAmount numeric(18,2) null,
	PartyBName nvarchar(200) null,
	PartyBId uniqueidentifier null,

	CostControlAmount numeric(18,2) null,--�ɱ����Ƽ�
	ContractCycle nvarchar(2000) null,--��ͬ����
	PartyInHuman nvarchar(2000) null,--�λ���Ա�����Ÿ�����
	StartMeetingDate datetime null,--������ʱ��
	AttentionRemark nvarchar(max) null,--һע�����Ҫ��
	OtherDecision nvarchar(max) null--��������
)


select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

select * from PB_Department where name='��Ʋ�'
select * from SF_HumanCheckOnWork where MasterId='' and DayTime=''
