--报表
select * from PB_Widget where id='fd2c0b6a-bb3b-45ee-8183-353886171deb'
--/PowerPlat/FormXml/zh-CN/KFQ_HT/Win_View_ContractSc.htm
--select *from  where (Name like'%临港%' and type='B') or type='A'

select * from PB_Widget where id='3fffb408-9619-48d7-923b-0c6f8fea4b78'
--/PowerPlat/FormXml/zh-CN/KFQ_HT/Win_View_PactRecord.htm
select * from View_PactRecord where (Name like'%大件%' and type='B') or type='A'

select * from PB_Widget where id='98595b7b-3e57-49c6-b276-f926b1d0493c'
--/PowerPlat/FormXml/zh-CN/KFQ_HT/Win_View_PayPlanBill.htm
select * from View_PayPlanBill where (Name like'%大件%' and type='B') or type='A'

select * from PB_Widget where id='6b1000c5-bff8-4753-ad19-51002f1ec935'
--/PowerPlat/FormXml/zh-CN/KFQ_HT/Win_View_PayContpayRecord.htm
select * from View_PayContpayRecord where (Name like'%大件%' and type='B') or type='A'

alter view View_PayContpayRecord
as
select 'A' as type,Id,ParentId,Code,Name,'' as perpent1,'' as perpent2,
0 as Prices,0 as sumapply,0 as sumpaying,
0 as ContractPrice,'' as fukuanrenName,'' as RegDate,'' as RegHumName from KFQ_QX_ClassifyTree  
where Id not in (select * from [dbo].[GetChildren]('750E30B8-CB59-4A15-AB90-085F11F56D01'))
union
select 'B' as type,a.Id,ClassifyTree_Id as ParentId,code as Code,name as Name,
case when  b.ContractPrice = 0 or b.ContractPrice is null then 0 else isnull(sum_apply_money,0)/b.ContractPrice end as perpent1,
case when  b.ContractPrice = 0 or b.ContractPrice is null then 0 else isnull(sum_payingfee,0)/b.ContractPrice end as perpent2,
b.ContractPrice as Prices,a.sum_apply_money as sumapply,a.sum_payingfee as sumpaying,
apply_money as ContractPrice,fukuanrenName,a.RegDate,a.RegHumName from KFQ_PAY_CONTPAY_RECORD a left join KFQ_PACT_record b on a.PACT_record_Id = b.Id  where a.Status=50



select sum_apply_money,b.ContractPrice,* from KFQ_PAY_CONTPAY_RECORD a left join KFQ_PACT_record b on a.PACT_record_Id = b.Id
--select ContractPrice from KFQ_PACT_record where PACT_record_Id

