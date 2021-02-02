--select * from SF_FK_EquipmentCostSchedule_dtl where MasterId='8414f934-03fb-471f-b0a0-67ed4eb92f3c'

--update SF_FK_EquipmentCostSchedule_dtl set CostReport='' where MasterId='8414f934-03fb-471f-b0a0-67ed4eb92f3c'

select * from PB_Widget where id='30d3eeda-6b7e-4aa4-9642-969d3d26894a'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SF_InContractAnalyse.htm

select * from PB_Widget where id='2c2df609-2458-4ee6-bdd8-b909b71a770d'

select * from PLN_project where project_name = '公司项目'

select * from PLN_project where project_guid in(select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))


select a.Id as MainId,a.Code as MainCode,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType,c.*
from SF_FK_EquipmentCostSchedule a left join PB_DefaultField b on a.Id = b.DefaultFieldId left join  SF_FK_EquipmentCostSchedule_dtl c on a.Id=c.MasterId
where b.Status=50 and a.IsNew='1' and EpsId = ''