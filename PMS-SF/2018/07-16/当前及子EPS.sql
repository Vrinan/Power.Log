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


--select * from [dbo].[returnEPSChildrenTreeIds]('920c3b9b-ab1c-4314-834f-747497ceeed6') 

select * from PB_Widget where id='b92fc059-9e0d-4147-85e3-39e8757ac94f'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_WorkFlowsModel.htm

select * from View_SF_WorkFlow where Title='HSE周报Al0716'
sp_helptext View_SF_WorkFlow
create view View_SF_WorkFlow
as
select al.*,alr.Content,alr.SequeID,alr.VoteText,alr.VoteValue from pwf_Infos al 
left join pwf_Opinion alr on al.WorkInfoID = alr.WorkInfoID 

select * from pwf_Infos where Title='HSE周报Al0716'