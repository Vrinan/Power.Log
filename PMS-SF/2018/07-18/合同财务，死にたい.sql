--死にたい，第几次修改了
--保函到期时间
alter table SF_FK_MarginOwnerApply add ExpirationTime datetime null
alter table SF_FK_MarginSubcontractorApply add ExpirationTime datetime null

create view View_SF_MarginSubcontractorApply
as
select stuff(convert(char(10),ExpirationTime,112),7,2,'') as ExpirationTimes,case when MarginType='1' then '投标保证金' when MarginType='2' then '履约保证金' 
when MarginType='3' then '履约保函' when MarginType='4' then 'HSE保证金' else '' end as MarginTypes,* from SF_FK_MarginSubcontractorApply

select * from View_SF_MarginSubcontractorApply

select * from PB_User

alter table SF_FK_MarginOwnerApply add DocumentNumber nvarchar(100) null--财务凭证号
alter table SF_FK_MarginOwnerApply add DocumentDate datetime null--
alter table SF_FK_MarginSubcontractorReturn add DocumentNumber nvarchar(100) null--财务凭证号
alter table SF_FK_MarginSubcontractorReturn add DocumentDate datetime null--财务凭证号

select * from PB_Widget where id='15fa9b9d-634e-439b-93a4-18c9d375de75'
--/PowerPlat/FormXml/zh-CN/StdContract/InvoiceRecord.htm

select * from PB_Widget where id='ab969f33-e07b-47b4-92c7-9e95d71e5d8e'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractReceipt.htm

select * from PS_CM_ContractReceipt

select * from PB_Widget where id='60952a39-a722-4acc-8a2f-882ffd1192fc'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractApplyMoney.htm

select * from PB_Widget where id='6665fd96-4c31-4f88-a262-d011ab0d8524'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractSettlement.htm

select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm