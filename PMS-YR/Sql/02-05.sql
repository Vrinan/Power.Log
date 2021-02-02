select * from V_PS_Purchase where request_code like '%0118-004%' and request_listmatname like '%Ωÿ÷π∑ß%' order by order_reghuman desc

select * from V_PS_Purchase where order_code = 'YRKJ-CGFB-20180119-016' order by inquiry_code desc


select * from xlx_pur_order_list where fk='58481d84-5d6d-4664-9ec8-77582350f7f9' order by selectflag desc

update xlx_pur_order_list set selectflag=0 where fk='58481d84-5d6d-4664-9ec8-77582350f7f9'

select * from XLX_PUR_Inquiry_matlist where fk='7af5a52e-a663-4fdb-be83-fe1189cc5a2c'
