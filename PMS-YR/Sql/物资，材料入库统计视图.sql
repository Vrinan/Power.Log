
ALTER VIEW [dbo].[V_PS_MatInStoreDtl]
AS
SELECT   b.Id, a.Code, a.InStoreDate, a.EpsProjId, c.Supplier, b.MatCode, b.MatName, b.MatDescription,b.Specifi,b.Standard,b.Texture,b.Pattern, b.MatUnit, b.UnitPrice, 
                b.InStoreNum, b.InStoreAmount
FROM      dbo.PS_PUR_MatInStore AS a INNER JOIN
                dbo.PS_PUR_MatInStore_Dtl AS b ON a.Id = b.MasterId INNER JOIN
                dbo.PS_PUR_ArrivalCheck AS c ON a.Arrival_Guid = c.Id where (a.Status=35 or a.Status=50)


GO


