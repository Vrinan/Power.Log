--�����ͬ-��ͬ�Ǽ�
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--PS_IncomeContract
--��ͬ�Ǽ�
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm
alter table PS_MK_ContractInfo add RunStatus nvarchar(100) null
select * from PS_MK_ContractInfo
SELECT Name FROM SysColumns WHERE id=Object_Id('PS_MK_ContractInfo')
select * from PS_MK_ContractReview

--��ͬ���
select * from PB_Widget where id='0f8849cc-48f3-4a1a-8a98-bd9e52401802'
--��Ŀ���_�����ͬ�������
--/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractChangeApply.htm
Select XCode_T1.* From (Select A.*,B.ProjectName as ProjectName , row_number() over(Order By a.Id) as rowNumber 
From PS_MK_ContractReview A 
left join PS_MK_ProjectInfo B on A.ProjectInfo_Guid = B.Id Where (0=0) and 1=1
) XCode_T1 Where rowNumber Between 1 And 15

--��ͬ��Ʊ
select * from PB_Widget where id='15fa9b9d-634e-439b-93a4-18c9d375de75'
--PS_InvoiceRecord
--��Ʊ��¼
--/PowerPlat/FormXml/zh-CN/StdContract/InvoiceRecord.htm
--SF_InvoiceContract_AmountList
alter table PS_CM_InvoiceRecord add AddNoTaxAmount float null
alter table PS_CM_InvoiceRecord add AddTaxAmount float null
alter table PS_CM_InvoiceRecord add AddTaxRate float null

--��ͬ����
select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'
--PS_ContractReceipt
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm
--SF_ReceiptContract_AmountList

sp_helptext V_PS_ContractReceipt
alter VIEW [dbo].[V_PS_ContractReceipt]
as
select CASE when b.KeyValue IS NULL  THEN 'δ��̯'
when b.KeyValue IS NOT NULL AND b.UnAllocatedAmount_CBS >0 THEN '���ַ�̯'
when b.KeyValue IS NOT NULL AND b.UnAllocatedAmount_CBS =0 THEN 'ȫ����̯'  END AllocationStatus,a.*,c.ContractName
FROM PS_CM_ContractReceipt a LEFT JOIN
PS_CC_CostAllocation b
ON a.Id = b.KeyValue  left join PS_MK_ContractInfo c on a.Contract_Guid=c.Id

--��ͬ����
select * from PB_Widget where id='6665fd96-4c31-4f88-a262-d011ab0d8524'
--PS_ContractSettlement
alter table PS_CM_ContractSettlement add SettlementApplyAmount float null
--��ͬ����
--/PowerPlat/FormXml/zh-CN/StdContract/ContractSettlement.htm
--SF_SettlementContract_AmountList