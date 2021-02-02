--alter view View_SF_EpsContract
--as
select project_shortname,LongCode,project_name,project_guid,
--进项合同数量
  (select count(*) from PS_MK_ContractInfo where status=50 and EPSProjectId = pln_project.project_guid) as InCount,
--出项合同数量
  (select count(*) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--进项合同金额
  (select isnull(sum(FinalContractAmount),0) from PS_MK_ContractInfo where status=50 and EPSProjectId = pln_project.project_guid) as InSum,
--出项合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--进项开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as InvoiceAmount,
--进项请款
  (select isnull(sum(RealApplyAmout),0) from PS_CM_ContractApplyMoney a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as InApplyAmount,
--进项收款
  (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as ReceiveAmount,
--出项收票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as OutvoiceAmount,
--出项请款
  (select isnull(sum(FinalApplyAmount),0) from PS_CM_SubContractApplyMny a left join PS_MK_ContractInfo b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as OutApplyAmount,
--出项付款
   (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as PaymentAmount,

--采购合同数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--技术服务类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--建安工程类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--其他类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--采购合同总金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum,
--采购合同开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='P' and b.EPSProjectId = pln_project.project_guid) as P_OutvoiceAmount,
--技术服务类合同开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='E' and b.EPSProjectId = pln_project.project_guid) as E_OutvoiceAmount,
--建安工程合同开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='C' and b.EPSProjectId = pln_project.project_guid) as C_OutvoiceAmount,
--其他合同开票
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='S' and b.EPSProjectId = pln_project.project_guid) as S_OutvoiceAmount,

--采购合同付款
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='P'and b.EPSProjectId = pln_project.project_guid) as P_PaymentAmount,
--技术服务合同付款
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='E'and b.EPSProjectId = pln_project.project_guid) as E_PaymentAmount,
--建安工程类合同付款
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='C'and b.EPSProjectId = pln_project.project_guid) as C_PaymentAmount,
--其他类合同付款
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='S'and b.EPSProjectId = pln_project.project_guid) as S_PaymentAmount,

--开票差值
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as Indifference,
--付款差值
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as Outdifference
from pln_project 



--select * from PB_HumanSign
--select * from SF_FK_ManageCostSchedule_dtl
--select SUM(Insum)Insum, SUM(OutSum)OutSum, SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract

create view View_SF_SubContractCount
as
select '技术服务类合同' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='E'
union
select '设备购置及备品备件合同' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='P'
union
select '建安工程类别合同' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='C'
union
select '其他合同' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='S'
union
select '年度合同' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='Y'