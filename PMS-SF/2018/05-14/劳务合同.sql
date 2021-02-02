--员工入职单
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

--试用期转正考评
Create table SF_TurnToPositive
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	--HumanName nvarchar(100) null,
	HumanId uniqueidentifier null,
	BeforePositiveSalary float null,--转正前工资
	AfterPositiveEntryRank nvarchar(100) null,--转正后岗级
	Department nvarchar(100) null,--工作部门
	DepartmentId uniqueidentifier null,
	--Position nvarchar(100) null,--岗位
	--PositionId uniqueidentifier null,
	Education nvarchar(150) null,--学历
	TechnicalTitles nvarchar(150) null,--技术职称
	Majors nvarchar(150) null,--所学专业
	SignContractTerm nvarchar(150) null,--签订劳动合同期限 
	ContractSignTime datetime Null,--签订劳动合同时间
	TryOutTime float null--试用期期限
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

--劳动合同签订
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
	ContractTerm float null,--合同期限
	ContractBeginDate datetime null,--合同起始时间
	ContractEndDate datetime null--合同截至时间
)
--alter table SF_LaborContractSigning add Major nvarchar(100) null
--外键
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

--劳动合同续签申请
Create table SF_LaborRenewalApply
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	IsNotice nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null,
	RenewalTimes nvarchar(100) null,--续签次数
	RenewalTerm int null,--续签合同期限
	RenewalBeginDate datetime null,--续签起始时间
	RenewalEndDate datetime null--续签截至时间
)
--EXEC sp_rename 'SF_LaborContractRenewalApply','SF_LaborRenewalApply' 
--外键
--LaborCode Code 合同编号
--LaborEndDate ContractEndDate 原劳动合同到期时间
--HumanName Name 姓名
--HumanCode Code 工号

--劳动合同不续签通知书
Create table SF_ZH_LaborNoRenewalApply
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null
)
--外键
--LaborCode Code 合同编号
--ContractBeginDate 劳动合同开始时间
--ContractEndDate 劳动合同截至时间
--HumanName Name 姓名
--HumanCode Code 工号

--离职办理手续
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


--解除通知单
Create table SF_ZH_SockNotice
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	LaborContractId uniqueidentifier null,
	HumanId uniqueidentifier null,
	LaborContractType nvarchar(100) null,
	LaborLawNum nvarchar(100) null,--合同法项号
	SockDate datetime null
)
--外键
--LaborCode Code 劳动合同编号
--ContractBeginDate 劳动合同开始时间
--ContractEndDate 劳动合同截至时间
--HumanName Name 姓名
--HumanCode Code 工号
