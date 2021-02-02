--a1项目编号申请
--f63e278b-9a70-4267-9e2c-39a7f7721bef
select * from pb_widget where id='f63e278b-9a70-4267-9e2c-39a7f7721bef'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_ProjectHandover.htm
select count(*) as Count from SF_SJ_ProjNumberApplication where Status=50 and ProjectNameId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--a2团队组建
--8d3d9c13-34b3-4222-8c25-1b31758829f0
select * from pb_widget where id='8d3d9c13-34b3-4222-8c25-1b31758829f0'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_ProjectMessage.htm
select * from SF_SJ_ProjectMessage
select count(*) as Count from SF_SJ_ProjectMessage where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--b1技术规格书评审
--893271f8-139b-4437-b213-5d03748147aa
select * from pb_widget where id='893271f8-139b-4437-b213-5d03748147aa'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_TechnoSpeciRev.htm
select * from SF_SJ_TechnoSpeciRev
select count(*) as Count from SF_SJ_TechnoSpeciRev where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--b2技术协议编制
--8026b45a-db97-4463-ace0-bb5fe83c1515
select * from pb_widget where id='8026b45a-db97-4463-ace0-bb5fe83c1515'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_TechDealCompile.htm
select * from SF_SJ_TechDealCompile
select count(*) as Count from SF_SJ_TechDealCompile where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--c1设计提资
--50f401b7-c25d-488a-943e-a025760f7e8a
select * from pb_widget where id='50f401b7-c25d-488a-943e-a025760f7e8a'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_DesignInformation.htm
select * from SF_SJ_DesignInformation
select count(*) as Count from SF_SJ_DesignInformation where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--d1设计文件校审
--422a7f3d-403a-4530-a34b-306545305beb
select * from pb_widget where id='422a7f3d-403a-4530-a34b-306545305beb'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_DesDocumentPro.htm
select * from SF_SJ_DesDocumentPro
select count(*) as Count from SF_SJ_DesDocumentPro where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--d2技术文件会审
--5570d165-446f-4598-a3ff-2c88774356a6
select * from pb_widget where id='5570d165-446f-4598-a3ff-2c88774356a6'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_TechnicalDocuments.htm
select * from SF_SJ_TechnicalDocuments
select count(*) as Count from SF_SJ_TechnicalDocuments where Status=50 and ProjectMessageId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--e1设计成品管理
--8cbe33b5-bf4d-45e0-b3ce-969d056539c4
select * from pb_widget where id='8cbe33b5-bf4d-45e0-b3ce-969d056539c4'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_DesFinishManagement.htm
select * from SF_SJ_DesFinishManagement
select count(*) as Count from SF_SJ_DesFinishManagement where Status=50 and ProjectNameId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--e2发出设计成果
--1a918c42-90ff-487f-a404-9799bfe75931
select * from pb_widget where id='1a918c42-90ff-487f-a404-9799bfe75931'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_EmitDesignResults.htm
select * from SF_SJ_EmitDesignResults
select count(*) as Count from SF_SJ_EmitDesignResults where Status=50 and ProjectNameId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 

--f1项目总结
--ae5e835f-bd8d-4209-b739-d74ed6835fcd
select * from pb_widget where id='ae5e835f-bd8d-4209-b739-d74ed6835fcd'
--/PowerPlat/FormXml/zh-CN/SF_Design/Win_SF_ProjectSummarize.htm
select * from SF_SJ_ProjectSummarize
select count(*) as Count from SF_SJ_ProjectSummarize where Status=50 and ProjectNameId='d14ae03b-44cf-4c86-bcc8-90faaa0c155e' 