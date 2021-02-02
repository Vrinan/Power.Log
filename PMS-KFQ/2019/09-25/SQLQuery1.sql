select * from PLN_project where project_guid in
(
	select B.id from dbo.returnEngineeringClassifyIds('6CF5B5E2-A64B-4212-8C27-3B2F7B3EC86F') B 
)

select * from pb_human where name='张何'
select * from pb_user where name='张何'
select * from PB_Department
select * from PB_HumanRelation where HumanId='6CF5B5E2-A64B-4212-8C27-3B2F7B3EC86F' 
select a.Code,a.Name,[dbo].GetBaseData('BD_OrganizeType',b.RoleType) as RoleType,b.Name from pb_organize a left join pb_human b on a.Id = b.RoleSourceId where b.Id='6CF5B5E2-A64B-4212-8C27-3B2F7B3EC86F'

sp_helptext returnEngineeringClassifyIds

CREATE function [dbo].[returnEngineeringClassifyIds](@id uniqueidentifier)        
 returns @re table(id uniqueidentifier)      
 as      
 begin           
  
  insert into @re
  select MasterId as id from KFQ_SG_EngineeringClassify_dlt where HumanId =  @id

  insert into @re
  select MasterId as id from KFQ_SG_EngineeringClassify_list where HumanId = @id
          
  while @@rowcount>0
       
    insert into @re
    select a.id
    from (
          select project_guid as id,parent_guid as pid
          from  PLN_project a
          )  a inner join @re b on a.pid=b.id
    where a.id not in(select id from @re)
  return
 end

 select * from PB_Widget where id='55c58e97-c090-4e1c-b644-083f5e058171'