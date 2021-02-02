--合同
select * from PB_Widget where id='1dd49a11-68a1-43c5-ad63-8aba0050339d'

select * from PS_CM_ContractApplyMoney_Nodes

select * from PS_MK_ContractInfo_PayNodes

alter table PS_MK_ContractInfo_PayNodes add CheckAmount float null


select * from V_PS_MK_ContractInfo_PayNodes 

--sp_helptext V_PS_MK_ContractInfo_PayNodes 
--alter VIEW [dbo].[V_PS_MK_ContractInfo_PayNodes]
--AS
--SELECT Id,MasterId,Sequ,PayNodes,isnull(CheckAmount,0) as CheckAmount,(SELECT Name FROM dbo.PB_BaseDataList b WHERE BaseDataId='30688728-C323-44EE-876B-C4E94F264CB6' AND Code=a.PayType) PayType,PayAmount FROM PS_MK_ContractInfo_PayNodes a

--create view V_PS_Contract_PayNodesCheck
--as
--SELECT Id,MasterId,Sequ,PayNodes,isnull(CheckAmount,0) as CheckAmount,(SELECT Name FROM dbo.PB_BaseDataList b WHERE BaseDataId='30688728-C323-44EE-876B-C4E94F264CB6' AND Code=a.PayType) PayType,PayAmount FROM PS_MK_ContractInfo_PayNodes a


select * from pb_widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--合同登记PS_IncomeContract
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'
--合同请款PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm

select * from PB_Widget where id='15fa9b9d-634e-439b-93a4-18c9d375de75'
--开票记录PS_InvoiceRecord
--/PowerPlat/FormXml/zh-CN/StdContract/InvoiceRecord.htm

select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'
--合同到款PS_ContractReceipt
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm

select * from PB_Widget where id='86613942-549b-4a0d-bd0e-05f4a499ba90'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_Organize.htm

