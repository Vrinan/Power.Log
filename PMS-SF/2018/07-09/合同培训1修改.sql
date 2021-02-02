--进项合同
--评审PS_ContractReview
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ContractReview.htm
select * from pb_widget where id='1b4e2bb8-31b2-4bc7-a3ce-1458801b4692'
--评审 表单PS_ContractReview
--/PowerPlat/FormXml/zh-CN/StdMarket/ContractReview.htm
select * from pb_widget where id='696ec71e-d26a-46d4-9ed2-6d6de2c4f9ff'

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

--开票登记 窗体PS_InvoiceRecord
--/PowerPlat/FormXml/zh-CN/StdContract/Win_InvoiceRecord.htm
select * from PB_Widget where id='0b47c4c7-38a1-4440-b77e-af35841450d2'
--开票登记 表单PS_InvoiceRecord
--/PowerPlat/FormXml/zh-CN/StdContract/InvoiceRecord.htm
select * from PB_Widget where id='15fa9b9d-634e-439b-93a4-18c9d375de75'

--合同到款 窗体V_PS_ContractReceipt
--/PowerPlat/FormXml/zh-CN/StdContract/Win_ContractReceipt.htm
select * from PB_Widget where id='802a81b7-dcd1-4c73-8f5a-482fad51bd35'
--合同到款 表单PS_ContractReceipt
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm
select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'

--合同违约通知 窗体PS_ContractDefaultNotices
--/PowerPlat/FormXml/zh-CN/StdContract/Win_pm_cont_breachnotice.htm
select * from PB_Widget where id='98b2662e-7b85-49d7-9fb4-05a596a9b96d'

--合同索赔意向 窗体PS_ContractClaimApplication
--/PowerPlat/FormXml/zh-CN/StdContract/Win_pm_cont_claimantnotice.htm
select * from PB_Widget where id='46f2aeb5-78a6-4cfe-acd7-aa9d876ced11'

--索赔结果PS_ContractClaim
--/PowerPlat/FormXml/zh-CN/StdContract/Win_pm_cont_breachresult.htm
select * from PB_Widget where id='83e6f27b-de5f-4eb7-8961-67d768909072'

--合同结算 窗体PS_ContractSettlement
--/PowerPlat/FormXml/zh-CN/StdContract/Win_ContractSettlement.htm
select * from PB_Widget where id='05bee0be-5dd3-4c11-9f7c-24990456052b'
--合同结算 表单PS_ContractSettlement
--/PowerPlat/FormXml/zh-CN/StdContract/ContractSettlement.htm
select * from PB_Widget where id='6665fd96-4c31-4f88-a262-d011ab0d8524'

--合同扣款记录 窗体PS_ContractCharged
--/PowerPlat/FormXml/zh-CN/StdContract/Win_PS_ContractCharged.htm
select * from PB_Widget where id='74028714-cada-444e-95d2-50be606a2e1b'


--出项合同
--出项合同评审 窗体PS_ContractReview
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ContractReview.htm
select * from PB_Widget where id='66fdb21f-a1af-4c79-903e-ff47d65d0604'
--出项合同评审 表单PS_ContractReview
--/PowerPlat/FormXml/zh-CN/SF_CM/PS_CM_ContractReview.htm
select * from PB_Widget where id='5c0640b9-fb52-4b58-bc90-b7af15a884c2'

--合同登记 窗体V_PS_SubContract
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContract_E.htm
select * from PB_Widget where id='f1340eae-0d30-4e12-9c64-7b13e97f4ee8'
--出项合同-设计合同 表单PS_SubContract
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContract_E.htm
select * from PB_Widget where id='c56cea22-6dcd-46a7-bceb-57e26ddfb4db'

--设计合同-支付申请 V_PS_SubContractApplyMny
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractApplyMoney_E.htm
select * from PB_Widget where id='f4e5b6e2-310a-4b37-861e-08193c69cfac'
--设计合同-支付申请 PS_SubContractApplyMoney
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_E.htm
select * from PB_Widget where id='36139912-2361-428e-af0c-38f2fcff2492'

--设计合同-收票记录 窗体PS_SubContractInvoice
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractInvoice_E.htm
select * from PB_Widget where id='3ed3afd0-6fab-4f3d-bce1-17010149abaf'
--设计合同-收票记录 表单PS_SubContractInvoice
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractInvoice_E.htm
select * from PB_Widget where id='1d8707f1-f8ed-4264-853a-d3cbd39bb6d8'

