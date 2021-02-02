select * from PB_Widget where id='12c19b2a-8faf-4018-98e7-5f28cf8713dd'
--请购计划SF_CG_PurchasePlan
--/PowerPlat/FormXml/zh-CN/SF_CG/SF_CG_PurchasePlan.htm
--alter table SF_CG_PurchasePlanlist add MatStatus nvarchar(100) null

select * from pb_user where name='江洋'
select * from pb_user where name='徐兴国'
select * from pb_user where name='周兴卫'
select * from PB_User where name='陈自强'

--select * from PB_Human where SecondDeptId ='00000000-0000-0000-0000-000000000000' or SecondDeptId =DeptId
--select * from View_SF_DesignBom where 
--DesignMajorId='26f45244-2c45-6b75-c39c-3cd8da5bcaf3' 
--and DesignStage= 'sg'
--and ProjectMessageId='1bc6d95e-4563-4eca-a2a2-ec93eab641a7'

select * from SF_HumanCheckOnWork

select * from SF_CG_PurchasePlanlist where MasterId='c327d641-e1ad-46db-976f-cc8059ad0a5b'
select * from PS_MDM_Mat where id='a4fc7693-cb06-4143-83bb-a7908413374d'

select * from PS_MDM_Mat
select * from PS_MDM_Mat where MatShortName like '%11%' and MatLongName like '%1%'


select * from SF_CG_PurchasePlanlist where MatCode is null

select matcode, * from PS_MDM_Mat where MatShortName like '%电%' and MatLongName like '%电%'

select * from PS_MDM_Mat where MatCode like '%03.%' order by UpdDate
select Convert(int,replace(MatCode,'03.','')) as MatCode from PS_MDM_Mat where MatCode like '%03.%' order by MatCode
select Max(Convert(int,replace(MatCode,'03.',''))) as MatCode from PS_MDM_Mat where MatCode like '%03.%' order by MatCode

select Id,MatBSName,MatBSCode from PS_MDM_MatBS where MatBSName like '%未分类%'


select Max(Convert(int, replace(MatCode, '03.', ''))) as MatCode from PS_MDM_Mat where MatCode like '%03.%' order by MatCode