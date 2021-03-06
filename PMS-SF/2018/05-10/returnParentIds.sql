USE [SF_PowerOnEPC]
GO
/****** Object:  UserDefinedFunction [dbo].[returnAllChildrenTreeIds]    Script Date: 2018/5/10 9:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter function [dbo].[returnAllParentTreeIds](@id uniqueidentifier)        
 returns @re table(pid uniqueidentifier)      
 as      
 begin
 --1     
  insert into @re     
  select pid     
  from (      
        select Id as id ,ParentId as pid     
        from V_SF_DocFolder a      
        )  tb   
  where id=@id
   --2
  while @id is not null
  begin
  declare @a uniqueidentifier
  select @a=pid
  from (
        select Id as id ,ParentId as pid
        from V_SF_DocFolder a
        )  tb
  where id=@id

  insert into @re
  select pid
  from (
        select Id as id ,ParentId as pid
        from V_SF_DocFolder a
        )  tb
  where id=@a
  set @id = @a
  end
  ----3
  --declare @b uniqueidentifier
  --  select @b=pid     
  --from (      
  --      select Id as id ,ParentId as pid     
  --      from V_SF_DocFolder a      
  --      )  tb     
  --where id=@a 

  --insert into @re   
  --select pid     
  --from (      
  --      select Id as id ,ParentId as pid     
  --      from V_SF_DocFolder a      
  --      )  tb     
  --where id=@b
  ----4
  --declare @c uniqueidentifier
  --  select @c=pid     
  --from (      
  --      select Id as id ,ParentId as pid     
  --      from V_SF_DocFolder a      
  --      )  tb     
  --where id=@b

  --insert into @re
  --select pid     
  --from (      
  --      select Id as id ,ParentId as pid     
  --      from V_SF_DocFolder a      
  --      )  tb     
  --where id=@c
  return      
 end 

 --select * from [dbo].[returnAllParentTreeIds]('CE4595EB-BC72-5ECB-1A42-DE3F31231BDF') 
 --select * from V_SF_DocFolder