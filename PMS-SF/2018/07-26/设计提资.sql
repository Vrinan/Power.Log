select * from SF_SJ_DesignInformation
SF_DesignInformation
select * from V_SF_SJ_ProjNumberApplication

update SF_SJ_DesignInformation set ProjectMessageId = 
(select project_guid from PLN_project where project_name = a.ProjectMessage)
from SF_SJ_DesignInformation a,PLN_project b

select * from SF_SJ_TechDealCompile
alter table SF_SJ_DesignInformation add Profession nvarchar(100) null
alter table SF_SJ_DesignInformation add ProfessionId uniqueidentifier null


select * from View_SF_DesignBom where 
ProjectMessageId='3467D8DB-FD18-42AA-9277-D5E7C5D07895' 
and DesignStage= 'cb'
and 
DesignMajorId='D4F7F470-4117-E179-84AA-EA6C7F4F9741' 