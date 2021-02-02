alter proc Proc_SF_OutContractAnalyse(@BeginDate nvarchar(200),@EndDate nvarchar(200))
as
--都为空
if (@BeginDate is null or @BeginDate ='') and (@EndDate is null or @EndDate ='')
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--出项合同数量
  (select count(*) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--出项合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--采购合同数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--技术服务类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--建安工程类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--其他类数量
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--采购合同总金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')) 
) al
where al.OutCount !=0
end

--有开始时间
if (@BeginDate is not null and @BeginDate !='' and (@EndDate is null or @EndDate =''))
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--出项合同数量
  (select count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--出项合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--采购合同数量
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--技术服务类数量
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--建安工程类数量
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--其他类数量
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--采购合同总金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end

--有结束时间
if (@BeginDate is null or @BeginDate ='') and @EndDate is not null and @EndDate !=''
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--出项合同数量
  (select count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--出项合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--采购合同数量
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--技术服务类数量
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--建安工程类数量
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--其他类数量
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--采购合同总金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end


--都有
if @BeginDate is not null and @BeginDate !='' and @EndDate is not null and @EndDate !=''
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--出项合同数量
  (select count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--出项合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--采购合同数量
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--技术服务类数量
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--建安工程类数量
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--其他类数量
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--采购合同总金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--技术服务类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--建安工程类合同金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--其他类金额
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end


