--质量检查
CREATE TABLE PB_QulityTree(
	[Id] [uniqueidentifier] NOT NULL,
	MasterId uniqueidentifier not null,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](255) NULL,
	[LongCode] [varchar](1000) NULL,
	[SourceId] [varchar](100) NULL,
	[SourceType] [varchar](50) NULL,
	[DeptType] [varchar](10) NOT NULL,
	[BaseDataId] [uniqueidentifier] NULL,
	[BaseDataName] [nvarchar](100) NULL,
	[Actived] [int] NULL
)

select * from PB_Widget where id='460528b9-ae2d-411c-9636-36e503522e4b'
--/PowerPlat/FormXml/zh-CN/SF_Complex/Win_SF_HelpDocFile.htm
--/PowerPlat/FormXml/zh-CN/SF_Complex/Win_SF_QulityDocFile.htm

select * from PB_QulityTree

delete from PB_QulityTree where Name = '桩基'

insert into PB_QulityTree values('26E77C79-668B-9BB5-DC61-DCD25D9537C1','71C350FC-E86C-4C1E-AABD-6BA64C6E8B43','A7E44010-7E63-5ED2-7A1D-8F3649A3C4FA','','土建1',NULL,NULL,NULL,'',NULL,NULL,0)

delete from PB_QulityTree where Name = '土建1'

exec Proc_QulityfilesTem '71C350FC-E86C-4C1E-AABD-6BA64C6E8B43'