--select * from PB_Widget where Id='85c77b57-c2af-42f4-9142-fbd46144359d'
--select * from PB_Position where Id in(
--select ParentId from PB_Menu where Name='合同登记')
--select * from PB_Menu
--select * from PB_MenuWidget
--select * from PB_DocFolderPost

--合同登记
select * from PB_Widget where Id='689f81fa-3adb-4f1f-ac32-20f99cd76266'
--出项合同-采购合同
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContract_P.htm
--PS_ArrivalCheck
select Contract_Guid,* from PS_PUR_ArrivalCheck
--"Contract_Guid": "Id"


alter view View_ArrivalMatInStore
as
select a.Id,a.Code,a.Title,a.InStoreType,b.Contract_Guid,b.ContractName,b.Id as ArrivalId,b.Code as ArrivalCode,b.Title as ArrivalTitle from PS_PUR_MatInStore a left join PS_PUR_ArrivalCheck b on a.Arrival_Guid =b.Id
where Contract_Guid is not null

select * from View_ArrivalMatInStore
145655



select * from PB_Widget where id='bf592f1b-5821-4dfb-82e5-fcc09ea9e300'


Select Top 50 * From (select 
va.Id,va.Mat_Guid,va.ArrivalMat_Guid,va.Storage_Guid,
va.StoreNum,(va.ValidNum-isnull(reqDtl.ReqNum,0)) ValidNum, va.UnitPrice,va.UnitPriceNoTax,va.BatchCode,va.BalanceType,va.EpsProjId,va.MatBS_Guid,va.IsTransfer,va.IsOther,
inlist.MatCode,inlist.MatName MatShortName,inlist.MatSpec MatLongName,inlist.MatUnit,
vc.StorageCode, vc.StorageName,vc.Id as StorageId,vc.LongCode ,planlist.Code as PlanCode
from
PS_PUR_MatStoreBalance va
left join PS_MDM_Mat vb on va.MatBs_Guid=vb.Id
left join PS_MDM_Storage vc on va.Storage_Guid=vc.Id
left join SF_CG_PurchasePlanList planlist on va.Mat_Guid=planlist.Id
left join PS_PUR_MatInStore_Dtl inlist on inlist.ArrivalMat_Guid=va.ArrivalMat_Guid
left join (select ArrivalMat_Guid,Sum(ActualNum) ReqNum from PS_PUR_MatRequisitions_Dtl  sb left join PS_PUR_MatRequisitions sbb on sb.MasterId=sbb.Id where sbb.Status in(0,20)  group by ArrivalMat_Guid) reqDtl on reqDtl.ArrivalMat_Guid=va.ArrivalMat_Guid
)x Where   IsTransfer='0' and ValidNum>0 and StoreNum>0 and exists(select x1.Id from PS_MDM_Storage x1 where StorageId=x1.Id and (LongCode='1.3.9' or LongCode like '1.3.9.%')) and (MatShortName like '%热风机%') Order By  X.Mat_Guid



select * from PS_PUR_MatOutStore_Dtl where MasterId='b5949647-7a68-4bf8-a45e-ef0c335a3a89' and MatName='中齿平锉'

update PS_PUR_MatOutStore_Dtl set RequisitionNum=1 where MasterId='b5949647-7a68-4bf8-a45e-ef0c335a3a89' and MatName='中齿平锉'

select * from PS_PUR_MatStoreBalance where Mat_Guid='5C807EAC-1726-4047-AE7A-DB5D4D6594C6'

update PS_PUR_MatStoreBalance set ValidNum=1 where Mat_Guid='5C807EAC-1726-4047-AE7A-DB5D4D6594C6'



select * from PS_PUR_MatRequisitions_Dtl where MasterId='68a8d017-431c-4800-aeb5-d2befe63c083' and MatName='中齿平锉'

update PS_PUR_MatRequisitions_Dtl set ActualNum=1  where MasterId='68a8d017-431c-4800-aeb5-d2befe63c083' and MatName='中齿平锉'
update PS_PUR_MatRequisitions_Dtl set RequestNum=1  where MasterId='68a8d017-431c-4800-aeb5-d2befe63c083' and MatName='中齿平锉'