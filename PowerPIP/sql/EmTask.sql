select ',' + str(project_id) from pln_project where parent_id =382  for xml path('') 

select (stuff((select ',' + str(project_id) from pln_project where parent_id =263  for xml path('')),1,8,'')) as project_id

select str(project_id)+',' from pln_project for xml path('')

select * from pln_project where project_shortname='New381'

select project_id,parent_id from pln_project where parent_id =263
select sum(initial_price),sum(finally_price) from pln_finalCost where auditstate = 'ÒÑÅú×¼'


 select sum(a.payingfee) from PAY_CONTPAY_RECORD a  inner join PACT_record b on a.PACT_record_UniqueId = b.uniqueId