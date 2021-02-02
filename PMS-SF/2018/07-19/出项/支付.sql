--合同请款PS_ContractApplyMoney
select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm

alter table PS_CM_ContractApplyMoney add RealApplyAmout float null

select * from PB_Widget where id='abd9f2b5-0330-4c53-91b8-ffc7be72da17'
--/PowerPlat/FormXml/zh-CN/StdMarket/PS_ProjectHandover.htm

select * from PB_Widget where id='f841338e-293c-4819-b11a-e399f5d58dca'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_Leave.htm

select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm

alter table PS_CM_ContractReceipt add ContractApplyCode nvarchar(100) null
alter table PS_CM_ContractReceipt add ContractApplyName nvarchar(100) null
alter table PS_CM_ContractReceipt add ContractApplyId uniqueidentifier null
alter table PS_CM_ContractReceipt add ContractApplyAmount float null

--出项合同
--设计合同-支付申请PS_SubContractApplyMoney
select * from PB_Widget where id='36139912-2361-428e-af0c-38f2fcff2492'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_E.htm

--合同支付
--设计合同-付款记录PS_SubContractPayment
select * from PB_Widget where id='0bc7d119-6a0d-418e-8bb4-273642584ba8'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractPayment_E.htm

alter table PS_CM_SubContractApplyMny add ReduceAmount float null
alter table PS_CM_SubContractApplyMny add FinalApplyAmount float null


alter table PS_CM_SubContractPayment add SubContractApplyCode nvarchar(100) null
alter table PS_CM_SubContractPayment add SubContractApplyName nvarchar(100) null
alter table PS_CM_SubContractPayment add SubContractApplyId uniqueidentifier null
alter table PS_CM_SubContractPayment add SubContractApplyAmount float null


sp_helptext V_PS_SubContractPaymen


--发票登记
--年度合同-收票记录
select * from PB_Widget where id='df6779a2-262f-47e4-86ff-f5239bc0c628'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractInvoice_Y.htm

--合同结算
--出项合同-合同结算
select * from PB_Widget where id='ff686798-78b4-4f9a-907d-914d5c4534ee'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractSettlement_S.htm


select * from PB_Widget where id='452df213-db90-4031-b9d8-0a37365eaa10'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_EquFlyingDust.htm


select * from PB_Widget where id='85507504-1b82-4866-9192-6ed055b65ebb'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_RunFlyingDust.htm
