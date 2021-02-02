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

--create view View_SF_SubContractCount
--as
select '�����������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='E'
union
select '�豸���ü���Ʒ������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='P'
union
select '������������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='C'
union
select '������ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='S'
union
select '��Ⱥ�ͬ' as Type,count(*) as Count from PS_CM_SubContract where SubContractType='Y'

--select * from View_SF_SubContractCount
select * from PB_Widget where id='2ce3adce-d536-4a4c-a10e-8803b46ebac0'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_CXContractAnalyse.htm

--select * from PB_Human where id not in(select HumanId from PB_HumanSign)

--select humanid from PB_HumanSign group by humanid having count(humanid)>1

--select sum(a.ContractAmount) as Amount from (select EpsProjectId, SUM(isNull(FinalContractAmount, 0)) ContractAmount from PS_MK_ContractInfo where PS_MK_ContractInfo.Status=50 group by EpsProjectId) a where a.EPSProjectId in(select project_guid from PLN_project where STATE = 1)
--19 9999 9998

select * from pb_widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'
--/PowerPlat/FormXml/zh-CN/StdSystem/HumanPage.htm

select * from PB_Widget where id='48ba02bf-7897-4104-b2d0-1d57c5b733e7'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_MKContractAnalyse.htm

select * from PB_Widget where id='2ce3adce-d536-4a4c-a10e-8803b46ebac0'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_CXContractAnalyse.htm

--select * from View_SF_EpsContract

--select SUM(Insum)Insum, SUM(OutSum)OutSum, sum(InApplyAmount)InApplyAmountSum,SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract
