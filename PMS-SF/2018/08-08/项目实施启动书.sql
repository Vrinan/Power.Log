--项目实施启动书
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

	CostControlAmount numeric(18,2) null,--成本控制价
	ContractCycle nvarchar(2000) null,--合同工期
	PartyInHuman nvarchar(2000) null,--参会人员及部门负责人
	StartMeetingDate datetime null,--启动会时间
	AttentionRemark nvarchar(max) null,--一注意事项及要求
	OtherDecision nvarchar(max) null--其它决定
)


select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

select * from PB_Department where name='设计部'
select * from SF_HumanCheckOnWork where MasterId='' and DayTime=''
