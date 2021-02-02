--select * from PB_HumanRelation where RelationId='0441A582-A9E0-41E6-9568-3CD329C04797'
--select * from PB_User where Name='杨鑫超'


--select * from PB_Widget where Id='555346ef-7277-446b-8e74-333cb5cb987c'
----/PowerPlat/FormXml/zh-CN/SF_CG/Win_SF_CG_PurchasePlanAdjust.htm

--设备资料库
select * from PB_Widget where Id='d0f688ad-479a-4702-abda-3c5bf3896171'
--质量检查
--/PowerPlat/FormXml/zh-CN/SF_Complex/Win_SF_QulityDocFile.htm


select * from SF_YX_RunProduction

sp_helptext V_PS_DocFile

CREATE view [dbo].[V_SF_EqumentDocFile]  
as  
select a.*,isNull(b.countNum,0)countNum,c.BizAreaId,c.RegDate,c.RegHumId,c.RegHumName,ISNULL(c.EpsProjId,'00000000-0000-0000-0000-000000000000') as EpsProjId,  
c.sequ from PB_DocFiles a  
left join  
(select keyvalue,count(1) countNum from PB_Comment where KeyWord = 'docfile' group by KeyValue) b  
on a.id = b.KeyValue  
left join PB_DefaultField c  
on a.id = c.DefaultFieldId where BOKeyWord='SF_SJ_EqupmentManagement_dtl'

select * from PB_Widget where Id='460528b9-ae2d-411c-9636-36e503522e4b'
--/PowerPlat/FormXml/zh-CN/SF_Complex/Win_SF_HelpDocFile.htm


select * from V_SF_EqumentDocFile