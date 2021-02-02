alter table XLX_PUR_Inquiry_SupplieList add PaymentMethod nvarchar(max) null
alter table XLX_PUR_Inquiry_SupplieList add SettlementMethod nvarchar(max) null
alter table XLX_PUR_Inquiry_SupplieList add WarrantyAmount numeric(23,2) null
alter table XLX_PUR_Inquiry_SupplieList add DiscountMethod nvarchar(max) null


select * from XLX_PUR_Inquiry_SupplieList