--合同收款形象进度
select * from PB_ContractMilepost

--93ff6698-8116-4ce0-af68-3c37f2509b6c
CREATE TABLE PB_ContractMilepost_dtl1(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	ParentId [uniqueidentifier] null,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL,
)

CREATE TABLE PB_ContractMilepost_dtl1_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL,
	PlanStart datetime null,
	PlanFinish datetime null,
	RealStart datetime null,
	RealFinish datetime null
)

CREATE TABLE PB_ContractMilepost_dtl2(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL,
	SchdulMemo nvarchar(500) null,
	FinshDate datetime null
)

select * from PB_Widget where Id='cd3e67df-b7c2-4686-894c-0b6eef97fc9a'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SF_Market_ContractMilepost.htm

alter table PB_ContractMilepost add StartDate datetime null
alter table PB_ContractMilepost add ProductionPlan nvarchar(4000) null
alter table PB_ContractMilepost add MilestoneNode nvarchar(4000) null
alter table PB_ContractMilepost add CollectionNode nvarchar(4000) null


--update PB_ContractMilepost set MilestoneNode=222 where Id='C613D1EB-8AEE-BECD-03E9-EBF7948CBEF5'