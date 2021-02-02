--合同评审添加技术协议
select * from PB_Widget where Id='5c0640b9-fb52-4b58-bc90-b7af15a884c2'
--/PowerPlat/FormXml/zh-CN/SF_CM/PS_CM_ContractReview.htm

alter table PS_MK_ContractReview add TechName nvarchar(500) null
alter table PS_MK_ContractReview add TechId uniqueidentifier null