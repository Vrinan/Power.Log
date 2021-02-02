--新的形式
select * from PB_ContractMilepost where Id='C613D1EB-8AEE-BECD-03E9-EBF7948CBEF5'


create proc Proc_SF_UpdateMilestoneNode(@id nvarchar(100))
as
update PB_ContractMilepost set MilestoneNode=
(
	select code + '：'+Name+'；' from PB_ContractMilepost_dtl1 where masterId=@id order by sequ for xml path('')
) where Id=@id

exec Proc_SF_UpdateMilestoneNode 'C613D1EB-8AEE-BECD-03E9-EBF7948CBEF5'


create proc Proc_SF_UpdateSchedule(@id nvarchar(100))
as
update PB_ContractMilepost set schedule=
(
	select top 1 schdulmemo from PB_ContractMilepost_dtl2 where masterid=@id order by finshdate desc
) where Id=@id
exec Proc_SF_UpdateSchedule 'C613D1EB-8AEE-BECD-03E9-EBF7948CBEF5'