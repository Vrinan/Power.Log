--公司项目
select count(id) as CompanyProjCount from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')

--在建项目
select * from PB_Widget where id='b16239b8-bfa1-43d7-8058-7bd16fcb694c'
--/PowerPlat/FormXml/zh-CN/StdPortal/Win_PS_PlnProject_More.htm


select * from View_SF_SJ_Overview order by xmbhCode,ProjectLeader,DesignStage,tdzjTitle,ggspsTitle


select * from V_PS_EPM_ProjectCount


select project_guid,LongCode,1 ProjectNum,isNull(b.ContractAmount,0)ProjectAmount
from pln_project a left join
(select EpsProjId,SUM(isNull(FinalContractAmount,0)) ContractAmount
from PS_MK_ContractInfo group by EpsProjId) b
on a.project_guid = b.EpsProjId
where a.project_type = 1

select EpsProjId,SUM(isNull(FinalContractAmount,0)) ContractAmount from PS_MK_ContractInfo group by EpsProjId

select * from PS_MK_ContractInfo

select * from PB_Widget where id='e5a9bc0c-76f7-433c-8547-0fb9f498a453'
--/PowerPlat/FormXml/zh-CN/StdSystem/BaseDataPageList.htm



--create view View_SF_ProjContract
--as
--select project_guid,LongCode,1 ProjectNum,isNull(b.ContractAmount,0)ProjectAmount
--from pln_project a left join
--(select EpsProjectId,SUM(isNull(FinalContractAmount,0)) ContractAmount from PS_MK_ContractInfo group by EpsProjectId) b
--on a.project_guid = b.EPSProjectId

--select * from View_SF_ProjContract

select EpsProjectId,SUM(isNull(FinalContractAmount,0)) ContractAmount from PS_MK_ContractInfo group by EpsProjectId

select SUM(ContractNum) ContractNum ,SUM(RealApplyAmout) RealApplyAmout from [View_SF_ContractIncome] where EpsProjId in('" + Ids + "')
CREATE view [dbo].[View_SF_ContractIncome]  ---企业中心,本年产值
as
select EpsProjId,Count(1) ContractNum,SUM(ISNULL(RealApplyAmout,0)) RealApplyAmout
from PS_CM_ContractApplyMoney
where YEAR(RegDate)=YEAR(GETDATE())  and  Status in (35,50)
group by EpsProjId







select * from V_ContractMianStatistics
sp_helptext V_ContractMianStatistics


CREATE view [dbo].[V_ContractMianStatistics]
as
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
(select SUM(FinalContractAmount) InSum,EpsProjId  from PS_MK_ContractInfo
 where Status in (35,50) GROUP BY EpsProjId)b
on a.project_guid=b.EpsProjId
 LEFT join
(select SUM(ReplyAmount) ReplyAmount,EpsProjId  FROM dbo.PS_CM_ContractApplyMoney
 where Status in (35,50) GROUP BY EpsProjId) u
on a.project_guid=u.EpsProjId
 LEFT join
(select SUM(InvoiceAmount) InvoiceAmount,EpsProjId  from dbo.PS_CM_InvoiceRecord
 where Status in (35,50) GROUP BY EpsProjId) v
on a.project_guid=v.EpsProjId
 LEFT join
(select SUM(ReceiveAmount) ReceiveAmount,EpsProjId  from dbo.PS_CM_ContractReceipt
 where Status in (35,50) GROUP BY EpsProjId)w
on a.project_guid=w.EpsProjId
LEFT join
(select SUM(FinalSubContractAmount) OutSum,EpsProjId from PS_CM_SubContract
 where Status in (35,50)  GROUP BY EpsProjId)c
