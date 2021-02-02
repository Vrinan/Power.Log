alter View View_SF_ProjCost
as
select 
--��Ŀ��Ϣ
a.LongCode as ProjCode,a.project_name as ProjName,a.project_guid as Id,a.parent_guid as ParentId,
--�ɱ��ƻ�
IsNull((select Total from SF_FK_EquipmentCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) EquipmentCost,
IsNull((select Total from SF_FK_EstablishCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) EstablishCost,
IsNull((select Total from SF_FK_InstallCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) InstallCost,
IsNull((select Total from SF_FK_ManageCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) ManageCost,
IsNull((select Total from SF_FK_OtherCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) OtherCost,
--�ϼ�
IsNull(IsNull((select Total from SF_FK_EquipmentCostSchedule where IsNew = 1 and EpsId= a.project_guid),0)+
IsNull((select Total from SF_FK_EstablishCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_InstallCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_ManageCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_OtherCostSchedule where IsNew = 1 and EpsId= a.project_guid),0),0) CostSum,
--��ͬǩ�����
IsNull((select sum(SubContractAmount) from PS_CM_SubContract where EpsProjectId = a.project_guid),0) ContractSignAmount,
--��ͬ������
IsNull((select sum(ChangeAmount) from SF_Contract_Change where SubContract_Guid in (select Id from PS_CM_SubContract where EpsProjectId = a.project_guid)),0) ContractChangeAmount,
--��Ŀǩ֤
IsNull((select sum(EstimatedCost) from SF_PD_VisaSiteApprovalSheet where ProjectNameId=a.project_guid),0) ProjectSign,
--ʵ�����
IsNull((select sum(Price) from SF_FK_EquipmentCostFeedback_dtl where MasterId in(select Id from SF_FK_EquipmentCostFeedback where EpsProjectId = a.project_guid)),0) EquipmentCostFeedBack,
IsNull((select sum(Price) from SF_FK_EstablishCostFeedback_dtl where MasterId in(select Id from SF_FK_EstablishCostFeedback where EpsProjectId = a.project_guid)),0) EstablishCostFeedBack,
IsNull((select sum(Price) from SF_FK_InstallCostFeedback_dtl where MasterId in(select Id from SF_FK_InstallCostFeedback where EpsProjectId = a.project_guid)),0) InstallCostFeedBack,
IsNull((select sum(Price) from SF_FK_ManageCostFeedback_dtl where MasterId in(select Id from SF_FK_ManageCostFeedback where EpsProjectId = a.project_guid)),0) ManageCostFeedBack,
IsNull((select sum(Price) from SF_FK_OtherCostFeedback_dtl where MasterId in(select Id from SF_FK_OtherCostFeedback where EpsProjectId = a.project_guid)),0) OtherCostFeedBack,
--ʵ����ɺϼ�
IsNull(IsNull((select sum(Price) from SF_FK_EquipmentCostFeedback_dtl where MasterId in(select Id from SF_FK_EquipmentCostFeedback where EpsProjectId = a.project_guid)),0)+
IsNull((select sum(Price) from SF_FK_EstablishCostFeedback_dtl where MasterId in(select Id from SF_FK_EstablishCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_InstallCostFeedback_dtl where MasterId in(select Id from SF_FK_InstallCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_ManageCostFeedback_dtl where MasterId in(select Id from SF_FK_ManageCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_OtherCostFeedback_dtl where MasterId in(select Id from SF_FK_OtherCostFeedback where EpsProjectId = a.project_guid)),0) ,0) CostFeedBackSum,
--���
(IsNull((select Total from SF_FK_EquipmentCostSchedule where IsNew = 1 and EpsId= a.project_guid),0)+
IsNull((select Total from SF_FK_EstablishCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_InstallCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_ManageCostSchedule where IsNew = 1 and EpsId= a.project_guid),0) +
IsNull((select Total from SF_FK_OtherCostSchedule where IsNew = 1 and EpsId= a.project_guid),0)) -
(IsNull((select sum(Price) from SF_FK_EquipmentCostFeedback_dtl where MasterId in(select Id from SF_FK_EquipmentCostFeedback where EpsProjectId = a.project_guid)),0)+
IsNull((select sum(Price) from SF_FK_EstablishCostFeedback_dtl where MasterId in(select Id from SF_FK_EstablishCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_InstallCostFeedback_dtl where MasterId in(select Id from SF_FK_InstallCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_ManageCostFeedback_dtl where MasterId in(select Id from SF_FK_ManageCostFeedback where EpsProjectId = a.project_guid)),0) +
IsNull((select sum(Price) from SF_FK_OtherCostFeedback_dtl where MasterId in(select Id from SF_FK_OtherCostFeedback where EpsProjectId = a.project_guid)),0)) Diff
from PLN_project a where a.project_guid in (select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674'))