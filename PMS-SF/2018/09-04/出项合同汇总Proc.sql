alter proc Proc_SF_OutContractAnalyse(@BeginDate nvarchar(200),@EndDate nvarchar(200))
as
--��Ϊ��
if (@BeginDate is null or @BeginDate ='') and (@EndDate is null or @EndDate ='')
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--�����ͬ����
  (select count(*) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--�����ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--�ɹ���ͬ����
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--����������
  (select Count(*) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--�ɹ���ͬ�ܽ��
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--��������
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')) 
) al
where al.OutCount !=0
end

--�п�ʼʱ��
if (@BeginDate is not null and @BeginDate !='' and (@EndDate is null or @EndDate =''))
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--�����ͬ����
  (select count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--�����ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--�ɹ���ͬ����
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--����������
  (select Count(*) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--�ɹ���ͬ�ܽ��
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--��������
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate>@BeginDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end

--�н���ʱ��
if (@BeginDate is null or @BeginDate ='') and @EndDate is not null and @EndDate !=''
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--�����ͬ����
  (select count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--�����ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--�ɹ���ͬ����
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--����������
  (select Count(*) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--�ɹ���ͬ�ܽ��
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--��������
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate<@EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end


--����
if @BeginDate is not null and @BeginDate !='' and @EndDate is not null and @EndDate !=''
begin
select al.* from(
select project_shortname,LongCode,project_name,project_guid,parent_guid,
--�����ͬ����
  (select count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutCount,
--�����ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and EPSProjectId = pln_project.project_guid) as OutSum,
--�ɹ���ͬ����
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Count,
--��������������
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Count,
--����������
  (select Count(*) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Count,
--�ɹ���ͬ�ܽ��
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='P' and EPSProjectId = pln_project.project_guid) as P_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='E' and EPSProjectId = pln_project.project_guid) as E_Sum,
--�����������ͬ���
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='C' and EPSProjectId = pln_project.project_guid) as C_Sum,
--��������
  (select isnull(sum(FinalSubContractAmount),0) from PS_CM_SubContract where SignDate between @BeginDate and @EndDate and status=50 and SubContractType='S' and EPSProjectId = pln_project.project_guid) as S_Sum
from pln_project where pln_project.project_guid in(select id from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))
) al
where al.OutCount !=0
end


