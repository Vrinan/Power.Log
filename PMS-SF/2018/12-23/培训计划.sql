select * from PB_Widget where id='4b363ae1-f2da-4a5e-8241-a628542d9411'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_NewTrainPlan.htm
--–¬≈‡—µº∆ªÆ
select * from SF_ZH_NewTrainPlan_list

select * from PB_Human where code = '0159'

select a.Title,a.Code,a.RegDate,b.* 
from SF_ZH_NewTrainPlan a left join SF_ZH_NewTrainPlan_list b on a.Id = b.MasterId

--view_NewTrainPlanList

select * from PB_Widget where id='f4959e04-cc38-49c2-a5f4-831682818df2'
--/PowerPlat/FormXml/zh-CN/SF_YX/View_SF_EachWeekCheck.htm