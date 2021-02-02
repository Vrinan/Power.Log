select distinct HumanId,DeptId,HumanCode,HumanName from SF_HumanCheckOnWork 
where Month={0} and Year={1} and DeptId in (select Id from PB_Department where id='{2}' or ParentId='{3}')
union
select distinct Id as HumanId,DeptId,Code,Name from PB_Human where Id not in (select distinct HumanId from SF_HumanCheckOnWork 
where Month={0} and Year={1} and DeptId in (select Id from PB_Department where id='{2}' or ParentId='{3}')) and DeptId='{2}'
select * from PB_Human

select distinct HumanId,DeptId,HumanCode,HumanName from 
SF_HumanCheckOnWork where Month=8 and Year=2018 and DeptId in 
(select Id from PB_Department where id='68f753b6-7ef7-42a8-a7a3-efc6068c740d' or ParentId='68f753b6-7ef7-42a8-a7a3-efc6068c740d')
union
select distinct Id as HumanId,DeptId,Code,Name from PB_Human where Id not in 
(select distinct HumanId from SF_HumanCheckOnWork where Month =8 and Year = 2018 and DeptId in 
(select Id from PB_Department where id = '68f753b6-7ef7-42a8-a7a3-efc6068c740d' or ParentId = '68f753b6-7ef7-42a8-a7a3-efc6068c740d'))  and 
 DeptId ='68f753b6-7ef7-42a8-a7a3-efc6068c740d' 
 



select * from PB_Human where DeptId='68f753b6-7ef7-42a8-a7a3-efc6068c740d'