Select Count(*) From view_XLX_Inquiry_Union_WinNotice Where   1=1 and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d'

Select Top 10 * From view_XLX_Inquiry_Union_WinNotice Where   1=1 and EpsProjId='22499ebc-401c-44e1-a036-6134dd424d8d' Order By  RegDate


select id,* from view_XLX_Inquiry_Union_WinNotice
select Id,RegDate,InquiryCode as Code,Title,BuyerId,BuyerName,SupplieId,SupplieName,EpsProjId,'采购询价' as Type from XLX_PUR_Inquiry where (Status=50 or Status=35) and (ContractId is null or ContractId='00000000-0000-0000-0000-000000000000')
union
select a.Id,a.RegDate,a.XLX_Code as Code,a.Title,b.RegHumId as BuyerId,b.RegHumName as BuyerName,
a.WinBidSupplierId as SupplieId,a.WinBidSupplier as SupplieName,a.EpsProjId,'中标通知书' as Type from 
PS_BID_BidWinNotice a   inner join XLX_PS_BID_Inquiry b on a.BidInquiry_Guid=b.Id
where (a.Status=50 or a.Status=35) and a.InquiryType=0  and (a.XLX_ContractId is null or a.XLX_ContractId='00000000-0000-0000-0000-000000000000')
 
--采购审批单/询价条件：XLX_PUR_Inquiry b
select id,* from XLX_PUR_Inquiry where(Status=50 or Status=35) and (ContractId is null or ContractId='00000000-0000-0000-0000-000000000000')
--中标通知书：PS_BID_BidWinNotice a---InquiryType：0采购，1分包
select BidInquiry_Guid,id,InquiryType,* from PS_BID_BidWinNotice a where (a.Status=50 or a.Status=35) and a.InquiryType=0  and (a.XLX_ContractId is null or a.XLX_ContractId='00000000-0000-0000-0000-000000000000')