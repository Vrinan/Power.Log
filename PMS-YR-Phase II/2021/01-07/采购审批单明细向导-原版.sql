CREATE VIEW [dbo].[View_XLX_PUR_Request]
AS
SELECT   main.Id AS MainId, main.Status, main.RequestCode, main.Title, main.ProMajor, main.RequestDate, main.IsUrgency, 
                main.RegHumId, main.RegHumName, main.RegDate, main.EpsProjId, main.OwnProjId, main.OwnProjName, 
                main.ApprHumName, main.ApprDate, bomfile.Id as Bomfile_Id, list.Id AS ListId, list.MatBS_Guid, list.MatBS_Code, list.MatBS_Name, list.MatId, 
                list.MatCode, list.MatName, list.Model, list.Standard, list.Texture, list.MatUnit, list.MatUnit2, list.Equ, list.Pressure, 
                list.TaxRate, list.Qty_Bom, list.Qty_Requested, list.Qty_Req, list.BeginDate,list.Pattern,list.Specifi,list.EndDate, list.DeviceName, 
                list.UnitName, list.ProMajor AS ListProMajor, list.SpecFileId, list.SpecFileNo, list.SpecFileName, list.Remark,list.CBS_Name,XLXOrder.OrderCode,XLXOrder.Qty_Order, 
                list.UpdDate, list.TaskStatus, list.SenderId, list.SenderName, list.SendTime,LEFT(list.MatBS_Code,7) as midcode,list.BuyerId, list.BuyerName, list.BackId, 
                list.BackName, list.BackTime,list.CBS_Id,list.CBSPath,CASE when sub.XLX_Request_List_Id IS NULL or sub.XLX_Request_List_Id='00000000-0000-0000-0000-000000000000' or  sub.MatAmount<>list.Qty_Req 
				THEN '未生成合同' when sub.XLX_Request_List_Id IS NOT NULL AND sub.XLX_Request_List_Id<>'00000000-0000-0000-0000-000000000000' and sub.MatAmount=list.Qty_Req THEN '生成合同' END SubContractStatus,
				CASE when Inquiry.InquirySupplieStatus IS NULL or PSInquiry.InquirySupplieStatus is not null  THEN PSInquiry.InquirySupplieStatus 
				WHEN Inquiry.InquirySupplieStatus IS NOT NULL or PSInquiry.InquirySupplieStatus is null  THEN Inquiry.InquirySupplieStatus 
				WHEN Inquiry.InquirySupplieStatus IS NULL or PSInquiry.InquirySupplieStatus is null  THEN '' END InquirySupplieStatus
				
FROM      dbo.XLX_PUR_Request AS main INNER JOIN
                dbo.XLX_PUR_Request_List AS list ON main.Id = list.FK LEFT OUTER JOIN
                    (SELECT   main.OwnProjId, main.OwnProjName, main.InquirySupplieStatus, list.RequestList_Id
                     FROM      dbo.XLX_PUR_Inquiry AS main INNER JOIN
                                     dbo.XLX_PUR_Inquiry_MatList AS list ON main.Id = list.FK
                     WHERE   (ISNULL(main.InquirySupplieStatus, N'') = '采购审批已生成' or ISNULL(main.InquirySupplieStatus, N'') = '采购审批已批准')) AS Inquiry ON list.Id = Inquiry.RequestList_Id
					 LEFT OUTER JOIN
                    (SELECT   main.OwnProjId, main.OwnProjName, main.InquirySupplieStatus, list.XLX_Request_List_Id
                     FROM      dbo.PS_BID_Inquiry AS main INNER JOIN
                                     dbo.PS_BID_Inquiry_MatList AS list ON main.Id = list.MasterId
                     WHERE   (ISNULL(main.InquirySupplieStatus, N'') = '竞价方案已生成' or ISNULL(main.InquirySupplieStatus, N'') = '竞价方案已批准')) AS PSInquiry ON list.Id = PSInquiry.XLX_Request_List_Id
					  LEFT OUTER JOIN
                    (SELECT   main.OrderCode, list.InquiryMatList_Id,list.Qty_Order
                     FROM      dbo.XLX_PUR_Order AS main INNER JOIN
                                     dbo.XLX_PUR_Order_list AS list ON main.Id = list.FK where main.BuyWay !='05') AS XLXOrder ON list.Id = XLXOrder.InquiryMatList_Id
					 left join PS_CM_SubContract_MatItem sub on sub.XLX_Request_List_Id = list.Id
					 left join PS_PUR_BOMFile bomfile on bomfile.Id = (select MasterId from PS_PUR_BOM where PS_PUR_BOM.id=list.BOMId)
					  group by main.Id, main.Status, main.RequestCode, main.Title, main.ProMajor, main.RequestDate, main.IsUrgency, 
                main.RegHumId, main.RegHumName, main.RegDate, main.EpsProjId, main.OwnProjId, main.OwnProjName, 
                main.ApprHumName, main.ApprDate, list.Id , list.MatBS_Guid, list.MatBS_Code, list.MatBS_Name, list.MatId, 
                list.MatCode, list.MatName, list.Model, list.Standard, list.Texture, list.MatUnit, list.MatUnit2, list.Equ, list.Pressure, 
                list.TaxRate, list.Qty_Bom, list.Qty_Requested, list.Qty_Req, list.BeginDate,list.Pattern,list.Specifi,list.EndDate, list.DeviceName, 
                list.UnitName, list.ProMajor , list.SpecFileId, list.SpecFileNo, list.SpecFileName, list.Remark,list.CBS_Name, OrderCode,
                list.UpdDate, list.TaskStatus, list.SenderId, list.SenderName, list.SendTime,list.MatBS_Code,list.BuyerId, list.BuyerName, list.BackId, XLXOrder.Qty_Order, 
                list.BackName, list.BackTime, Inquiry.InquirySupplieStatus,list.CBS_Id,list.CBSPath,sub.XLX_Request_List_Id,PSInquiry.InquirySupplieStatus,bomfile.Id,sub.MatAmount





select count(*) from View_XLX_PUR_Request where MatCode='1100202200237'
