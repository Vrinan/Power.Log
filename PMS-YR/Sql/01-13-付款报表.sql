select * from PB_Widget where id='b1dbbe05-1300-4f20-9057-7b318f5af220'
--dt1,付款申请主表
select ApplyNo,CPL_BankName,CPL_Bankcode,ApplyAmount,* from PS_CM_SubContractApplyMny
--dt2,项目
select project_shortname,* from PLN_project where project_guid=(select OwnProjId from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE')
--dt3,合同
select FinalSubContractAmount,SignDate,SubContractName,* from PS_CM_SubContract where id=(select subcontract_guid from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE')
--dt4,付款申请主表的支付方式
select (case CPL_CloseName when '014' then '银行承兑汇款' when '004' then '汇款'
when '005' then '信用证'  when '009' then '现金' else '其他' end) AS CPL_CloseName from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE'
--dt5,金额大写
declare @a money
set @a = 123
select @a = ApplyAmount from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE'
select @a
select dbo.fn_getformatmoney(@a) as money


