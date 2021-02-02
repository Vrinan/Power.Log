--项目统计
select * from PB_Widget where id='4e7dfde9-3c5d-442e-976a-ce7a15420ae0'
--/PowerPlat/FormXml/zh-CN/StdPortal/Win_PS_ProjectContractCenter.html
 select longcode,* from PLN_project where project_guid='4b5d4678-5f00-4eb6-b14d-61e6bfc01674'
select * from PLN_project where STATE=1 and project_guid in(select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))

select * from PB_BaseData where DataType='BD_ProjectState'
select * from PB_BaseDataList where BaseDataId='3D79A4AC-DA4F-45E4-8A67-D51879F87F63'

select FinalContractAmount  from PS_MK_ContractInfo where Status in (35,50) and EpsProjectId IN  (select project_guid from pln_project 
where (LongCode like '1.177.%' or LongCode='1.177') and state=0 ) 
