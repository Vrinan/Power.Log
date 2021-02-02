select * from View_SF_DesignBom where ProjectMessageId='c35fd8d5-4b72-4918-a2ab-455db1a78f1b' and DesignStage = 'ky'

select * from SF_SJ_ProjStartWorkTing

sp_helptext View_SF_DesignBom	
alter view View_SF_DesignBomasselect mes.ProjectMessageId,ProjectMessage,c.DesignStage,DesignMajorId, Auditor,AuditorId,Leader,LeaderId from SF_SJ_ProjectMessage_List listleft joinSF_SJ_ProjectMessage meson list.MasterId = mes.Idleft join(select DesignStage,Id 
from SF_SJ_ProjNumberApplication) con c.Id = mes.ProjectCodeApplication--项目编号申请select * from SF_SJ_ProjNumberApplication where Code='1'--团队组建select * from SF_SJ_ProjectMessage--物资select * from SF_SJ_ProjStartWorkTingselect * from SF_SJ_InvProPlanCompileselect * from SF_SJ_ProjectMessage_List