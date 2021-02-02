--部门联系单，回复记录
--窗体
select * from PB_Widget where id='ffb3893c-3825-4195-8e3c-3448ba73ebb9'
--/PowerPlat/FormXml/zh-CN/StdCommunicate/Win_PS_SendPaper.htm

--表单
select * from PB_Widget where id='929739a9-8b4e-4595-8ffc-6ea70ff3dea2'
--/PowerPlat/FormXml/zh-CN/StdCommunicate/PS_SendPaper.htm

select * from SF_ZH_DeptContact

CREATE TABLE SF_ZH_DeptContact(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Title] [nvarchar](200) NULL,
	[ContactType] [int] NULL,--1是发送，2是回复
	[FromDept] [nvarchar](100) NULL,
	[FromDeptId] [uniqueidentifier] NULL, 
	[Sender] [nvarchar](20) NULL,
	[SenderId] [uniqueidentifier] NULL,
	[ToDept] [nvarchar](100) NULL,
	[ToDeptId] [uniqueidentifier] NULL,
	[Receiver] [nvarchar](20) NULL,
	[ReceiverId] [uniqueidentifier] NULL,
	[IsNeedReply] [int] NULL,
	[IsAlreadyReply] [int] NULL,
	[ReplyContactId] [uniqueidentifier] NULL,

	[UpdHumId] [uniqueidentifier] NULL,
	[UpdHumName] [nvarchar](80) NULL,
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
	[Memo] [nvarchar](2000) NULL)


	select * from PB_Human where PosiName like '%部长%' and PosiName not like '%副部长%'