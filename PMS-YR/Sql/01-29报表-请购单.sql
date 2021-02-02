select * from xlx_pur_request_list where fk=(select id from xlx_pur_request where id='[@KeyValue]')

select  case BomType when '1' then '行政类' when '2' then '生产设备类' 
when '3' then '仪表类' when '4' then '工程类' when '5' then '信息类' 
when '6' then '电气类' when '7' then '生产类'  else '' end as BomType from xlx_pur_request

select  case Is_Budget when '1' then '预算内' when '2' then '不在预算内' 
else '' end as Is_Budget from xlx_pur_request


select * from xlx_pur_request
Select Name FROM SysColumns Where id=Object_Id('xlx_pur_request')
select top 1 * from xlx_pur_request_list 
Select Name FROM SysColumns Where id=Object_Id('xlx_pur_request_list')

select * from ps_cm_subcontract where id='[@KeyValue]'
select * from ps_cm_subcontract_PayNodes where MasterId='[@KeyValue]'


--8fa85823-035e-4c5e-b3d5-5c23da099c47
declare @money nvarchar(50)
select @money = subcontractamount from ps_cm_subcontract where id='[@KeyValue]'
select dbo.fn_getformatmoney(@money) as money

