USE [PowerPMS_0204]
GO

/****** Object:  View [dbo].[V_PS_Purchase]    Script Date: 2018-2-7 10:22:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER VIEW [dbo].[V_PS_Purchase]        
as   

select case when d.Inquiry_Code is null and e.PSInquiry_Code is null and g.Subcontract_Code is null then '待采购' 
when (d.Inquiry_Code is not null or e.PSInquiry_Code is not null) and g.Subcontract_Code is null then '采购中' 
when g.Subcontract_Code is not null then '已采购'
else '' end as PurchaseStatus, 
bomfile.Id as Bomfile_Id,bomfile.Code as Bomfile_Code,bomfile.Title as Bomfile_Title,bom.Id as Bom_Id,bom.Matcode as Bom_MatCode,bom.MatName as Bom_MatName,bom.MatDescription as Bom_MatDescription,
b.Request_Id,b.Request_Code,b.Request_Name,b.Request_listId,b.Request_listBomID,b.Request_listMatName,b.Request_listModel,b.BizAreaId,b.EpsProjId,
c.Order_Id,c.Order_Code,c.Order_Name,c.Order_RegHuman,c.Order_listId,c.Order_listinquiryMatList_Id,
d.Inquiry_Id,d.Inquiry_Code,d.Inquiry_Name,d.Inquiry_listId,d.Inquiry_listrequestlist_id,
e.PSInquiry_Id,e.PSInquiry_Code,e.PSInquiry_Name,e.PSInquiry_listId,e.PSInquiry_listxlx_request_list_id,
f.XLXBidInquiry_Id,f.XLXBidInquiry_Code,f.XLXBidInquiry_Name,f.XLXBidInquiry_listId,f.XLXBidInquiry_listxlx_request_list_id,
g.Subcontract_Id,g.Subcontract_Code,g.Subcontract_Name,g.Subcontract_listId,g.Subcontract_listxlx_request_list_id,
h.ArrivalCheck_Id,h.ArrivalCheck_Code,h.ArrivalCheck_Name,h.ArrivalCheck_listId,h.ArrivalCheck_listContractlist_id,
i.MatInStore_Id,i.MatInStore_Code,i.MatInStore_Name,i.MatInStore_listId,i.MatInStore_listArrivalmat_guid,
j.MatRequisitions_Id,j.MatRequisitions_Code,j.MatRequisitions_Name,j.MatRequisitions_dtlId,j.MatRequisitions_dtlArrivalmat_guid,
k.MatOutStore_Id,k.MatOutStore_Code,k.MatOutStore_Name,k.MatOutStore_dtlId,k.MatOutStore_dtlrequisition_guid
from ps_pur_bomfile bomfile inner join ps_pur_bom bom on bomfile.id=bom.MasterId
left join 
(select Request.BizAreaId as BizAreaId,Request.EpsProjId as EpsProjId, Request.Id as Request_Id,Request.RequestCode as Request_Code,Request.Title as Request_Name,Request_list.Id as Request_listId,Request_list.BomID as Request_listBomID,Request_list.MatName as Request_listMatName,Request_list.Model as Request_listModel from xlx_pur_request Request
inner join xlx_pur_request_list Request_list on Request.Id =Request_list.FK) as b on b.Request_listBomID = bom.Id
left join
(select OrderMain.Id as Order_Id,OrderMain.OrderCode as Order_Code,OrderMain.Title as Order_Name,OrderMain.RegHumName as Order_RegHuman,Order_list.Id as Order_listId,Order_list.inquiryMatList_Id as Order_listinquiryMatList_Id from xlx_pur_order OrderMain
inner join xlx_pur_order_list Order_list on OrderMain.Id =Order_list.fk) as c on c.Order_listinquiryMatList_Id = b.Request_listId
left join
(select Inquiry.Id as Inquiry_Id,Inquiry.InquiryCode as Inquiry_Code,Inquiry.Title as Inquiry_Name,Inquiry_list.Id as Inquiry_listId,Inquiry_list.requestlist_id as Inquiry_listrequestlist_id from XLX_PUR_Inquiry Inquiry
inner join XLX_PUR_Inquiry_matlist Inquiry_list on Inquiry.Id =Inquiry_list.fk) as d on d.Inquiry_listrequestlist_id = b.Request_listId
left join
(select PSInquiry.Id as PSInquiry_Id,PSInquiry.Code as PSInquiry_Code,PSInquiry.Title as PSInquiry_Name,PSInquiry_list.Id as PSInquiry_listId,PSInquiry_list.xlx_request_list_id as PSInquiry_listxlx_request_list_id from PS_bid_Inquiry PSInquiry
inner join PS_bid_Inquiry_matlist PSInquiry_list on PSInquiry.Id =PSInquiry_list.masterid) as e on e.PSInquiry_listxlx_request_list_id = b.Request_listId
left join
(select XLXBidInquiry.Id as XLXBidInquiry_Id,XLXBidInquiry.Code as XLXBidInquiry_Code,XLXBidInquiry.Title as XLXBidInquiry_Name,XLXBidInquiry_list.Id as XLXBidInquiry_listId,XLXBidInquiry_list.xlx_request_list_id as XLXBidInquiry_listxlx_request_list_id from XLX_PS_BID_Inquiry XLXBidInquiry
inner join XLX_PS_BID_Inquiry_matlist XLXBidInquiry_list on XLXBidInquiry.Id =XLXBidInquiry_list.masterid) as f on f.XLXBidInquiry_listxlx_request_list_id = b.Request_listId
left join
(select Subcontract.Id as Subcontract_Id,Subcontract.SubcontractCode as Subcontract_Code,Subcontract.SubcontractName as Subcontract_Name,Subcontract_list.Id as Subcontract_listId,Subcontract_list.xlx_request_list_id as Subcontract_listxlx_request_list_id from ps_cm_subcontract Subcontract
inner join ps_cm_subcontract_matitem Subcontract_list on Subcontract.Id =Subcontract_list.masterid) as g on g.Subcontract_listxlx_request_list_id = b.Request_listId
left join
(select ArrivalCheck.Id as ArrivalCheck_Id,ArrivalCheck.Code as ArrivalCheck_Code,ArrivalCheck.Title as ArrivalCheck_Name,ArrivalCheck_list.Id as ArrivalCheck_listId,ArrivalCheck_list.contractlistid as ArrivalCheck_listContractlist_id from PS_PUR_ArrivalCheck ArrivalCheck
inner join PS_pur_ArrivalCheck_Dtl ArrivalCheck_list on ArrivalCheck.Id =ArrivalCheck_list.masterid) as h on h.ArrivalCheck_listContractlist_id = g.Subcontract_listId
left join
(select MatInStore.Id as MatInStore_Id,MatInStore.Code as MatInStore_Code,MatInStore.Title as MatInStore_Name,MatInStore_list.Id as MatInStore_listId,MatInStore_list.Arrivalmat_guid as MatInStore_listArrivalmat_guid from PS_PUR_MatInStore MatInStore
inner join PS_PUR_MatInStore_dtl MatInStore_list on MatInStore.Id =MatInStore_list.masterid) as i on i.MatInStore_listArrivalmat_guid = h.ArrivalCheck_listId
left join
(select MatRequisitions.Id as MatRequisitions_Id,MatRequisitions.Code as MatRequisitions_Code,MatRequisitions.Title as MatRequisitions_Name,MatRequisitions_dtl.Id as MatRequisitions_dtlId,MatRequisitions_dtl.Arrivalmat_guid as MatRequisitions_dtlArrivalmat_guid from PS_pur_MatRequisitions MatRequisitions
inner join ps_pur_MatRequisitions_dtl MatRequisitions_dtl on MatRequisitions.Id =MatRequisitions_dtl.masterid) as j on j.MatRequisitions_dtlArrivalmat_guid = bom.Id
left join
(select MatOutStore.Id as MatOutStore_Id,MatOutStore.Code as MatOutStore_Code,MatOutStore.Title as MatOutStore_Name,MatOutStore_dtl.Id as MatOutStore_dtlId,MatOutStore_dtl.requisition_guid as MatOutStore_dtlrequisition_guid from PS_pur_MatOutStore MatOutStore
inner join PS_pur_MatOutStore_dtl MatOutStore_dtl on MatOutStore.Id =MatOutStore_dtl.masterid) as k on k.MatOutStore_dtlrequisition_guid = j.MatRequisitions_dtlId





GO


select case when bomfile.Status = '15' and b.Request_Code is null then '已发起申请'
when bomfile.Status = '50' and b.Request_Code is null and g.Subcontract_Code is null then '申请已通过'
when b.Request_Status = '15' and c.Order_Code is null and g.Subcontract_Code is null then '已发起请购'
when b.Request_Status = '50' and c.Order_Code is null and g.Subcontract_Code is null then '请购已通过'
when c.Order_Status = '0' and (d.Inquiry_Code is null and e.PSInquiry_Code is null) then '已分包'
when c.Order_Status = '50' and (d.Inquiry_Code is null and e.PSInquiry_Code is null) then '分包已批准'
when d.Inquiry_Status = '15' and g.Subcontract_Code is null then '采购审批已发起'
when d.Inquiry_Status = '50' and g.Subcontract_Code is null then '采购审批已通过'
when e.PSInquiry_Status = '15' and f.XLXBidInquiry_Code is null then '招标方案已提交'
when e.PSInquiry_Status = '50' and f.XLXBidInquiry_Code is null then '招标方案已通过'
when f.XLXBidInquiry_Status = '15' and g.Subcontract_Code is null then '招标报告已提交'
when f.XLXBidInquiry_Status = '50' and g.Subcontract_Code is null then '招标报告已通过'
when g.Subcontract_Status ='15' and h.ArrivalCheck_Code is null then '采购合同已提交'
when g.Subcontract_Status ='50' and h.ArrivalCheck_Code is null then '采购合同已通过'
when (g.Subcontract_listrequireDate>getdate() or h.ArrivalCheck_Code is null) and g.Subcontract_Code is not null then '到货延迟'
when h.ArrivalCheck_Status = '15' and i.MatInStore_Code is null then '已到货'
when h.ArrivalCheck_Status = '50' and i.MatInStore_Code is null then '到货完成'
when h.ArrivalCheck_Status = '50' and i.MatInStore_Code is null then '到货完成'
when i.MatInStore_Status = '50' and g.Subcontract_listMatAmount > g.Subcontract_listArrivalNum then '已入库'
when i.MatInStore_Status = '50' and g.Subcontract_listMatAmount <= g.Subcontract_listArrivalNum then '已完全入库'
else '' end as PurchaseStatus, 
bomfile.Status as Bom_Status,bomfile.Id as Bomfile_Id,bomfile.Code as Bomfile_Code,bomfile.RegHumName as Bomfile_RegHumName,bomfile.Title as Bomfile_Title,bom.Id as Bom_Id,bom.Matcode as Bom_MatCode,bom.MatName as Bom_MatName,bom.MatDescription as Bom_MatDescription,bom.Pattern as Bom_Pattern,bom.Specifi as Bom_Specifi,bom.MatUnit as Bom_MatUnit,bom.Pur_Major as Bom_PurMajor,bom.Design_Qty as Bom_DesignQty,
b.Request_Status,b.Request_Id,b.Request_Code,b.Request_Name,b.Request_listId,b.Request_listBomID,b.BizAreaId,b.EpsProjId,b.Request_listCBSName,b.Request_listQtyReq,
c.Order_Status,c.Order_Id,c.Order_Code,c.Order_Name,c.Order_RegHuman,c.Order_listId,c.Order_listinquiryMatList_Id,
d.Inquiry_Status,d.Inquiry_Id,d.Inquiry_Code,d.Inquiry_Name,d.Inquiry_listId,d.Inquiry_listrequestlist_id,
e.PSInquiry_Status,e.PSInquiry_Id,e.PSInquiry_Code,e.PSInquiry_Name,e.PSInquiry_listId,e.PSInquiry_listxlx_request_list_id,
f.XLXBidInquiry_Status,f.XLXBidInquiry_Id,f.XLXBidInquiry_Code,f.XLXBidInquiry_Name,f.XLXBidInquiry_listId,f.XLXBidInquiry_listxlx_request_list_id,
g.Subcontract_Status,g.Subcontract_Id,g.Subcontract_Code,g.Subcontract_Name,g.Subcontract_listId,g.Subcontract_listxlx_request_list_id,g.Subcontract_listrequireDate,g.Subcontract_listMatAmount,g.Subcontract_listArrivalNum,g.Subcontract_PartyB,
h.ArrivalCheck_Status,h.ArrivalCheck_Id,h.ArrivalCheck_Code,h.ArrivalCheck_Name,h.ArrivalCheck_listId,h.ArrivalCheck_listContractlist_id,
i.MatInStore_Status,i.MatInStore_Id,i.MatInStore_Code,i.MatInStore_Name,i.MatInStore_listId,i.MatInStore_listArrivalmat_guid,
j.MatRequisitions_Status,j.MatRequisitions_Id,j.MatRequisitions_Code,j.MatRequisitions_Name,j.MatRequisitions_dtlId,j.MatRequisitions_dtlArrivalmat_guid,
k.MatOutStore_Status,k.MatOutStore_Id,k.MatOutStore_Code,k.MatOutStore_Name,k.MatOutStore_dtlId,k.MatOutStore_dtlrequisition_guid
from ps_pur_bomfile bomfile inner join ps_pur_bom bom on bomfile.id=bom.MasterId left join pwf_Infos Bomfilepwfinfo on bomfile.Id = Bomfilepwfinfo.KeyValue
left join 
(select Request.Status as Request_Status,Request.BizAreaId as BizAreaId,Request.EpsProjId as EpsProjId, Request.Id as Request_Id,Request.RequestCode as Request_Code,Request.Title as Request_Name,Request_list.Id as Request_listId,Request_list.BomID as Request_listBomID,Request_list.CBS_Name as Request_listCBSName,Request_list.Qty_Req as Request_listQtyReq from xlx_pur_request Request
inner join xlx_pur_request_list Request_list on Request.Id =Request_list.FK) as b on b.Request_listBomID = bom.Id
left join
(select OrderMain.Status as Order_Status,OrderMain.Id as Order_Id,OrderMain.OrderCode as Order_Code,OrderMain.Title as Order_Name,OrderMain.RegHumName as Order_RegHuman,Order_list.Id as Order_listId,Order_list.inquiryMatList_Id as Order_listinquiryMatList_Id from xlx_pur_order OrderMain
inner join xlx_pur_order_list Order_list on OrderMain.Id =Order_list.fk) as c on c.Order_listinquiryMatList_Id = b.Request_listId
left join
(select Inquiry.Status as Inquiry_Status,Inquiry.Id as Inquiry_Id,Inquiry.InquiryCode as Inquiry_Code,Inquiry.Title as Inquiry_Name,Inquiry_list.Id as Inquiry_listId,Inquiry_list.requestlist_id as Inquiry_listrequestlist_id from XLX_PUR_Inquiry Inquiry
inner join XLX_PUR_Inquiry_matlist Inquiry_list on Inquiry.Id =Inquiry_list.fk) as d on d.Inquiry_listrequestlist_id = b.Request_listId
left join
(select PSInquiry.Status as PSInquiry_Status,PSInquiry.Id as PSInquiry_Id,PSInquiry.Code as PSInquiry_Code,PSInquiry.Title as PSInquiry_Name,PSInquiry_list.Id as PSInquiry_listId,PSInquiry_list.xlx_request_list_id as PSInquiry_listxlx_request_list_id from PS_bid_Inquiry PSInquiry
inner join PS_bid_Inquiry_matlist PSInquiry_list on PSInquiry.Id =PSInquiry_list.masterid) as e on e.PSInquiry_listxlx_request_list_id = b.Request_listId
left join
(select XLXBidInquiry.Status as XLXBidInquiry_Status,XLXBidInquiry.Id as XLXBidInquiry_Id,XLXBidInquiry.Code as XLXBidInquiry_Code,XLXBidInquiry.Title as XLXBidInquiry_Name,XLXBidInquiry_list.Id as XLXBidInquiry_listId,XLXBidInquiry_list.xlx_request_list_id as XLXBidInquiry_listxlx_request_list_id from XLX_PS_BID_Inquiry XLXBidInquiry
inner join XLX_PS_BID_Inquiry_matlist XLXBidInquiry_list on XLXBidInquiry.Id =XLXBidInquiry_list.masterid) as f on f.XLXBidInquiry_listxlx_request_list_id = b.Request_listId
left join
(select Subcontract.Status as Subcontract_Status,Subcontract.Id as Subcontract_Id,Subcontract.SubcontractCode as Subcontract_Code,Subcontract.SubcontractName as Subcontract_Name,Subcontract.PartyB as Subcontract_PartyB,Subcontract_list.Id as Subcontract_listId,Subcontract_list.xlx_request_list_id as Subcontract_listxlx_request_list_id,Subcontract_list.requireDate as Subcontract_listrequireDate,Subcontract_list.MatAmount as Subcontract_listMatAmount,Subcontract_list.ArrivalNum as Subcontract_listArrivalNum from ps_cm_subcontract Subcontract
inner join ps_cm_subcontract_matitem Subcontract_list on Subcontract.Id =Subcontract_list.masterid) as g on g.Subcontract_listxlx_request_list_id = b.Request_listId
left join
(select ArrivalCheck.Status as ArrivalCheck_Status,ArrivalCheck.Id as ArrivalCheck_Id,ArrivalCheck.Code as ArrivalCheck_Code,ArrivalCheck.Title as ArrivalCheck_Name,ArrivalCheck_list.Id as ArrivalCheck_listId,ArrivalCheck_list.contractlistid as ArrivalCheck_listContractlist_id from PS_PUR_ArrivalCheck ArrivalCheck
inner join PS_pur_ArrivalCheck_Dtl ArrivalCheck_list on ArrivalCheck.Id =ArrivalCheck_list.masterid) as h on h.ArrivalCheck_listContractlist_id = g.Subcontract_listId
left join
(select MatInStore.Status as MatInStore_Status,MatInStore.Id as MatInStore_Id,MatInStore.Code as MatInStore_Code,MatInStore.Title as MatInStore_Name,MatInStore_list.Id as MatInStore_listId,MatInStore_list.Arrivalmat_guid as MatInStore_listArrivalmat_guid from PS_PUR_MatInStore MatInStore
inner join PS_PUR_MatInStore_dtl MatInStore_list on MatInStore.Id =MatInStore_list.masterid) as i on i.MatInStore_listArrivalmat_guid = h.ArrivalCheck_listId
left join
(select MatRequisitions.Status as MatRequisitions_Status,MatRequisitions.Id as MatRequisitions_Id,MatRequisitions.Code as MatRequisitions_Code,MatRequisitions.Title as MatRequisitions_Name,MatRequisitions_dtl.Id as MatRequisitions_dtlId,MatRequisitions_dtl.Arrivalmat_guid as MatRequisitions_dtlArrivalmat_guid from PS_pur_MatRequisitions MatRequisitions
inner join ps_pur_MatRequisitions_dtl MatRequisitions_dtl on MatRequisitions.Id =MatRequisitions_dtl.masterid) as j on j.MatRequisitions_dtlArrivalmat_guid = bom.Id
left join
(select MatOutStore.Status as MatOutStore_Status,MatOutStore.Id as MatOutStore_Id,MatOutStore.Code as MatOutStore_Code,MatOutStore.Title as MatOutStore_Name,MatOutStore_dtl.Id as MatOutStore_dtlId,MatOutStore_dtl.requisition_guid as MatOutStore_dtlrequisition_guid from PS_pur_MatOutStore MatOutStore
inner join PS_pur_MatOutStore_dtl MatOutStore_dtl on MatOutStore.Id =MatOutStore_dtl.masterid) as k on k.MatOutStore_dtlrequisition_guid = j.MatRequisitions_dtlId


