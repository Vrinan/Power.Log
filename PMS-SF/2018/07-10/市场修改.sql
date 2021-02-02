create view View_SF_DeptHumans
as
select a.Code,a.Id as Id, a.Name as Name,b.Id as HumanId,
b.Name as HumanName,c.Id as HumanAID,c.Name as HumanNameA from PB_Department a 
left join 
(select * from pb_human where PosiId in(
select Id from PB_Position  where (Name like '%部长%' or Name='国际_部门负责人') and Name not like '%副部长%')) b
on b.DeptId = a.Id 
left join
(select * from PB_Human where PosiId in(
select Id from PB_Position where Name like '%副总经理%')) c on c.DeptId = a.Id where a.Name<>'领导班子' 


select a.Code,a.Id,a.Name,
case when a.HumanId is null then 'E87B1084-180B-48DE-BFEA-0D80EACF7337' else a.HumanId end as HumanId,
case when a.HumanName is null then '刘佳鑫' else a.HumanName end as HumanName,
case when a.Name like '%站%' or a.Name='运行部' then 'CF990F95-5872-4D6F-9D60-7A263E9CEE2F'
     when a.Name = '安全环保部' or a.Name='项目管理部' or a.Name='设计部' then '10C90E39-5C25-406D-BF0D-9E3EEC2AAA69' 
	 when a.Name = '综合部' or a.Name='市场开发部' or a.Name='制造部' or a.Name='国际业务部' then 'FF528BB6-B2D8-4D47-8952-C69E987ADCB0' 
	 when a.Name = '财务部' or a.Name='合同管理部' or a.Name='招标采购部' then '1CB8AF7C-74A6-473C-9E7C-0C4251213684' 
	 else null end as HumanAID,
case when a.Name like '%站%' or a.Name='运行部' then '何玉福'
     when a.Name = '安全环保部' or a.Name='项目管理部' or a.Name='设计部' then '吴忠勇'
	 when a.Name = '综合部' or a.Name='市场开发部' or a.Name='制造部' or a.Name='国际业务部' then '雷东' 
	 when a.Name = '财务部' or a.Name='合同管理部' or a.Name='招标采购部' then '周兴卫' 
	 else null end as HumanNameA
from View_SF_DeptHumans a order by Code



select * from PB_Human where Code='1705'
select * from pb_human where PosiId in(
select Id from PB_Position  where Name like '%副总经理%')
--何玉福CF990F95-5872-4D6F-9D60-7A263E9CEE2F
--吴忠勇10C90E39-5C25-406D-BF0D-9E3EEC2AAA69
--周兴卫1CB8AF7C-74A6-473C-9E7C-0C4251213684
--雷东FF528BB6-B2D8-4D47-8952-C69E987ADCB0
select * from SF_RecruitmentDocumentsPlan_dtl
select * from PB_Department
select * from PB_Position
