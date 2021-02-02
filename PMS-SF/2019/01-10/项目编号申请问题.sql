select * from PB_Widget where id='4a1a1d71-02e6-49af-908c-a57fc1b7054f'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_IncomeAnalysis.htm

select * from PLN_project


select * from V_SF_SJ_ProjNumberApplication where Code like '%SK18047S%'

   
select *, case when ProjectName is null then ProjectBName when ProjectBName is null then ProjectName else ProjectName end as ProjectName1    
 from SF_SJ_ProjNumberApplication 

 select * from SF_SJ_ProjNumberApplication where Code like '%SK18047S%'

 Select Count(*) From V_SF_SJ_ProjNumberApplication Where  Status=50 and ProjectNameId not in 
 (select ProjectNameId from  SF_SJ_EmitDesignResults) and Code like '%SK18047S%'


 select * from SF_SJ_EmitDesignResults where ProjectNameId='B7EF9C57-4370-48E5-B99E-746671E29B1A'  ProjectCode = 'SK18047S'