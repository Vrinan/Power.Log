select Order_Guid,* from PS_CM_SubContract where subcontractcode ='YRKJGC-170055'
--采购审批单/询价单
select XLX_PUR_Order_Id,* from XLX_PUR_Inquiry where id='75D45876-E636-4B29-B169-6CF6AA86B0BA'
--分包
select * from xlx_pur_order where id='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'
select inquirymatlist_id,* from xlx_pur_order_list where fk='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'
--请购单明细
select * from XLX_PUR_Request_List where id in(
select inquirymatlist_id from xlx_pur_order_list where fk='1B6CEC0C-A1A0-418B-ADA0-77211EECE024')

select * from XLX_PUR_Request_List
select * from ps_pur_bomfile


select * from XLX_PUR_Supplie where id='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'
select * from XLX_PUR_InquirySupplie where id='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'
select * from XLX_PUR_Inquiry where inquirycode='YRKJ-XJD-20171214-003'
select * from xlx_pur_order where id='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'
select * from xlx_pur_order_list where fk='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'

select * from PS_BID_BidWinNotice where id='1B6CEC0C-A1A0-418B-ADA0-77211EECE024'