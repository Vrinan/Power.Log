--合同分析create function returnEPSTreeIds(@epsid uniqueidentifier)        
 returns @re table(id uniqueidentifier)      
 as
 begin
 --取出当前层Id
 insert into @re     
 select project_guid as Id from PLN_project  where project_guid=@epsid
  --循环取出每一个Id对应的所有子节点，加到@re表里
  declare @i int
  declare @tbLength int
  set @i = 0
  select @tbLength = count(*) from PLN_project where parent_guid = @epsid

  while @i<@tbLength
  begin 
  declare @treeId uniqueidentifier
  insert into @re
  select m.project_guid from(
  select *,number = row_number() over(order by project_guid desc) from PLN_project) 
  m where number = @i+1
  set @i=@i+1
  end

  return      
 end 

 --
 --select * from PLN_project where parent_guid = ''
select * from [dbo].returnEPSTreeIds('00000000-0000-0000-0000-0000000000a4') 

