USE [PowerPMS_0204]
GO

/****** Object:  View [dbo].[V_PS_Purchase]    Script Date: 2018-2-28 16:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [dbo].[V_PS_Purchase]        
as   

select case
when bomfile.Status <> '20' and bomfile.Status <> '50' and b.Request_Code is null then '已发起申请'
when bomfile.Status = '20' and b.Request_Code is null then '已发起申请'
when (bomfile.Status = '50' and b.Request_Code is null and g.Subcontract_Code is null) or (b.Request_Status = '0' and c.Order_Code is null and g.Subcontract_Code is null) then '申请已通过'
when (b.Request_Status <> '50' and b.Request_Status <> '99') and c.Order_Code is null and g.Subcontract_Code is null then '已发起请购'
when (b.Request_Status = '50' or b.Request_Status = '99') and c.Order_Code is null and g.Subcontract_Code is null then '请购已通过'
when c.Order_Status = '0' and (d.Inquiry_Code is null and e.PSInquiry_Code is null) then '已分包'
when c.Order_Status = '50' and (d.Inquiry_Code is null and e.PSInquiry_Code is null) then '分包已批准'
when (datediff(day, d.Inquiry_CreateDate ,c.Order_RegDate)>9 and d.Inquiry_Status <> '50') or (datediff(day, getdate() ,c.Order_RegDate)>9 and d.Inquiry_Status <> '50') or (Inquiry_Status = '0' and g.Subcontract_Code is null) then '采购审批超期未发'
when d.Inquiry_Status = '20' and g.Subcontract_Code is null then '采购审批已发起'
when (d.Inquiry_Status = '50' and g.Subcontract_Code is null) or (e.PSInquiry_Status = '0' and f.XLXBidInquiry_Code is null) then '采购审批已通过'
when e.PSInquiry_Status = '20' and f.XLXBidInquiry_Code is null then '招标方案已提交'
when (e.PSInquiry_Status = '50' and f.XLXBidInquiry_Code is null) or (f.XLXBidInquiry_Status = '0' and g.Subcontract_Code is null) then '招标方案已通过'
when f.XLXBidInquiry_Status = '20' and g.Subcontract_Code is null then '招标报告已提交'
when (f.XLXBidInquiry_Status = '50' and g.Subcontract_Code is null) or (g.Subcontract_Status ='0' and h.ArrivalCheck_Code is null) then '招标报告已通过'
when g.Subcontract_Status ='20' and h.ArrivalCheck_Code is null then '采购合同已提交'
when g.Subcontract_Status ='50' and h.ArrivalCheck_Code is null then '采购合同已通过'
when ((g.Subcontract_listrequireDate>getdate() or h.ArrivalCheck_Code is null) and g.Subcontract_Code is not null) or (h.ArrivalCheck_Status = '0' and i.MatInStore_Code is null) then '到货延迟'
when h.ArrivalCheck_Status = '20' and i.MatInStore_Code is null then '已到货'
when (h.ArrivalCheck_Status = '50' and i.MatInStore_Code is null) or (i.MatInStore_Status = '0' or i.MatInStore_Status = '20') then '到货完成'
when i.MatInStore_Status = '50' and g.Subcontract_listMatAmount > g.Subcontract_listArrivalNum then '已入库'
when i.MatInStore_Status = '50' and g.Subcontract_listMatAmount <= g.Subcontract_listArrivalNum then '已完全入库'
else '' end as PurchaseStatus, 
bomfile.Status as Bom_Status,bomfile.Id as Bomfile_Id,bomfile.Code as Bomfile_Code,bomfile.RegHumName as Bomfile_RegHumName,bom.Matcode as Bom_MatCode,bom.MatName as Bom_MatName,bom.MatDescription as Bom_MatDescription,bom.Pattern as Bom_Pattern,bom.Specifi as Bom_Specifi,bom.MatUnit as Bom_MatUnit,bom.Pur_Major as Bom_PurMajor,bom.Design_Qty as Bom_DesignQty,CONVERT(varchar(100), bomfile.RegDate, 23) as bomfile_RegDate,CONVERT(varchar(100), Bomfilepwfinfo.CreateDate, 23) as Bom_CreateDate,CONVERT(varchar(100), Bomfilepwfinfo.FinishDate, 23) as Bom_FinishDate,
b.Request_Status,b.Request_Id,b.Request_Code,b.BizAreaId,b.EpsProjId,b.Request_listCBSName,b.Request_listQtyReq,b.Request_CreateDate,b.Request_FinishDate,b.Request_listRemark,
c.Order_Id,c.Order_Status,c.Order_Code,c.Order_RegHuman,c.Order_RegDate,
d.Inquiry_Id,d.Inquiry_Status,d.Inquiry_Code,d.Inquiry_CreateDate,d.Inquiry_FinishDate,
e.PSInquiry_Id,e.PSInquiry_Status,e.PSInquiry_Code,e.PSInquiry_CreateDate,e.PSInquiry_FinishDate,
f.XLXBidInquiry_Id,f.XLXBidInquiry_Status,f.XLXBidInquiry_Code,f.XLXBidInquiry_CreateDate,f.XLXBidInquiry_FinishDate,
g.Subcontract_Id,g.Subcontract_Status,g.Subcontract_Code,g.Subcontract_listrequireDate,g.Subcontract_listMatAmount,g.Subcontract_listArrivalNum,g.Subcontract_PartyB,g.Subcontract_CreateDate,g.Subcontract_FinishDate,
h.ArrivalCheck_Id,h.ArrivalCheck_Status,h.ArrivalCheck_Code,h.ArrivalCheck_CreateDate,h.ArrivalCheck_FinishDate,
i.MatInStore_Id,i.MatInStore_Status,i.MatInStore_Code,i.MatInStore_RegDate,i.MatInStore_CreateDate,i.MatInStore_FinishDate
from ps_pur_bomfile bomfile inner join ps_pur_bom bom on bomfile.id=bom.MasterId left join pwf_Infos Bomfilepwfinfo on bomfile.Id = Bomfilepwfinfo.KeyValue
left join 
(select Request.Status as Request_Status,Request.BizAreaId as BizAreaId,Request.EpsProjId as EpsProjId,Request.RequestCode as Request_Code,Request.Id as Request_Id,Request_list.Id as Request_listId,Request_list.BomID as Request_listBomID,Request_list.CBS_Name as Request_listCBSName,Request_list.Remark as Request_listRemark,Request_list.Qty_Req as Request_listQtyReq,Requestpwfinfo.CreateDate as Request_CreateDate,Requestpwfinfo.FinishDate as Request_FinishDate from xlx_pur_request Request
inner join xlx_pur_request_list Request_list on Request.Id = Request_list.FK left join pwf_Infos Requestpwfinfo on Request.Id = Requestpwfinfo.KeyValue) as b on b.Request_listBomID = bom.Id
left join
(select OrderMain.Id as Order_Id,OrderMain.Status as Order_Status,OrderMain.OrderCode as Order_Code,OrderMain.RegHumName as Order_RegHuman,OrderMain.RegDate as Order_RegDate,Order_list.Id as Order_listId,Order_list.inquiryMatList_Id as Order_listinquiryMatList_Id from xlx_pur_order OrderMain
inner join xlx_pur_order_list Order_list on OrderMain.Id =Order_list.fk) as c on c.Order_listinquiryMatList_Id = b.Request_listId
left join
(select Inquiry.Id as Inquiry_Id,Inquiry.Status as Inquiry_Status,Inquiry.InquiryCode as Inquiry_Code,Inquiry_list.Id as Inquiry_listId,Inquiry_list.requestlist_id as Inquiry_listrequestlist_id,Inquirypwfinfo.CreateDate as Inquiry_CreateDate,Inquirypwfinfo.FinishDate as Inquiry_FinishDate from XLX_PUR_Inquiry Inquiry
inner join XLX_PUR_Inquiry_matlist Inquiry_list on Inquiry.Id =Inquiry_list.FK left join pwf_Infos Inquirypwfinfo on Inquiry.Id = Inquirypwfinfo.KeyValue) as d on d.Inquiry_listrequestlist_id = b.Request_listId
left join
(select PSInquiry.Id as PSInquiry_Id,PSInquiry.Status as PSInquiry_Status,PSInquiry.Code as PSInquiry_Code,PSInquiry_list.Id as PSInquiry_listId,PSInquiry_list.xlx_request_list_id as PSInquiry_listxlx_request_list_id,PSInquirypwfinfo.CreateDate as PSInquiry_CreateDate,PSInquirypwfinfo.FinishDate as PSInquiry_FinishDate from PS_bid_Inquiry PSInquiry
inner join PS_bid_Inquiry_matlist PSInquiry_list on PSInquiry.Id =PSInquiry_list.masterid left join pwf_Infos PSInquirypwfinfo on PSInquiry.Id = PSInquirypwfinfo.KeyValue) as e on e.PSInquiry_listxlx_request_list_id = b.Request_listId
left join
(select XLXBidInquiry.Id as XLXBidInquiry_Id,XLXBidInquiry.Status as XLXBidInquiry_Status,XLXBidInquiry.Code as XLXBidInquiry_Code,XLXBidInquiry_list.Id as XLXBidInquiry_listId,XLXBidInquiry_list.xlx_request_list_id as XLXBidInquiry_listxlx_request_list_id,XLXBidInquirypwfinfo.CreateDate as XLXBidInquiry_CreateDate,XLXBidInquirypwfinfo.FinishDate as XLXBidInquiry_FinishDate from XLX_PS_BID_Inquiry XLXBidInquiry
inner join XLX_PS_BID_Inquiry_matlist XLXBidInquiry_list on XLXBidInquiry.Id =XLXBidInquiry_list.masterid left join pwf_Infos XLXBidInquirypwfinfo on XLXBidInquiry.Id = XLXBidInquirypwfinfo.KeyValue) as f on f.XLXBidInquiry_listxlx_request_list_id = b.Request_listId
left join
(select Subcontract.Id as Subcontract_Id,Subcontract.Status as Subcontract_Status,Subcontract.SubcontractCode as Subcontract_Code,Subcontract.PartyB as Subcontract_PartyB,Subcontract_list.Id as Subcontract_listId,Subcontract_list.xlx_request_list_id as Subcontract_listxlx_request_list_id,Subcontract_list.requireDate as Subcontract_listrequireDate,Subcontract_list.MatAmount as Subcontract_listMatAmount,Subcontract_list.ArrivalNum as Subcontract_listArrivalNum,Subcontractpwfinfo.CreateDate as Subcontract_CreateDate,Subcontractpwfinfo.FinishDate as Subcontract_FinishDate from ps_cm_subcontract Subcontract
inner join ps_cm_subcontract_matitem Subcontract_list on Subcontract.Id =Subcontract_list.masterid left join pwf_Infos Subcontractpwfinfo on Subcontract.Id = Subcontractpwfinfo.KeyValue) as g on g.Subcontract_listxlx_request_list_id = b.Request_listId
left join
(select ArrivalCheck.Id as ArrivalCheck_Id,ArrivalCheck.Status as ArrivalCheck_Status,ArrivalCheck.Code as ArrivalCheck_Code,ArrivalCheck_list.Id as ArrivalCheck_listId,ArrivalCheck_list.contractlistid as ArrivalCheck_listContractlist_id  ,ArrivalCheckpwfinfo.CreateDate as ArrivalCheck_CreateDate,ArrivalCheckpwfinfo.FinishDate as ArrivalCheck_FinishDate from PS_PUR_ArrivalCheck ArrivalCheck
inner join PS_pur_ArrivalCheck_Dtl ArrivalCheck_list on ArrivalCheck.Id =ArrivalCheck_list.masterid left join pwf_Infos ArrivalCheckpwfinfo on ArrivalCheck.Id = ArrivalCheckpwfinfo.KeyValue) as h on h.ArrivalCheck_listContractlist_id = g.Subcontract_listId
left join
(select MatInStore.Id as MatInStore_Id,MatInStore.Status as MatInStore_Status,MatInStore.Code as MatInStore_Code,MatInStore.RegDate as MatInStore_RegDate,MatInStore_list.Id as MatInStore_listId,MatInStore_list.Arrivalmat_guid as MatInStore_listArrivalmat_guid,MatInStorepwfinfo.CreateDate as MatInStore_CreateDate,MatInStorepwfinfo.FinishDate as MatInStore_FinishDate from PS_PUR_MatInStore MatInStore
inner join PS_PUR_MatInStore_dtl MatInStore_list on MatInStore.Id =MatInStore_list.masterid left join pwf_Infos MatInStorepwfinfo on MatInStore.Id = MatInStorepwfinfo.KeyValue) as i on i.MatInStore_listArrivalmat_guid = h.ArrivalCheck_listId


GO


