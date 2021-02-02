select * from PB_Widget where Id='72737005-7b7d-4d11-bc8b-1400b08d2b85'
--/PowerPlat/FormXml/zh-CN/SF_Complex/Win_SF_HelpDocFile.htm
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_EqumentManagement.htm
select * from PB_Human

select ContractType, * from V_SF_SubContract  where ContractType in('03','05')

select * from PB_Widget where Id='f1340eae-0d30-4e12-9c64-7b13e97f4ee8'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContract_E.htm

select * from V_SF_SubContract where 
(EPSProjectId in(select ISNULL(aa.project_guid,'00000000-0000-0000-0000-000000000000') from PLN_project aa where aa.parent_guid='6de1a54c-5f45-4dd4-951b-9a9b4d8b4db4') or EPSProjectId in(select ISNULL(aa.project_guid,'00000000-0000-0000-0000-000000000000') from PLN_project aa where aa.parent_guid='977ccdf4-3f12-43bd-9d03-d4fa58b6c1a8'))

select * from PLN_project where project_name='项目部项目'

select * from V_SF_SubContract where 
EPSProjectId in(select ISNULL(aa.project_guid,'00000000-0000-0000-0000-000000000000') from PLN_project aa where aa.parent_guid='82bef379-1d68-4681-baf0-42924ca6b2b7')



select* from PB_Widget where Id='cd3e67df-b7c2-4686-894c-0b6eef97fc9a'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SF_Market_ContractMilepost.htm

select * from PB_ContractMilepost where convert(nvarchar(6),RegDate,112)=