CREATE TABLE SF_SJ_EqupmentManagement(
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
	[Memo] [nvarchar](4000) NULL,

	[CostId] [uniqueidentifier] NULL,
	[CostCode] [nvarchar](200) NULL,
	[CostName] [nvarchar](200) NULL,
	[EpsProjectId] [uniqueidentifier] NULL,
	[EpsProjectCode] [nvarchar](200) NULL,
	[EpsProjectName] [nvarchar](200) NULL,
	[CostType] [nvarchar](100) NULL,
	[SeasonNum] [nvarchar](200) NULL
)
alter table SF_SJ_EqupmentManagement add ParentId uniqueidentifier null

--вс╠М
CREATE TABLE SF_SJ_EqupmentManagement_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[Remark] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL,
)
alter table SF_SJ_EqupmentManagement_dtl add ParentId uniqueidentifier null

select request_session_id spid,OBJECT_NAME(resource_associated_entity_id) tableName from sys.dm_tran_locks where resource_type='OBJECT';
