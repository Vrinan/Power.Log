--合同金额
select * from PS_MK_ContractInfo
--累计申请

--累计开票

--累计到款

--未申请金额

--未开票金额

--未到款金额



--费用类型
select AmountType, 
(select FinalContractAmount from PS_MK_ContractInfo b where b.Id = a.MasterId ) as FinalContractAmount 



from SF_Contract_AmountList a where a.MasterId= '4267cc40-34df-4419-854b-6d41b65f1b09'