on a.project_guid=c.EpsProjId
LEFT join
(select SUM(FinalSubContractAmount) P_Sum,EpsProjId from PS_CM_SubContract
WHERE SubContractType='P'  and Status in (35,50)  GROUP BY EpsProjId)d
on a.project_guid=d.EpsProjId
left join
(select SUM(FinalSubContractAmount) S_Sum,EpsProjId from PS_CM_SubContract
WHERE SubContractType='S' and Status in (35,50) GROUP BY EpsProjId)e
on a.project_guid=e.EpsProjId
left join
(select SUM(FinalSubContractAmount) E_Sum,EpsProjId from PS_CM_SubContract
WHERE SubContractType='E' and Status in (35,50) GROUP BY EpsProjId)F
on a.project_guid=F.EpsProjId
left join
(select SUM(FinalSubContractAmount) C_Sum,EpsProjId from PS_CM_SubContract
 where SubContractType='C' and Status in (35,50) GROUP BY EpsProjId)g
on a.project_guid=g.EpsProjId
LEFT join
(select SUM(InvoiceAmount) OutvoiceAmount,EpsProjId from PS_CM_SubContractInvoice
WHERE Status in (35,50) GROUP BY EpsProjId)i on a.project_guid=i.EpsProjId
left join
(select SUM(InvoiceAmount) P_OutvoiceAmount,EpsProjId from PS_CM_SubContractInvoice
WHERE SubContractType='P' and  Status in (35,50) GROUP BY EpsProjId)j on a.project_guid=j.EpsProjId
left join
(select SUM(InvoiceAmount) S_OutvoiceAmount,EpsProjId from PS_CM_SubContractInvoice
WHERE SubContractType='S' and  Status in (35,50) GROUP BY EpsProjId)k on a.project_guid=k.EpsProjId
left join
(select SUM(InvoiceAmount) E_OutvoiceAmount,EpsProjId from PS_CM_SubContractInvoice
WHERE SubContractType='E' and  Status in (35,50) GROUP BY EpsProjId)l on a.project_guid=l.EpsProjId
left join
(select SUM(InvoiceAmount) C_OutvoiceAmount,EpsProjId from PS_CM_SubContractInvoice
WHERE SubContractType='C' GROUP BY EpsProjId)m on a.project_guid=m.EpsProjId
left join
(select SUM(PaymentAmount) PaymentAmount,EpsProjId from PS_CM_SubContractPayment
WHERE  Status in (35,50)  GROUP BY EpsProjId)o on a.project_guid=o.EpsProjId
left join
(select SUM(PaymentAmount) P_PaymentAmount,EpsProjId from PS_CM_SubContractPayment
WHERE SubContractType='P' and Status in (35,50) GROUP BY EpsProjId)q on a.project_guid=q.EpsProjId
left join
(select SUM(PaymentAmount) S_PaymentAmount,EpsProjId from PS_CM_SubContractPayment
WHERE SubContractType='S' and Status in (35,50) GROUP BY EpsProjId)r on a.project_guid=r.EpsProjId
left join
(select SUM(PaymentAmount) E_PaymentAmount,EpsProjId from PS_CM_SubContractPayment
 where SubContractType='E' and Status in (35,50) GROUP BY EpsProjId)s on a.project_guid=s.EpsProjId
left join
(select SUM(PaymentAmount) C_PaymentAmount,EpsProjId from PS_CM_SubContractPayment
WHERE SubContractType='C' and Status in (35,50) GROUP BY EpsProjId)t on a.project_guid=t.EpsProjId
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



select  EPSProjectId from PS_CM_SubContract GROUP BY EPSProjectId


select * from View_SF_EpsContract

create view View_SF_EpsContract
as
select project_shortname,LongCode,project_name,project_guid,
--进项合同
  (select isnull(sum(FinalContractAmount),0) from PS_MK_ContractInfo where EPSProjectId = pln_project.project_guid) as InSum,
--出项合同
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where EPSProjectId = pln_project.project_guid) as OutSum,
--采购合同
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类合同
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum,
--累计开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as InvoiceAmount,
--累计收票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as OutvoiceAmount,
--累计付款
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as PaymentAmount,
--累计收款
  (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as ReceiveAmount,
--开票差值
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as Indifference,
--付款差值
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as Outdifference
from pln_project 