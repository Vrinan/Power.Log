--�����ͬ
--����PS_ContractReview
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ContractReview.htm
select * from pb_widget where id='1b4e2bb8-31b2-4bc7-a3ce-1458801b4692'

--��ͬ�Ǽ� ����V_PS_ContractInfo
--/PowerPlat/FormXml/zh-CN/StdContract/Win_View_IncomeContract.htm
select * from PB_Widget where id='f97c722a-a50f-4828-bc9a-9cacd434ac58'
--��ͬ�Ǽ� ��PS_IncomeContract
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'

--��ͬ��� ����V_PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/Win_ContractApplyMoney.htm
select * from PB_Widget where id='67630c46-7551-43a9-97c2-2fba56e69d92'
--��ͬ��� ��PS_ContractApplyMoney
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm
select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'

--��ͬ�Ǽ��տ�ڵ�
select * from  PS_MK_ContractInfo_PayNodes
--��ͬ�����տ�ڵ�
select * from  PS_CM_ContractApplyMoney_Nodes



alter table PS_CM_ContractApplyMoney_Nodes add NodeAmount float null
--create view V_SF_HT_ContractInfo_PayNodes
--AS
--SELECT Id,MasterId,Sequ,PayNodes,CheckAmount,(SELECT Name FROM dbo.PB_BaseDataList b WHERE BaseDataId='30688728-C323-44EE-876B-C4E94F264CB6' AND Code=a.PayType) PayType,PayAmount 
--FROM PS_MK_ContractInfo_PayNodes a










--delete from PS_MK_ContractReview--�����ͬ����
--delete from PS_MK_ContractInfo--�����ͬ�Ǽ�
--delete from SF_Contract_AmountList--�����ϸ
--delete from PS_MK_ContractInfo_PayNodes--�տ�ڵ�
--delete from PS_CM_ContractApplyMoney--��ͬ���
--delete from PS_CM_ContractApplyMoney_Other--�����ۿ�
--delete from PS_CM_ContractApplyMoney_Nodes--�տ���ɽڵ�
--delete from PS_CM_InvoiceRecord--��ͬ��Ʊ
--delete from PS_CM_InvoiceRecord_Dtl--��Ʊ��ϸ
--delete from PS_CM_ContractReceipt--��ͬ����
--delete from PS_CM_ContractDefaultNotices--��ͬ����
--delete from PS_CM_ContractClaimApp--��������
--delete from PS_CM_ContractClaimApp_files
--delete from PS_CM_ContractClaimApp_branch
--delete from PS_CM_ContractClaim--������
--delete from PS_CM_ContractClaim_Dtl
--delete from PS_CM_ContractSettlement--��ͬ����
--delete from PS_CM_ContractCharged--��ͬ�ۿ�
