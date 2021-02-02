select * from PB_Widget where id='33529b2b-3c6d-41a5-aeca-c0d2079a1b33'
--旁站监理清单
--/PowerPlat/FormXml/zh-CN/KFQ_HSE_Y/Win_KFQ_HSE_SupervisionSideStation.htm
select ProjectId,* from KFQ_HSE_SupervisionSideStation

select * from PB_Widget where Id='5588c6d9-88ca-48f7-a93c-95401d09a6fb'
--成品平行检测记录
--/PowerPlat/FormXml/zh-CN/KFQ_QualityManage/Win_KFQ_FinishedProductParallelDetection.htm
select ProjectId,* from KFQ_FinishedProductParallelDetection

select * from PB_Widget where id='68e054b0-f721-4f91-84d0-b8c320978216'
--原材平行检测
--/PowerPlat/FormXml/zh-CN/KFQ_QualityManage/Win_KFQ_ParallelDetectionRecord.htm
select ProjectId,* from KFQ_ParallelDetectionRecord

select * from PB_Widget where id='73d40769-37d0-47be-8610-ea91742026c1'
--监理通知
--/PowerPlat/FormXml/zh-CN/KFQ_JL_Y/Win_KFQ_JL_SupervisionNotice.htm
--select ProjectId,* from

select * from PB_Widget where id='33f714b9-9cd7-4602-984b-39355ffc7f6c'
--整改通知
--/PowerPlat/FormXml/zh-CN/KFQ_JL_Y/Win_KFQ_JL_RectificationNotice.htm
--select ProjectId,* from

select * from PB_Widget where id='a67f314a-6b56-4b32-bc43-3fd784ee334a'
--监理日志
--/PowerPlat/FormXml/zh-CN/KFQ_JL_Y/Win_KFQ_JL_SupervisionJournal.htm
--select ProjectId,* from

select * from PB_Widget where id='30df4306-0780-42de-b5a9-b1341ac935fb'
--施工日志
--/PowerPlat/FormXml/zh-CN/StdConstruct/Win_PS_ConstructLog.htm
--select ProjectId,* from


select * from View_KFQ_SG_EngineeringClassify
where
 1=1   and projectid in(select id from returnEngineeringClassifyIds('6cf5b5e2-a64b-4212-8c27-3b2f7b3ec86f')) 
 and ProjectId ='0109a8b0-be07-4ab1-a9eb-5b8583ac86e6'


 select * from PB_Widget where Id='1b20d2d9-453c-43ed-a2ba-a2abc11367f4'
 --/PowerPlat/FormXml/zh-CN/StdPortalManage/Win_PS_Analysis.html


 select* from PB_Widget where Id='2b9a8adb-121e-40e7-ab4a-52d05806c548'
 --/PowerPlat/FormXML/zh-CN/Systems/WorkFlowListMore.htm