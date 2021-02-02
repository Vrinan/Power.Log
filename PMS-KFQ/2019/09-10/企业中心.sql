USE [KFQ_PowerPMDB]
GO

/****** Object:  UserDefinedFunction [dbo].[returnEPSChildrenTreeIds]    Script Date: 2019/9/10 15:33:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


alter function [dbo].[returnEPSChildrenTreeIds](@id uniqueidentifier)        
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
GO

--������Բ��ӹ��ˡ�����ɵ�ˣ�����Ϊд����
--̫��֮ǰд����
--��֮û����
select * from PLN_project
select * from PLN_project where project_name='�����ٸ�Ͷ�ʼ���'
select * from dbo.[returnEPSChildrenTreeIds]('00000000-0000-0000-0000-0000000000a4')
--349
select * from PLN_project where project_type=1 
--302

