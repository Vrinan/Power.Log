select * from PB_Widget where id='e15183cd-0b33-48fc-92ab-0020612aecbd'
--未找到合同的：合同重复的：YRKJ-CGHT-,(补录)YRKJGC-170122,,合同无明细的：YRKJEQ-170153-2,

select * from PS_CM_SubContract where SubContractCode='物-X150302430号-1'
select * from PS_CM_SubContract_MatItem where MasterId='391D8A2F-19CC-4A2D-BCEB-6AA3D3869682'


--删除导入数据（2018-03-06后的）

delete from PS_PUR_ArrivalCheck_Dtl where MasterId in(
select id from PS_PUR_ArrivalCheck where ActArrivalDate>='2018-03-06 15:58:47.000')
delete from PS_PUR_ArrivalCheck where ActArrivalDate>='2018-03-06 15:58:47.000'
delete from PS_PUR_MatInStore_Dtl where MasterId in(
select id from PS_PUR_MatInStore where InStoreDate>='2018-03-06 15:58:47.000')
delete from PS_PUR_MatInStore where InStoreDate>='2018-03-06 15:58:47.000'
delete from PS_PUR_MatStoreBalance where UpdDate>='2018-03-06 16:04:00.000'


select * from PS_PUR_ArrivalCheck_Dtl where MasterId in(
select id from PS_PUR_ArrivalCheck where ActArrivalDate>='2018-03-06 15:58:47.000') and mat_guid is not null
select * from PS_PUR_MatStoreBalance where UpdDate>='2018-03-06 16:04:00.000'
CREATE VIEW [dbo].[V_PS_PUR_ContractItemStoreBalance] ---采购合同查询  
as  
SELECT a.*,b.MatCode,b.MatLongName,b.MatShortName,b.MatUnit,b.Specifi,b.Standard,b.Texture,b.Pattern,  
c.LongCode,c.MatBSName pinming,d.MatBSName xiaolei,e.MatBSName zhonglei,f.MatBSName dalei  ,g.StorageName
FROM dbo.PS_PUR_MatStoreBalance a LEFT JOIN (select MatCode,MatModel as MatLongName,matName as MatShortName,MatUnit,Specifi,Standard,Texture,Pattern,Mat_Guid,MatBS_Guid from PS_CM_SubContract_MatItem) b
ON a.Mat_Guid= b.Mat_Guid  
LEFT JOIN dbo.PS_MDM_MatBS c  
ON b.MatBS_Guid= c.Id  
LEFT JOIN PS_MDM_MatBS d  
ON LEFT(c.LongCode,10) = d.LongCode  
LEFT JOIN PS_MDM_MatBS e 
ON LEFT(c.LongCode,7) = e.LongCode  
LEFT JOIN PS_MDM_MatBS f  
ON LEFT(c.LongCode,4) = f.LongCode 
LEFT JOIN PS_MDM_Storage g
ON g.Id=a.Storage_Guid





