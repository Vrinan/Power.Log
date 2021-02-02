sp_helptext V_IncomeContractProgress
CREATE VIEW [dbo].[V_IncomeContractProgress]
as
SELECT a.Id,b.project_guid,b.parent_guid,project_name,ContractName,ContractAmount,
(Select TOP 1 complete_pct from pln_projwbs WHERE proj_node_flag='Y' AND proj_guid =b.project_guid ) as progress,

(CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE Contract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE Contract_Guid=a.Id)<>0 AND ContractAmount<>0 THEN
((SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE Contract_Guid=a.Id)/a.ContractAmount)
ELSE 0 END) AS InvoicePercent,

(CASE WHEN (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE Contract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE Contract_Guid=a.Id)<>0 AND ContractAmount<>0 THEN
((SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE Contract_Guid=a.Id)/a.ContractAmount)
ELSE 0 END) AS ReceivePercent,

CASE WHEN (SELECT SUM(ApplyAmount) FROM PS_CM_ContractApplyMoney WHERE Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(ApplyAmount) FROM PS_CM_ContractApplyMoney WHERE Contract_Guid=a.Id) END AS ApplyAmount,

CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE Contract_Guid=a.Id) END AS InvoiceAmount,

CASE WHEN (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE Contract_Guid=a.Id) END AS ReceiveAmount

FROM PS_MK_ContractInfo a LEFT JOIN PLN_project b
ON a.EpsProjectId=b.project_guid