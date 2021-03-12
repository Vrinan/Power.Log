select Id,MatGuid,BalanceType,EpsProjId,EpsName,StorageName,daleiCode,dalei,zhonglei,xiaolei,MatCode,MatShortName,MatLongName,
Specifi,Standard,Texture,Pattern,pinming,MatUnit,StoreNum,ValidNum,UnitPrice,TotalAmount,
(select count(*) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as InStoreNum,
(select sum(b.InStoreNum) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatInStoreNum,
(select sum(b.InStoreAmount) from PS_PUR_MatInStore a left join PS_PUR_MatInStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatInStoreAmount,
(select count(*) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as OutStoreNum,
(select ISNULL(sum(b.OutStoreNum),0) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatOutStoreNum,
(select ISNULL(sum(b.OutStoreAmount),0) from PS_PUR_MatOutStore a left join PS_PUR_MatOutStore_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatOutStoreAmount,
(select count(*) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as ReturnNum,
(select ISNULL(sum(b.ReturnNum),0) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatReturnNum,
(select ISNULL(sum(b.ReturnAmount),0) from PS_PUR_MatReturn a left join PS_PUR_MatReturn_Dtl b on a.Id = b.MasterId where Mat_Guid=al.MatGuid) as MatReturnAmount
into YR_StoreBalanceItems
from V_PS_PUR_ContractItemStoreBalance al where BalanceType=0 and (StoreNum<>0 or ValidNum<>0)


create table YR_StoreBalanceItems
(
	Id uniqueidentifier null
)
update YR_StoreBalanceItems set ReturnJson = '[]' where MatGuid = '3ed26b79-3a51-4916-81c1-00c88f015795'
select bb.Id,bb.Code,bb.ApprDate,aa.InStoreNum as Num,aa.InStoreAmount as Amount from PS_PUR_MatInStore_Dtl aa left join PS_PUR_MatInStore bb on aa.MasterId = bb.Id where aa.Mat_Guid ='ef6cfdef-5231-4b05-83cf-00cd31bee46d'
select * from YR_StoreBalanceItems

select id from YR_StoreBalanceItems group by id having count(id)>1
select MatGuid from YR_StoreBalanceItems group by MatGuid having count(MatGuid)>1
--drop table YR_StoreBalanceItems

--
select count(*) from V_PS_PUR_ContractItemStoreBalance

--alter view V_PS_PUR_ContractItemStoreBalance
--as
SELECT a.Id,b.id as MatGuid,a.BalanceType,
	   (select ss.project_name from PLN_project ss where ss.project_guid = a.epsprojid) as EpsName,
	   a.epsprojid,a.storage_guid,a.mat_guid,a.batchcode,a.validnum,a.storeNum,a.unitprice,a.totalamount,a.Upddate,
	   b.MatCode,b.MatLongName,b.MatShortName,b.MatUnit,b.Specifi,b.Standard,b.Texture,b.Pattern,    
       c.LongCode,c.MatBSName pinming,d.MatBSName xiaolei,e.MatBSName zhonglei,f.MatBSName dalei,f.MatBSCode daleiCode,g.StorageName  
FROM dbo.PS_PUR_MatStoreBalance a  --库存
INNER JOIN XLX_MDM_MAT_Middle b on a.Mat_Guid = b.id --中间物资表
LEFT JOIN dbo.PS_MDM_MatBS c ON b.MatBS_Guid= c.Id    --物资分类
LEFT JOIN PS_MDM_MatBS d ON LEFT(c.LongCode,10) = d.LongCode    
LEFT JOIN PS_MDM_MatBS e ON LEFT(c.LongCode,7) = e.LongCode    
LEFT JOIN PS_MDM_MatBS f ON LEFT(c.LongCode,4) = f.LongCode   
LEFT JOIN PS_MDM_Storage g ON g.Id=a.Storage_Guid
union
SELECT a.id,b.id as MatGuid,a.balancetype,
	   (select ss.project_name from PLN_project ss where ss.project_guid = a.epsprojid) as EpsName,
	   a.epsprojid,a.storage_guid,a.mat_guid,a.batchcode,a.validnum,a.storeNum,a.unitprice,a.totalamount,a.Upddate,
       b.MatCode,b.MatLongName,b.MatShortName,b.MatUnit,b.Specifi,b.Standard,b.Texture,b.Pattern,    
       c.LongCode,c.MatBSName pinming,d.MatBSName xiaolei,e.MatBSName zhonglei,f.MatBSName dalei,f.MatBSCode daleiCode,g.StorageName  
FROM dbo.PS_PUR_MatStoreBalance a  --库存
INNER JOIN ps_mdm_mat b on a.Mat_Guid = b.id --原始物资表
LEFT JOIN dbo.PS_MDM_MatBS c ON b.MatBS_Guid= c.Id    --物资分类
LEFT JOIN PS_MDM_MatBS d ON LEFT(c.LongCode,10) = d.LongCode    
LEFT JOIN PS_MDM_MatBS e ON LEFT(c.LongCode,7) = e.LongCode    
LEFT JOIN PS_MDM_MatBS f ON LEFT(c.LongCode,4) = f.LongCode   
LEFT JOIN PS_MDM_Storage g ON g.Id=a.Storage_Guid where (validnum>0 or storeNum >0 or unitprice>0 or totalamount>0)



select * from YR_StoreBalanceItems