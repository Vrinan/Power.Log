alter view View_SF_EpsContract
as
select project_shortname,LongCode,project_name,project_guid,
--�����ͬ
  (select isnull(sum(FinalContractAmount),0) from PS_MK_ContractInfo where EPSProjectId = pln_project.project_guid) as InSum,
--�����ͬ
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where EPSProjectId = pln_project.project_guid) as OutSum,
--�ɹ���ͬ
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--�������ͬ
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum,
--�ۼƿ�Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as OutvoiceAmount,
--�ɹ���ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='P' and b.EPSProjectId = pln_project.project_guid) as P_OutvoiceAmount,
--�����������ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='E' and b.EPSProjectId = pln_project.project_guid) as E_OutvoiceAmount,
--�������̺�ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='C' and b.EPSProjectId = pln_project.project_guid) as C_OutvoiceAmount,
--������ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='S' and b.EPSProjectId = pln_project.project_guid) as S_OutvoiceAmount,
--�ۼ���Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as InvoiceAmount,
--�ۼƸ���
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as PaymentAmount,
--�ɹ���ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='P'and b.EPSProjectId = pln_project.project_guid) as P_PaymentAmount,
--���������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='E'and b.EPSProjectId = pln_project.project_guid) as E_PaymentAmount,
--�����������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='C'and b.EPSProjectId = pln_project.project_guid) as C_PaymentAmount,
--�������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.SubContractType='S'and b.EPSProjectId = pln_project.project_guid) as S_PaymentAmount,
--�ۼ��տ�
  (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as ReceiveAmount,
--��Ʊ��ֵ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as Indifference,
--�����ֵ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where b.EPSProjectId = pln_project.project_guid) as Outdifference
from pln_project 
--where Insum!=0 or OutSum!=0 or InvoiceAmount !=0 or OutvoiceAmount!=0

--where project_guid in(select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))


--select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm