select * from ps_MDM_Mat a where 1=1 and a.MatBS_Guid in (select b.id from ps_MDM_MatBS b where b.LongCode like  '1%')


select MatBS_Guid from ps_MDM_Mat
select id,LongCode from ps_MDM_MatBS where LongCode like  '1%'

Select count(*) as RecordCount From PS_MDM_Mat A 
Where (0=0) and (0=0) and 1=1
and a.MatBS_Guid in (select b.id from ps_MDM_MatBS b where b.LongCode like  '1%')

Select count(*) as RecordCount From PS_MDM_Mat A 
Where (0=0) and (0=0) and 1=1
 or exists(select x1.Id from PS_MDM_MatBS x1 where A.MatBS_Guid=x1.Id 
 and (x1.LongCode='" + node.LongCode + "' or x1.LongCode like '"1.%'))

Select count(*) as RecordCount From PS_MDM_Mat A 
Where (0=0) and (0=0) and 1=1
and MatBS_Guid in (select x1.Id from PS_MDM_MatBS x1 where x1.LongCode 
like '1.%'  or x1.LongCode='" + treeNode.LongCode + "')
