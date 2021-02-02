select status,* from KFQ_ContractSc order by regdate
--a1
select count(*)as re from KFQ_ContractSc where status=50
--a2
select convert(varchar,convert(money,sum(ContractAmount)),1) as re from KFQ_ContractSc where status=50
--a3
select count(*)as re from KFQ_ContractSc where status=50 and DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--a4
select convert(varchar,convert(money,sum(ContractAmount)),1) as re from KFQ_ContractSc where status=50 and DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--a5
select count(*)as re from KFQ_ContractSc where status=50 and DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--a6
select convert(varchar,convert(money,sum(ContractAmount)),1) as re from KFQ_ContractSc where status=50 and DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)



select * from KFQ_PAY_PLAN_BILL
--b1
select convert(varchar,convert(money,sum(payingfee)),1) as re from KFQ_PAY_PLAN_BILL where DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--b2
select convert(varchar,convert(money,sum(payingfee)),1) as re from KFQ_PAY_PLAN_BILL where DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--b3
select convert(varchar,convert(money,sum(payingfee)),1) as re from KFQ_PAY_PLAN_BILL where DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)


select * from KFQ_PAY_CONTPAY_RECORD
--c1
select convert(varchar,convert(money,sum(apply_money)),1) as re from KFQ_PAY_CONTPAY_RECORD where DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--c2
select convert(varchar,convert(money,isnull(sum(apply_money),0)),1) as re from KFQ_PAY_CONTPAY_RECORD where DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--c3
select convert(varchar,convert(money,isnull(sum(apply_money),0)),1) as re from KFQ_PAY_CONTPAY_RECORD where DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)


select * from KFQ_PAY_CHANGE_BILL
--d1
select convert(varchar,convert(money,sum(changeSum)),1) as re from KFQ_PAY_CHANGE_BILL where DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--d2
select convert(varchar,convert(money,isnull(sum(changeSum),0)),1) as re from KFQ_PAY_CHANGE_BILL where DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)
--d3
select convert(varchar,convert(money,isnull(sum(changeSum),0)),1) as re from KFQ_PAY_CHANGE_BILL where DATEPART(mm, GETDATE()) = DATEPART(mm,RegDate) and DATEPART(yyyy, GETDATE()) = DATEPART(yyyy,RegDate)


select * from KFQ_PAY_CHANGE_BILL where DATEPART(qq, GETDATE()) = DATEPART(qq,RegDate) 