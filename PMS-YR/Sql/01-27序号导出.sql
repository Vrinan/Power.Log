alter VIEW [dbo].[View_XLX_PUR_InquirySupplie]
AS
SELECT   main.Status, main.RegHumId, main.RegHumName, main.RegDate, main.OwnProjId, main.OwnProjName, main.UpdDate, 
                main.Title, main.Id 

 AS MainId, main.Inquiry_Id, main.Inquiry_Name, main.SupplieId, main.Code, main.Name 

, 
                main.EName, main.ShortName, main.TypeName, main.ClassName, main.Address, main.PostCode, main.Linkman, 
                main.Phone, main.Email, list.Id 

 AS ListId, list.MatBS_Guid,list.sequ, list.MatBS_Code, list.MatBS_Name, list.MatId, list.MatCode, 
                list.MatName, list.Model,list.Specifi,list.Pattern, list.Standard, list.Texture, list.MatUnit, list.MatUnit2, list.Equ, list.Pressure, list.TaxRate, 
                list.Qty_Inquiry, list.MatPrice, list.MatMoney,list.GoodsMatPrice, list.GoodsMatMoney, list.DeliveryDate, list.Remark,list.RequestList_Id,cbs.CbsCode,cbs.CbsName,
				cbs.Id 

 as Cbs_Guid,request.DeviceName,request.UnitName,requestbbs.RequestCode as RequestCode1,requestbbs.Id as Request_Id1
FROM      dbo.XLX_PUR_InquirySupplie AS main INNER JOIN
                dbo.XLX_PUR_InquirySupplie_List AS list ON main.Id = list.FK 

				left join XLX_PUR_Request_List as request ON request.Id =list.RequestList_Id
				left join XLX_PUR_Request as requestbbs on requestbbs.Id = request.FK
				left join PS_CC_CBS as cbs ON request.CBS_Id=cbs.Id 

select * from XLX_PUR_Inquiry
select * from XLX_PUR_Inquiry_MatList
select * from XLX_PUR_InquirySupplie
select * from XLX_PUR_InquirySupplie_List
select * from XLX_PUR_Inquiry_SupplieList

select sequ,* from View_XLX_PUR_InquirySupplie