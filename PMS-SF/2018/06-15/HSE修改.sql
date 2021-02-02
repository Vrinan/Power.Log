--HSE
alter table SF_HSE_HazardResources add ParentId uniqueidentifier null
select * from SF_HSE_HazardResources

create table SF_HSE_HazardResources_dtl(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	UpdDate datetime null,
	Memo nvarchar(500) null,
	MainReason nvarchar(500) null,--��ҪΣ������
	MainDamage nvarchar(500) null,--��ҪΣ��
	MayDamage nvarchar(500) null,--���ܵ��µ��¹�
	MainDel nvarchar(500) null,--��Ҫ���ƴ�ʩ
)
create view View_SF_HazardResources
as
select al.Code,al.Title,ald.* from SF_HSE_HazardResources al left join SF_HSE_HazardResources_dtl ald on al.Id = ald.MasterId
go


--Ӧ������
--Ӧ��Ԥ��
CREATE TABLE SF_HSE_EmergencyPre(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	DeptName nvarchar(100) null,--�����
	DeptId uniqueidentifier null,
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
create table SF_HSE_EmergencyPre_dtl(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	UpdDate datetime null,
	Memo nvarchar(500) null,
	Content nvarchar(500) null,--��������
	PeopleAmount int null,--��ģ����
)

--Ӧ�������ƻ�
CREATE TABLE SF_HSE_EmergencyPlan(
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
create table SF_HSE_EmergencyPlan_dtl(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	UpdDate datetime null,
	Memo nvarchar(500) null,
	PartyBDept nvarchar(500) null,--��λ/����
	PartyBDeptId uniqueidentifier null,
	Content nvarchar(500) null,--��������
	PeopleAmount int null,--��ģ����
	PlanDate datetime null,--����ʱ��
	PlanLocation NVARCHAR(200) NULL,--�����ص�
	PlanType nvarchar(100) null,--������ʽ
	IsInC nvarchar(200) null, --�Ƿ�������һ��м��ص�������Ŀ
)
select * from SF_HSE_Investigation

select * from PB_Widget where id='c2ec17c6-68e9-43c8-942f-05b28efd96b5'

Select XCode_T1.* From (Select A.*, row_number() over(Order By a.Id) as rowNumber From  SF_HSE_RectificationNotice A Where   (0=0)  and A.Id not in (select ReNoticeId from SF_HSE_RectificationReturn)) XCode_T1 Where rowNumber Between 1 And 15

select Isnull(ReNoticeId,'00000000-0000-0000-0000-000000000000') from SF_HSE_RectificationReturn


alter table SF_HSE_RectificationNotice add InvestigationId uniqueidentifier null
alter table SF_HSE_RectificationNotice add InvestigationTitle nvarchar(100) null

--SF_HSE_RectificationNotice
--SF_HSE_RectificationNotice_dtl
--SF_HSE_RectificationReturn
--SF_HSE_RectificationReturn_dtl

select * from SF_HSE_RectificationNotice
select * from SF_HSE_RectificationReturn
--select * from SF_HSE_Investigation where Id not in(select Isnull(InvestigationId,'00000000-0000-0000-0000-000000000000') from SF_HSE_RectificationNotice)