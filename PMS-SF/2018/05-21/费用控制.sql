--费控管理
--alter table SF_FK_OtherCostSchedule add Total float null
--alter table SF_FK_InstallCostSchedule add Total float null
--alter table SF_FK_EquipmentCostSchedule add Total float null
--alter table SF_FK_ManageCostSchedule add Total float null
--alter table SF_FK_EstablishCostSchedule add Total float null

--alter table SF_FK_OtherCostSchedule alter column Version nvarchar(100) null
--alter table SF_FK_InstallCostSchedule alter column Version nvarchar(100) null
--alter table SF_FK_EquipmentCostSchedule alter column Version nvarchar(100) null
--alter table SF_FK_ManageCostSchedule alter column Version nvarchar(100) null
--alter table SF_FK_EstablishCostSchedule alter column Version nvarchar(100) null

--alter table SF_FK_OtherCostSchedule add IsNew int null
--alter table SF_FK_InstallCostSchedule add IsNew int null
--alter table SF_FK_EquipmentCostSchedule add IsNew int null
--alter table SF_FK_ManageCostSchedule add IsNew int null
--alter table SF_FK_EstablishCostSchedule add IsNew int null
delete from SF_FK_OtherCostSchedule
delete from SF_FK_InstallCostSchedule
delete from SF_FK_EquipmentCostSchedule
delete from SF_FK_ManageCostSchedule
delete from SF_FK_EstablishCostSchedule

delete from SF_FK_OtherCostSchedule_dtl
delete from SF_FK_InstallCostSchedule_dtl
delete from SF_FK_EquipmentCostSchedule_dtl
delete from SF_FK_ManageCostSchedule_dtl
delete from SF_FK_EstablishCostSchedule_dtl

--delete from SF_FK_EstablishCostSchedule
select * from SF_FK_EquipmentCostSchedule

select * from SF_FK_ContractBudget
select * from SF_FK_ContractBudget_CBS
select * from SF_FK_CBS_Class

select * from PB_Widget where id='3ff4e469-c8f2-4ea4-8b94-d9510f8a4981'
--费用科目定义
--/PowerPlat/FormXml/zh-CN/StdCost/Win_PS_CBS_Class.htm
select * from PB_Widget where id='1702f11d-8856-4f8c-b0b1-42365ce8175b'
--企业知识分类-sf
--/PowerPlat/FormXml/zh-CN/SF_KM/Win_SF_KM_DocFolder.htm

--CBS窗体
select * from PB_Widget where id='4ff21e09-2356-44f3-be74-0e70a69beecf'
--项目预算CBS
--/PowerPlat/FormXml/zh-CN/SF_FK/Win_SF_FK_ContractBudget.htm

select * from PB_Widget where id='90944435-3671-4ab0-9174-5f8546638615'
--项目预算CBS
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_ContractBudget.htm
/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractBudget_CBS.htm

select * from SF_FK_ContractBudget
select * from SF_FK_EquipmentCostSchedule_dtl
select * from SF_FK_EquipmentCostSchedule

select * from SF_FK_EstablishCostSchedule_dtl
alter table SF_FK_OtherCostSchedule_dtl drop column EpsName
alter table SF_FK_OtherCostSchedule_dtl drop column EpsCode
alter table SF_FK_OtherCostSchedule_dtl add Memo nvarchar(500) null

delete from SF_FK_EstablishCostSchedule
update SF_FK_EstablishCostSchedule set IsNew=1
delete from SF_FK_EstablishCostSchedule_dtl

select * from SF_FK_CBS_Class
select * from SF_FK_EstablishCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId



--设备
select Isnull(sum(Price),0) as Amount from SF_FK_EquipmentCostSchedule_dtl where MasterId in(
select t1.Id from SF_FK_EquipmentCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1)

select t1.Total from SF_FK_EquipmentCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1
--安装
select Isnull(sum(Price),0) as Amount from SF_FK_InstallCostSchedule_dtl where MasterId in(
select t1.Id from SF_FK_InstallCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1)

select t1.Total from SF_FK_InstallCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1
--建筑
select Isnull(sum(Price),0) as Amount from SF_FK_EstablishCostSchedule_dtl where MasterId in(
select t1.Id from SF_FK_EstablishCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1)

select t1.Total from SF_FK_EstablishCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1
--管理
select Isnull(sum(Price),0) as Amount from SF_FK_ManageCostSchedule_dtl where MasterId in(
select t1.Id from SF_FK_ManageCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1)

select t1.Total from SF_FK_ManageCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1
--其他
select Isnull(sum(Price),0) as Amount from SF_FK_OtherCostSchedule_dtl where MasterId in(
select t1.Id from SF_FK_OtherCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1)

select t1.Total from SF_FK_OtherCostSchedule t1 left join PB_DefaultField t2 on t1.Id=t2.DefaultFieldId
where t1.EpsId='00000000-0000-0000-0000-0000000000A4' and t2.Status=50 and t1.IsNew=1

select * from SF_FK_CBS_Class
select * from SF_FK_ContractBudget_CBS
select * from SF_FK_ContractBudget
--Id Cbs_Guid
--ParentId Parent_Cbs_Guid
--CbsClassCode CbsCode
--CbsClassName CbsName
--delete from SF_FK_ContractBudget
--delete from SF_FK_ContractBudget_CBS