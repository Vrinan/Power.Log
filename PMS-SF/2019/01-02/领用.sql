select * from PS_PUR_MatStoreBalance

Select Count(*) From (
select store.*,planlist.MatName,planlist.MatUnit,planlist.Specification,planlist.Model,planlist.Code PlanCode,plans.Id as Plan_Guid,storage.StorageName
from
PS_PUR_MatStoreBalance store
left join SF_CG_PurchasePlanList planlist on store.Mat_Guid=planlist.Id
left join SF_CG_PurchasePlan plans on planlist.MasterId=plans.Id
left join PS_MDM_Storage storage on store.Storage_Guid=storage.Id
where ValidNum>0 and StoreNum>0 ) s Where   1=1 and s.Id='882cdca1-37da-480b-b7af-0731fb1fb719'

select store.*,planlist.MatName,planlist.MatUnit,planlist.Specification,planlist.Model,planlist.Code PlanCode,plans.Id as Plan_Guid,storage.StorageName
from
PS_PUR_MatStoreBalance store
left join SF_CG_PurchasePlanList planlist on store.Mat_Guid=planlist.Id
left join SF_CG_PurchasePlan plans on planlist.MasterId=plans.Id
left join PS_MDM_Storage storage on store.Storage_Guid=storage.Id
where ValidNum>0 and StoreNum>0 and StorageName='东营飞灰处理站' and StoreNum='30'