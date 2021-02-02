select * from SF_ZH_Allocation
select * from SF_ZH_Allocation_list


select a.Id,a.Name,a.PosiId,a.PosiName from PB_Human a
select * from PB_Department where name='运行部办公室（站）'
select * from PB_HumanRelation 

select a.Id,a.Name,a.PosiId,a.PosiName from PB_Human a where a.DeptId='31440F0E-7E09-4EE9-A99D-88A72B7040D7'



--查到所有部门Id
select distinct OldDeptId as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221'
union
select distinct 
case when DeptId ='BB3EC90C-C456-4449-BA2B-43EDF3C25D3B' then '3EDC4D0C-37EA-430D-9DEB-84533C14FCD6'
when DeptId ='D045F0D9-C9F2-4DC8-B5AB-15EEE958A186' then 'C08B71BB-83D8-4E27-BBF5-55F487A93669'
else DeptId end as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221'



--通过部门找到部门所有负责人
select a.Id,a.Name,a.PosiId,a.PosiName,b.IsDeptLeader from PB_Human a left join PB_HumanRelation b on a.Id = b.HumanId where b.IsDeptLeader='1' and  b.RelationId in(  select id from PB_Department where(id in(select distinct OldDeptId as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221' union select distinct DeptId as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221')or parentid in(select distinct OldDeptId as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221' union select distinct DeptId as deptId from SF_ZH_Allocation_list where MasterId='0dd6e124-6440-4bb4-a39e-f1bdcbfb6221'))) 





select * from PB_Human where Name='卓维'
select * from PB_Human where Name='陈居明'

select a.Id,a.Name,a.PosiId,a.PosiName,b.IsDeptLeader from PB_Human a left join PB_HumanRelation b on a.Id = b.HumanId where b.IsDeptLeader='1' and  b.RelationId = '31440f0e-7e09-4ee9-a99d-88a72b7040d7' 


Select * From SF_ZH_Allocation a Where a.Id='efdc192d-5f60-439c-912f-3b76f7d69ce3'


select * from SF_HumanCheckOnWork where masterid='' and DayTime=''