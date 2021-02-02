--wbs
--delete from PLN_project_plan where create_user='王国栋'

--编辑里删除所有作业
--审批记录
delete from PS_PLN_PlanApprove where ApprHumName='王国栋'

--发包记录
delete from PS_PLN_TaskAssign where ApprHumName='王国栋'

--计划回收
select * from PS_PLN_SubPlanTemp where task_name = '空气制氮' or task_name = '循环水站'
delete from PS_PLN_SubPlanTemp where id= 'D83E63B2-AA67-4B26-95A2-70C611406A92'

--进度反馈V_PS_PlN_PlanOverallProgress
--select * from PLN_project_plan
--select * from PS_PLN_TaskBCWS
--select * from PLN_PROJWBS
--select * from PLN_project
