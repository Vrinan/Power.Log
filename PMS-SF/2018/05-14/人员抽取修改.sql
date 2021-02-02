select * from PB_User

sp_helptext P_SF_LoopHuman

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

select * from View_SF_LoopHuman
sp_helptext View_SF_LoopHuman
alter view View_SF_LoopHuman
AS
select * from PB_Human where Id in(
select HumanId from PB_HumanRelation where RelationId='246873C5-8B8F-42C0-9C12-B0CE73BF0710')
select * from PB_HumanRelation
select * from pb_department