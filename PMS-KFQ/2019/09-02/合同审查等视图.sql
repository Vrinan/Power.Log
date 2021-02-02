--ºÏÍ¬Éó²é
select * from KFQ_ContractSc where ClassifyTree_Id not in(
select Id from KFQ_QX_ClassifyTree
)
--×ó²à
select * from KFQ_QX_ClassifyTree

create view View_ContractSc
as
select r1.ClassifyTree_Id,le.ParentId,le.Name,r1.Id,ContractAmount,PartyA,PartyA_Guid,PartyB,PartyB_Guid,ExecutorName,r1.RegDate,r1.RegHumId,r1.Status,r1.Memo,Title,r1.Code
from KFQ_ContractSc r1
left join 
KFQ_QX_ClassifyTree le on r1.ClassifyTree_Id = le.Id



select aa.Id as treeId,aa.ParentId,aa.Name,
r1.Id,ContractAmount,PartyA,PartyA_Guid,PartyB,PartyB_Guid,ExecutorName,r1.RegDate,r1.RegHumId,r1.Status,r1.Memo,Title,r1.Code 
from KFQ_QX_ClassifyTree aa
left join KFQ_ContractSc r1 on aa.Id = r1.ClassifyTree_Id 
where r1.Status=50

