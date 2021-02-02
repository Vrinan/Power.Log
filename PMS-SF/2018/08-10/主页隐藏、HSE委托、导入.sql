--主页隐藏

--HSE流程
select * from PB_Human where name like '%林松'

--导入
select 合同编号 from 付款申请$ group by 合同编号 having count(合同编号)>1
select * from 付款申请$
select * from 合同开票$

select 合同编号,合同名称,供应商名称,申请金额,设备费 from 付款申请$
select * from PS_CM_SubContractApplyMny


select 合同编号,合同名称,供应商名称,申请金额,实际付款金额,设备费 from 付款申请$
select * from PS_CM_SubContractPayment


select 合同编号,合同名称,供应商名称,发票金额,设备费 from 合同开票$
select * from PS_CM_SubContractInvoice
select * from PS_CM_SubContractInvoice_Dtl
