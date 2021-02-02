select 
va.Id,va.Mat_Guid,va.ArrivalMat_Guid,va.Storage_Guid,
va.StoreNum,reqDtl.ReqNum,(va.ValidNum-isnull(reqDtl.ReqNum,0)) ValidNum, va.UnitPrice,va.UnitPriceNoTax,va.BatchCode,va.BalanceType,va.EpsProjId,va.MatBS_Guid,va.IsTransfer,va.IsOther,
inlist.MatCode,inlist.MatName MatShortName,inlist.MatSpec MatLongName,inlist.MatUnit,
vc.StorageCode, vc.StorageName,vc.Id as StorageId,vc.LongCode ,planlist.Code as PlanCode
from
PS_PUR_MatStoreBalance va
left join PS_MDM_Mat vb on va.MatBs_Guid=vb.Id
left join PS_MDM_Storage vc on va.Storage_Guid=vc.Id
left join SF_CG_PurchasePlanList planlist on va.Mat_Guid=planlist.Id
left join PS_PUR_MatInStore_Dtl inlist on inlist.ArrivalMat_Guid=va.ArrivalMat_Guid
left join (select ArrivalMat_Guid,Sum(ActualNum) ReqNum from PS_PUR_MatRequisitions_Dtl group by ArrivalMat_Guid) reqDtl on reqDtl.ArrivalMat_Guid=va.ArrivalMat_Guid
where MatShortName like 'Ïû·ÀË®´ü±§¹¿'

select 
va.Id,va.Mat_Guid,va.ArrivalMat_Guid,va.Storage_Guid,
va.StoreNum,reqDtl.ReqNum,(va.ValidNum-isnull(reqDtl.ReqNum,0)) ValidNum, va.UnitPrice,va.UnitPriceNoTax,va.BatchCode,va.BalanceType,va.EpsProjId,va.MatBS_Guid,va.IsTransfer,va.IsOther,
inlist.MatCode,inlist.MatName MatShortName,inlist.MatSpec MatLongName,inlist.MatUnit,
vc.StorageCode, vc.StorageName,vc.Id as StorageId,vc.LongCode ,planlist.Code as PlanCode
from
PS_PUR_MatStoreBalance va
left join PS_MDM_Mat vb on va.MatBs_Guid=vb.Id
left join PS_MDM_Storage vc on va.Storage_Guid=vc.Id
left join SF_CG_PurchasePlanList planlist on va.Mat_Guid=planlist.Id
left join PS_PUR_MatInStore_Dtl inlist on inlist.ArrivalMat_Guid=va.ArrivalMat_Guid
left join (select ArrivalMat_Guid,Sum(ActualNum) ReqNum from PS_PUR_MatRequisitions_Dtl sb left join PS_PUR_MatRequisitions sbb on sb.MasterId=sbb.Id where sbb.Status in(0,20) group by ArrivalMat_Guid) reqDtl on reqDtl.ArrivalMat_Guid=va.ArrivalMat_Guid
where MatShortName like 'Ïû·ÀË®´ü±§¹¿'


select * from PS_PUR_MatRequisitions_Dtl where ArrivalMat_Guid='6E0D8651-5968-4E66-AA17-90846884370D'
select * from PS_PUR_MatRequisitions where id='98252FE3-F287-42D2-A84A-508179823034'

