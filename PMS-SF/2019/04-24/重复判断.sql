select ContractCode, * from PS_MK_ContractReview

select ContractCode,* from PS_MK_ContractInfo

select  SubContractCode, * from PS_CM_SubContract


select * from PB_Widget where Id='696ec71e-d26a-46d4-9ed2-6d6de2c4f9ff'
--/PowerPlat/FormXml/zh-CN/StdMarket/ContractReview.htm

select * from PB_Widget where Id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

select * from PB_Widget where Id='5c0640b9-fb52-4b58-bc90-b7af15a884c2'
--/PowerPlat/FormXml/zh-CN/SF_CM/PS_CM_ContractReview.htm


select
a.OwnerDept as DeptName ,b.TroubleType,b.TroubleContent,b.TroubleChange, convert(nvarchar,b.ChangeTime,23) as ChangeTime,b.ScheduleContent,
convert(nvarchar,b.ChangeDate,23) as ChangeDate,b.NextRequest,b.Memo as Memo1 ,
Convert(varchar(50),a.StartTime,23) as StartTime,
Convert(varchar(50),a.EndTime,23) as EndTime,
Convert(varchar(50),a.RegDate,23) as RegDate
from
SF_HSE_WeekReport a inner join SF_HSE_WeekReport_dtl b on a.id = b.MasterId 