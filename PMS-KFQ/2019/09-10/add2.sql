select a.RegHumName,a.RegHumId,a.ClassifyTree_Id,a.adder_sid ,* from KFQ_ContractSc a
left join PB_Human b on a.RegHumId=b.Id where a.RegHumId is null


select Id,OrgId,* from PB_Department



--1
--humanid
--合同里找录入人是上面的

--0
--rt0