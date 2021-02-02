create function returnHumanTreeIds(@humanid uniqueidentifier )        
 returns @re table(id uniqueidentifier)      
 as      
 begin        
  insert into @re     
  select MasterId as Id from SF_KM_DocFolderLimit  
  
  --调用返回所有子节点Id的函数returnAllChildrenTreeIds，获取所有子节点
  declare @treeId uniqueidentifier
  select @treeId = MasterId from SF_KM_DocFolderLimit

  insert into @re
  select Id from dbo.returnAllChildrenTreeIds(@treeId)

  return      
 end 


 select * from dbo.returnHumanTreeIds('ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8')