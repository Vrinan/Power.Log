alter function returnTreeIds(@id uniqueidentifier,@humanid uniqueidentifier )        
 returns @re table(id uniqueidentifier)      
 as      
 begin        
  insert into @re     
  select @id     
     
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
  
/*      
根据权限判定       
    delete from  @re    
    where id  not in ( select id from  SF_KM_DocFolderLimit ( @humanid )  )    
 delete from  @re where id=@id      
 */
 --delete from  @re    
 --   where id  not in ( select MasterId from  SF_KM_DocFolderLimit where HumanId = @humanid)   
  return      
 end 

 select * from dbo.returnTreeIds('4BF0ADDA-BB09-3256-C4B8-FE5F9450799D','ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8')
 select * from V_SF_DocFolder
 --人员
 select MasterId,* from SF_KM_DocFolderLimit
 delete from SF_KM_DocFolderLimit