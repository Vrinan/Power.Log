--alter view View_SF_EpsContract
--as
select project_shortname,LongCode,project_name,project_guid,
--�����ͬ����
  (select count(*) from PS_MK_ContractInfo where status=50 and EPSProjectId = pln_project.project_guid) as InCount,
--�����ͬ����
  (select count(*) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--�����ͬ���
  (select isnull(sum(FinalContractAmount),0) from PS_MK_ContractInfo where status=50 and EPSProjectId = pln_project.project_guid) as InSum,
--�����ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--���Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as InvoiceAmount,
--�������
  (select isnull(sum(RealApplyAmout),0) from PS_CM_ContractApplyMoney a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as InApplyAmount,
--�����տ�
  (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as ReceiveAmount,
--������Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as OutvoiceAmount,
--�������
  (select isnull(sum(FinalApplyAmount),0) from PS_CM_SubContractApplyMny a left join PS_MK_ContractInfo b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as OutApplyAmount,
--�����
   (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as PaymentAmount,

--�ɹ���ͬ����
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--����������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--�ɹ���ͬ�ܽ��
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--��������
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum,
--�ɹ���ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='P' and b.EPSProjectId = pln_project.project_guid) as P_OutvoiceAmount,
--�����������ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='E' and b.EPSProjectId = pln_project.project_guid) as E_OutvoiceAmount,
--�������̺�ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='C' and b.EPSProjectId = pln_project.project_guid) as C_OutvoiceAmount,
--������ͬ��Ʊ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='S' and b.EPSProjectId = pln_project.project_guid) as S_OutvoiceAmount,

--�ɹ���ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='P'and b.EPSProjectId = pln_project.project_guid) as P_PaymentAmount,
--���������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='E'and b.EPSProjectId = pln_project.project_guid) as E_PaymentAmount,
--�����������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='C'and b.EPSProjectId = pln_project.project_guid) as C_PaymentAmount,
--�������ͬ����
  (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.SubContractType='S'and b.EPSProjectId = pln_project.project_guid) as S_PaymentAmount,

--��Ʊ��ֵ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_SubContractInvoice a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalPaymentAmount),0) from PS_CM_SubContractPayment a left join PS_CM_SubContract b on a.SubContract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as Indifference,
--�����ֵ
  (select isnull(sum(TotalInvoiceAmount),0) from PS_CM_InvoiceRecord a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) - (select isnull(sum(TotalReceiveAmount),0) from PS_CM_ContractReceipt a left join PS_MK_ContractInfo b on a.Contract_Guid = b.Id
   where a.status=50 and b.EPSProjectId = pln_project.project_guid) as Outdifference
from pln_project 



--select * from PB_HumanSign
--select * from SF_FK_ManageCostSchedule_dtl
--select SUM(Insum)Insum, SUM(OutSum)OutSum, SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract

create view View_SF_SubContractCount
as
select '�����������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='E'
union
select '�豸���ü���Ʒ������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='P'
union
select '������������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='C'
union
select '������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='S'
union
select '��Ⱥ�ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='Y'