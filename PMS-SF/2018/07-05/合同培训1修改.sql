--进项合同
--评审PS_ContractReview
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ContractReview.htm
select * from pb_widget where id='1b4e2bb8-31b2-4bc7-a3ce-1458801b4692'

--合同登记 窗体V_PS_ContractInfo
--/PowerPlat/FormXml/zh-CN/StdContract/Win_View_IncomeContract.htm
select * from PB_Widget where id='f97c722a-a50f-4828-bc9a-9cacd434ac58'
--合同登记 表单PS_IncomeContract
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'

--合同请款 窗体V_PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/Win_ContractApplyMoney.htm
select * from PB_Widget where id='67630c46-7551-43a9-97c2-2fba56e69d92'
--合同请款 表单PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm
select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'

--合同登记收款节点
select * from  PS_MK_ContractInfo_PayNodes
--合同请款的收款节点
select * from  PS_CM_ContractApplyMoney_Nodes



alter table PS_CM_ContractApplyMoney_Nodes add NodeAmount float null
--create view V_SF_HT_ContractInfo_PayNodes
--AS
--SELECT Id,MasterId,Sequ,PayNodes,CheckAmount,(SELECT Name FROM dbo.PB_BaseDataList b WHERE BaseDataId='30688728-C323-44EE-876B-C4E94F264CB6' AND Code=a.PayType) PayType,PayAmount 
--FROM PS_MK_ContractInfo_PayNodes a










--delete from PS_MK_ContractReview--进项合同评审
--delete from PS_MK_ContractInfo--进项合同登记
--delete from SF_Contract_AmountList--金额明细
--delete from PS_MK_ContractInfo_PayNodes--收款节点
--delete from PS_CM_ContractApplyMoney--合同请款
--delete from PS_CM_ContractApplyMoney_Other--其他扣款
--delete from PS_CM_ContractApplyMoney_Nodes--收款完成节点
--delete from PS_CM_InvoiceRecord--合同开票
--delete from PS_CM_InvoiceRecord_Dtl--开票明细
--delete from PS_CM_ContractReceipt--合同到款
--delete from PS_CM_ContractDefaultNotices--合同索赔
--delete from PS_CM_ContractClaimApp--索赔意向
--delete from PS_CM_ContractClaimApp_files
--delete from PS_CM_ContractClaimApp_branch
--delete from PS_CM_ContractClaim--索赔结果
--delete from PS_CM_ContractClaim_Dtl
--delete from PS_CM_ContractSettlement--合同结算
--delete from PS_CM_ContractCharged--合同扣款
