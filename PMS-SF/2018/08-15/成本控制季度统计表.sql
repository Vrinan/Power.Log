--成本计划表--SF_YX_MonthReportSL
--设备CostReport和FeedBackReport
select * from SF_FK_EquipmentCostSchedule
select * from SF_FK_EquipmentCostSchedule_dtl
select * from SF_FK_EquipmentCostFeedback
select * from SF_FK_EquipmentCostFeedback_dtl
--建筑
select * from SF_FK_EstablishCostSchedule
select * from SF_FK_EstablishCostSchedule_dtl
--安装
select * from SF_FK_InstallCostSchedule
select * from SF_FK_InstallCostSchedule_dtl
--管理
select * from SF_FK_ManageCostSchedule
select * from SF_FK_ManageCostSchedule_dtl
--其他
select * from SF_FK_OtherCostSchedule
select * from SF_FK_OtherCostSchedule_dtl

delete from SF_FK_EquipmentCostSchedule
delete from SF_FK_EquipmentCostSchedule_dtl
delete from SF_FK_EquipmentCostFeedback
delete from SF_FK_EquipmentCostFeedback_dtl

delete from SF_FK_EstablishCostSchedule
delete from SF_FK_EstablishCostSchedule_dtl
update SF_FK_EquipmentCostSchedule_dtl set FeedBackReport = null

