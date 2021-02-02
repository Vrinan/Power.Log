select * from PB_Widget where id='2253c580-98ba-49de-ba94-2b8d6e96141e'
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_EquipmentCostFeedback.htm

select * from SF_FK_EquipmentCostFeedback where id ='e592d25e-18d9-474b-96d6-6638a35879a9'
select * from SF_FK_EquipmentCostFeedback_dtl where MasterId='e592d25e-18d9-474b-96d6-6638a35879a9'

select * from SF_FK_EquipmentCostSchedule_dtl where MasterId='8e424ea8-7ca1-431b-8904-b7a656f545be' 


select * from SF_FK_EquipmentCostFeedback_dtl where MasterId='e592d25e-18d9-474b-96d6-6638a35879a9' 
and ListId not in(select pps.Id from SF_FK_EquipmentCostSchedule_dtl pps where pps.MasterId='8e424ea8-7ca1-431b-8904-b7a656f545be')

select * from SF_FK_EquipmentCostSchedule_dtl where FeedBackReport is not null

select * from SF_FK_EquipmentCostFeedback_dtl where MasterId ='c39d1f84-59c6-4714-adc8-9a100a3b963e'

select * from SF_FK_EquipmentCostSchedule_dtl where MasterId = '8e424ea8-7ca1-431b-8904-b7a656f545be'

and id not in(select ssr.ListId from SF_FK_EquipmentCostFeedback_dtl ssr where ssr.MasterId='c39d1f84-59c6-4714-adc8-9a100a3b963e')

select * from PB_Human

Select A.* From  SF_FK_EquipmentCostSchedule_dtl A Where   (0=0)  and A.MasterId='' and A.Id not in(select ssr.ListId from SF_FK_EquipmentCostFeedback_dtl ssr where ssr.MasterId='c39d1f84-59c6-4714-adc8-9a100a3b963e'

select * from SF_FK_EquipmentCostSchedule where IsNew =1 and EpsId=''
select * from SF_FK_EquipmentCostFeedback

Select f.TenderAmount,a.*,b.Code as BoughtCode,b.Title as BoughtName,c.EstimatedCost,c.Duration,b.Id as FilesBoughtRecordId,d.Name as ClientName,a.ProjectType as ProjectType1,a.ProjectSize as ProjectSize1,a.ProjectName as ProjectName1 , row_number() over(Order By a.ProjectName ASC ) as rowNumber 
From PS_MK_ProjectInfo a 
left join SF_FilesBoughtRecord b on a.Id=b.ProjId 
left join SF_BiddingFiles c on b.Id=c.FilesBoughtRecordId 
left join PB_Organize d on a.Client_Guid = d.Id 
left join PS_MK_isBidReview f on a.Id = f.ProjectInfo_Guid Where a.Id not in
( select ProjectInfo_Guid from PS_MK_isBidReview where ProjectInfo_Guid is not null)

--select * from View_BidReviewChoseProject

select * from SF_FK_EquipmentCostFeedback_dtl where MasterId ='c39d1f84-59c6-4714-adc8-9a100a3b963e'

select * from SF_FK_EquipmentCostSchedule where Id='920c3b9b-ab1c-4314-834f-747497ceeed6'

Select A.* From  SF_FK_EquipmentCostSchedule_dtl A Where  A.MasterId='920c3b9b-ab1c-4314-834f-747497ceeed6' and A.FeedBackReport is not null 


Select A.*,B.* From  SF_FK_EquipmentCostSchedule A join PB_DefaultField B on A.Id=B.DefaultFieldId Where   (0=0)  and A.EpsId='920c3b9b-ab1c-4314-834f-747497ceeed6' and A.IsNew =1



select * from PB_DocFiles