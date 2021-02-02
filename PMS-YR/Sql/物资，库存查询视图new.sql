

/****** Object:  View [dbo].[V_PS_PUR_ContractItemStoreBalance]    Script Date: 2018-1-4 16:44:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter VIEW [dbo].[V_PS_PUR_ContractItemStoreBalance] ---采购合同查询  
as  
SELECT a.*,b.MatCode,b.MatLongName,b.MatShortName,b.MatUnit,b.Specifi,b.Standard,b.Texture,b.Pattern,  
c.LongCode,c.MatBSName pinming,d.MatBSName xiaolei,e.MatBSName zhonglei,f.MatBSName dalei  ,g.StorageName
FROM dbo.PS_PUR_MatStoreBalance a LEFT JOIN (select MatCode,MatModel as MatLongName,matName as MatShortName,MatUnit,Specifi,Standard,Texture,Pattern,Mat_Guid,MatBS_Guid from PS_CM_SubContract_MatItem) b
ON a.Mat_Guid= b.Mat_Guid  
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


