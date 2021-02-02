select * from XLX_PUR_Supplie
select * from XLX_PUR_Request_List where bomid='42FE66B0-AC44-4D68-A76A-B759398BAFAB'
select * from PS_PUR_BOMFile where reghumid='AD000000-0000-0000-0000-000000000000'
select * from pb_widget where id='a282f668-a395-4a9f-823e-61a2909aa10e'
select * from xlx_pur_order
select * from xlx_pur_order_list
select * from xlx_pur_request_List
select * from View_CPL_OrderMat
select * from PS_PUR_BOMFile
select * from pb_user

select * from xlx_pur_request a right join(
select * from XLX_PUR_Request_List q where q.BOMId in(
select c.id from PS_PUR_BOM c where c.MasterId in (select d.Id from PS_PUR_BOMFile d where d.RegHumId='AD000000-0000-0000-0000-000000000000'))) as b
on  a.Id = b.FK

select * from xlx_pur_request a right join(
select * from XLX_PUR_Request_List) as b on  a.Id = b.FK where BOMId in(select c.id from PS_PUR_BOM c where
c.MasterId in (select d.Id from PS_PUR_BOMFile d where d.PurchashHumanId='AD000000-0000-0000-0000-000000000000'))

select * from XLX_PUR_Request_List  a left join(
select Id as RequestId,Title as RequestTitle,RequestCode,ProMajor as RequestProMajor,IsUrgency,Order_Guid,PurchaseHuman,PurchaseHumanId
from xlx_pur_request) as b on  a.FK = b.RequestId where 
BOMId in(select c.id from PS_PUR_BOM c where
c.MasterId in (select d.Id from PS_PUR_BOMFile d where d.PurchashHumanId='AD000000-0000-0000-0000-000000000000'))

select CBS_Id,CBS_Name,* from View_CPL_OrderMat where 1=1 and 
BOMId in(select c.id from PS_PUR_BOM c where
c.MasterId in (select d.Id from PS_PUR_BOMFile d where d.PurchashHumanId='604B4292-41A3-4AAD-82C0-049D4C08FCE2'))
and Id not in (select InquiryMatList_Id from xlx_pur_order_list)


select * from xlx_pur_request_list where id='C877DF01-A7D8-4A0F-B88F-6DF6BE49C0DB'
select InquiryMatList_Id from xlx_pur_order_list
