select * from SF_PD_ProjectImplementStartBook 


select ProjectNameId from SF_PD_ProjectImplementStartBook group by projectnameid having count(projectnameid)>1 

select * from PB_Widget where id='7892ed51-c787-4477-a006-fb2ea7df6ce1'
--/PowerPlat/FormXml/zh-CN/SF_PD/SF_ProjectImplementStartBook.htm


select * from PLN_project where project_guid not in (select projectnameid from SF_PD_ProjectImplementStartBook)

select * from ps_cm_subcontract


select * from SF_ProjectImplementStartBook_dtl
select * from PS_SubContract_View