select id from PS_CC_ContractBudget where IsLastVersion = 0 and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d' order by VersionCode desc

select * from PS_CC_ContractBudget_CBS where masterid = '7D75FAD3-F209-4183-A478-C3AB4DEDB45C'


select * from PB_Widget where id='90944435-3671-4ab0-9174-5f8546638615'
--/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractBudget_CBS.htm


select * from pln_project
--一期
--22499ebc-401c-44e1-a036-6134dd424d8d
--二期
--e8379933-2d9b-4744-9053-d668883ede5e
select * from PS_CC_CBS_Class where EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d' and parentid='00000000-0000-0000-0000-000000000000'
select * from PS_CC_CBS_Class where EpsProjId='e8379933-2d9b-4744-9053-d668883ede5e' and parentid='00000000-0000-0000-0000-000000000000'


select * from PS_CC_ContractBudget_CBS where CbsClass_Guid='4BFF47BF-B087-4E0C-95A0-6E92CBBCD0CD'









--合同
select * from PS_CM_SubContract  where RegDate is null
select sum(FinalSubContractAmount) as Amount from PS_CM_SubContract 
where status = 50 and SubContractType in('E','P','C','S') and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d'

select sum(FinalSubContractAmount) as Amount from PS_CM_SubContract 
where status = 50 and SubContractType in('E','P','C','S') and year(regdate) = year(GETDATE()) and month(regdate) = month(GETDATE()) and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d'

select  month(GETDATE()),month(regdate), * from PS_CM_SubContract 


select *  from PS_CM_SubContractApplyMny where status = 50 and year(regdate) = year(GETDATE()) and SubContractType in('E','P','C','S') and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d'



select * from PS_CM_SubContractApplyMny
where status = 50 and SubContractType in('E','P','C','S') and year(regdate) = year(GETDATE()) and month(regdate) = month(GETDATE()) and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d'
