--alter table XLX_PUR_SupplieHeGe add InquiryHumanName nvarchar(max) null
--alter table XLX_PUR_SupplieHeGe add InquiryHumanId uniqueidentifier null
--alter table XLX_PUR_Supplie add InquiryHumanName nvarchar(max) null
--alter table XLX_PUR_Supplie add InquiryHumanId uniqueidentifier null

--alter table XLX_PUR_Inquiry add InquiryEndDate datetime null

--alter table XLX_PUR_Inquiry_SupplieList add InquiryHumanId uniqueidentifier null
--alter table XLX_PUR_Inquiry_SupplieList add InquiryHumanName nvarchar(max) null
--alter table XLX_PUR_Inquiry_SupplieList add InquiryStatus nvarchar(max) null
--alter table XLX_PUR_Inquiry_SupplieList add WizardType nvarchar(max) null

--供应商评审
select * from PB_Widget where id='04871cb2-c253-4974-8f56-7a18ebb9a64c'
--供应商_供应商审批
--/PowerPlat/FormXml/zh-CN/XLX_PUR/XLX_PUR_SupplieHeGe.htm
--select * from XLX_PUR_SupplieHeGe

--乙方单位维护
select * from pb_widget where id='022765e2-b49b-4325-9fae-d8b77d9b5169'
--供应商_供应商信息
--/PowerPlat/FormXml/zh-CN/XLX_PUR/XLX_PUR_Supplie.htm
--select * from XLX_PUR_Supplie

--采购审批单
--XLX_PUR_Inquiry
--XLX_PUR_Inquiry_SupplieList
select * from PB_Widget where id='4b140dee-6936-46e8-bfc0-d37bc9478c69'
--采购_询价单
--/PowerPlat/FormXml/zh-CN/XLX_PUR/XLX_PUR_Inquiry.htm
--询价状态123
--InquiryStatusCombox
--供应商向导视图 View_XLX_PUR_SupplieHeGe



select * from PB_User
select * from XLX_PUR_Inquiry_SupplieList




--LINK START
select * from XLX_PUR_Inquiry where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
select * from XLX_PUR_Inquiry_MatList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
select * from XLX_PUR_Inquiry_SupplieList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'



update XLX_PUR_Inquiry set status = '23' where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryStatus='2' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';

select a.SupplieId,a.Code as SupplieCode,a.Name as SupplieName,b.*
from XLX_PUR_InquirySupplie a left join XLX_PUR_InquirySupplie_List b on a.Id = b.FK
where a.Inquiry_Id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

select * from XLX_PUR_InquiryOnline
SELECT * from XLX_PUR_InquiryOnline_MatList
SELECT * from XLX_PUR_InquiryOnline_Supply
SELECT * from XLX_PUR_InquiryOnline_Offer


insert into XLX_PUR_InquiryOnline select * from XLX_PUR_Inquiry where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
update XLX_PUR_InquiryOnline set InquiryCode = 'ZXXJ-'+InquiryCode where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
update XLX_PUR_InquiryOnline set Title = '在线询价-'+Title where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

insert into XLX_PUR_InquiryOnline_MatList select * from XLX_PUR_Inquiry_MatList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

insert into XLX_PUR_InquiryOnline_Supply select * from XLX_PUR_Inquiry_SupplieList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

insert into XLX_PUR_InquiryOnline_Offer
select b.*,a.SupplieId,a.Code as SupplieCode,a.Name as SupplieName,'f4968dd8-f22b-4218-a234-dcaa46f4fafe' as MasterId
from XLX_PUR_InquirySupplie a left join XLX_PUR_InquirySupplie_List b on a.Id = b.FK
where a.Inquiry_Id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'






--Email内容：东阳市晨昊金银线有限公司,三化建01您好，新的报价单；url：<a href=http://172.30.30.212:8002/StandardPage/StandardLogin.aspx?Opt=Inquiry&Key=f4968dd8-f22b-4218-a234-dcaa46f4fafe&Supplier=318d8dc4-9696-4c03-8238-000b7d7ac484>点击填写报价</a>
--Email内容：保定市玉立电子电器有限公司,王国栋您好，新的报价单；url：<a href=http://172.30.30.212:8002/StandardPage/StandardLogin.aspx?Opt=Inquiry&Key=f4968dd8-f22b-4218-a234-dcaa46f4fafe&Supplier=5e72e724-04fa-4c90-8735-00012bdf4d76>点击填写报价</a>
--Email内容：厦门洪鹭实业有限公司,王浩洋您好，新的报价单；url：<a href=http://172.30.30.212:8002/StandardPage/StandardLogin.aspx?Opt=Inquiry&Key=f4968dd8-f22b-4218-a234-dcaa46f4fafe&Supplier=d85aeced-5118-4ae4-b2b7-0014097d98d2>点击填写报价</a>
--Email内容：厦门洪鹭实业有限公司,严小宇您好，新的报价单；url：供应商：厦门洪鹭实业有限公司<br/><br/>报价人：严小宇<br/><br/><a href=http://172.30.30.212:8002/StandardPage/StandardLogin.aspx?Opt=Inquiry&Key=f4968dd8-f22b-4218-a234-dcaa46f4fafe&Supplier=d85aeced-5118-4ae4-b2b7-0014097d98d2>>>>查看报价单</a>
--http://172.30.30.212:8002/StandardPage/StandardLogin.aspx?Opt=Inquiry&Key=f4968dd8-f22b-4218-a234-dcaa46f4fafe&Supplier=318d8dc4-9696-4c03-8238-000b7d7ac484

select * from Standard_interfacelog
select * from PB_User where name='王国栋'

--重新测试的
delete from XLX_PUR_InquiryOnline
delete from XLX_PUR_InquiryOnline_MatList
delete from XLX_PUR_InquiryOnline_Supply
delete from XLX_PUR_InquiryOnline_Offer
delete from Standard_interfacelog
update XLX_PUR_Inquiry set status = '0' where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryStatus='1' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';

--更改询价状态的
update XLX_PUR_InquiryOnline_Supply set InquiryStatus ='2'
update XLX_PUR_InquiryOnline set Status=23
select * from XLX_PUR_InquiryOnline_Supply where InquiryStatus != ''
