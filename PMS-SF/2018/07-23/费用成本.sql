--alter table SF_FK_EquipmentCostSchedule_dtl add ParentId uniqueidentifier null
--alter table SF_FK_EquipmentCostSchedule_dtl add Code nvarchar(200) null
--alter table SF_FK_EstablishCostSchedule_dtl add ParentId uniqueidentifier null
--alter table SF_FK_EstablishCostSchedule_dtl add Code nvarchar(200) null
--alter table SF_FK_InstallCostSchedule_dtl add ParentId uniqueidentifier null
--alter table SF_FK_InstallCostSchedule_dtl add Code nvarchar(200) null
--alter table SF_FK_ManageCostSchedule_dtl add ParentId uniqueidentifier null
--alter table SF_FK_ManageCostSchedule_dtl add Code nvarchar(200) null
--alter table SF_FK_OtherCostSchedule_dtl add ParentId uniqueidentifier null
--alter table SF_FK_OtherCostSchedule_dtl add Code nvarchar(200) null


select * from SF_FK_EquipmentCostSchedule_dtl
select * from SF_FK_EstablishCostSchedule_dtl
select * from SF_FK_InstallCostSchedule_dtl
select * from SF_FK_ManageCostSchedule_dtl
select * from SF_FK_OtherCostSchedule_dtl


delete from SF_FK_EquipmentCostSchedule_dtl
delete from SF_FK_EstablishCostSchedule_dtl
delete from SF_FK_InstallCostSchedule_dtl
delete from SF_FK_ManageCostSchedule_dtl
delete from SF_FK_OtherCostSchedule_dtl
