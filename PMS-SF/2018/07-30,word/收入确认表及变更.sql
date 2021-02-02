--收入确认表及变更
select * from SF_FK_RevenueRecognition
select * from SF_FK_RevenueRecognition_dtl
--delete from SF_FK_RevenueRecognition
--delete from SF_FK_RevenueRecognition_dtl

--alter table SF_FK_RevenueRecognition_dtl add AccumulativeSchedule numeric(18,2) null
--alter table SF_FK_RevenueRecognition_dtl add AccumulativeGetAmount numeric(18,2) null
--alter table SF_FK_RevenueRecognition_dtl add AccumulativeAmount numeric(18,2) null
--alter table SF_FK_RevenueRecognition_dtl add AccumulativeRate numeric(18,2) null

select * from PB_Widget where id='12c19b2a-8faf-4018-98e7-5f28cf8713dd'
--/PowerPlat/FormXml/zh-CN/SF_CG/SF_CG_PurchasePlan.htm


select Name from PB_Human where PosiName='总经理'

select b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d on b.DeptPositionID = d.PosiId 
where  b.BeforeSequeID=2 order by  b.SequeID 


select a.Id ,a.HumId,a.OverType,b.Id as ListId,b.OverDate,b.OverDate1,b.OverTime
from SF_ZH_Overtime a inner join sf_zh_overtime_list b on a.id=b.masterid
where a.Status=50  and a.Status=50

select * from View_SF_DesignBom where 
ProjectMessageId='07115458-a4cc-4ea1-9a4b-f0afa0e0cefa' 

and  DesignMajorId='26f45244-2c45-6b75-c39c-3cd8da5bcaf3' 
and DesignStage = 'sg'

sp_helptext View_SF_DesignBom
select mes.ProjectMessageId,ProjectMessage,c.DesignStage,DesignMajorId, Auditor,AuditorId,Leader,LeaderId,Proofreader,ProofreaderId from SF_SJ_ProjectMessage_List listleft joinSF_SJ_ProjectMessage meson list.MasterId = mes.Idleft join(select DesignStage,Id from SF_SJ_ProjNumberApplication) con c.Id = mes.ProjectCodeApplication


select