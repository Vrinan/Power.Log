select * from PB_Widget where id='4f5061a5-5ab6-43e5-8e4e-80577fb5d02b'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SF_InComeContractBudget.htm
select * from PB_BaseData where DataType='AmountType'

select * from PB_Widget where id='8b7dcd69-d7f6-4cb6-84c7-20ea8d446e0b'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_DesFinishManagement.htm
--合同金额
--累计申请
--累计开票
--累计到款
--未申请金额
--未开票金额
--未到款金额


select a.AmountType,s.Name,
Isnull(a.TotalAmount,0) as ContractAmount,Isnull(c.TotalAmount,0) as ApplyAmount,
Isnull(e.TotalAmount,0) as InvoiceAmount,Isnull(g.TotalAmount,0) as ReceiptAmount,
(Isnull(a.TotalAmount,0) - Isnull(c.TotalAmount,0)) as NeverApplyAmount,
(Isnull(a.TotalAmount,0) - Isnull(e.TotalAmount,0)) as NeverInvoiceAmount,
(Isnull(a.TotalAmount,0) - Isnull(g.TotalAmount,0)) as NeverReceiptAmount
from SF_Contract_AmountList a 
left join
(select Code,Name from PB_BaseDataList where BaseDataId = 'D0EBA7C9-02E9-4BB2-8C01-E385E7D3B3C3') s on s.Code = a.AmountType
left join
(select b.AmountType,sum(b.TotalAmount) as TotalAmount from SF_Contract_AmountList b where b.MasterId in (select Id from PS_CM_ContractApplyMoney where Contract_Guid = '15450986-29b5-4f43-bac0-ed5a75b0efb1') group by b.AmountType) c on a.AmountType = c.AmountType
left join
(select d.AmountType,sum(d.TotalAmount) as TotalAmount from SF_Contract_AmountList d where d.MasterId in (select Id from PS_CM_InvoiceRecord where Contract_Guid = '15450986-29b5-4f43-bac0-ed5a75b0efb1') group by d.AmountType) e on a.AmountType = e.AmountType
left join
(select f.AmountType,sum(f.TotalAmount) as TotalAmount from SF_Contract_AmountList f where f.MasterId in (select Id from PS_CM_ContractReceipt where Contract_Guid = '15450986-29b5-4f43-bac0-ed5a75b0efb1') group by f.AmountType) g on a.AmountType = g.AmountType
where a.MasterId = '15450986-29b5-4f43-bac0-ed5a75b0efb1' order by a.AmountType



alter proc P_SF_InComeContractAmountList(@ContractId nvarchar(200))
as
select a.AmountType,s.Name,Isnull(a.TotalAmount,0) as ContractAmount,Isnull(c.TotalAmount,0) as ApplyAmount,
Isnull(e.TotalAmount,0) as InvoiceAmount,Isnull(g.TotalAmount,0) as ReceiptAmount,
(Isnull(a.TotalAmount,0) - Isnull(c.TotalAmount,0)) as NeverApplyAmount,
(Isnull(a.TotalAmount,0) - Isnull(e.TotalAmount,0)) as NeverInvoiceAmount,
(Isnull(a.TotalAmount,0) - Isnull(g.TotalAmount,0)) as NeverReceiptAmount
from SF_Contract_AmountList a 
left join
(select Code,Name from PB_BaseDataList where BaseDataId = 'D0EBA7C9-02E9-4BB2-8C01-E385E7D3B3C3') s on s.Code = a.AmountType
left join
(select b.AmountType,sum(b.TotalAmount) as TotalAmount from SF_Contract_AmountList b where b.MasterId in (select Id from PS_CM_ContractApplyMoney where Contract_Guid = @ContractId) group by b.AmountType) c on a.AmountType = c.AmountType
left join
(select d.AmountType,sum(d.TotalAmount) as TotalAmount from SF_Contract_AmountList d where d.MasterId = (select Id from PS_CM_InvoiceRecord where Contract_Guid = @ContractId) group by d.AmountType) e on a.AmountType = e.AmountType
left join
(select f.AmountType,sum(f.TotalAmount) as TotalAmount from SF_Contract_AmountList f where f.MasterId = (select Id from PS_CM_ContractReceipt where Contract_Guid = @ContractId) group by f.AmountType) g on a.AmountType = g.AmountType
where a.MasterId = @ContractId order by a.AmountType

exec P_SF_InComeContractAmountList '15450986-29b5-4f43-bac0-ed5a75b0efb1'
