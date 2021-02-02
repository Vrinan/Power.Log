select ImplementationHuman,* from SF_HSE_RewardsAndPunishments

--select RorP,a3.Name from SF_HSE_RewardsAndPunishments a4
--left join 
--(select a2.Code,a2.Name from PB_BaseData a1 left join PB_BaseDataList a2 on a1.Id = a2.BaseDataId where DataType='RorP') a3
--on a4.RorP = a3.Code

--select * from PB_Human
--select HumanName,DeptName,PartyBName,RAPReason,RAPAmount, * from SF_HSE_RewardsAndPunishments_dtl
--select b.DeptName,case when a.HumanName is not null then a.HumanName when a.DeptName is not null then a.DeptName when a.PartyBName is not null then a.PartyBName end as allName,
--RAPReason,RAPAmount from SF_HSE_RewardsAndPunishments_dtl a
--left join PB_Human b on a.HumanId =b.Id where a.MasterId=

--select * from pwf_pastNodes
--select a.KeyValue,b.WorkInfoID, b.SequeID ,case when b.ActName = '开始' then '考核员' else b.ActName end as ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
--       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content,sgn.Picture,
--       d.PosiName,d.DeptName 
--from pwf_infos a 
--right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
--left join PB_HumanSign sgn on b.UserId = sgn.HumanId
--left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
--left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
--left join PB_Department dept on posi.DeptId=dept.Id ) d 
--on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
--where ActName !='结束' and KeyValue='D3A003FB-6AA0-4E64-B78F-573EC2CF1C67'

select * from SF_HSE_MonthReport

select * from View_SF_SJ_Overview
Select Count(*) From View_SF_SJ_Overview

Select * From View_SF_SJ_Overview Order By  xmbhCode,ProjectLeader,DesignStage,tdzjTitle,ggspsTitle,jsxyTitle,sjtzTitle,wjjsTitle,wjhsTitle,cpTitle,sjcgTitle,sjzjTitle


select * from PB_Widget where id='2410f17c-7f9b-426d-b133-4a7c575ec04f'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SFSJ_Overview.htm

Select XCode_T1.* From (Select *, row_number() over(Order By  xmbhCode,ProjectLeader,DesignStage,tdzjTitle,ggspsTitle,jsxyTitle,sjtzTitle,wjjsTitle,wjhsTitle,cpTitle,sjcgTitle,sjzjTitle) as rowNumber From View_SF_SJ_Overview) XCode_T1 Where rowNumber Between 101 And 150