--进度支付申请
CREATE view View_PayPlanBill
as
select 'A' as type,Id,ParentId,Code,Name,
0 as ContractPrice,'' as scheduleEndDate,'' as period,'' as RegDate,'' as RegHumName from KFQ_QX_ClassifyTree  
where Id not in (select * from [dbo].[GetChildren]('750E30B8-CB59-4A15-AB90-085F11F56D01  '))
union
select 'B' as type,Id,ClassifyTree_Id as ParentId,scheduleBillCode as Code,scheduleBillName as Name,
thisTimeSum as ContractPrice,scheduleEndDate,period,RegDate,RegHumName from KFQ_PAY_PLAN_BILL where Status=50


--合同记录（没备注，有丙方）
--alter view View_PactRecord
--as
select 'A' as type,Id,ParentId,Code,Name,
0 as ContractPrice,'' as PartyA,'' as PartyB,'' as ExecutorName,'' as RegDate,'' as RegHumName from KFQ_QX_ClassifyTree  
where Id not in (select * from [dbo].[GetChildren]('750E30B8-CB59-4A15-AB90-085F11F56D01  '))
union
select 'B' as type,Id,right_type_Id as ParentId,stockContId as Code,stockContName as Name,
ContractPrice,stakeHolder as PartyA,Associator as PartyB,Associator2 as ExecutorName,RegDate,RegHumName from KFQ_PACT_record where Status=50

select PACT_record_Id,apply_money,payingfee,sum_apply_money,sum_payingfee from KFQ_PAY_CONTPAY_RECORD


--合同支付
--alter view View_PayContpayRecord
--as
select 'A' as type,Id,ParentId,Code,Name,'' as perpent1,'' as perpent2,
0 as Prices,0 as sumapply,0 as sumpaying,
0 as ContractPrice,'' as fukuanrenName,'' as RegDate,'' as RegHumName from KFQ_QX_ClassifyTree  
where Id not in (select * from [dbo].[GetChildren]('750E30B8-CB59-4A15-AB90-085F11F56D01'))
union
select 'B' as type,a.Id,ClassifyTree_Id as ParentId,code as Code,name as Name,
case when  b.ContractPrice = 0 or b.ContractPrice is null then 0 else isnull(sum_apply_money,0)/b.ContractPrice end as perpent1,
case when  b.ContractPrice = 0 or b.ContractPrice is null then 0 else isnull(sum_payingfee,0)/b.ContractPrice end as perpent2,
b.ContractPrice,a.sum_apply_money,a.sum_payingfee,
apply_money as ContractPrice,fukuanrenName,a.RegDate,a.RegHumName from KFQ_PAY_CONTPAY_RECORD a left join KFQ_PACT_record b on a.PACT_record_Id = b.Id  where a.Status=50





--select * from KFQ_PAY_CONTPAY_RECORD where status=50
--select * from KFQ_PAY_PLAN_BILL where Status=50
--select * from KFQ_QX_ClassifyTree Id where Id not in (select * from [dbo].[GetChildren]('750E30B8-CB59-4A15-AB90-085F11F56D01  '))
--select right_type_Id from KFQ_PACT_record where right_type_Id not in(select id from KFQ_QX_ClassifyTree)
--select * from KFQ_PACT_record where right_type_Id='35A9B96B-A403-4985-B111-D426B88289B6'
--select * from KFQ_PACT_record where Status=50