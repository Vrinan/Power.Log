--采购审批单-议价

--1、报价物资项数
alter table XLX_PUR_Inquiry_SupplieList add InquiryMatNum int null
alter table XLX_PUR_InquiryOnline_Supply add InquiryMatNum int null

select count(*) as Num from XLX_PUR_InquiryOnline_Offer where MasterId='f9239713-3910-4895-aa51-fd81a5ef55d6' and MatPrice != 0
--2、在线议价
select * from Standard_interfacelog

select * from XLX_PUR_InquiryOnline
SELECT * from XLX_PUR_InquiryOnline_MatList
SELECT * from XLX_PUR_InquiryOnline_Supply
SELECT * from XLX_PUR_InquiryOnline_Offer

--重新测试的
delete from Standard_interfacelog
delete from XLX_PUR_InquiryOnline
delete from XLX_PUR_InquiryOnline_MatList
delete from XLX_PUR_InquiryOnline_Supply
delete from XLX_PUR_InquiryOnline_Offer
update XLX_PUR_Inquiry set status = '0' where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryStatus='1' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryMatNum='0' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';


select InquiryStatus from XLX_PUR_Inquiry_SupplieList where FK='' and SupplieId=''


select * from XLX_PUR_InquiryOnline_Offer


select count(*) as num from XLX_PUR_Inquiry_SupplieList where InquiryStatus =5 and FK='f4968dd8-f22b-4218-a234-dcaa46f4fafe'



