--��ͬ���
select * from PS_MK_ContractInfo
--�ۼ�����

--�ۼƿ�Ʊ

--�ۼƵ���

--δ������

--δ��Ʊ���

--δ������



--��������
select AmountType, 
(select FinalContractAmount from PS_MK_ContractInfo b where b.Id = a.MasterId ) as FinalContractAmount 



from SF_Contract_AmountList a where a.MasterId= '4267cc40-34df-4419-854b-6d41b65f1b09'