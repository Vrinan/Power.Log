
select * from PLN_project where project_type=0
select * from PB_Human where name='³ÂÁè'
select * from PB_User where name='³ÂÁè'

select MasterId, * from KFQ_QX_ClassifyTreeLimit where Human_Id ='CA09F9EE-8C76-92F2-B973-B909E6504B0C'


select count(distinct sum.project_guid) as count from 
(
	select * from dbo.returnEPSWithHumanRelation('430F7079-9E2B-4583-BBD1-32F150B143BB')
	union all
	select * from dbo.returnEPSWithHumanRelation('13D34FE9-2C71-4951-96AC-535F139A7D9A')
	union all
	select * from dbo.returnEPSWithHumanRelation('2839A687-C85A-4E71-BF80-9969EDE34774')
) sum
select MasterId, * from KFQ_QX_ClassifyTreeLimit where Human_Id =&#39;ca09f9ee-8c76-92f2-b973-b909e6504b0c&#39;



select sum(payingfee) as re from KFQ_PAY_PLAN_BILL where DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)


select * from KFQ_PAY_PLAN_BILL
select ApplyMny,* from KFQ_NoContractApply



select apply_money,payingfee,RegDate,DATEPART(yyyy,RegDate),DATEPART(MM,RegDate) from KFQ_PAY_CONTPAY_RECORD
where DATEPART(yyyy,RegDate)='2018' and DATEPART(MM,RegDate)='11'

select sum(apply_money) as applyMoney,sum(payingfee) as payMoney from KFQ_PAY_CONTPAY_RECORD
where DATEPART(yyyy,RegDate)='2018' and DATEPART(MM,RegDate)='11' and Status=50

select b.UserName,b.UserID from pwf_infos a right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID left join PB_HumanSign s on b.UserID = s.HumanId left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi left join PB_Department dept on posi.DeptId=dept.Id) d on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId where KeyValue='018a877f-f619-4889-ab69-8be38a6fb9b8' and b.SendDate is null order by b.SequeID Desc


select Mobile, * from PB_Human

update PB_Human set Mobile =  null
delete from PB_Messages where IsTextmessage=1

select * from PB_Messages order by FromDate desc 