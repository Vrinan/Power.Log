--��ƣ�����ֶΣ�������Ա����
--���������
select * from PB_Widget where id='8c59bb23-3ec7-4cbd-a11e-aababfa42475'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_TechnoSpeciRev.htm
alter table SF_SJ_TechnoSpeciRev add ProfessionId uniqueidentifier null
alter table SF_SJ_TechnoSpeciRev add Profession nvarchar(100) null
alter table SF_SJ_TechnoSpeciRev add DesignStage nvarchar(100) null
select * from SF_SJ_TechnoSpeciRev

--����Э�����
select * from PB_Widget where id='27c7e4cc-61b9-443e-9465-fed2c91cdf55'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_TechDealCompile.htm
alter table SF_SJ_TechDealCompile add ProfessionId uniqueidentifier null
alter table SF_SJ_TechDealCompile add Profession nvarchar(100) null
alter table SF_SJ_TechDealCompile add DesignStage nvarchar(100) null
select * from SF_SJ_TechDealCompile

--����ļ�У��
select * from PB_Widget where id='14433179-9495-4e82-ac44-4e3975c11572'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_DesDocumentPro.htm
alter table SF_SJ_DesDocumentPro add ProfessionId uniqueidentifier null
alter table SF_SJ_DesDocumentPro add Profession nvarchar(100) null
select * from SF_SJ_DesDocumentPro
select * from V_SF_SJ_ProjNumberApplication
sp_helptext V_SF_SJ_ProjNumberApplication
 select *,case ProjectSource when 'T' then ProjectBName when 'F' then ProjectName end as ProjectName1
 from SF_SJ_ProjNumberApplication
 select * from SF_SJ_ProjNumberApplication

--�����ļ�����
select * from PB_Widget where id='ead38bac-c0ad-4415-abd1-6ea82ff53774'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_TechnicalDocuments.htm
alter table SF_SJ_TechnicalDocuments add ProfessionId uniqueidentifier null
alter table SF_SJ_TechnicalDocuments add Profession nvarchar(100) null
select * from SF_SJ_TechnicalDocuments


select * from View_SF_DesignBom
--Auditor�����
--Leader������
--ProofreaderУ����

sp_helptext View_SF_DesignBom
alter view View_SF_DesignBomasselect mes.ProjectMessageId,ProjectMessage,c.DesignStage,DesignMajorId, Auditor,AuditorId,Leader,LeaderId,Proofreader,ProofreaderId from SF_SJ_ProjectMessage_List listleft joinSF_SJ_ProjectMessage meson list.MasterId = mes.Idleft join(select DesignStage,Id 
from SF_SJ_ProjNumberApplication) con c.Id = mes.ProjectCodeApplication
