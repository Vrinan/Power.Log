create table SF_CM_ApplyMoneyProj(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier not null,
	Type nvarchar(100) null,
	ListId uniqueidentifier not null,
	Code nvarchar(500) null,
	Name nvarchar(500) null,
	Remark nvarchar(2000) null,
	Sequ int null,
	UpdDate datetime null
)

select * from PB_Widget where id='0cb9ff34-f056-4a0b-8e07-2ab3d193445c'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_C.htm
--ʩ���ְ���ͬ-֧������


select * from SF_CM_ApplyMoneyProj
select * from SF_PD_TestRunCertification

--������֧ͬ��������Ŀ
--ee7ee0d6-d3e1-ca0a-c66e-a618ebf139a3
alter view View_ApplyMoneyProjList
as
select '��ˮ�Գ��ϸ�֤' as Type,a.Id,a.Code,a.Title,a.Memo as Remark,ProjectNameId from SF_PD_TestRunCertification a where a.Status=50
union
select '���ܼ��' as Type,b.Id,b.Code,b.Title,b.Memo as Remark,ProjectNameId from SF_PD_PerformanceTesting b where b.Status=50
union
select '�������պϸ�֤' as Type,c.Id,c.Code,c.Title,c.Memo as Remark,ProjectNameId from SF_PD_EnvProtectionAcceptance c where c.Status=50
union
select '��������' as Type,d.Id,d.Code,d.Title,d.Memo as Remark,ProjectNameId from SF_PD_CompletionAcceptance d where d.Status=50


select * from SF_PD_EnvProtectionAcceptance 


select * from PS_CM_SubContractApplyMny where SubContractType='C'







select * from View_ApplyMoneyProjList where projectnameid is not null