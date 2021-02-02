--alter table SF_YX_EquProduction add constraint Con_SF_YX_EquProduction unique (Date)
--delete from SF_YX_EquProduction
--delete from SF_YX_EquProduction_list
select * from SF_YX_EquProduction
select * from SF_YX_EquTechnology
select * from SF_YX_EquWaterTesting
select * from SF_YX_EquMedicine
select * from SF_YX_EquFlyingDust
alter table SF_YX_EquProduction drop column date
alter table SF_YX_EquProduction add date nvarchar(10)
alter table SF_YX_EquTechnology drop column date
alter table SF_YX_EquTechnology add date nvarchar(10)
alter table SF_YX_EquWaterTesting drop column date
alter table SF_YX_EquWaterTesting add date nvarchar(10)
alter table SF_YX_EquMedicine drop column date
alter table SF_YX_EquMedicine add date nvarchar(10)
alter table SF_YX_EquFlyingDust drop column date
alter table SF_YX_EquFlyingDust add date nvarchar(10)


select * from SF_YX_RunProduction
select * from SF_YX_RunTechnology
select * from SF_YX_RunWaterTesting
select * from SF_YX_RunMedicine
select * from SF_YX_RunFlyingDust

alter table SF_YX_RunProduction alter column Date nvarchar(10) null
alter table SF_YX_RunTechnology alter column Date nvarchar(10) null
alter table SF_YX_RunWaterTesting alter column Date nvarchar(10) null
alter table SF_YX_RunMedicine alter column Date nvarchar(10) null
alter table SF_YX_RunFlyingDust alter column Date nvarchar(10) null

select Id,MatBSName,MatBSCode from PS_MDM_MatBS where MatBSName like '%Œ¥∑÷¿‡%'