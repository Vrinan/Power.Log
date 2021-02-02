--已批准的
select * from DATAGRID_record
select * from Pay_CONTPAY_RECORD_CONTENT
select * from payment_NoPact
select * from PLN_project
select * from PLN_project where project_name like '九港路%'
 
select * from PAY_PLAN_BILL 
select * from PAY_CONTPAY_RECORD 

--part1
select uniqueId as sid,scheduleBillName + '['+scheduleBillCode+']'as title,scheduleEndDate as add_date,bookFinishOrNot as check_Fk ,'0' as myTypes 
from PAY_PLAN_BILL where scheduleStatus='已批准' and payOrNot='0'

--！=编制完成
select * from PAY_CONTPAY_RECORD 
select b.uniqueId as [sid],'['+b.code+']'+b.name as title,add_date,check_Fk,  '0' as myTypes from PAY_CONTPAY_RECORD b where bookFinishedOrNot <> 1

--a+b
select a.uniqueId as Id,'['+a.scheduleBillCode+']'+scheduleBillName as Name,
bookDate as Data,payContUniqueId as Payid,period,payOrNot,3 as check_Fk 
from  PAY_PLAN_BILL a 
union
select b.uniqueId as [sid],'['+b.code+']'+b.name as title,
add_date,PACT_record_UniqueId as Payid,0 as period ,3 as payOrNot,check_Fk 
from PAY_CONTPAY_RECORD b where state <> '新增' and state <> '编制完成' order by Payid,period 

select PACT_record_UniqueId as Pay2id from PAY_CONTPAY_RECORD b order by Pay2id

select top 3 * from PAY_PLAN_BILL 


