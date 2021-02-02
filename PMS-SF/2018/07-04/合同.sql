--进项-合同登记
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

select * from PB_Department where name='项目管理部'
select * from SF_HumanCheckOnWork
select distinct HumanId,DeptId,HumanCode,HumanName from SF_HumanCheckOnWork where Month=6 and Year=2018 and DeptId in
(select Id from PB_Department where id='BB3EC90C-C456-4449-BA2B-43EDF3C25D3B' or ParentId='bb3ec90c-c456-4449-ba2b-43edf3c25d3b')