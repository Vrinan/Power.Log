select * from pb_widget where id='0172ef6c-e0e9-497a-bab6-1eb81a298f82'

--物资计划
select * from ps_pur_bomfile where id ='40207202-b286-4b07-a7cc-16ca18c1867f'
select * from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'
--请购单
--主表order_guid为物资计划Id
--明细表的BomID为物资计划明细Id
select * from xlx_pur_request where id='ca39d54f-f5d3-4d58-9e26-ed41ee01023b'
select * from xlx_pur_request_list where fk='ca39d54f-f5d3-4d58-9e26-ed41ee01023b'
--采购分包
--主表和其他没关联
--inquiryMatList_Id为请购单明细Id
select * from xlx_pur_order
select * from xlx_pur_order_list where inquiryMatList_Id in (
select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--采购审批单
--主表有采购分包主表的Id，name，code,合同的Code
--明细有请购单明细id：requestlist_id，请购单Id，Code
select * from XLX_PUR_Inquiry
select * from XLX_PUR_Inquiry_matlist where requestlist_id in(select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--竞价方案
--主表有采购分包的Id，Code
--子表有请购单RequestCode，Request_Id，请购单明细xlx_request_list_id
select * from PS_bid_Inquiry
select * from PS_bid_Inquiry_matlist where xlx_request_list_id in(
select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--竞价报告
--主表有分包Id,Code,Name:Order_Guid,OrderCode,OrderName
--子表有竞价方案明细的Id:Inquiry_Matlistid,请购单明细的Id：xlx_request_list_id,请购单Code，Id：RequestCode，Request_Id
select * from XLX_PS_BID_Inquiry
select * from XLX_PS_BID_Inquiry_matlist
--合同
--主表有采购审批单/竞价成功通知书Id,Name,Code：Order_Guid,OrderName,OrderCode
--子表有xlx_request_list_id
select * from ps_cm_subcontract
select * from ps_cm_subcontract_matitem
--到货检查
--主表
--子表，contractlistid为合同明细Id
select * from PS_PUR_ArrivalCheck
select * from PS_pur_ArrivalCheck_Dtl
--物资入库
--主表
--子表，Arrivalmat_guid为到货明细Id
select * from PS_PUR_MatInStore
select Arrivalmat_guid,* from PS_PUR_MatInStore_dtl
--领料申请
--主表
--子表，Arrivalmat_guid为物资计划明细Id
select * from ps_pur_MatRequisitions
select * from ps_pur_MatRequisitions_dtl
--物资出库
--主表
--子表，requisition_guid为领料明细Id
select * from PS_pur_MatOutStore
select requisition_guid,* from PS_pur_MatOutStore_dtl



