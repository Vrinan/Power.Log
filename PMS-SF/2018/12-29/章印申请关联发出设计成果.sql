--��ӡ����
select * from PB_Widget where id='f9412e6a-6e10-4905-bf93-77109c8e7b47'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_SealApplication.htm


--��ӡ�������������Ƴɹ�
CREATE TABLE SF_SealApplication_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](100) NULL,
	[ListId] [uniqueidentifier] NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL
)
select * from SF_SealApplication_dtl
select * from SF_SJ_SealApplication
alter table SF_SJ_SealApplication add ProjectCode nvarchar(100) null



select * from V_SF_SJ_ProjNumberApplication where ProjectName1 = '��������Ϫ������������������Һ����վ����'

select projectcode,ProjectName,ProjectNameId from SF_SJ_SealApplication where projectcode is null
--update SF_SJ_SealApplication set projectcode = ProjectName
select Title,* from SF_SJ_SealApplication where projectcode='��������Ϫ������������������Һ����վ����'