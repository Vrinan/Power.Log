alter view View_SF_HumanOverTime
as
select al.*,alr.Code,alr.Title,alr.HumCode,alr.HumName,alr.Department,alr.OverType,alr.OverRemark,alr.Position,alr.Mouth from SF_ZH_OverTime_list al
left join
SF_ZH_OverTime alr on al.MasterId= alr.Id where alr.Status=50

select * from SF_ZH_OverTime_list
select * from SF_ZH_OverTime

select * from SF_ZH_HumanOvertime
select * from SF_ZH_HumanOvertime_dtl

drop view View_SF_HumanOverTime