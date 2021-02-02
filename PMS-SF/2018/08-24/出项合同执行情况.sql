select * from V_SubContractProgress
sp_helptext V_SubContractProgress
--alter VIEW [dbo].[V_SubContractProgress]
--AS
SELECT a.Id,b.project_guid,b.parent_guid,project_name,SubContractName,SubContractAmount,
(SELECT TOP 1 act_complete_pct FROM dbo.PS_PLN_TaskBCWS where type ='plan' AND plan_guid =a.Plan_Guid ) as progress,
(CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_SubContractInvoice WHERE SubContract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(InvoiceAmount) FROM PS_CM_SubContractInvoice WHERE SubContract_Guid=a.Id)<>0 AND SubContractAmount<>0 THEN
((SELECT SUM(InvoiceAmount) FROM PS_CM_SubContractInvoice WHERE SubContract_Guid=a.Id)/a.SubContractAmount)
ELSE 0 END) AS InvoicePercent,
(CASE WHEN (SELECT SUM(PaymentAmount) FROM PS_CM_SubContractPayment WHERE SubContract_Guid=a.Id)IS NOT NULL AND
(SELECT SUM(PaymentAmount) FROM PS_CM_SubContractPayment WHERE SubContract_Guid=a.Id)<>0 AND SubContractAmount<>0 THEN
((SELECT SUM(PaymentAmount) FROM PS_CM_SubContractPayment WHERE SubContract_Guid=a.Id)/a.SubContractAmount)
ELSE 0 END) AS ReceivePercent,
CASE WHEN (SELECT SUM(ApplyAmount) FROM PS_CM_SubContractApplyMny WHERE SubContract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(ApplyAmount) FROM PS_CM_SubContractApplyMny WHERE SubContract_Guid=a.Id) END AS ApplyAmount,
CASE WHEN (SELECT SUM(InvoiceAmount) FROM PS_CM_SubContractInvoice WHERE SubContract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(InvoiceAmount) FROM PS_CM_SubContractInvoice WHERE SubContract_Guid=a.Id) END AS InvoiceAmount,
CASE WHEN (SELECT SUM(PaymentAmount) FROM PS_CM_SubContractPayment WHERE SubContract_Guid=a.Id)IS NULL THEN 0
ELSE (SELECT SUM(PaymentAmount) FROM PS_CM_SubContractPayment WHERE SubContract_Guid=a.Id) END AS PaymentAmount,ControlAmount
FROM PS_CM_SubContract a LEFT JOIN PLN_project b
ON a.EPSProjectId=b.project_guid WHERE a.SubContractType='C'






--分包合同执行
select * from pb_widget where id='370b9a55-c61e-4cb1-96f8-4d2f24c5e121'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_SubContractProgress.htm
