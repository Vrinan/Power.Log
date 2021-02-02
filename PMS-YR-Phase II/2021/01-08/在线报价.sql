--LINK START
select * from XLX_PUR_Inquiry where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
select * from XLX_PUR_Inquiry_MatList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'
select * from XLX_PUR_Inquiry_SupplieList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

select a.SupplieId,a.Code as SupplieCode,a.Name as SupplieName,b.*
from XLX_PUR_InquirySupplie a left join XLX_PUR_InquirySupplie_List b on a.Id = b.FK
where a.Inquiry_Id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

select * from XLX_PUR_InquiryOnline
delete from XLX_PUR_InquiryOnline

insert into XLX_PUR_InquiryOnline 
select * from XLX_PUR_Inquiry where id='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

insert into XLX_PUR_InquiryOnline_MatList
select * from XLX_PUR_Inquiry_MatList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'

insert into XLX_PUR_InquiryOnline_Supply
select * from XLX_PUR_Inquiry_SupplieList where fk='f4968dd8-f22b-4218-a234-dcaa46f4fafe'


