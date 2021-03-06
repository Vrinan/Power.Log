create table SF_YX_Waterquality
(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	[Department] [nvarchar](200) NULL,
	[DeptId] [uniqueidentifier] NULL,
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
	[Date] [nvarchar](10) NULL,
	Type nvarchar(100) null
)
CREATE TABLE SF_YX_Waterquality_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	Sequ int null,
	A1 numeric(18,2) null,
	A2 numeric(18,2) null,
	B1 numeric(18,2) null,
	B2 numeric(18,2) null,
	B3 numeric(18,2) null,
	B4 numeric(18,2) null,
	B5 numeric(18,2) null,
	B6 numeric(18,2) null,
	C1 numeric(18,2) null,
	C2 numeric(18,2) null,
	C3 numeric(18,2) null,
	C4 numeric(18,2) null,
	D1 numeric(18,2) null,
	D2 numeric(18,2) null,
	D3 numeric(18,2) null,
	D4 numeric(18,2) null,
	D5 numeric(18,2) null,
	D6 numeric(18,2) null,
	D7 numeric(18,2) null,
	D8 numeric(18,2) null,
	E1 numeric(18,2) null,
	E2 numeric(18,2) null,
	E3 numeric(18,2) null,
	E4 numeric(18,2) null,
	F1 numeric(18,2) null,
	F2 numeric(18,2) null,
	F3 numeric(18,2) null
)