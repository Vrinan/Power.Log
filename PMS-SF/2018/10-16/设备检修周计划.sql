--设备检修周计划汇总
create view View_SF_WeekCheck_dtl
as
select a.Id,a.Code,a.Title,a.RunStation,a.StartDate,a.EndDate, b.Description,b.Date,b.EndDate as DtlEndDate,b.Type,b.Remark,'next' as Which
from SF_YX_EquWeekCheck a right join SF_YX_EquWeekCheck_list b on a.Id = b.MasterId
where a.Status=50 and a.Type=0
union
select a.Id,a.Code,a.Title,a.RunStation,a.StartDate,a.EndDate,b.Description,b.Date,b.EndDate  as DtlEndDate,b.Type,b.Remark,'now' as Which
from SF_YX_EquWeekCheck a right join SF_YX_EquWeekCheck_dtl b on a.Id = b.MasterId
where a.Status=50 and a.Type=0


--检修班检修周计划汇总select a.Id,a.Code,a.Title,a.RunStation,a.StartDate,a.EndDate, b.Description,b.Date,b.EndDate as DtlEndDate,b.Type,b.Remark,'next' as Which
from SF_YX_EquWeekCheck a right join SF_YX_EquWeekCheck_list b on a.Id = b.MasterId
where a.Status=50 and a.Type=1
union
select a.Id,a.Code,a.Title,a.RunStation,a.StartDate,a.EndDate,b.Description,b.Date,b.EndDate  as DtlEndDate,b.Type,b.Remark,'now' as Which
from SF_YX_EquWeekCheck a right join SF_YX_EquWeekCheck_dtl b on a.Id = b.MasterId
where a.Status=50 and a.Type=1