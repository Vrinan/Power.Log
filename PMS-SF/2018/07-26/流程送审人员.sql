select * from View_SF_DesignBom where DesignMajorId='d8834875-05d5-f8dd-5d60-14ac5d4d6332' and DesignStage = 'sg'

and ProjectMessageId='3467d8db-fd18-42aa-9277-d5e7c5d07895' 

--项目Id
select * from SF_SJ_ProjectMessage where ProjectMessageId='3467d8db-fd18-42aa-9277-d5e7c5d07895' 
--专业
select * from SF_SJ_ProjectMessage_List
--阶段，
select * from SF_sj_ProjNumberApplication where ProjectNameId='3467d8db-fd18-42aa-9277-d5e7c5d07895' 