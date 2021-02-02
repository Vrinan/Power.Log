select
 a.EstablishId,a.EstablishCode,a.EstablishName,a.EpsCode,a.EpsName,
b.ListId,b.ParentId,b.Sequ,b.Code,b.Name,b.Specifications,b.unit,b.Quantity,b.UnitPrice,b.Price,c.Quantity as CostQuantity,c.UnitPrice as CostUnitPrice,c.Price as CostPrice
from
 SF_DrawingBudget a left join SF_DrawingBudget_dtl b on a.Id =b.MasterId 
left join SF_FK_EstablishCostSchedule_dtl c on b.ListId = c.Id
where
 a.Status=50
order by
EpsCode,b.Sequ

--安庆土建成本
--江津区双宝城市生活垃圾卫生填埋场渗滤液项目建筑成本计划
select 
a.EpsId,a.EpsCode,a.EpsName,
b.Id,b.ParentId,b.Sequ,b.Code,b.Name,b.Specifications,b.unit,b.Quantity,b.UnitPrice,b.Price,c.allPrce,c.ListId
from SF_FK_EstablishCostSchedule a left join PB_DefaultField asta on a.Id = asta.DefaultFieldId  left join SF_FK_EstablishCostSchedule_dtl b on a.Id = b.MasterId
left join 
(
select a.Status,sum(b.Price) as allPrce,b.ListId from SF_DrawingBudget a left join SF_DrawingBudget_dtl b on a.Id = b.MasterId where a.Status=50 group by a.Status,b.ListId
) c on b.Id = c.ListId 
where asta.Status=50




