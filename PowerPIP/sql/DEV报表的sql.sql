select * from PLN_project where project_type = '1'
select project_shortname as TypeCode,project_name as TypeName,
project_shortname as Code,project_name as Name from PLN_project where project_shortname <> 'shPower'

select project_shortname as TypeCode,project_name as TypeName from PLN_project 
where parent_id IN( select parent_id from PLN_project where project_shortname <> 'shPower' and project_type = '1')

select project_shortname as TypeCode,project_name as TypeName,plan_short_name as Code,plan_name as Name,Target,Amount,Content,SocietyAsset,CountyAsset,SubTotal,ReplyCode,QA,Apartment,Important from PLN_project,PLN_project_plan,CQwater_Project
where project_id in(
select parent_id from PLN_project 
where project_id in (select proj_id from PLN_project_plan)and PLN_project.project_guid = id and PLN_project.project_guid = PLN_project_plan.proj_guid)

create procedure proc_QueryProject
as
select project_shortname as TypeCode,project_name as TypeName,plan_short_name as Code,plan_name as Name,Target,Amount,Content,SocietyAsset,CountyAsset,SubTotal,ReplyCode,QA,Apartment,Important from PLN_project,PLN_project_plan,CQwater_Project
where project_id in(
select parent_id from PLN_project 
where project_id in (select proj_id from PLN_project_plan)and PLN_project.project_guid = id and PLN_project.project_guid = PLN_project_plan.proj_guid)
go

exec proc_QueryProject