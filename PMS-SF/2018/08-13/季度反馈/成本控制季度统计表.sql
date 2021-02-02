--成本计划表
--最新版禁止删除——完成

--成本控制季度统计表
select * from SF_YX_MonthReportSL
select * from SF_YX_MonthReportSL_dtl
select * from SF_YX_MonthReportSL_dtlChild

--建表
select * from SF_FK_EquipmentCostSchedule
select * from SF_FK_EquipmentCostSchedule_dtl

select * from SF_FK_EquipmentCostFeedback
select * from SF_FK_EquipmentCostFeedback_dtl

select 
a.EpsId,a.SceduleType,c.* 
from 
SF_FK_OtherCostSchedule a left join PB_DefaultField b on a.Id = b.DefaultFieldId left join  SF_FK_OtherCostSchedule_dtl c on a.Id=c.MasterId where b.Status=50 and a.IsNew='1'


Select a.EpsId,a.SceduleType,c.* From SF_FK_EquipmentCostSchedule a left join PB_DefaultField b on a.Id = b.DefaultFieldId left join  SF_FK_EquipmentCostSchedule_dtl c on a.Id=c.MasterId Where  b.Status=50 and a.IsNew='1' and  1=1  Order By  Code