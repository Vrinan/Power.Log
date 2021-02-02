select * from PB_Position where Name like '%部长%'


select Id from PB_Human where PosiId in(select Id from PB_Position where Name like '%部长%')

select * from PB_User where Name='杨华明'

select * from PB_Human where Name='冯星'

select * from SF_CG_PurchasePlan where Id='056df7a0-4a07-407f-8df0-c2cf3218f076'
select * from PB_Position where Id='885D5C9C-F3EE-418F-AAF1-A6FD77D94171'



alter table SF_CG_PurchasePlan add RegPosiId uniqueidentifier null

update SF_CG_PurchasePlan set RegPosiId =  (select Id from PB_Human a where a.Id =  SF_CG_PurchasePlan.RegHumId)
--([humname] = '刘佳鑫') || ([humname] = '向远志') || ([humname] = '冯星')