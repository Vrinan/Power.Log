alter proc [dbo].[Proc_SF_InContractAnalyse](@BeginDate nvarchar(200),@EndDate nvarchar(200))
as
--都为空
if (@BeginDate is null or @BeginDate ='') and (@EndDate is null or @EndDate ='')
begin
select al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid,
count(ContractCode) as Incount,sum(FinalContractAmount) as InContractAmount,
sum(InvoiceCount) as InvoiceCount,sum(InvoiceAmount) as InvoiceAmount,
sum(InApplyCount) as InApplyCount,sum(InApplyAmount) as InApplyAmount,
sum(InReceiveCount) as InReceiveCount,sum(InReceiveAmount) as InReceiveAmount
from(
select a.Id,a.ContractCode,a.ContractName,a.FinalContractAmount,a.SignedDate,a.EpsProjectId,
(select count(TotalInvoiceAmount) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceCount,
(select isnull(sum(b.TotalInvoiceAmount),0) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceAmount,
(select count(RealApplyAmout) from PS_CM_ContractApplyMoney b where b.status=50 and a.Id = b.Contract_Guid) InApplyCount,
(select isnull(sum(c.RealApplyAmout),0) from PS_CM_ContractApplyMoney c where c.status=50 and a.Id = c.Contract_Guid) InApplyAmount,
(select count(ReceiveAmount) from PS_CM_ContractReceipt b where b.status=50 and a.Id = b.Contract_Guid) InReceiveCount,
(select isnull(sum(d.ReceiveAmount),0) from PS_CM_ContractReceipt d where d.status=50 and a.Id = d.Contract_Guid) InReceiveAmount,
(select project_guid from PLN_project e where e.project_guid = a.EPSProjectId) project_guid,
(select project_shortname from PLN_project e where e.project_guid = a.EPSProjectId) project_shortname,
(select LongCode from PLN_project e where e.project_guid = a.EPSProjectId) LongCode,
(select project_name from PLN_project e where e.project_guid = a.EPSProjectId) project_name,
(select parent_guid from PLN_project e where e.project_guid = a.EPSProjectId) parent_guid
from PS_MK_ContractInfo a where a.Status=50
) al group by al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid
end



--有开始时间
if (@BeginDate is not null and @BeginDate !='' and (@EndDate is null or @EndDate =''))
begin
select al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid,
count(ContractCode) as Incount,sum(FinalContractAmount) as InContractAmount,
sum(InvoiceCount) as InvoiceCount,sum(InvoiceAmount) as InvoiceAmount,
sum(InApplyCount) as InApplyCount,sum(InApplyAmount) as InApplyAmount,
sum(InReceiveCount) as InReceiveCount,sum(InReceiveAmount) as InReceiveAmount
from(
select a.Id,a.ContractCode,a.ContractName,a.FinalContractAmount,a.SignedDate,a.EpsProjectId,
(select count(TotalInvoiceAmount) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceCount,
(select isnull(sum(b.TotalInvoiceAmount),0) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceAmount,
(select count(RealApplyAmout) from PS_CM_ContractApplyMoney b where b.status=50 and a.Id = b.Contract_Guid) InApplyCount,
(select isnull(sum(c.RealApplyAmout),0) from PS_CM_ContractApplyMoney c where c.status=50 and a.Id = c.Contract_Guid) InApplyAmount,
(select count(ReceiveAmount) from PS_CM_ContractReceipt b where b.status=50 and a.Id = b.Contract_Guid) InReceiveCount,
(select isnull(sum(d.ReceiveAmount),0) from PS_CM_ContractReceipt d where d.status=50 and a.Id = d.Contract_Guid) InReceiveAmount,
(select project_guid from PLN_project e where e.project_guid = a.EPSProjectId) project_guid,
(select project_shortname from PLN_project e where e.project_guid = a.EPSProjectId) project_shortname,
(select LongCode from PLN_project e where e.project_guid = a.EPSProjectId) LongCode,
(select project_name from PLN_project e where e.project_guid = a.EPSProjectId) project_name,
(select parent_guid from PLN_project e where e.project_guid = a.EPSProjectId) parent_guid
from PS_MK_ContractInfo a where a.Status=50 and a.SignedDate>@BeginDate
) al group by al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid
end

--有结束时间
if (@BeginDate is null or @BeginDate ='') and @EndDate is not null and @EndDate !=''
begin
select al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid,
count(ContractCode) as Incount,sum(FinalContractAmount) as InContractAmount,
sum(InvoiceCount) as InvoiceCount,sum(InvoiceAmount) as InvoiceAmount,
sum(InApplyCount) as InApplyCount,sum(InApplyAmount) as InApplyAmount,
sum(InReceiveCount) as InReceiveCount,sum(InReceiveAmount) as InReceiveAmount
from(
select a.Id,a.ContractCode,a.ContractName,a.FinalContractAmount,a.SignedDate,a.EpsProjectId,
(select count(TotalInvoiceAmount) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceCount,
(select isnull(sum(b.TotalInvoiceAmount),0) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceAmount,
(select count(RealApplyAmout) from PS_CM_ContractApplyMoney b where b.status=50 and a.Id = b.Contract_Guid) InApplyCount,
(select isnull(sum(c.RealApplyAmout),0) from PS_CM_ContractApplyMoney c where c.status=50 and a.Id = c.Contract_Guid) InApplyAmount,
(select count(ReceiveAmount) from PS_CM_ContractReceipt b where b.status=50 and a.Id = b.Contract_Guid) InReceiveCount,
(select isnull(sum(d.ReceiveAmount),0) from PS_CM_ContractReceipt d where d.status=50 and a.Id = d.Contract_Guid) InReceiveAmount,
(select project_guid from PLN_project e where e.project_guid = a.EPSProjectId) project_guid,
(select project_shortname from PLN_project e where e.project_guid = a.EPSProjectId) project_shortname,
(select LongCode from PLN_project e where e.project_guid = a.EPSProjectId) LongCode,
(select project_name from PLN_project e where e.project_guid = a.EPSProjectId) project_name,
(select parent_guid from PLN_project e where e.project_guid = a.EPSProjectId) parent_guid
from PS_MK_ContractInfo a where a.Status=50 and a.SignedDate<@EndDate
) al group by al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid
end

--都有
if @BeginDate is not null and @BeginDate !='' and @EndDate is not null and @EndDate !=''
begin
select al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid,
count(ContractCode) as Incount,sum(FinalContractAmount) as InContractAmount,
sum(InvoiceCount) as InvoiceCount,sum(InvoiceAmount) as InvoiceAmount,
sum(InApplyCount) as InApplyCount,sum(InApplyAmount) as InApplyAmount,
sum(InReceiveCount) as InReceiveCount,sum(InReceiveAmount) as InReceiveAmount
from(
select a.Id,a.ContractCode,a.ContractName,a.FinalContractAmount,a.SignedDate,a.EpsProjectId,
(select count(TotalInvoiceAmount) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceCount,
(select isnull(sum(b.TotalInvoiceAmount),0) from PS_CM_InvoiceRecord b where b.status=50 and a.Id = b.Contract_Guid) InvoiceAmount,
(select count(RealApplyAmout) from PS_CM_ContractApplyMoney b where b.status=50 and a.Id = b.Contract_Guid) InApplyCount,
(select isnull(sum(c.RealApplyAmout),0) from PS_CM_ContractApplyMoney c where c.status=50 and a.Id = c.Contract_Guid) InApplyAmount,
(select count(ReceiveAmount) from PS_CM_ContractReceipt b where b.status=50 and a.Id = b.Contract_Guid) InReceiveCount,
(select isnull(sum(d.ReceiveAmount),0) from PS_CM_ContractReceipt d where d.status=50 and a.Id = d.Contract_Guid) InReceiveAmount,
(select project_guid from PLN_project e where e.project_guid = a.EPSProjectId) project_guid,
(select project_shortname from PLN_project e where e.project_guid = a.EPSProjectId) project_shortname,
(select LongCode from PLN_project e where e.project_guid = a.EPSProjectId) LongCode,
(select project_name from PLN_project e where e.project_guid = a.EPSProjectId) project_name,
(select parent_guid from PLN_project e where e.project_guid = a.EPSProjectId) parent_guid
from PS_MK_ContractInfo a where a.Status=50 and a.SignedDate between @BeginDate and @EndDate
) al group by al.project_guid,al.project_shortname,al.LongCode,al.project_name,al.parent_guid
end
