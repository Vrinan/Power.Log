--select * from V_PS_DocFile

--sp_helptext V_PS_DocFile

----ÏîÄ¿ÎÄµµ
--select * from PB_Widget where id='c17b202f-0856-4163-b143-dc25678efed2'
----/PowerPlat/FormXml/zh-CN/StdDocument/Win_PS_DocFile.htm

--sp_helptext V_PS_DocFolder


--create view V_SF_HelpDocFolder
--as
--select * from PB_DocFolder x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId


--select * from V_PS_DocFolder
--select * from V_SF_HelpDocFolder

--select * from PB_Department




CREATE TABLE PB_HelpTree(
	[Id] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](255) NULL,
	[LongCode] [varchar](1000) NULL,
	[SourceId] [varchar](100) NULL,
	[SourceType] [varchar](50) NULL,
	[DeptType] [varchar](10) NOT NULL,
	[BaseDataId] [uniqueidentifier] NULL,
	[BaseDataName] [nvarchar](100) NULL,
	[Actived] [int] NULL DEFAULT ((1))
	)