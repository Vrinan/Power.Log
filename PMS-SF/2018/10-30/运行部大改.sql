--1
--调试问题反馈
select * from PB_Widget where id='2fe62a5c-6d97-4c6b-abeb-f7048c854cb3'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_DebugFeedback.htm

--2
--成本目标计划下发
select * from PB_Widget where id='4d8f71b2-419a-4cf0-a110-ceac11997696'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_RunCostPlan.htm
select * from PB_Widget where id='9d3c8b00-409a-43e4-bb57-f159b3714c85'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_SF_YX_RunCostPlan.htm
--alter table SF_YX_RunCostPlan add RegType nvarchar(10) null

--3
select * from PB_Widget where id='aa8687a2-36ac-41c6-a0b1-57f7a773690c'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_RunWeekPlan.htm

--生产月度计划-渗滤液处理量计划View_SF_MonthPlanSLY
select a.*,b.JinShui,b.WaiYunLiang,b.MoChanShuiLv,b.ChanShuiLv,b.HuiPeiLiang,b.ChanShengLiang,b.ZhiBiao 
from SF_YX_RunMonthPlan a right join SF_YX_RunMonthPlan_ShenLvYe b on a.Id= b.MasterId
where a.Status=50 order by a.Code

--生产月度计划-飞灰处理量计划View_SF_MonthPlanFH
select a.*,b.ChuLiLv,b.ZheHeJi,b.ShuiNi,b.YongDian,b.GongYeShui,b.HeGeLv,b.Remark
from SF_YX_RunMonthPlan a right join SF_YX_RunMonthPlan_FeiHui b on a.Id= b.MasterId
where a.Status=50 order by a.Code

select * from SF_YX_RunMonthPlan

--12
--设备季度反馈报表  加合计
select * from PB_Widget where id='59703ef1-f954-45a8-9064-27571630a7b6'
--/PowerPlat/FormXml/zh-CN/SF_FK/Win_SF_FK_EquipmentFeedBackReport.htm

--4设备检修周计划
select * from PB_Widget where id='22ee9872-830b-4770-b1d4-bc42462df39f'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_EquWeekCheck.htm
--SF_YX_EachWeekCheck


--5
select q.* from (
select '生产' as CheckType,a.Type,b.RunStation,b.StartDate,b.EndDate,a.Content,a.DtlMemo from SF_YX_EachWeekCheck_DtlProduce a left join SF_YX_EachWeekCheck b on a.MasterId = b.Id where b.Status=50
union
select '检修' as CheckType,a.Type,b.RunStation,b.StartDate,b.EndDate,a.Content,a.DtlMemo from SF_YX_EachWeekCheck_DtlOverhaul a left join SF_YX_EachWeekCheck b on a.MasterId = b.Id where b.Status=50
union
select '环保' as CheckType,a.Type,b.RunStation,b.StartDate,b.EndDate,a.Content,a.DtlMemo from SF_YX_EachWeekCheck_DtlEnviroment a left join SF_YX_EachWeekCheck b on a.MasterId = b.Id where b.Status=50
union
select '协助解决' as CheckType,a.Type,b.RunStation,b.StartDate,b.EndDate,a.Content,a.DtlMemo from SF_YX_EachWeekCheck_DtlCompany a left join SF_YX_EachWeekCheck b on a.MasterId = b.Id where b.Status=50
) q
order by RunStation,StartDate,EndDate




Select Count(*) From SF_YX_RunMonthPlan a right join SF_YX_RunMonthPlan_ShenLvYe b on a.Id= b.MasterId Where  a.Status=50   and RunStation like '%%' 