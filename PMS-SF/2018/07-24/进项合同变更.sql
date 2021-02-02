--项目变更_进项合同变更申请
--/PowerPlat/FormXml/zh-CN/StdCost/PS_ContractChangeApply.htm
select * from PB_Widget where id='0f8849cc-48f3-4a1a-8a98-bd9e52401802'

--项目变更_进项合同变更登记
--/PowerPlat/FormXml/zh-CN/StdCost/PS_IncomeContractChange.htm
select * from PB_Widget where id='6d0387b0-8a57-4422-8dd4-ac415e418b46'


--合同登记
select * from PB_Widget where id='34399717-2ebe-40fe-9fd7-bca7b76f54e4'
--/PowerPlat/FormXml/zh-CN/StdContract/IncomeContract.htm

--合同请款视图
create view View_SF_IncomeContractApply
as
select * from PS_mk_ContractInfo al left join
(select MasterId,sum(CheckAmount) as CheckAmount from PS_MK_ContractInfo_PayNodes  group by MasterId) alr on al.Id=alr.MasterId 

select * from PB_Wizard where WizardId='de2145bb-3b11-4188-8766-5ca8aa6530df'
--/PowerPlat/FormXml/zh-CN/StdMarket/WizardContractInfoList.htm


select * from PS_CM_ContractApplyMoney

delete from PS_CM_ContractApplyMoney

select * from PS_MK_ContractInfo

update PS_MK_ContractInfo set status=0
select * from PS_MK_ContractInfo_PayNodes

---------------------------------------------------
create view View_SF_IncomeContractApply_C
as
select distinct al.Id,al.ContractForm,al.ContractCode,al.ContractName,al.PartyA,al.ContractStrartDate,al.ContractEndDate,al.FinalContractAmount,al.EpsProjId,al.RegDate
from PS_mk_ContractInfo al
inner join PS_MK_ContractInfo_PayNodes on al.Id=PS_MK_ContractInfo_PayNodes.MasterId and isnull(PS_MK_ContractInfo_PayNodes.CheckAmount,0) <>  0
where status=50 and isnull(al.ContractForm,0) = 2 
union
select alro.id,alro.ContractForm,alro.ContractCode,alro.ContractName,alro.PartyA,alro.ContractStrartDate,alro.ContractEndDate,alro.FinalContractAmount,alro.EpsProjId,alro.RegDate
from PS_mk_ContractInfo alro where status=50 and isnull(alro.ContractForm,0) = 1 --and isnull(alro.RunStatus,0) <> 3

--将查询内容分成两块，每块做过滤
--闭口合同，剩余支付节点不等于0
select al.Id,al.ContractForm,al.ContractCode,al.ContractName,al.PartyA,al.ContractStrartDate,al.ContractEndDate,al.FinalContractAmount,al.EpsProjId,al.RegDate
from PS_mk_ContractInfo al
inner join PS_MK_ContractInfo_PayNodes on al.Id=PS_MK_ContractInfo_PayNodes.MasterId and isnull(PS_MK_ContractInfo_PayNodes.CheckAmount,0) <>  0
where status=50 and isnull(al.ContractForm,0) = 2
--union
--开口合同，只要批准都能选
select alro.id,alro.ContractForm,alro.ContractCode,alro.ContractName,alro.PartyA,alro.ContractStrartDate,alro.ContractEndDate,alro.FinalContractAmount,alro.EpsProjId,alro.RegDate
from PS_mk_ContractInfo alro where status=50 and isnull(alro.ContractForm,0) = 1 --and isnull(alro.RunStatus,0) <> 3


select * from View_SF_IncomeContractApply_C 















select * from PB_Wizard where WizardId='de2145bb-3b11-4188-8766-5ca8aa6530df'
--/PowerPlat/FormXml/zh-CN/StdMarket/WizardContractInfoList.htm
select RunStatus,* from PS_mk_ContractInfo


delete from PS_CM_ContractApplyMoney
delete from PS_CM_ContractApplyMoney_Nodes

create view View_SF_ContractPay
as
select RealApplyAmout -(select isnull(sum(ReceiveAmount),0) from PS_CM_ContractReceipt where contractapplyid = a.id) as LeaveAmount,
a.* from PS_CM_ContractApplyMoney a 
where a.status = 50
and (RealApplyAmout -(select isnull(sum(ReceiveAmount),0) from PS_CM_ContractReceipt where contractapplyid = a.id) > 0)

select * from View_SF_ContractPay

