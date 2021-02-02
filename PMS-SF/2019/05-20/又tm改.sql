create proc Proc_SF_UpdateSchedule(@id nvarchar(100))
as
update PB_ContractMilepost set schedule=
(
	select top 1 schdulmemo from PB_ContractMilepost_dtl2 where masterid=@id order by finshdate desc
) where Id=@id


alter proc Proc_SF_UpdateMilestoneNode(@id nvarchar(100))  
as  
update PB_ContractMilepost set MilestoneNode=  
(  
 select code + '¡¢'+Name+'£»' from PB_ContractMilepost_dtl1 where masterId=@id order by sequ for xml path('')  
) where Id=@id
update PB_ContractMilepost set MilestoneNode_schedule= 
(
 select top 1 name from PB_ContractMilepost_dtl1_dtl where MasterId in(
 select id from PB_ContractMilepost_dtl1 where MasterId=@id
 ) order by UpdDate desc 
) where Id=@id

update PB_ContractMilepost set MilestoneNode_schedule = null

--CREATE proc Proc_SF_Updatedtl(@id nvarchar(100))  
--as  
--update PB_ContractMilepost set ProductionPlan=  
--(  
-- select convert(nvarchar(100),row_number() over(order by sequ)) + '¡¢'+SchdulMemo+'£»'  from PB_ContractMilepost_dtl3 where masterId=@id order by sequ for xml path('')
--) where Id=@id

select * from PB_ContractMilepost_dtl1_dtl