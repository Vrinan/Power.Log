-- ©π§Õº‘§À„
--SF_DrawingBudget
--SF_DrawingBudget_dtl
select * from SF_DrawingBudget


select
 a.EstablishId,a.EstablishCode,a.EstablishName,a.EpsCode,a.EpsName,
b.ListId,b.ParentId,b.Sequ,b.Code,b.Name,b.Specifications,b.unit,b.Quantity,b.UnitPrice,b.Price,c.Quantity as CostQuantity,c.UnitPrice,c.Price as CostPrice
from
 SF_DrawingBudget a left join SF_DrawingBudget_dtl b on a.Id =b.MasterId 
left join SF_FK_EstablishCostSchedule_dtl c on b.ListId = c.Id
where
 a.Status=50
order by
EpsCode,Sequ

--View_FK_BudgetCost


select * from PB_Widget where id='c9ac92b0-6cda-4f27-9065-8f999d2f132d'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_View_SF_YX_RunProduction.htm


Select XCode_T1.* From 
(
Select a.EstablishId,a.EstablishCode,a.EstablishName,a.EpsCode,a.EpsName, 
b.ListId,b.ParentId,b.Sequ,b.Code,b.Name,b.Specifications,b.unit,b.Quantity,b.UnitPrice,b.Price,
c.Quantity as CostQuantity,c.UnitPrice as CostUnitPrice,c.Price as CostPrice, row_number() over(Order By EpsCode,b.Sequ) as rowNumber
 From SF_DrawingBudget a left join SF_DrawingBudget_dtl b on a.Id =b.MasterId 
 left join SF_FK_EstablishCostSchedule_dtl c on b.ListId = c.Id Where a.Status=50
) XCode_T1
 Where rowNumber Between 1 And 50