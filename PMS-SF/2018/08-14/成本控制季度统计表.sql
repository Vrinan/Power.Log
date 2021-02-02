--成本计划表
--最新版禁止删除——完成

--成本控制季度统计表
select * from SF_YX_MonthReportSL
select * from SF_YX_MonthReportSL_dtl
select * from SF_YX_MonthReportSL_dtlChild

select * from SF_FK_EquipmentCostSchedule
select * from SF_FK_EquipmentCostSchedule_dtl
select * from SF_FK_EquipmentCostFeedback
select * from SF_FK_EquipmentCostFeedback_dtl

alter table SF_FK_EquipmentCostFeedback_dtl drop column SeasonReport
alter table SF_FK_EquipmentCostFeedback_dtl add SeasonReport nvarchar(max) null

--delete from SF_FK_EquipmentCostSchedule
--delete from SF_FK_EquipmentCostSchedule_dtl
delete from SF_FK_EquipmentCostFeedback
delete from SF_FK_EquipmentCostFeedback_dtl

select * from SF_FK_EquipmentCostSchedule_dtl where id in(select ListId from SF_FK_EquipmentCostFeedback_dtl)

[{"UnitPrice":22.6688,"Quantity":4.0,"SeasonReport":"4","Price":90.6752}]
[{"UnitPrice":4.90952,"Quantity":4.0,"SeasonReport":"4","Price":19.63808},{"UnitPrice":4.90952,"Quantity":6.0,"SeasonReport":"6","Price":29.45712}]
[{"UnitPrice":4.90952,"Quantity":4.0,"SeasonReport":"4","Price":19.63808},{"UnitPrice":4.90952,"Quantity":6.0,"SeasonReport":"6","Price":29.45712},{"UnitPrice":4.90952,"Quantity":5.0,"SeasonReport":"5","Price":24.5476}]



Select A.* From  SF_FK_EquipmentCostFeedback_dtl A Where   (0=0)  and A.MasterId='8c346844-f498-47c3-8a11-69cd7b6e4266' 
Select A.* From  SF_FK_EquipmentCostFeedback_dtl A Where   (0=0)  and A.MasterId='8c346844-f498-47c3-8a11-69cd7b6e4266' and 1=0
Select * From SF_FK_EquipmentCostFeedback a Where a.Id='606f8db2-24b2-4f21-9c57-a6fc58c4e088'
Select A.* From  SF_FK_EquipmentCostFeedback_dtl A Where   (0=0)  and A.MasterId='606f8db2-24b2-4f21-9c57-a6fc58c4e088' and 1=1 