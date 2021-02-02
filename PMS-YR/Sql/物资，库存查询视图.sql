



ALTER VIEW [dbo].[V_PS_PUR_MatStoreBalance] ---ø‚¥Ê≤È—Ø  
as  
SELECT a.*,b.MatCode,b.MatLongName,b.MatShortName,b.MatUnit,b.Specifi,b.Standard,b.Texture,b.Pattern,  
c.LongCode,c.MatBSName pinming,d.MatBSName xiaolei,e.MatBSName zhonglei,f.MatBSName dalei  ,g.StorageName
FROM dbo.PS_PUR_MatStoreBalance a LEFT JOIN dbo.PS_MDM_Mat b  
ON a.Mat_Guid= b.Id  
LEFT JOIN dbo.PS_MDM_MatBS c  
ON b.MatBS_Guid= c.Id  
LEFT JOIN PS_MDM_MatBS d  
ON LEFT(c.LongCode,10) = d.LongCode  
LEFT JOIN PS_MDM_MatBS e  
ON LEFT(c.LongCode,7) = e.LongCode  
LEFT JOIN PS_MDM_MatBS f  
ON LEFT(c.LongCode,4) = f.LongCode 
LEFT JOIN PS_MDM_Storage g
ON g.Id=a.Storage_Guid



GO


