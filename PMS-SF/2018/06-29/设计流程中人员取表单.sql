--select * from PS_SubContractApplyMoney--alter table PS_CM_SubContractApplyMny add PayType nvarchar(100) null----设计合同-支付申请--select * from PB_Widget where id='36139912-2361-428e-af0c-38f2fcff2492'----/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_E.htm




--delete from SF_SJ_ProjNumberApplication
--delete from SF_SJ_ProjectMessage
--delete from SF_SJ_ProjectMessage_List
--delete from SF_SJ_InvProPlanCompile
--delete from SF_SJ_InvProPlanCompileList

--项目开工会
select ProjectMessageId,DesignStage,* from SF_SJ_ProjStartWorkTing
--物资清单采购计划编制select ProjectStartMeetingId,* from SF_SJ_InvProPlanCompileselect * from SF_SJ_InvProPlanCompileList--团队组建select * from SF_SJ_ProjectMessageselect * from SF_SJ_ProjectMessage_List--项目编号申请select * from SF_SJ_ProjNumberApplication------专业负责人-------校对人--------------------审核人-----------设计/绘图select Leader,LeaderId,Proofreader,ProofreaderId,Auditor,AuditorId,DesignDrawing,DesignDrawingId from SF_SJ_ProjectMessage_Listalter view View_SF_DesignBomasselect mes.ProjectMessageId,ProjectMessage,c.DesignStage, Auditor,AuditorId,Leader,LeaderId from SF_SJ_ProjectMessage_List listleft joinSF_SJ_ProjectMessage meson list.MasterId = mes.Idleft join(select DesignStage,Id from SF_SJ_ProjNumberApplication) con c.Id = mes.ProjectCodeApplicationselect * from SF_SJ_ProjStartWorkTing where Id = '51DDF79E-7F1E-4972-B2D3-8CFA0845E737'--F3E1B2EC-E64F-4093-BDAF-319A36784CE3--kyselect * from View_SF_DesignBom where ProjectMessageId='F3E1B2EC-E64F-4093-BDAF-319A36784CE3' and DesignStage = 'ky'--采购清单SF_InvProPlanCompile