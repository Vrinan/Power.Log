select * from PB_User where Name='¼ÍÁ¼öÎ'


select * from View_SF_DesignBom where
 DesignMajorId='26f45244-2c45-6b75-c39c-3cd8da5bcaf3' 
 and DesignStage = 'sg'
 and ProjectMessageId='b7ef9c57-4370-48e5-b99e-746671e29b1a' 

--5D3FE4CE-3B7B-4AF2-9A7D-2658F4A23FAE
select ProjectMessageId,* from SF_SJ_ProjectMessage where Code='SK18047S'
update SF_SJ_ProjectMessage set ProjectMessageId='B7EF9C57-4370-48E5-B99E-746671E29B1A' where Code='SK18047S'

--B7EF9C57-4370-48E5-B99E-746671E29B1A
select * from SF_SJ_ProjNumberApplication where Code='SK18047S'