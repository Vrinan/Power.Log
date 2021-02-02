select a.project_shortname,a.LongCode,a.project_name,a.project_guid,isnull(b.InSum,0) InSum,
ISNULL(u.ReplyAmount,0)ReplyAmount,ISNULL(v.InvoiceAmount,0)InvoiceAmount,ISNULL(w.ReceiveAmount,0)ReceiveAmount,
ISNULL(c.OutSum,0) OutSum,ISNULL(d.P_Sum,0)P_Sum,
ISNULL(e.S_Sum,0) S_Sum,ISNULL(F.E_Sum,0) E_Sum,ISNULL(g.C_Sum,0) C_Sum,
ISNULL(i.OutvoiceAmount,0)OutvoiceAmount,ISNULL(j.P_OutvoiceAmount,0)P_OutvoiceAmount,ISNULL(k.S_OutvoiceAmount,0)S_OutvoiceAmount
,ISNULL(l.E_OutvoiceAmount,0)E_OutvoiceAmount,ISNULL(m.C_OutvoiceAmount,0)C_OutvoiceAmount,
ISNULL(o.PaymentAmount,0)PaymentAmount,ISNULL(q.P_PaymentAmount,0)P_PaymentAmount,ISNULL(r.S_PaymentAmount,0)S_PaymentAmount
,ISNULL(s.E_PaymentAmount,0)E_PaymentAmount,ISNULL(t.C_PaymentAmount,0)C_PaymentAmount,
ISNULL(p.PmCost,0) PmCost,ISNULL(Ic.InChange,0)InChange,ISNULL(Oc.OutChange,0)OutChange,
ISNULL(v.InvoiceAmount,0)-ISNULL(w.ReceiveAmount,0) Indifference,
ISNULL(i.OutvoiceAmount,0)-ISNULL(o.PaymentAmount,0) Outdifference,
ISNULL(v.InvoiceAmount,0)-ISNULL(j.P_OutvoiceAmount,0)-ISNULL(P.PmCost,0)+ISNULL(InChange,0)-ISNULL(OutChange,0) GrossProfit
 from  PLN_project a
 LEFT join
(select SUM(FinalContractAmount) InSum,EPSProjectId  from PS_MK_ContractInfo
 where Status in (35,50) GROUP BY EPSProjectId)b
on a.project_guid=b.EPSProjectId
 LEFT join
(select SUM(RealApplyAmout) ReplyAmount,b1.EPSProjectId  FROM dbo.PS_CM_ContractApplyMoney a1
left join PS_MK_ContractInfo b1 on a1.Contract_Guid = b1.Id
where a1.Status in(35,50) GROUP BY b1.EPSProjectId) u
on a.project_guid=u.EPSProjectId
LEFT join
(select SUM(InvoiceAmount) InvoiceAmount,b1.EPSProjectId  from dbo.PS_CM_InvoiceRecord a3
left join PS_MK_ContractInfo b1 on a3.Contract_Guid = b1.Id
 where a3.Status in (35,50) GROUP BY b1.EPSProjectId) v
on a.project_guid=v.EPSProjectId
 LEFT join
(select SUM(ReceiveAmount) ReceiveAmount,b1.EPSProjectId  from dbo.PS_CM_ContractReceipt a4
left join PS_MK_ContractInfo b1 on a4.Contract_Guid = b1.Id
 where a4.Status in (35,50) GROUP BY b1.EPSProjectId)w
on a.project_guid=w.EPSProjectId
LEFT join
(select SUM(FinalSubContractAmount) OutSum,EPSProjectId from PS_CM_SubContract
 GROUP BY EPSProjectId)c
on a.project_guid=c.EPSProjectId
LEFT join
(select SUM(FinalSubContractAmount) P_Sum,EPSProjectId from PS_CM_SubContract
WHERE SubContractType='P'  and Status in (35,50)  GROUP BY EPSProjectId)d
on a.project_guid=d.EPSProjectId
left join
(select SUM(FinalSubContractAmount) S_Sum,EPSProjectId from PS_CM_SubContract
WHERE SubContractType='S' and Status in (35,50) GROUP BY EPSProjectId)e
on a.project_guid=e.EPSProjectId
left join
(select SUM(FinalSubContractAmount) E_Sum,EPSProjectId from PS_CM_SubContract
WHERE SubContractType='E' and Status in (35,50) GROUP BY EPSProjectId)F
on a.project_guid=F.EPSProjectId
left join
(select SUM(FinalSubContractAmount) C_Sum,EPSProjectId from PS_CM_SubContract
 where SubContractType='C' and Status in (35,50) GROUP BY EPSProjectId)g
