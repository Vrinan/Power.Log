--�ɱ��ƻ���--SF_YX_MonthReportSL
--�豸CostReport��FeedBackReport
select * from SF_FK_EquipmentCostSchedule
select * from SF_FK_EquipmentCostSchedule_dtl
select * from SF_FK_EquipmentCostFeedback
select * from SF_FK_EquipmentCostFeedback_dtl
--����
select * from SF_FK_EstablishCostSchedule
select * from SF_FK_EstablishCostSchedule_dtl
--��װ
select * from SF_FK_InstallCostSchedule
select * from SF_FK_InstallCostSchedule_dtl
--����
select * from SF_FK_ManageCostSchedule
select * from SF_FK_ManageCostSchedule_dtl
--����
select * from SF_FK_OtherCostSchedule
select * from SF_FK_OtherCostSchedule_dtl

delete from SF_FK_EquipmentCostSchedule
delete from SF_FK_EquipmentCostSchedule_dtl
delete from SF_FK_EquipmentCostFeedback
delete from SF_FK_EquipmentCostFeedback_dtl

delete from SF_FK_EstablishCostSchedule
delete from SF_FK_EstablishCostSchedule_dtl
update SF_FK_EquipmentCostSchedule_dtl set FeedBackReport = null

