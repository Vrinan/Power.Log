select * from PS_CC_ContractBudget_WBS

select * from PS_CC_ContractBudget


select * from PS_CC_CBS
select * from PS_CC_ContractBudget_CBS 

select * from YR_StoreBalanceItems

select bb.epsprojid, bb.Id,bb.Code,bb.ApprDate,aa.InStoreNum as Num,aa.InStoreAmount as Amount from PS_PUR_MatInStore_Dtl aa 
left join PS_PUR_MatInStore bb on aa.MasterId = bb.Id where bb.epsprojid = '8FBFC64E-3F18-4447-8AFE-DA26920D8202'

delete from YR_StoreBalanceItems

select * from PS_CC_ContractBudget_CBS

--21 rows
select NEWID() as Id,MasterId,Cbs_Guid,CbsClass_Guid,'cbs' as NodeType,
CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice,CbsTitle,CbsValue,Sequ
from PS_CC_ContractBudget_CBS where CbsName like '%容器 S-31702 己内酰胺蒸馏分离器%'



insert into PS_CC_ContractBudget_CBS(Id,MasterId,Cbs_Guid,CbsClass_Guid,NodeType,CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice,CbsTitle,CbsValue,Sequ) 
select NEWID() as Id,MasterId,Cbs_Guid,CbsClass_Guid,'cbs' as NodeType,CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice,CbsTitle,CbsValue,Sequ
from PS_CC_ContractBudget_CBS where MasterId = '9034619a-b016-488e-a9fc-2897b34a91e1'
and cbsname='总承包'

select Id,MasterId,Cbs_Guid,CbsClass_Guid,'cbs' as NodeType,CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice,CbsTitle,CbsValue,Sequ
from PS_CC_ContractBudget_CBS where MasterId = '9034619a-b016-488e-a9fc-2897b34a91e1'
and cbsname='总承包'

delete from PS_CC_ContractBudget_CBS where id='FB3CD4A5-31C2-41B4-B984-4FDF9A388EDC'





select * from PS_CC_ContractBudget where id='9034619a-b016-488e-a9fc-2897b34a91e1'
select * from PS_CC_CBS 


insert into PS_CC_ContractBudget_CBS(Id,MasterId,Cbs_Guid,CbsClass_Guid,LongCode,NodeType,CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice)
select newid() as Id,'9034619a-b016-488e-a9fc-2897b34a91e1' as MasterId,Id,MasterId,LongCode,'cbs' as NodeType,CbsCode,CbsName,EstimatePrice,BudgetPrice,ControlPrice
from PS_CC_CBS where EpsProjId = 'E8379933-2D9B-4744-9053-D668883EDE5E'
and id not in (select Cbs_Guid from PS_CC_ContractBudget_CBS where masterid='9034619a-b016-488e-a9fc-2897b34a91e1')

select * from PS_CC_CBS where EpsProjId = 'E8379933-2D9B-4744-9053-D668883EDE5E'
and id not in (select Cbs_Guid from PS_CC_ContractBudget_CBS where masterid='9034619a-b016-488e-a9fc-2897b34a91e1')


select * from PB_Widget where id='90944435-3671-4ab0-9174-5f8546638615'
--/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractBudget_CBS.htm

select * from PS_CC_ContractBudget where Title='第一版永荣二期项目预算' and VersionCode='6.0'

update PS_CC_ContractBudget set IsLastVersion = 0 where Title='第一版永荣二期项目预算' and VersionCode='2.0'
Select * From PS_CC_ContractBudget a Where a.Id='9034619a-b016-488e-a9fc-2897b34a91e1'

select Id,MatGuid,BalanceType,EpsProjId,EpsName,StorageName,daleiCode,dalei,zhonglei,xiaolei,MatCode,MatShortName,MatLongName,
Specifi,Standard,Texture,Pattern,pinming,MatUnit,StoreNum,ValidNum,UnitPrice,TotalAmount,
(select count(*) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as InStoreNum,
(select sum(b.InStoreNum) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatInStoreNum,
(select sum(b.InStoreAmount) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatInStoreAmount,
(select count(*) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as OutStoreNum,
(select ISNULL(sum(b.OutStoreNum),0) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatOutStoreNum,
(select ISNULL(sum(b.OutStoreAmount),0) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatOutStoreAmount,
(select count(*) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as ReturnNum,
(select ISNULL(sum(b.ReturnNum),0) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatReturnNum,
(select ISNULL(sum(b.ReturnAmount),0) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid and a.EpsProjId = al.EpsProjId) as MatReturnAmount
from V_PS_PUR_ContractItemStoreBalance al where BalanceType=0 and EpsProjId ='E8379933-2D9B-4744-9053-D668883EDE5E'