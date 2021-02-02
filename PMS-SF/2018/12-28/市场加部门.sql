--市场模块
--录入部门
select * from PB_Widget where id='35492436-a5fb-4867-93c4-dec2b0aceda2'
--/PowerPlat/FormXml/zh-CN/SF_ZZ/ContractControl.htm

--合同收款里程碑管理

--项目实施启动书
alter table SF_FK_ProjCarryOut add RegDeptId uniqueidentifier null
select * from PB_Widget where id='36d09346-c73e-4f02-b781-4a4fc0a33883'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_FK_ProjCarryOut.htm

--生产经营计划
alter table SF_Market_ProductionManagement add RegDeptId uniqueidentifier null
select * from PB_Widget where id='8e4f3958-8d1e-4c62-8066-0efcd4212009'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_Market_ProductionManagement.htm

--文件审批alter table SF_WJSP add RegDeptId uniqueidentifier null
select * from PB_Widget where id='f501ce51-96b4-4583-b9a9-6fd66b5ffc08'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_WJSP.htm

--专利申请alter table SF_SJ_ApplyForAPatent add RegDeptId uniqueidentifier null
select * from PB_Widget where id='2a236aa4-9b2e-4ed2-aa0b-0e4c83e3174d'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_ApplyForAPatent.htm

--科技管理集团
alter table SF_SJ_TechnologicalManagement add RegDeptId uniqueidentifier null
select * from PB_Widget where id='e40e4bea-f421-47e8-91d6-5b6b6779980c'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_TechnologicalManagement.htm

--科技管理内部（申请表）
select * from PB_Widget where id='bef3ab0d-f1af-481e-81b6-c601af5c3ec5'
--/PowerPlat/FormXml/zh-CN/SF_ZZ/Win_Technology.htm

--科技管理内部(鉴定表)
--1

--客户满意度调查
select * from PB_Widget where id='07df2690-4b07-4df2-89ac-5a8adbdb2c4a'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_CustomerSatisfaction.htm

--项目交接单
alter table PS_MK_ProjectHandover add RegDeptId uniqueidentifier null
select * from PB_Widget where id='abd9f2b5-0330-4c53-91b8-ffc7be72da17'
--/PowerPlat/FormXml/zh-CN/StdMarket/PS_ProjectHandover.htm

--开标情况登记
select * from PB_Widget where id='0e2baf3c-d2b4-4f5d-829e-9d206c0b956b'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_OpenBidding.htm

--投标保证金（保函）申请
select * from SF_BidDepositApplication

--投标文件编制计划
alter table PS_MK_isBidReview add RegDeptId uniqueidentifier null
select * from PB_Widget where id='9b283e34-b426-4506-b917-7a23e95a7385'
--/PowerPlat/FormXml/zh-CN/StdMarket/isBidReview.htm

--项目跟踪
select * from PS_MK_ProjectInfo
select * from PB_Widget where id='029d6895-3186-4565-adc3-61919e3ab1ed'
--/PowerPlat/FormXml/zh-CN/StdMarket/ProjectInfo.htm

--招标文件购买记录
alter table PB_Organize add SFRegDeptId uniqueidentifier null

--客户
select * from PB_Widget where id='415381b5-1566-4e5b-8a59-527f7377ceca'
--/PowerPlat/FormXml/zh-CN/StdMarket/Organize.htm

select * from PB_User where Code='0227'
select * from PB_Human where Id='7F464B4A-D096-4A87-BFCE-BF1A3ACE4285'
select * from PB_Human where Name='金外琼'


select * from PB_Organize

select b.RegHumId,a.SFRegDeptId from PB_Organize a left join PB_DefaultField b on a.Id = b.DefaultFieldId where a.SFRegDeptId is not null

select b.RegHumId,a.SFRegDeptId from PB_Organize a left join PB_DefaultField b on a.Id = b.DefaultFieldId where a.SFRegDeptId is null

--update PB_Organize set SFRegDeptId ='6373B459-9C3E-4C34-90DA-F51F61993458' where Id in
--(
--	select DefaultFieldId from PB_DefaultField s where PB_Organize.Id = s.DefaultFieldId 
--	and s.RegHumId='5B11DFFD-7A15-41C9-ABB4-7A94B32A0DB8'
--)

select RegHumId,RegDeptId from PS_MK_isBidReview
--update PS_MK_isBidReview set RegDeptId = '76E5F96F-4FE5-4F76-A103-8FB8443909DD'

select RegHumId,RegDeptId from PS_MK_ProjectHandover
update PS_MK_ProjectHandover set RegDeptId='76E5F96F-4FE5-4F76-A103-8FB8443909DD'


select RegHumId,RegDeptId from SF_WJSP
update SF_WJSP set RegDeptId='6373B459-9C3E-4C34-90DA-F51F61993458'

select RegHumId,RegDeptId from SF_FK_ProjCarryOut
update SF_FK_ProjCarryOut set RegDeptId='76E5F96F-4FE5-4F76-A103-8FB8443909DD'

select RegHumId,RegDeptId from ContractControl