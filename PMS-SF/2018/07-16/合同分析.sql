--合同分析
select * from PB_Widget where id='4a1a1d71-02e6-49af-908c-a57fc1b7054f'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_IncomeAnalysis.htm

select * from V_SF_CM_IncomeContract
sp_helptext V_SF_CM_IncomeContract


alter view V_SF_CM_IncomeContract
as
select a.Id,a.ContractCode ,a.EPSProjectId,a.EPSProjectName,a.ContractName,a.FinalContractAmount,a.ContractAmount,isNUll(a.ChangeAmount,0)ChangeAmount,
a.contracttype,a.EpsProjId,a.PartyA,a.SignedDate,g.LongCode,
isNUll(b.TotalApplyAmount,0)TotalApplyAmount,isNUll(c.TotalInvoiceAmount,0)TotalInvoiceAmount,
isNUll(d.TotalReceiveAmount,0) TotalReceiveAmount,isNUll(e.TotalClaimAmount,0) TotalClaimAmount,isNUll(f.TotalSettlementAmount,0) TotalSettlementAmount from
PS_MK_ContractInfo a
left join
(select Contract_Guid,SUM(isNUll(ApplyAmount,0)) TotalApplyAmount from PS_CM_ContractApplyMoney group by Contract_Guid) b
on a.Id = b.Contract_Guid  ----合同累计请款
left join
(select Contract_Guid,SUM(isNUll(InvoiceAmount,0)) TotalInvoiceAmount from PS_CM_InvoiceRecord group by Contract_Guid) c
on a.Id = c.Contract_Guid  ----累计开票
left join
(select Contract_Guid,SUM(isNUll(ReceiveAmount,0)) TotalReceiveAmount from PS_CM_ContractReceipt group by Contract_Guid) d
on a.Id = d.Contract_Guid  ----累计到款
left join
(select Contract_Guid,SUM(isNUll(ClaimAmount,0)) TotalClaimAmount from PS_CM_ContractClaim group by Contract_Guid) e
on a.Id = e.Contract_Guid  ----累计索赔
left join
(select Contract_Guid,SUM(isNUll(SettlementAmount,0)) TotalSettlementAmount from PS_CM_ContractSettlement group by Contract_Guid) f
on a.Id = f.Contract_Guid  ----累计结算
left join
(select project_guid,LongCode from pln_project ) g
on a.EpsProjId =g.project_guid   ----LongCode


--出项合同分析
select * from PB_Widget where id='70f719dd-8487-4837-847a-74616de4a532'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractAnalysis.htm

select * from V_SF_CM_SubContract
sp_helptext V_SF_CM_SubContract


alter view V_SF_CM_SubContract
as

SELECT     a.Id, a.SubContractCode,a.Status, a.PaymentWay, a.SubContractName,a.EPSProjectName,a.EPSProjectId, a.EpsProjId, a.PartyB,a.RegDate, a.SignDate, a.SubContractType,a.DeliveryDate,a.DeliveryPlace, ISNULL(a.SubContractAmount, 0) AS SubContractAmount, ISNULL(a.ChangeAmount, 0)
                      AS ChangeAmount, ISNULL(a.FinalSubContractAmount, 0) AS FinalSubContractAmount, ISNULL(b.TotalApplyAmount, 0) AS TotalApplyAmount, ISNULL(c.TotalInvoiceAmount, 0) AS TotalInvoiceAmount,
                      ISNULL(d.TotalPaymentAmount, 0) AS TotalPaymentAmount, ISNULL(e.TotalClaimAmount, 0) AS TotalClaimAmount, ISNULL(f.TotalSettlementAmount, 0) AS TotalSettlementAmount, g.LongCode
                      ,ISNULL(a.FinalSubContractAmount, 0)-ISNULL(c.TotalInvoiceAmount, 0) as InvoiceAmountDisparity,
                     ISNULL(a.FinalSubContractAmount, 0)- ISNULL(d.TotalPaymentAmount, 0) AS PaymentAmountDisparity
FROM         dbo.PS_CM_SubContract AS a LEFT OUTER JOIN
                          (SELECT     SubContract_Guid, SUM(ISNULL(ApplyAmount, 0)) AS TotalApplyAmount
                            FROM          dbo.PS_CM_SubContractApplyMny
                            GROUP BY SubContract_Guid) AS b ON a.Id = b.SubContract_Guid LEFT OUTER JOIN
                          (SELECT     SubContract_Guid, SUM(ISNULL(InvoiceAmount, 0)) AS TotalInvoiceAmount
                            FROM          dbo.PS_CM_SubContractInvoice
                            GROUP BY SubContract_Guid) AS c ON a.Id = c.SubContract_Guid LEFT OUTER JOIN
                          (SELECT     SubContract_Guid, SUM(ISNULL(PaymentAmount, 0)) AS TotalPaymentAmount
                            FROM          dbo.PS_CM_SubContractPayment
                            GROUP BY SubContract_Guid) AS d ON a.Id = d.SubContract_Guid LEFT OUTER JOIN
                          (SELECT     SubContract_Guid, SUM(ISNULL(ClaimAmount, 0)) AS TotalClaimAmount
                            FROM          dbo.PS_CM_SubContractClaim
                            GROUP BY SubContract_Guid) AS e ON a.Id = e.SubContract_Guid LEFT OUTER JOIN
                          (SELECT     SubContract_Guid, SUM(ISNULL(SettlementAmount, 0)) AS TotalSettlementAmount
                            FROM          dbo.PS_CM_SubContractSettle
                            GROUP BY SubContract_Guid) AS f ON a.Id = f.SubContract_Guid LEFT OUTER JOIN
                          (SELECT     project_guid, LongCode
                            FROM          dbo.PLN_project) AS g ON a.EpsProjId = g.project_guid
