


ALTER VIEW [dbo].[View_XLX_PUR_InquirySupplie]
AS
SELECT   main.Status, main.RegHumId, main.RegHumName, main.RegDate, main.OwnProjId, main.OwnProjName, main.UpdDate, 
                main.Title, main.Id 

 AS MainId, main.Inquiry_Id, main.Inquiry_Name, main.SupplieId, main.Code, main.Name 

, 
                main.EName, main.ShortName, main.TypeName, main.ClassName, main.Address, main.PostCode, main.Linkman, 
                main.Phone, main.Email, list.Id 

 AS ListId, list.MatBS_Guid, list.MatBS_Code, list.MatBS_Name, list.MatId, list.MatCode, 
                list.MatName, list.Model,list.Specifi,list.Pattern, list.Standard, list.Texture, list.MatUnit, list.MatUnit2, list.Equ, list.Pressure, list.TaxRate, 
                list.Qty_Inquiry, list.MatPrice, list.MatMoney, list.DeliveryDate, list.Remark,list.RequestList_Id,cbs.CbsCode,cbs.CbsName,
				cbs.Id 

 as Cbs_Guid,request.DeviceName,request.UnitName
FROM      dbo.XLX_PUR_InquirySupplie AS main INNER JOIN
                dbo.XLX_PUR_InquirySupplie_List AS list ON main.Id 

 = list.FK 

				left join XLX_PUR_Request_List as request ON request.Id 

=list.RequestList_Id
				left join PS_CC_CBS as cbs ON request.CBS_Id=cbs.Id 


GO


