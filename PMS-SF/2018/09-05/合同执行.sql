--ºÏÍ¬Ö´ÐÐ
select * from PB_Widget where id='d58d7dee-b444-495c-b418-12d58bcdbae8'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_IncomeContractProgress.htm

SELECT * from V_IncomeContractProgress where 1=1 and project_guid in(SELECT project_guid FROM PLN_project
WHERE LongCode LIKE '.%'or LongCode='')

select * from pln_projwbs
select SignedDate,* from PS_MK_ContractInfo where Status=50
select * from V_IncomeContractProgress where project_name like '%%' and ContractName like '%%' and PartyA like '%%' and SignedDate between '' and '2018-9-9'
SELECT * from V_IncomeContractProgress where 1=1 and SignedDate between '2017-1-1' and '2018-9-5'
sp_helptext V_IncomeContractProgress

alter VIEW [dbo].[V_IncomeContractProgress]
as
SELECT a.Id,b.project_guid,b.parent_guid,project_name,a.ContractName,a.ContractAmount,a.SignedDate,a.PartyA,
--(Select TOP 1 complete_pct from pln_projwbs WHERE proj_node_flag='Y' AND proj_guid =b.project_guid ) as progress,
(CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE status=50 and Contract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE status=50 and Contract_Guid = a.Id)<>0 AND ContractAmount<>0 THEN
((SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE status=50 and Contract_Guid = a.Id)/a.ContractAmount)
ELSE 0 END) AS InvoicePercent,
(CASE WHEN (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE status=50 and Contract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE status=50 and Contract_Guid=a.Id)<>0 AND ContractAmount<>0 THEN
((SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE status=50 and Contract_Guid=a.Id)/a.ContractAmount)
ELSE 0 END) AS ReceivePercent,
CASE WHEN (SELECT SUM(ApplyAmount) FROM PS_CM_ContractApplyMoney WHERE status=50 and Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(ApplyAmount) FROM PS_CM_ContractApplyMoney WHERE status=50 and Contract_Guid=a.Id) END AS ApplyAmount,
CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE status=50 and Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(InvoiceAmount) FROM PS_CM_InvoiceRecord WHERE status=50 and Contract_Guid=a.Id) END AS InvoiceAmount,
CASE WHEN (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE status=50 and Contract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(ReceiveAmount) FROM PS_CM_ContractReceipt WHERE status=50 and Contract_Guid=a.Id) END AS ReceiveAmount
FROM PS_MK_ContractInfo a LEFT JOIN PLN_project b
ON a.EpsProjectId=b.project_guid where a.Status=50




select * from PB_Widget where id='4e7dfde9-3c5d-442e-976a-ce7a15420ae0'
--/PowerPlat/FormXml/zh-CN/StdPortal/Win_PS_ProjectContractCenter.html