SELECT * from PB_Widget where id='26eca136-0ecb-4b64-a83a-7c670a672c97'
--/PowerPlat/FormXml/zh-CN/StdPurchase/PS_PurchaseRequisition.htm
--请购单
select * from PS_PUR_PurchaseRequisition where RegHumName='王国栋'
delete from PS_PUR_PurchaseRequisition where RegHumName='王国栋'

select MAX(Code) as maxCode from PS_PUR_PurchaseRequisition where Code like '%YXZ-18-%' 

Update PS_PUR_PurchaseRequisition Set Code=N'YXZ-18-0003' Where Id='b60f05e1-9380-4ead-964a-5293dc31871f'