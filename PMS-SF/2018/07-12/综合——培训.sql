select RegDate,b.Id,StartDate,EndDate,TrainDeptName,TrainNumber,PosiType,TrainType,TrainMode,PartyB,Teacher,Address,Money,b.Remark,b.Type
from SF_ZH_TrainPlan a left join SF_ZH_TrainPlan_list b on a.Id=b.MasterId

select * from SF_ZH_TrainPlan
select * from SF_ZH_NewTrainPlan
select * from SF_ZH_NewTrainPlan_list


alter table SF_ZH_TrainPlan add TrainHumans NVARCHAR(1000) null

select * from PB_Widget where id='4030cb0f-b5eb-4a21-9e4f-db1c71723ddd'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_SF_ZH_TrainPlan.htm

select * from PB_Widget where id='d0a45f36-03ab-4467-bc1a-6f919ca5f351'
--/PowerPlat/FormXml/zh-CN/SF_ZH/Win_View_SF_ZH_TrainPlan.htm

create view View_SF_TrainPlanAl
as
select * from SF_ZH_TrainPlan