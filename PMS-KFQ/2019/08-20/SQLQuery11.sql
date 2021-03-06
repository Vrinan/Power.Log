
create function [dbo].[returnEPSChildrenTreeIds](@id uniqueidentifier)        
 returns @re table(id uniqueidentifier)      
 as      
 begin           
     
  insert into @re     
  select id     
  from (      
        select project_guid as id ,parent_guid as pid     
        from PLN_project a      
        )  tb     
  where pid=@id or id=@id
          
  while @@rowcount>0      
       
    insert into @re       
    select a.id
    from (      
          select project_guid as id ,parent_guid as pid     
          from  PLN_project a       
          )  a inner join @re b on a.pid=b.id      
    where a.id not in(select id from @re)       
  return      
 end 