alter table XLX_PUR_Order_List add QtyOrig_Order numeric(23,2) null



update XLX_PUR_Order_List set QtyOrig_Order = 
(
	select Qty_Req from XLX_PUR_Request_List where id=XLX_PUR_Order_List.InquiryMatList_Id
)


select * from XLX_PUR_Order_List where MatCode='1100202200237'

select * from View_XLX_PUR_Request where matcode='1100202200237'



--采购分包
select * from PB_Widget where id='a282f668-a395-4a9f-823e-61a2909aa10e'
--采购_采购订单
--/PowerPlat/FormXml/zh-CN/XLX_PUR/XLX_PUR_Order.htm


--采购审批单
--采购_询价单
select * from PB_Widget where id='4b140dee-6936-46e8-bfc0-d37bc9478c69'
--/PowerPlat/FormXml/zh-CN/XLX_PUR/XLX_PUR_Inquiry.htm

--RequestList_Id
select * from XLX_PUR_Inquiry_MatList where MatCode=''
--sum(Qty_Inquiry)
select * from XLX_PUR_Inquiry_MatList 
where RequestList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'

update XLX_PUR_Order_List set Qty_Order = ISNULL(XLX_PUR_Order_List.QtyOrig_Order - (select sum(Qty_Inquiry) from XLX_PUR_Inquiry_MatList 
where RequestList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'),0) where XLX_PUR_Order_List.InquiryMatList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'

update XLX_PUR_Order_List set Qty_Order = isnull(XLX_PUR_Order_List.QtyOrig_Order - 
(select isnull(sum(Qty_Inquiry),0) from XLX_PUR_Inquiry_MatList where RequestList_Id=XLX_PUR_Order_List.InquiryMatList_Id),0)


select * from XLX_PUR_Order_List where InquiryMatList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'
select * from XLX_PUR_Inquiry_MatList where RequestList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'

select * from XLX_PUR_Order_List where InquiryMatList_Id='0E304FC5-F837-CE3D-549D-F88889F3FD8B'



select Qty_Inquiry from XLX_PUR_Inquiry_MatList where FK='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
select * from XLX_PUR_InquirySupplie_List where FK='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

select * from XLX_PUR_Inquiry_MatList where matcode='1100202200239'
select * from XLX_PUR_Inquiry_MatList where requestlist_id='A0AE0CB5-2BCD-EC50-8045-C60F1BFA12DC'

update XLX_PUR_InquirySupplie_List set Qty_Inquiry = isnull((select Qty_Inquiry from XLX_PUR_Inquiry_MatList where XLX_PUR_Inquiry_MatList.RequestList_Id ='A0AE0CB5-2BCD-EC50-8045-C60F1BFA12DC' ),0)
where XLX_PUR_InquirySupplie_List.RequestList_Id ='A0AE0CB5-2BCD-EC50-8045-C60F1BFA12DC'

update XLX_PUR_InquirySupplie_List set Qty_Inquiry = ISNULL((select Qty_Inquiry from XLX_PUR_Inquiry_MatList where XLX_PUR_Inquiry_MatList.Id ='E9243565-461F-6E5E-4163-EAB8583B1218' ),0) where XLX_PUR_InquirySupplie_List.InquiryMatList_Id ='E9243565-461F-6E5E-4163-EAB8583B1218'



--select * from View_XLX_InquirySupplie


select
main.Status, main.RegHumId, main.RegHumName, main.RegDate, main.OwnProjId, main.OwnProjName, main.UpdDate, 
                main.Title, main.Id 
 AS MainId, main.Inquiry_Id, main.Inquiry_Name, main.SupplieId, main.Code, main.Name ,
                main.EName, main.ShortName, main.TypeName, main.ClassName, main.Address, main.PostCode, main.Linkman, 
                main.Phone, main.Email, list.Id 
 AS ListId, list.MatBS_Guid, list.MatBS_Code, list.MatBS_Name, list.MatId, list.MatCode, 
                list.MatName, list.Model,list.Specifi,list.Pattern, list.Standard, list.Texture, list.MatUnit, list.MatUnit2, list.Equ, list.Pressure, list.TaxRate, 
                list.Qty_Inquiry, list.MatPrice, list.MatMoney,list.GoodsMatPrice, list.GoodsMatMoney, list.DeliveryDate, list.Remark,list.RequestList_Id,cbs.CbsCode,cbs.CbsName,
cbs.Id as Cbs_Guid,request.DeviceName,request.UnitName,requestbbs.RequestCode as RequestCode1,requestbbs.Id as Request_Id1,list.MatSpec,list.TagNumber,bomfile.PartyBName 
from
dbo.XLX_PUR_InquirySupplie AS main INNER JOIN
                dbo.XLX_PUR_InquirySupplie_List AS list ON main.Id = list.FK 
				left join XLX_PUR_Request_List as request ON request.Id =list.RequestList_Id
				left join XLX_PUR_Request as requestbbs on requestbbs.Id = request.FK
				left join PS_CC_CBS as cbs ON request.CBS_Id=cbs.Id 
				left join ps_pur_bom as bom on bom.Id=request.bomid
				left join ps_pur_bomfile as bomfile on bom.masterid=bomfile.id