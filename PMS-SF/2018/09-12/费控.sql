alter table SF_FK_EquipmentCostSchedule_dtl add FeedBackAmount numeric(18,2)
alter table SF_FK_EstablishCostSchedule_dtl add FeedBackAmount numeric(18,2)
alter table SF_FK_InstallCostSchedule_dtl add FeedBackAmount numeric(18,2)
alter table SF_FK_ManageCostSchedule_dtl add FeedBackAmount numeric(18,2)
alter table SF_FK_OtherCostSchedule_dtl add FeedBackAmount numeric(18,2)



select * from SF_FK_EquipmentCostSchedule
select * from SF_FK_EquipmentCostSchedule_dtl

select * from SF_FK_EquipmentCostFeedback
select * from SF_FK_EquipmentCostFeedback_dtl


select * from SF_FK_EquipmentCostSchedule_dtl where MasterId='9a0a64b6-62b6-4018-ab31-e4ae4c18a491'