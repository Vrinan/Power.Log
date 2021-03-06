USE [SF_PowerOnEPC]
GO
/****** Object:  UserDefinedFunction [dbo].[returnHumanTreeIds]    Script Date: 2018/5/9 14:30:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[returnHumanTreePositionIds](@humanid uniqueidentifier )        
 returns @re table(id uniqueidentifier)      
 as
 begin
  insert into @re     
  select MasterId as Id from SF_KM_DocFolderPoisitionLimit  where HumanId=@humanid

  --循环取出每一个Id对应的所有子节点，加到@re表里
  declare @i int
  declare @tbLength int
  set @i = 0
  select @tbLength = count(*) from SF_KM_DocFolderPoisitionLimit where HumanId=@humanid

  while @i<@tbLength
  begin 
  declare @treeId uniqueidentifier
  select @treeId = m.MasterId from(
  select *,number = row_number() over(order by Id desc) from SF_KM_DocFolderPoisitionLimit) 
  m where number = @i+1
  insert into @re
  select Id from dbo.returnAllChildrenTreeIds(@treeId) where Id not in (select Id from @re)
  set @i=@i+1
  end

  return      
 end 


--select MasterId as Id from SF_KM_DocFolderLimit  where HumanId='ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8'
--select * from [dbo].[returnHumanTreeIds]('ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8')  
     
--select * from SF_KM_DocFolderLimit
