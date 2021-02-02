select * from PB_Widget where id='b5fffcd8-1f25-43b3-bf7e-6c1e6b975ace'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_View_MonthReportBGH_dtlFirst.htm\

select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm


--进项合同台账
select * from PB_Widget where id='605a1e94-c4fb-47fe-add7-6df118281fee'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_IncomeContractInfo_Sum.htm

--企业中心
select * from PB_Widget where id='2c2df609-2458-4ee6-bdd8-b909b71a770d'
--/PS_EnterpriseCenter.html

select * from PLN_project where project_name ='公司项目'
select * from PLN_project where project_shortname = 'PI-2018-0073' or project_shortname = 'PI-2018-0072' or project_shortname = 'PI-2018-0072'

--update PLN_project set parent_guid = '82bef379-1d68-4681-baf0-42924ca6b2b7' where project_shortname = 'PI-2018-0073' or project_shortname = 'PI-2018-0072' or project_shortname = 'PI-2018-0071'

--分包合同执行
select * from pb_widget where id='370b9a55-c61e-4cb1-96f8-4d2f24c5e121'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_SubContractProgress.htm

select count(*) as CompanyProjCount from PLN_project where project_guid in(select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))