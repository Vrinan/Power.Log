USE [SF_PowerOnEPC]
GO
/****** Object:  UserDefinedFunction [dbo].[returnTreeIds]    Script Date: 2018/5/10 10:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[returnTreeIds](@id uniqueidentifier,@humanid uniqueidentifier )        
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
 delete from  @re    
    where id  not in ( select id from dbo.returnHumanTreeIds(@humanid))   
  return      
 end 