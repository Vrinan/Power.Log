alter function returnAllChildrenTreeIds(@id uniqueidentifier)        
 returns @re table(id uniqueidentifier)      
 as      
 begin           
     
  insert into @re     
  select id     
  from (      
        select Id as id ,ParentId as pid     
        from V_SF_DocFolder a      
        )  tb     
  where pid=@id      
          
  while @@rowcount>0      
       
    insert into @re       
    select a.id
    from (      
          select Id as id,parentId as pid     
          from  V_SF_DocFolder a       
          )  a inner join @re b on a.pid=b.id      
    where a.id not in(select id from @re)       
  return      
 end 