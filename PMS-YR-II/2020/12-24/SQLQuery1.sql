select * from PB_Wizard where wizardid='0b51f034-766d-43ef-b4ba-7af9bfc68236'
--/PowerPlat/FormXml/zh-CN/XLX_PUR/Wizard_View_SubContract_MatStoreBalance.html


Select Count(*) From (
select a.*,b.ValidNum,b.StoreNum,b.Storage_Guid,B.BalanceType,c.StorageName as StorageNameNew,d.SubContractCode,d.SubContractName 
from  ps_cm_subcontract d left join ps_cm_subcontract_matitem a on d.id=a.masterid left join PS_PUR_MatStoreBalance b on a.Mat_Guid=b.Mat_Guid
inner join PS_MDM_Storage c on b.Storage_Guid=c.Id  where b.StoreNum>0
) vpn Where  ( 1=1 and MasterId='b6172123-d143-4433-9a7b-00365c64b88f'   and ValidNum>0 and BalanceType=0)

Select A.Id,A.SubContractCode,A.SubContractName from  PS_CM_SubContract A 
left  join PS_MK_ContractInfo B on A.Contract_Guid = B.Id 
Where  (A.Status=50 or A.Status=35) and  A.EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d' 
and A.Id='b6172123-d143-4433-9a7b-00365c64b88f'


Select A.Id from  PS_CM_SubContract A 
left  join PS_MK_ContractInfo B on A.Contract_Guid = B.Id 
Where  (A.Status=50 or A.Status=35)
