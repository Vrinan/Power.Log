select * from PB_Widget where Id='bdac34e4-1575-4f0b-94d6-fd9094225b1f'
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_CommunicateReimburse.htm


alter table SF_FK_CommunicateReimburse_dtl add SumApprove numeric(18, 2) null


select * from PB_Department where Name like '%��Ŀ��%'

select * from PB_Department where Name = '��Ŀ����'

select id from PB_Department where ParentId='BB3EC90C-C456-4449-BA2B-43EDF3C25D3B'

select * from PB_Widget where Id='19f77660-e976-4917-afbb-2c9f6f00ec1f'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_CommunicationFeeMonthPlan.htm


select * from PB_Human where Name='׿ά'
select * from PB_User where Name='׿ά'


select * from PB_Widget where Id='3432a0e1-147d-44e9-9b64-e360666b99ff'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_DelegateYAppy.htm

select * from SF_HSE_DelegateYAppy
select DelegateId ,* from SF_HSE_MonitorIssued



Select count(*) as RecordCount From  SF_CG_PurchasePlan A Where   (0=0)  and  (0=0)  and A.PurchaseMajor!=1 
and (A.DepartmentId='f389154e-fb2d-4e93-99a5-4ded9a9a9d75')  

select * from PB_User where Name='���'
select * from PB_User where Code='1203'



select * from SF_ZH_OverTime_list

Select XCode_T1.* From (Select *, row_number() over(Order By  OrganizeName DESC ) as rowNumber From V_PS_ProjectOrganize VPPO Where  VPPO.EpsProjId='00000000-0000-0000-0000-0000000000a4' and (VPPO.RoleType=1 AND VPPO.RoleType IS NOT NULL) and VPPO.OrganizeName like '%����ұ����������װ�������޹�˾%') XCode_T1 Where rowNumber Between 1 And 10
select * from V_PS_ProjectOrganize where OrganizeName like '%����ұ����������װ�������޹�˾%'

Select XCode_T1.* From (Select *, row_number() over(Order By  OrganizeName DESC ) as rowNumber From V_PS_ProjectOrganize VPPO Where  VPPO.EpsProjId='00000000-0000-0000-0000-0000000000a4' and (VPPO.RoleType<>1 AND VPPO.RoleType IS NOT NULL) and VPPO.OrganizeName like '%���ݸ��¹��̹������޹�˾%') XCode_T1 Where rowNumber Between 1 And 10
select * from V_PS_ProjectOrganize where OrganizeName like '%���ݸ��¹��̹������޹�˾%'

select * from PB_Organize where Name like '%���ݸ��¹��̹������޹�˾%'

sp_helptext V_PS_ProjectOrganize

CREATE view [dbo].[V_PS_ProjectOrganize]  ----��ȡ��Ŀ���뵥λ  
as  
select newid() KeyId,X1.*,X2.Code,X2.LegalPerson,MainLinker,Phone,Email,Address,RoleType,x3.BizAreaId  
from  
(select distinct PartyA OrganizeName,PartyA_Guid OrganizeGuid ,'ҵ��' OrganizeRole,EpsProjId  
from PS_MK_ContractInfo where PartyA_Guid is not null  
union all  
select PartyB,PartyB_Guid,  
case when subcontracttype = 'E' then '��Ʒְ�'  
when subcontracttype = 'C' then 'ʩ���ְ�'  
when subcontracttype = 'P' then '��Ӧ��'  
when subcontracttype = 'S' then '����' end OrganizeRole,  
EpsProjId  
from PS_CM_SubContract  
where PartyB_Guid is  not null) x1  
left join PB_Organize x2  
on x1.OrganizeGuid  = x2.Id  
left join PB_DefaultField X3  
on x2.Id = x3.DefaultFieldId  