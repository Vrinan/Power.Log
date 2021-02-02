sp_helptext P_SF_LoopHuman

alter proc P_SF_LoopHuman(@relationId nvarchar(200),@masterId nvarchar(200))
as
declare @num int--行数
declare @tableLength int --表长度
select @tableLength=count(*) from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId=@relationId)
print @tableLength

--print @tableLength
--floor为0到100-1之间
--ceiling为1到100之间
--select @num='第'+convert(varchar(3000),@i) +'次：'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= cast(ceiling(rand()*@tableLength) as int)
print @num
select alr.* from(
select al.*,number = row_number() over(order by al.Id desc) from (
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId=@relationId)
) al
) alr
 where number = @num and Id not in(select HumanId from SF_LoopHuman_dtl where MasterId=@masterId)

 exec P_SF_LoopHuman '9be1ff92-11de-4460-8d51-8b618a9e5afd','656f50d8-d74e-7116-ac06-19c940247392'

select al.*,number = row_number() over(order by al.Id desc) from (
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='9be1ff92-11de-4460-8d51-8b618a9e5afd')
) al where al.Id not in (select HumanId from SF_LoopHuman_dtl)

sp_helptext View_SF_LoopHuman
select * from PB_HumanRelation

select * from SF_LoopHuman
select * from SF_LoopHuman_dtl

--alter table SF_LoopHuman drop column ProjId
--alter table SF_LoopHuman drop column ClientId
alter table SF_LoopHuman add PositionId uniqueidentifier
alter table SF_LoopHuman add Position nvarchar(150) null
alter table SF_LoopHuman add LoopHumanId uniqueidentifier
alter table SF_LoopHuman add LoopHumanName nvarchar(150)
alter table SF_LoopHuman add LoopDate datetime

select * from PB_Position
Insert Into SF_LoopHuman(Id, Code, Title, LoopHumanName, LoopDate, LoopHumanId, PositionId) Values('5355c2ca-9625-b5db-fafd-34cc027d5079', null, null, N'123', {ts'2018-05-15 00:00:00'}, null, null