--采购合同-付款记录 窗体PS_SubContractPayment
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractPayment_P.htm
select* from PB_Widget where id='ca908e9e-1e6f-4e58-9d2a-bdb771a62a7b'
--采购合同-付款记录 表单PS_SubContractPayment
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractPayment_P.htm
select* from PB_Widget where id='b9bd19f5-2536-42c3-997f-55bbe4082fa7'

--设计合同-合同结算 窗体PS_SubContractSettlement
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractSettlement_E.htm
select * from PB_Widget where id='bb69ea35-1c41-452e-b0b8-72705708c031'
--设计合同-合同结算 表单PS_SubContractSettlement
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractSettlement_E.htm
select * from PB_Widget where id='9f17627b-b9f0-4bb1-9f1f-91ef137de070'

--进项合同分析V_PS_CM_IncomeContract
--/PowerPlat/FormXml/zh-CN/StdContract/Win_IncomeAnalysis.htm
select * from PB_Widget where id='4a1a1d71-02e6-49af-908c-a57fc1b7054f'

--出项合同分析
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractAnalysis.htm
select * from PB_Widget where id='70f719dd-8487-4837-847a-74616de4a532'

select * from V_PS_CM_IncomeContract 
select * from V_SF_CM_IncomeContract

select * from V_PS_CM_SubContract 
select * from V_SF_CM_SubContract 

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

--delete from PS_CM_SubContract
--delete from PS_CM_SubContract_PayNodes
--delete from PS_CM_SubContractApplyMny
--delete from PS_CM_SubContractApplyMny_Mat
--delete from PS_CM_SubContractApplyMny_Node
--delete from PS_CM_SubContractApplyMny_Oth
--delete from PS_CM_SubContractInvoice
--delete from PS_CM_SubContractPayment
--delete from PS_CM_SubContractSettle


--alter table PS_CM_ContractApplyMoney_Nodes add NodeAmount float null
--create view V_SF_HT_ContractInfo_PayNodes
--AS
--SELECT Id,MasterId,Sequ,PayNodes,CheckAmount,(SELECT Name FROM dbo.PB_BaseDataList b WHERE BaseDataId='30688728-C323-44EE-876B-C4E94F264CB6' AND Code=a.PayType) PayType,PayAmount 
--FROM PS_MK_ContractInfo_PayNodes a
--alter table PS_MK_ContractReview add EPSProjectId uniqueidentifier null
--alter table PS_MK_ContractReview add EPSProjectCode nvarchar(200) null
--alter table PS_MK_ContractReview add EPSProjectName nvarchar(200) null
--alter table PS_MK_ContractInfo add EPSProjectId uniqueidentifier null
--alter table PS_MK_ContractInfo add EPSProjectCode nvarchar(200) null
--alter table PS_MK_ContractInfo add EPSProjectName nvarchar(200) null
--alter table PS_CM_SubContract add EPSProjectId uniqueidentifier null
--alter table PS_CM_SubContract add EPSProjectCode nvarchar(200) null
--alter table PS_CM_SubContract add EPSProjectName nvarchar(200) null
--alter table PS_CM_SubContractSettle add FlowAmount float null

