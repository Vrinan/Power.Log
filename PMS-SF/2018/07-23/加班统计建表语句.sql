
CREATE TABLE SF_ZH_HumanOvertime(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	[DeptId] [uniqueidentifier] NULL,
	[Department] [nvarchar](50) NULL,
	[Month] [datetime] NULL,
	[MonthTime] [int] NULL,
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
	[OverDate] [datetime] NULL,
	[OverDate1] [datetime] NULL,
)

CREATE TABLE SF_ZH_HumanOvertime_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[HumId] [uniqueidentifier] NULL,
	[HumName] [nvarchar](100) NULL,
	[HumCode] [nvarchar](100) NULL,
	[OverType] [nvarchar](10) NULL,
	[MonthTime] [numeric](18, 0) NULL,
	[Memo] [nvarchar](1000) NULL,
	[Remark] [nvarchar](200) NULL,
)
