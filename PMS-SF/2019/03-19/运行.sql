select * from PB_Widget where Id='c9ac92b0-6cda-4f27-9065-8f999d2f132d'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_View_SF_YX_RunProduction.htm


select
*,
--if(清液产量+浓液产量=0) then 1 
QingCL/ case when (QingCL+NongCL)=0 then 1 else (QingCL+NongCL) end  as MoCSL,
--if(原液系统进水 = 0) then 1
QingCL/case when YuanXTJS=0 then 1 else YuanXTJS end as CSL
from
(SELECT a.Date,a.Department,sum(b.SystemWater) as SystemWater,sum(b.YuanTJCCL) as YuanTJCCL,sum(b.YuanWY) as YuanWY,
sum(b.YuanXTJS) as YuanXTJS,sum(b.QingCL) as QingCL,
sum(b.NongCL) as NongCL,sum(b.NongHP) as NongHP,sum(b.NongWY) as NongWY,
sum(b.GanCL) as GanCL,sum(b.GanFS) as GanFS,sum(b.GanWW) as GanWW,sum(b.NiWW) as NiWW,
sum(b.NengD) as NengD,sum(b.NengS) as NengS
from SF_YX_RunProduction  a inner join SF_YX_RunProduction_list b on a.Id=b.MasterId group by a.Date,a.Department) RunProduction 
order by Date