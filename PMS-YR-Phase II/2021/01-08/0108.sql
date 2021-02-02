alter table XLX_PUR_Inquiry add InquiryEndDate datetime null

alter table XLX_PUR_Inquiry_SupplieList add InquiryHumanId uniqueidentifier null
alter table XLX_PUR_Inquiry_SupplieList add InquiryHumanName nvarchar(max) null
alter table XLX_PUR_Inquiry_SupplieList add InquiryStatus nvarchar(max) null

select * from XLX_PUR_SupplieHeGe where id ='48e0320a-a707-4fa6-8b6d-fadaa84818c7'
select * from View_XLX_PUR_SupplieHeGe
select * from XLX_PUR_Supplie where id ='48e0320a-a707-4fa6-8b6d-fadaa84818c7'

select * from PB_Widget where id='ce1d49f6-f89a-44b8-a271-ab677f883351'
--物资类别定义bak
--/PowerPlat/FormXml/zh-CN/StdMasterData/Win_PS_MDM_MatBSbak.htm



select * from View_XLX_InquirySupplie