on a.project_guid=g.EPSProjectId
LEFT join
(select SUM(InvoiceAmount) OutvoiceAmount,b1.EPSProjectId from PS_CM_SubContractInvoice a5
left join PS_MK_ContractInfo b1 on a5.SubContract_Guid = b1.Id
WHERE a5.Status in (35,50) GROUP BY b1.EPSProjectId)i on a.project_guid=i.EPSProjectId
left join
(select SUM(InvoiceAmount) P_OutvoiceAmount,b1.EPSProjectId from PS_CM_SubContractInvoice a6
left join PS_MK_ContractInfo b1 on a6.SubContract_Guid = b1.Id
WHERE SubContractType='P' and  a6.Status in (35,50) GROUP BY b1.EPSProjectId)j on a.project_guid=j.EPSProjectId
left join
(select SUM(InvoiceAmount) S_OutvoiceAmount,b1.EPSProjectId from PS_CM_SubContractInvoice a7
left join PS_MK_ContractInfo b1 on a7.SubContract_Guid = b1.Id
WHERE SubContractType='S' and  a7.Status in (35,50) GROUP BY b1.EPSProjectId)k on a.project_guid=k.EPSProjectId 
left join
(select SUM(InvoiceAmount) E_OutvoiceAmount,b1.EPSProjectId from PS_CM_SubContractInvoice a9
left join PS_MK_ContractInfo b1 on a9.SubContract_Guid = b1.Id
WHERE SubContractType='E' and  a9.Status in (35,50) GROUP BY b1.EPSProjectId)l on a.project_guid=l.EPSProjectId
left join
(select SUM(InvoiceAmount) C_OutvoiceAmount,b1.EPSProjectId from PS_CM_SubContractInvoice a10
left join PS_MK_ContractInfo b1 on a10.SubContract_Guid = b1.Id
WHERE SubContractType='C' GROUP BY b1.EPSProjectId)m on a.project_guid=m.EPSProjectId
left join
(select SUM(PaymentAmount) PaymentAmount,b1.EPSProjectId from PS_CM_SubContractPayment a11
left join PS_MK_ContractInfo b1 on a11.SubContract_Guid = b1.Id
WHERE  a11.Status in (35,50)  GROUP BY b1.EPSProjectId)o on a.project_guid=o.EPSProjectId
left join
(select SUM(PaymentAmount) P_PaymentAmount,b1.EPSProjectId from PS_CM_SubContractPayment a12
left join PS_MK_ContractInfo b1 on a12.SubContract_Guid = b1.Id
WHERE SubContractType='P' and a12.Status in (35,50) GROUP BY b1.EPSProjectId)q on a.project_guid=q.EPSProjectId
left join
(select SUM(PaymentAmount) S_PaymentAmount,b1.EPSProjectId from PS_CM_SubContractPayment a13
left join PS_MK_ContractInfo b1 on a13.SubContract_Guid = b1.Id
WHERE SubContractType='S' and a13.Status in (35,50) GROUP BY b1.EPSProjectId)r on a.project_guid=r.EPSProjectId
left join
(select SUM(PaymentAmount) E_PaymentAmount,b1.EPSProjectId from PS_CM_SubContractPayment a14
left join PS_MK_ContractInfo b1 on a14.SubContract_Guid = b1.Id
 where SubContractType='E' and a14.Status in (35,50) GROUP BY b1.EPSProjectId)s on a.project_guid=s.EPSProjectId
left join
(select SUM(PaymentAmount) C_PaymentAmount,b1.EPSProjectId from PS_CM_SubContractPayment a15
left join PS_MK_ContractInfo b1 on a15.SubContract_Guid = b1.Id
WHERE SubContractType='C' and a15.Status in (35,50) GROUP BY b1.EPSProjectId)t on a.project_guid=t.EPSProjectId
LEFT JOIN
(SELECT EpsProjId,SUM(ISNULL(actualAmount,0)) PmCost FROM PS_CC_PmFeeExpense WHERE status IN (35,50)
GROUP BY EpsProjId) p
ON a.project_guid = p.EpsProjId
LEFT join
(select SUM(ChangAmount) Inchange,EpsProjId from dbo.PS_CM_ContractChange
WHERE  Status in (35,50)  GROUP BY EpsProjId) IC
on a.project_guid=IC.EpsProjId
LEFT join
(select SUM(ChangeAmount) Outchange,EpsProjId from dbo.PS_CM_SubContractChange
WHERE  Status in (35,50)  GROUP BY EpsProjId)OC
on a.project_guid=OC.EpsProjId