--CREATE view V_SF_CM_IncomeContract
--as
--select a.Id,a.ContractCode ,a.EPSProjectName,a.ContractName,a.FinalContractAmount,a.ContractAmount,isNUll(a.ChangeAmount,0)ChangeAmount,
--a.contracttype,a.EpsProjId,a.PartyA,a.SignedDate,g.LongCode,
--isNUll(b.TotalApplyAmount,0)TotalApplyAmount,isNUll(c.TotalInvoiceAmount,0)TotalInvoiceAmount,
--isNUll(d.TotalReceiveAmount,0) TotalReceiveAmount,isNUll(e.TotalClaimAmount,0) TotalClaimAmount,isNUll(f.TotalSettlementAmount,0) TotalSettlementAmount from
--PS_MK_ContractInfo a
--left join
--(select Contract_Guid,SUM(isNUll(ApplyAmount,0)) TotalApplyAmount from PS_CM_ContractApplyMoney group by Contract_Guid) b
--on a.Id = b.Contract_Guid  ----合同累计请款
--left join
--(select Contract_Guid,SUM(isNUll(InvoiceAmount,0)) TotalInvoiceAmount from PS_CM_InvoiceRecord group by Contract_Guid) c
--on a.Id = c.Contract_Guid  ----累计开票
--left join
--(select Contract_Guid,SUM(isNUll(ReceiveAmount,0)) TotalReceiveAmount from PS_CM_ContractReceipt group by Contract_Guid) d
--on a.Id = d.Contract_Guid  ----累计到款
--left join
--(select Contract_Guid,SUM(isNUll(ClaimAmount,0)) TotalClaimAmount from PS_CM_ContractClaim group by Contract_Guid) e
--on a.Id = e.Contract_Guid  ----累计索赔
--left join
--(select Contract_Guid,SUM(isNUll(SettlementAmount,0)) TotalSettlementAmount from PS_CM_ContractSettlement group by Contract_Guid) f
--on a.Id = f.Contract_Guid  ----累计结算
--left join
--(select project_guid,LongCode from pln_project ) g
--on a.EpsProjId =g.project_guid   ----LongCode



--create view V_SF_CM_SubContract
--as
--SELECT     a.Id, a.SubContractCode,a.Status, a.PaymentWay, a.SubContractName,a.EPSProjectName, a.EpsProjId, a.PartyB,a.RegDate, a.SignDate, a.SubContractType,a.DeliveryDate,a.DeliveryPlace, ISNULL(a.SubContractAmount, 0) AS SubContractAmount, ISNULL(a.ChangeAmount, 0)
--                      AS ChangeAmount, ISNULL(a.FinalSubContractAmount, 0) AS FinalSubContractAmount, ISNULL(b.TotalApplyAmount, 0) AS TotalApplyAmount, ISNULL(c.TotalInvoiceAmount, 0) AS TotalInvoiceAmount,
--                      ISNULL(d.TotalPaymentAmount, 0) AS TotalPaymentAmount, ISNULL(e.TotalClaimAmount, 0) AS TotalClaimAmount, ISNULL(f.TotalSettlementAmount, 0) AS TotalSettlementAmount, g.LongCode
--                      ,ISNULL(a.FinalSubContractAmount, 0)-ISNULL(c.TotalInvoiceAmount, 0) as InvoiceAmountDisparity,
--                     ISNULL(a.FinalSubContractAmount, 0)- ISNULL(d.TotalPaymentAmount, 0) AS PaymentAmountDisparity
--FROM         dbo.PS_CM_SubContract AS a LEFT OUTER JOIN
--                          (SELECT     SubContract_Guid, SUM(ISNULL(ApplyAmount, 0)) AS TotalApplyAmount
--                            FROM          dbo.PS_CM_SubContractApplyMny
--                            GROUP BY SubContract_Guid) AS b ON a.Id = b.SubContract_Guid LEFT OUTER JOIN
--                          (SELECT     SubContract_Guid, SUM(ISNULL(InvoiceAmount, 0)) AS TotalInvoiceAmount
--                            FROM          dbo.PS_CM_SubContractInvoice
--                            GROUP BY SubContract_Guid) AS c ON a.Id = c.SubContract_Guid LEFT OUTER JOIN
--                          (SELECT     SubContract_Guid, SUM(ISNULL(PaymentAmount, 0)) AS TotalPaymentAmount
--                            FROM          dbo.PS_CM_SubContractPayment
--                            GROUP BY SubContract_Guid) AS d ON a.Id = d.SubContract_Guid LEFT OUTER JOIN
--                          (SELECT     SubContract_Guid, SUM(ISNULL(ClaimAmount, 0)) AS TotalClaimAmount
--                            FROM          dbo.PS_CM_SubContractClaim
--                            GROUP BY SubContract_Guid) AS e ON a.Id = e.SubContract_Guid LEFT OUTER JOIN
--                          (SELECT     SubContract_Guid, SUM(ISNULL(SettlementAmount, 0)) AS TotalSettlementAmount
--                            FROM          dbo.PS_CM_SubContractSettle
--                            GROUP BY SubContract_Guid) AS f ON a.Id = f.SubContract_Guid LEFT OUTER JOIN
--                          (SELECT     project_guid, LongCode
--                            FROM          dbo.PLN_project) AS g ON a.EpsProjId = g.project_guid

