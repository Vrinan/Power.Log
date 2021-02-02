--成本计划
--1设备SF_FK_EquipmentCostSchedule
--3建筑SF_FK_EstablishCostSchedule
--2安装SF_FK_InstallCostSchedule
--6管理SF_FK_ManageCostSchedule
--1.2其他SF_FK_OtherCostSchedule

--费用科目
--select a.CbsClassCode as Code,a.CbsClassName as Name from SF_FK_CBS_Class a order by a.CbsClassCode





--alter table SF_FK_EquipmentCostSchedule add SceduleType nvarchar(100) null
--alter table SF_FK_EstablishCostSchedule add SceduleType nvarchar(100) null
--alter table SF_FK_InstallCostSchedule add SceduleType nvarchar(100) null
--alter table SF_FK_ManageCostSchedule add SceduleType nvarchar(100) null
--alter table SF_FK_OtherCostSchedule add SceduleType nvarchar(100) null

--delete from SF_FK_EquipmentCostSchedule
--delete from SF_FK_EquipmentCostSchedule_dtl
--delete from SF_FK_EstablishCostSchedule
--delete from SF_FK_EstablishCostSchedule_dtl
--delete from SF_FK_InstallCostSchedule
--delete from SF_FK_InstallCostSchedule_dtl
--delete from SF_FK_ManageCostSchedule
--delete from SF_FK_ManageCostSchedule_dtl
--delete from SF_FK_OtherCostSchedule
--delete from SF_FK_OtherCostSchedule_dtl

select * from SF_FK_EquipmentCostSchedule

