select * from PB_HumanRelation where RelationId='D511ED55-F304-4766-BECA-DDDF3A5AAF1C'
select * from PB_Position where name='AAA'
--�����ô�ע��������Ա��ʱ����Ҫ��Ա���û�����һ��
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='176FC6AF-B088-47A5-A58A-61DC5E8279F2')
--�����ͼ
create view View_SF_LoopHuman
AS
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='176FC6AF-B088-47A5-A58A-61DC5E8279F2')
--�̶��������ҵ���
select * from(
select *,number = row_number() over(order by Id desc) from View_SF_LoopHuman) 
m where number = 2
--�����洢����
create proc P_SF_LoopHuman
as
declare @num int--����
declare @tableLength int --����
select @tableLength=count(*) from View_SF_LoopHuman
--print @tableLength
--floorΪ0��100-1֮��
--ceilingΪ1��100֮��
--select @num='��'+convert(varchar(3000),@i) +'�Σ�'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= cast(ceiling(rand()*@tableLength) as int)
print @num
select * from(
select *,number = row_number() over(order by Id desc) from View_SF_LoopHuman) 
m where number = @num

exec P_SF_LoopHuman



--��Ա��ȡ
create table SF_LoopHuman
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,
	ClientId uniqueidentifier null 
)
create table SF_LoopHuman_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	HumanId uniqueidentifier null,
	IsInvalid nvarchar(10) null,
	Memo nvarchar(300) null
)
alter table SF_LoopHuman_dtl add HumanCode nvarchar(100) null
alter table SF_LoopHuman_dtl add HumanName nvarchar(100) null
--SF_LoopHuman_dtl_Invalid
select * from PB_Widget where id='1702f11d-8856-4f8c-b0b1-42365ce8175b'
--��ҵ֪ʶ����-sf
--/PowerPlat/FormXml/zh-CN/SF_KM/Win_SF_KM_DocFolder.htm


