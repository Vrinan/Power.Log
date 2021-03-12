select * from PS_PUR_MatInStore
select * from PS_PUR_MatInStore_Dtl where Mat_Guid ='CA7E5980-ACCB-417E-A63B-209F9C3694B1'
select bb.Id,bb.Code,bb.ApprDate,aa.InStoreNum as Num,aa.InStoreAmount as Amount from PS_PUR_MatInStore_Dtl aa left join PS_PUR_MatInStore bb on aa.MasterId = bb.Id where aa.Mat_Guid ='CA7E5980-ACCB-417E-A63B-209F9C3694B1'

select * from PS_PUR_MatOutStore
select * from PS_PUR_MatOutStore_Dtl where Mat_Guid ='9DB9BD1A-B521-450F-BE1A-7338BE99BC97'
select bb.Id,bb.Code,bb.ApprDate,aa.OutStoreNum as Num,aa.OutStoreAmount as Amount from PS_PUR_MatOutStore_Dtl aa left join PS_PUR_MatOutStore bb on aa.MasterId = bb.Id where aa.Mat_Guid ='CA7E5980-ACCB-417E-A63B-209F9C3694B1'

select * from PS_PUR_MatReturn
select * from PS_PUR_MatReturn_Dtl where Mat_Guid ='9DB9BD1A-B521-450F-BE1A-7338BE99BC97'
select bb.Id,bb.Code,bb.ApprDate,aa.ReturnNum as Num,aa.ReturnAmount as Amount from PS_PUR_MatReturn_Dtl aa left join PS_PUR_MatReturn bb on aa.MasterId = bb.Id where aa.Mat_Guid ='CA7E5980-ACCB-417E-A63B-209F9C3694B1'
 
select * from YR_StoreBalanceItems