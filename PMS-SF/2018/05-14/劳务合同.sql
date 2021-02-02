--Ա����ְ��
Create table SF_Hires
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	HumanName nvarchar(100) null,
	Position nvarchar(100) null,
	PositionId uniqueidentifier null,
	Professionals nvarchar(50) null,
	EntryRank nvarchar(100) null,
	Probation float null,
	ContractSignBegin datetime Null,
	ContractSignEnd datetime Null
)
--EXEC sp_rename 'Hires','SF_Hires' 

select * from SF_Hires
select * from PB_Human
--delete from PB_Human where id='ACCB613E-3F7B-4990-8DB4-673A8FC9BC47'

select * from SF_FilesBoughtRecord

--delete from SF_FilesBoughtRecord

select * from PB_HumanRelation
select * from PB_Department 
select * from SF_Hires
select * from PB_DefaultField where DefaultFieldId='397512BC-0766-4BB7-B2C8-344D6CA8519C'
--update PB_DefaultField set Status = 0 where DefaultFieldId='397512BC-0766-4BB7-B2C8-344D6CA8519C'
--update SF_Hires set status = 0 

--������ת������
Create table SF_TurnToPositive
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	--HumanName nvarchar(100) null,
	HumanId uniqueidentifier null,
	BeforePositiveSalary float null,--ת��ǰ����
	AfterPositiveEntryRank nvarchar(100) null,--ת����ڼ�
	Department nvarchar(100) null,--��������
	DepartmentId uniqueidentifier null,
	--Position nvarchar(100) null,--��λ
	--PositionId uniqueidentifier null,
	Education nvarchar(150) null,--ѧ��
	TechnicalTitles nvarchar(150) null,--����ְ��
	Majors nvarchar(150) null,--��ѧרҵ
	SignContractTerm nvarchar(150) null,--ǩ���Ͷ���ͬ���� 
	ContractSignTime datetime Null,--ǩ���Ͷ���ͬʱ��
	TryOutTime float null--����������
)
select * from PB_Human
--alter table SF_TurnToPositive drop column HumanName
--alter table SF_TurnToPositive drop column Position
--alter table SF_TurnToPositive drop column PositionId
--HumanName Name
--HumanPosition PosiId
--HuamnPositionName PosiName
  select * from SF_TurnToPositive
  select * from pb_human where id='097736B4-F7F1-4D7A-813D-A60321548EA8'

select * from PB_Human
select * from PB_HumanRelation where HumanId='B8D65E0A-80B5-4AE6-98B9-0B1A11B69839'
--update PB_HumanRelation set RelationType=2 where Id='3DBD51A8-211C-461E-B778-0E5A22D8BEED'
select * from PB_HumanRelation where relationtype=2

--�Ͷ���ͬǩ��
Create table SF_LaborContractSigning
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ContractTitle nvarchar(100) null,
	HumanId uniqueidentifier null,
	DeptId uniqueidentifier null,
	PosiId uniqueidentifier null,
	MajorId uniqueidentifier null,
	ContractTerm float null,--��ͬ����
	ContractBeginDate datetime null,--��ͬ��ʼʱ��
	ContractEndDate datetime null--��ͬ����ʱ��
)
--alter table SF_LaborContractSigning add Major nvarchar(100) null
--���
--HumanName Name
--HumanCode Code
--HumanSex Sex
--Birthday Birthday
--Degree Degree
--Schoole Schoole
--PosiName PosiName
--DeptName DeptName
--MajorName MajorName

select * from PB_Human
select * from PB_Widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'

--�Ͷ���ͬ��ǩ����
Create table SF_LaborRenewalApply
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	IsNotice nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null,
	RenewalTimes nvarchar(100) null,--��ǩ����
	RenewalTerm int null,--��ǩ��ͬ����
	RenewalBeginDate datetime null,--��ǩ��ʼʱ��
	RenewalEndDate datetime null--��ǩ����ʱ��
)
--EXEC sp_rename 'SF_LaborContractRenewalApply','SF_LaborRenewalApply' 
--���
--LaborCode Code ��ͬ���
--LaborEndDate ContractEndDate ԭ�Ͷ���ͬ����ʱ��
--HumanName Name ����
--HumanCode Code ����

--�Ͷ���ͬ����ǩ֪ͨ��
Create table SF_ZH_LaborNoRenewalApply
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null
)
--���
--LaborCode Code ��ͬ���
--ContractBeginDate �Ͷ���ͬ��ʼʱ��
--ContractEndDate �Ͷ���ͬ����ʱ��
--HumanName Name ����
--HumanCode Code ����

--��ְ��������
Create table SF_ZH_Departure
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	HumanId uniqueidentifier null
)
select * from PB_Human
--HumanName Name
--HumanCode Code
--DeptName DeptName
--PosiName PosiName


--���֪ͨ��
Create table SF_ZH_SockNotice
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null,
	LaborContractType nvarchar(100) null,
	LaborLawNum nvarchar(100) null,--��ͬ�����
	SockDate datetime null
)
--���
--LaborCode Code �Ͷ���ͬ���
--ContractBeginDate �Ͷ���ͬ��ʼʱ��
--ContractEndDate �Ͷ���ͬ����ʱ��
--HumanName Name ����
--HumanCode Code ����
