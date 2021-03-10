--ÖØÐÂ²âÊÔµÄ
delete from Standard_interfacelog
delete from XLX_PUR_InquiryOnline
delete from XLX_PUR_InquiryOnline_MatList
delete from XLX_PUR_InquiryOnline_Supply
delete from XLX_PUR_InquiryOnline_Offer
update XLX_PUR_Inquiry set status = '0' where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryStatus='1' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';
update XLX_PUR_Inquiry_SupplieList set InquiryMatNum='0' where FK ='f4968dd8-f22b-4218-a234-dcaa46f4fafe';





select * from Standard_interfacelog
delete from Standard_interfacelog

select * from XLX_PUR_Inquiry_SupplieList

update XLX_PUR_Inquiry set Status = '26' where Id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'; 
update XLX_PUR_InquiryOnline set Status = '26' where Id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'; 
update XLX_PUR_Inquiry_SupplieList set InquiryStatus = '3' where SupplieId='5e72e724-04fa-4c90-8735-00012bdf4d76';
 update XLX_PUR_InquiryOnline_Supply set InquiryStatus = '3' where SupplieId='5e72e724-04fa-4c90-8735-00012bdf4d76';
  update XLX_PUR_Inquiry_SupplieList set InquiryStatus = '3' where SupplieId='d85aeced-5118-4ae4-b2b7-0014097d98d2';
   update XLX_PUR_InquiryOnline_Supply set InquiryStatus = '3' where SupplieId='d85aeced-5118-4ae4-b2b7-0014097d98d2';
