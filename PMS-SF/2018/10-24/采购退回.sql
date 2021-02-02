--待组包
select * from PB_Widget where id='d9d081a1-83d6-4c9d-b884-11b33ea0aa89'
--/PowerPlat/FormXml/zh-CN/SF_CG/Win_SF_CG_PurchasePackageView.htm

--待下发
select * from PB_Widget where id='95a8aa3e-34be-43d1-870a-a9f118f0b393'
--/PowerPlat/FormXml/zh-CN/SF_CG/Win_SF_CG_PurchasePlanView.htm

alter table SF_CG_PurchasePlanList add ReturnReasons text null


select * from (select PurPlan.IsDirect,PurPlan.Code as MainCode,PurPlan.Title,PurPlan.Status,PurPlan.ApprDate,PurPlan.ProjId,PurPlan.ProjName,PurPlan.ProjShortName,list.*  
from SF_CG_PurchasePlanList list
left join SF_CG_PurchasePlan PurPlan on list.MasterId=PurPlan.Id 
where Status=50 
and IsSign=0 
and IsCanceled=0 
and list.IsChosen = 0
and( (MatStatus != 2 and IsAdjust!=1 ) or MatStatus is null) ) s