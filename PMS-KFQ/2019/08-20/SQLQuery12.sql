
create function [dbo].[returnEPSWithHumanRelation](@id uniqueidentifier)        
 returns @re table(project_guid uniqueidentifier)      
 as      
 begin           
     
  insert into @re     
  select project_guid from PLN_project where project_guid in(
		select * from dbo.[returnEPSChildrenTreeIds](@id)
		)
  and project_type=1
  return
 end 