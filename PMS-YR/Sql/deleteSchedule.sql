--wbs
--delete from PLN_project_plan where create_user='������'

--�༭��ɾ��������ҵ
--������¼
delete from PS_PLN_PlanApprove where ApprHumName='������'

--������¼
delete from PS_PLN_TaskAssign where ApprHumName='������'

--�ƻ�����
select * from PS_PLN_SubPlanTemp where task_name = '�����Ƶ�' or task_name = 'ѭ��ˮվ'
delete from PS_PLN_SubPlanTemp where id= 'D83E63B2-AA67-4B26-95A2-70C611406A92'

--���ȷ���V_PS_PlN_PlanOverallProgress
--select * from PLN_project_plan
--select * from PS_PLN_TaskBCWS
--select * from PLN_PROJWBS
--select * from PLN_project
