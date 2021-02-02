select * from PB_Widget where id='2c2df609-2458-4ee6-bdd8-b909b71a770d'
--/PS_EnterpriseCenter.html
select code from PB_Human where Id=''

select receive_user_guid,receive_user,plan_name,proj_plan_guid, * from PLN_project_plan where proj_plan_guid =(
select plan_guid from PLN_PROJWBS where wbs_id='84701')

select HumanId,HumanName from PS_PLN_PlanLimit where MasterId=(select proj_plan_guid from PLN_project_plan where proj_plan_guid =(select plan_guid from PLN_PROJWBS where wbs_id='84701'))

select * from PB_Widget where id='79e97453-cb66-4237-b774-827a1be54424'
select * from PB_Human

select * from PB_Widget where id='e184b183-c550-43a9-9698-6374f52e8d05'
--/PowerPlat/FormXml/zh-CN/StdPlan/EditPlanWithGantt.html?uiview=EditPlanWithInline.js&showOpen=1&normalreadonly=1