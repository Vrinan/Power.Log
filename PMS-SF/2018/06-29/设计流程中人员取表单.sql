--select * from PS_SubContractApplyMoney--alter table PS_CM_SubContractApplyMny add PayType nvarchar(100) null----��ƺ�ͬ-֧������--select * from PB_Widget where id='36139912-2361-428e-af0c-38f2fcff2492'----/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_E.htm




--delete from SF_SJ_ProjNumberApplication
--delete from SF_SJ_ProjectMessage
--delete from SF_SJ_ProjectMessage_List
--delete from SF_SJ_InvProPlanCompile
--delete from SF_SJ_InvProPlanCompileList

--��Ŀ������
select ProjectMessageId,DesignStage,* from SF_SJ_ProjStartWorkTing
--�����嵥�ɹ��ƻ�����select ProjectStartMeetingId,* from SF_SJ_InvProPlanCompileselect * from SF_SJ_InvProPlanCompileList--�Ŷ��齨select * from SF_SJ_ProjectMessageselect * from SF_SJ_ProjectMessage_List--��Ŀ�������select * from SF_SJ_ProjNumberApplication------רҵ������-------У����--------------------�����-----------���/��ͼselect Leader,LeaderId,Proofreader,ProofreaderId,Auditor,AuditorId,DesignDrawing,DesignDrawingId from SF_SJ_ProjectMessage_Listalter view View_SF_DesignBomasselect mes.ProjectMessageId,ProjectMessage,c.DesignStage, Auditor,AuditorId,Leader,LeaderId from SF_SJ_ProjectMessage_List listleft joinSF_SJ_ProjectMessage meson list.MasterId = mes.Idleft join(select DesignStage,Id from SF_SJ_ProjNumberApplication) con c.Id = mes.ProjectCodeApplicationselect * from SF_SJ_ProjStartWorkTing where Id = '51DDF79E-7F1E-4972-B2D3-8CFA0845E737'--F3E1B2EC-E64F-4093-BDAF-319A36784CE3--kyselect * from View_SF_DesignBom where ProjectMessageId='F3E1B2EC-E64F-4093-BDAF-319A36784CE3' and DesignStage = 'ky'--�ɹ��嵥SF_InvProPlanCompile