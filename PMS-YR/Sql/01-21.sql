select * from XLX_OverbroadApply
select * from XLX_OverbroadApply_item

--项目预算-CBS
--左边选费用科目，右边是具体费用明细列表
select * from PS_CC_CBS_Class
select * from PS_CC_CBS
select * from PS_CC_ContractBudget
select * from PS_CC_ContractBudget_CBS

where masterid='2B472F1D-B0A6-4FC2-A0B9-21C5AB66B527'
select * from PS_CC_ContractBudget_CBS 
where CbsClass_Guid='60AAD0C2-D646-4960-9805-37E7A8AF8526'

select * from PS_CC_ContractBudget_CBS where 1=1 and exists(select a.id from PS_CC_CBS_Class a where a.id = )
select a.id from PS_CC_CBS_Class a where a.id = 'AABB4DE7-06E2-4108-A02B-879261E420A9'

select * from pb_widget where id='0172ef6c-e0e9-497a-bab6-1eb81a298f82'
select * from pb_wizard where id='577449f9-1d60-4e26-8d85-fc23bd73c9d4'



select * from XLX_OverbroadApply

select * from XLX_OverbroadApply_item where MasterId = '7299EDDC-F066-4E94-9720-4AB0EB42FD54'

select * from xlx_pur_request_list

select count(*) from xlx_pur_request_list