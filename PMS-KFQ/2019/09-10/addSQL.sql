CREATE function [dbo].[returnMonthEPSWithHumanRelation](@id uniqueidentifier)        
 returns @re table(project_guid uniqueidentifier)      
 as      
 begin           
     
  insert into @re     
  select project_guid from PLN_project where project_guid in(
		select * from dbo.[returnEPSChildrenTreeIds](@id)
		)
  and project_type=1 and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate) and DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate)
  return
 end 
GO


