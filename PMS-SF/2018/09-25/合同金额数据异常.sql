select sum(ContractAmount) as ContractAmount from 
(select EpsProjectId, SignedDate, isNull(FinalContractAmount, 0) ContractAmount from PS_MK_ContractInfo 
where status = 50 and year(SignedDate) = year(GETDATE())) a 

select Count(1) ContractNum,SUM(ISNULL(ReceiveAmount,0)) as RealApplyAmout from PS_CM_ContractReceipt 
where status = 50 and YEAR(RegDate)=YEAR(GETDATE())  

129710520
1279941512.26
130696545

129710520
1279941512.26

select a.ContractCode, a.FinalContractAmount,b.ReceiveAmount from PS_MK_ContractInfo a  left join
(select contract_guid,RegDate,status,sum(ReceiveAmount) as ReceiveAmount from PS_CM_ContractReceipt group by contract_guid,RegDate,status) b on  b.Contract_Guid = a.Id where (b.ReceiveAmount>a.FinalContractAmount) or a.FinalContractAmount is null or a.FinalContractAmount = 0
and a.status = 50 and  year(a.SignedDate) = year(GETDATE()) and  b.status = 50 and YEAR(b.RegDate)=YEAR(GETDATE())


if( '123' like '%1%')
print '1'
else
print '2'