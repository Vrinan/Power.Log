select * from PB_HumanRelation where RelationId='D511ED55-F304-4766-BECA-DDDF3A5AAF1C'
select * from PB_Position where name='AAA'
--如果这么差，注意配置人员的时候需要人员和用户名称一样
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='176FC6AF-B088-47A5-A58A-61DC5E8279F2')
--变成视图
create view View_SF_LoopHuman
AS
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='176FC6AF-B088-47A5-A58A-61DC5E8279F2')
--固定行数的找到了
select * from(
select *,number = row_number() over(order by Id desc) from View_SF_LoopHuman) 
m where number = 2
--创建存储过程
create proc P_SF_LoopHuman
as
declare @num int--行数
declare @tableLength int --表长度
select @tableLength=count(*) from View_SF_LoopHuman
--print @tableLength
--floor为0到100-1之间
--ceiling为1到100之间
--select @num='第'+convert(varchar(3000),@i) +'次：'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= cast(ceiling(rand()*@tableLength) as int)
print @num
select * from(
select *,number = row_number() over(order by Id desc) from View_SF_LoopHuman) 
m where number = @num

exec P_SF_LoopHuman



--人员抽取
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
--企业知识分类-sf
--/PowerPlat/FormXml/zh-CN/SF_KM/Win_SF_KM_DocFolder.htm


