select * from PB_Widget where Id='7671b950-e5b3-4a2f-ad09-d23b90c09e61'
--/PowerPlat/FormXml/zh-CN/SF_CG/SF_CG_PurchasePlan_gc.htm
--打印

--物资入库（有发票）-备品备件
--物资入库（有发票）-低耗及其他
--物资入库（无发票）-金属材料及制品
--1，2，3，in('3','4')，5
--in('3','4')
select Code,StorageName,CONVERT(varchar(100),InStoreDate, 23) as InStoreDate from PS_PUR_MatInStore where Id='[@KeyValue]'
--2
select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',MatType) as MatType,MatName,MatSpec,
MatUnit,InStoreNum, convert(varchar,convert(money,UnitPrice),1) as UnitPrice,convert(varchar,convert(money,InStoreAmount),1)  as InStoreAmount
from PS_PUR_MatInStore_Dtl 
where MasterId='[@KeyValue]'  and MatType = '1'
--3
select case when dbo.fn_getformatmoney(sum(InStoreAmount)) = '(负)' then null else dbo.fn_getformatmoney(sum(InStoreAmount)) end as TotalAmountF,
convert(varchar,convert(money,sum(InStoreAmount)),1) as TotalAmount from PS_PUR_MatInStore_Dtl 
where MasterId='[@KeyValue]'  and MatType = '1'
--4
select Supplier,ContractName from PS_PUR_ArrivalCheck where Id=(select Arrival_Guid from PS_PUR_MatInStore where Id='[@KeyValue]')





--出库单
--物资入库（有发票）-备品备件
--物资入库（有发票）-低耗及其他
--物资入库（无发票）-金属材料及制品
--设备
--1，2，3，in('3','4')，5
--in('3','4')
--1
select * from PS_PUR_MatRequisitions where Id = '[@KeyValue]'
--2
select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',b.MatType) as MatType,a.MatName,a.MatDescription,
a.MatUnit,a.ActualNum, convert(varchar,convert(money,b.UnitPrice),1) as UnitPrice,convert(varchar,convert(money,a.ActualNum*b.UnitPrice),1)  as InStoreAmount
from PS_PUR_MatRequisitions_Dtl a left join PS_PUR_MatInStore_Dtl b on a.ArrivalMat_Guid = b.ArrivalMat_Guid
where a.MasterId='[@KeyValue]' and MatType='1'
--3
select case when dbo.fn_getformatmoney(sum(b.InStoreAmount)) = '(负)' then null else dbo.fn_getformatmoney(sum(b.InStoreAmount)) end as TotalAmountF,
convert(varchar,convert(money,sum(b.InStoreAmount)),1) as TotalAmount 
from PS_PUR_MatRequisitions_Dtl a left join PS_PUR_MatInStore_Dtl b on a.ArrivalMat_Guid = b.ArrivalMat_Guid
where a.MasterId='[@KeyValue]' and MatType='1'



--盘点
--备品备件
--低耗及其他
--金属材料及制品
--设备
--1，2，3，in('3','4')，5
--in('3','4')

--1
select Year(InventoryDate) y,Month(InventoryDate) m,* from PS_PUR_MatInventory where Id='[@KeyValue]'
--2
select MatType,Sequ,MatName,Spec,Unit, 
       convert(nvarchar,cast(UnitPrice as money),1) UnitPrice, 
	   convert(nvarchar,cast(StoreNum as money),1) StoreNum, 
	   convert(nvarchar,cast(StoreAmount as money),1) StoreAmount, 
       convert(nvarchar,cast(oldStoreNum as money),1) oldStoreNum, 
	   convert(nvarchar,cast(oldStoreAmount as money),1) oldStoreAmount, 
	   convert(nvarchar,cast(outStoreNum as money),1) outStoreNum, 
	   convert(nvarchar,cast(outStoreAmount as money),1) outStoreAmount, 
	   convert(nvarchar,cast(ActualNum as money),1) ActualNum, 
	   convert(nvarchar,cast(ActualAmount as money),1) ActualAmount 
from PS_PUR_MatInventory_Dtl where MasterId='[@KeyValue]' and MatType ='设备'
order by Sequ 
--3
select convert(nvarchar,cast(sum(OldStoreAmount)as money),1) SumOldStoreAmount, 
	   convert(nvarchar,cast(sum(StoreAmount)as money),1) SumStoreAmount, 
       convert(nvarchar,cast(sum(outStoreAmount)as money),1) SumoutStoreAmount, 
	   convert(nvarchar,cast(sum(ActualAmount)as money),1) SumActualAmount 
from PS_PUR_MatInventory_Dtl where MasterId='[@KeyValue]' and  MatType ='设备'

select STUFF((select ','+ al.Purchaser from
(
select  distinct a.PurchaserId1,a.Purchaser ,a.Department   from(
select Purchaser as Purchaser,Department as Department,PurchaserId as PurchaserId1 from SF_ZH_BusinessTravel where Id='0aaf18cf-c075-464d-8d21-07db0c31c27d'
union all
select HumName as Purchaserdddd,DeptName  as DeptNameddddd ,HumId as PurchaserId  from SF_ZH_BusinessTravel_list where MasterId='0aaf18cf-c075-464d-8d21-07db0c31c27d'
)a
) al for xml path(''))
,1,1,'') as Name

select STUFF((select ','+ al.Department from
(
select  distinct a.PurchaserId1,a.Purchaser ,a.Department   from(
select Purchaser as Purchaser,Department as Department,PurchaserId as PurchaserId1 from SF_ZH_BusinessTravel where Id='0aaf18cf-c075-464d-8d21-07db0c31c27d'
union all
select HumName as Purchaserdddd,DeptName  as DeptNameddddd ,HumId as PurchaserId  from SF_ZH_BusinessTravel_list where MasterId='0aaf18cf-c075-464d-8d21-07db0c31c27d'
)a
) al for xml path(''))
,1,1,'') as Name