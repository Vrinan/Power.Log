Select count(*) as RecordCount From  PS_MK_ProjectInfo A 
left  join PB_Organize B on A.Client_Guid = B.Id Where   (0=0)  and  (0=0)  
and  A.Id IN (SELECT ProjectInfo_Guid FROM PS_MK_BidTrack WHERE BidResult ='01') 
AND A.Id NOT IN (SELECT ProjectInfo_Guid FROM PS_MK_ContractReview WHERE ProjectInfo_Guid IS NOT NULL ) 

select * from PS_MK_BidTrack
select * from PB_Widget where id='696ec71e-d26a-46d4-9ed2-6d6de2c4f9ff'
--��ͬ����
--/PowerPlat/FormXml/zh-CN/StdMarket/ContractReview.htm
select * from PB_Wizard where id='00473762-da00-4560-84db-fc2d30447038'
select * from PS_MK_ContractReview

select * from PB_Widget where id='1b4e2bb8-31b2-4bc7-a3ce-1458801b4692'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ContractReview.htm
select * from PB_BaseData where DataType='PS_ContractForm'
select * from PB_BaseDataList where BaseDataId='8996BCE3-9B97-445D-ADF4-11C9C37E1C41'
--delete from PB_BaseDataList where Id='5A35A1D8-88A7-C0CC-077D-6DB6F8CAC3C1'
select * from PS_MK_ContractReview

--��ͬ�Ǽ�
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm
select * from PB_Widget where id='f97c722a-a50f-4828-bc9a-9cacd434ac58'
--��ͬ�Ǽ�--��ͼ
--/PowerPlat/FormXml/zh-CN/StdContract/Win_View_IncomeContract.htm
--alter table PS_MK_ContractInfo add IsGuarantee nvarchar(100) null
--alter table PS_MK_ContractInfo add GuaranteeAmount float null

--�������
select * from PB_Widget where id='0f8849cc-48f3-4a1a-8a98-bd9e52401802'
--��Ŀ���_�����ͬ�������
--/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractChangeApply.htm
select * from PB_Widget where id='fae17254-e2de-4e2c-a4e3-4f7619b4f6f4'
--��Ŀ���_�����ͬ�������
--/PowerPlat/FormXml/zh-CN/StdCost/Win_PS_ContractChangeApply.htm
alter table PS_CM_ContractChange   add Memo nvarchar(500) null
--����Ǽ�
select * from PB_Widget where id='6d0387b0-8a57-4422-8dd4-ac415e418b46'
--��Ŀ���_�����ͬ����Ǽ�
--/PowerPlat/FormXml/zh-CN/StdCost/PS_IncomeContractChange.htm
--����Ǽǽ����ϸ
Create table SF_Contract_AmountList
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	FinancialDocumentNumber nvarchar(100) null,--����ƾ֤
	AmountType nvarchar(100) null,--��������
	NoTaxAmount float null,--����˰���
	TaxRate float null,--˰��
	TaxAmount float null,--˰��
	TotalAmount float null,--�ϼ�
	Memo nvarchar(500) null
)

--��ͬ���
select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'
--PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm
--SF_ApplyContract_AmountList

--alter table PS_CM_ContractApplyMoney add FinancialDocumentNumber nvarchar(100) null--����ƾ֤��
Create table SF_CM_ContractApplyMoneyList
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	EstablishAmount float null,
	DesignAmount float null,
	EquipmentAmount float null,
	OthersAmount float null,
	Memo nvarchar(500) null
)
--exec sp_rename 'PS_CM_ContractApplyMoneyList','SF_CM_ContractApplyMoneyList'

--��ͬ��Ʊ

--��ͬ����
select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm
Create table SF_ContractReceipt_List
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	EstablishAmount float null,
	DesignAmount float null,
	EquipmentAmount float null,
	OthersAmount float null,
	Memo nvarchar(500) null
)
--alter table PS_CM_ContractReceipt add FinancialDocumentNumber nvarchar(100) null--����ƾ֤��
--alter table PS_CM_ContractReceipt add NoTaxAmount float null--����˰���
--alter table PS_CM_ContractReceipt add TaxAmount float null--��˰���
--alter table PS_CM_ContractReceipt add AddNoTaxAmount float null--�ۼƲ���˰���
--alter table PS_CM_ContractReceipt add AddTaxAmount float null--�ۼƺ�˰���


--ΥԼ֪ͨ
select * from PB_Widget where id='c7f7c58f-6c12-4a84-bc76-9d227b9a36fe'
--��ͬΥԼ֪ͨ
--/PowerPlat/FormXml/zh-CN/StdContract/pm_cont_breachnotice.htm

--����������-��������
select * from PB_Widget where id='36139912-2361-428e-af0c-38f2fcff2492'
--��ƺ�ͬ-֧������
--/PowerPlat/FormXml/zh-CN/StdContract/SubContractApplyMoney_E.htm
Create table SF_SubContractApplyMoney_list
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	EstablishAmount float null,
	DesignAmount float null,
	EquipmentAmount float null,
	OthersAmount float null,
	Memo nvarchar(500) null
)
--alter table PS_CM_SubContractApplyMny add FinancialDocumentNumber nvarchar(100) null--����ƾ֤��
select * from PS_CM_SubContractApplyMny
select * from V_PS_SubContractApplyMny

sp_helptext V_PS_SubContractApplyMny


--alter VIEW [dbo].[V_PS_SubContractApplyMny]
--as
select CASE when b.KeyValue IS NULL  THEN 'δ��̯'
when b.KeyValue IS NOT NULL AND b.UnAllocatedAmount_CBS >0 THEN '���ַ�̯'
when b.KeyValue IS NOT NULL AND b.UnAllocatedAmount_CBS =0 THEN 'ȫ����̯'  END AllocationStatus,a.*,c.SubContractName,c.SubContractCode,c.SubContractAmount
FROM PS_CM_SubContractApplyMny a LEFT JOIN
 PS_CC_CostAllocation b
ON a.Id = b.KeyValue
left join PS_CM_SubContract c on a.SubContract_Guid =c.Id

--��Ʊ�Ǽ�
select * from PB_Widget where id='1d8707f1-f8ed-4264-853a-d3cbd39bb6d8'
--PS_SubContractInvoice
--��ƺ�ͬ-��Ʊ��¼
--/PowerPlat/FormXml/zh-CN/StdContract/SubContractInvoice_E.htm
Create table SF_CM_SubContractInvoice_List
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	EstablishAmount float null,
	DesignAmount float null,
	EquipmentAmount float null,
	OthersAmount float null,
	Memo nvarchar(500) null
)
--alter table PS_CM_SubContractInvoice add FinancialDocumentNumber nvarchar(100) null--����ƾ֤��
--alter table PS_CM_SubContractInvoice add NoTaxAmount float null--����˰���
--alter table PS_CM_SubContractInvoice add TaxAmount float null--��˰���
--alter table PS_CM_SubContractInvoice add AddNoTaxAmount float null--�ۼƲ���˰���
--alter table PS_CM_SubContractInvoice add AddTaxAmount float null--�ۼƺ�˰���


select * from PS_MK_ProjectInfo

Select count(*) as RecordCount From  PS_MK_ProjectInfo A 
left  join PB_Organize B on A.Client_Guid = B.Id 
Where   (0=0)  and  (0=0)  and  
A.Id NOT IN (SELECT ProjectInfo_Guid FROM PS_MK_ContractReview WHERE ProjectInfo_Guid IS NOT NULL) 

