--·É»Ò
alter table SF_YX_RunFlyingDust_list add SNweight numeric(18,2) null

select * from SF_YX_RunFlyingDust

select
convert(varchar(100),a.Date,23) as Date,a.Department,b.Id,YHCLL,ZHJ_Use,ZHJ_Lave,UseWater,UsaeDian,SNweight,GHWCL,ZDL,WYL,KCL,QXH,CPHGL
from
SF_YX_RunFlyingDust a left join SF_YX_RunFlyingDust_list b on a.Id=b.MasterId