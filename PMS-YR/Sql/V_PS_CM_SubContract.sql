USE [PowerPMS_218]
GO

/****** Object:  View [dbo].[V_PS_CM_SubContract]    Script Date: 2017-12-13 15:38:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[V_PS_CM_SubContract]
as

SELECT     a.Id, a.SubContractCode,a.Status, a.PaymentWay, a.SubContractName, a.EpsProjId, a.PartyB,a.RegDate, a.SignDate, a.SubContractType,a.DeliveryDate,a.DeliveryPlace, ISNULL(a.SubContractAmount, 0) AS SubContractAmount, ISNULL(a.ChangeAmount, 0) 
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

GO


