--变更
--土建
select sum(isnull(EstimatedAmount,0)) as ChangeAmount from SF_SJ_ChangeApplication where ProjectType='01' and ProjectNameId='0f1d4c6c-67cb-42be-997e-670e2c30efa8' and Status=50 group by ProjectNameId
--安装
select sum(EstimatedAmount) as ChangeAmount from SF_SJ_ChangeApplication where ProjectType='02' and ProjectNameId='0f1d4c6c-67cb-42be-997e-670e2c30efa8' group by ProjectNameId

--签证
--土建
select sum(EstimatedCost) as SignAmount  from SF_PD_VisaSiteApprovalSheet where  ProjectType='01' and ProjectNameId='0f1d4c6c-67cb-42be-997e-670e2c30efa8' group by ProjectNameId
--安装
select sum(EstimatedCost) as SignAmount  from SF_PD_VisaSiteApprovalSheet where  ProjectType='02' and ProjectNameId='0f1d4c6c-67cb-42be-997e-670e2c30efa8' group by ProjectNameId


select case when b.Name='变更' then  '1111' else Isnull(d.MatMoney,0) end as RealPrice,ISNULL(b.Price,0) as CostPrice,(Isnull(d.MatMoney,0) - ISNULL(b.Price,0)) as RealDiff,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType, b.* from SF_FK_EquipmentCostSchedule a inner join PB_DefaultField s on a.Id = s.DefaultFieldId inner join SF_FK_EquipmentCostSchedule_dtl b on a.id = b.masterid left join(select c.mat_guid,c.MatMoney, b.scheduledtlid from SF_CG_PurchasePlan a inner join SF_CG_PurchasePlanList b on a.id = b.masterid left join(select b.mat_guid,sum(isnull(MatMoney,0)) as MatMoney from PS_CM_SubContract a inner join PS_CM_SubContract_MatItem b on a.id = b.masterid where a.status = 50 group by  b.mat_guid)c on b.id = c.mat_guid)d on b.id = d.scheduledtlid where s.Status=50 and EpsId='0F1D4C6C-67CB-42BE-997E-670E2C30EFA8' order by b.sequ


select case when b.Name='变更' then  '1111' when b.Name='签证' then '22222' else ISNULL(fk.fk_price,0) end as RealPrice, ISNULL(dr.dr_price,0) DrawPrice,ISNULL(b.Price,0) as CostPrice,(ISNULL(b.Price,0)- ISNULL(dr.dr_price,0)) as Diff1,(ISNULL(b.Price,0)-ISNULL(fk.fk_price,0)) as Diff2,b.* from SF_FK_EstablishCostSchedule a inner join PB_DefaultField s on a.Id = s.DefaultFieldId inner join SF_FK_EstablishCostSchedule_dtl b on a.ID = b.masterid left join(select b.listId,sum(isnull(b.price,0)) as dr_price from SF_DrawingBudget a inner join SF_DrawingBudget_dtl b on a.id = b.masterid group by b.listId)dr on b.id = dr.listId left join(select b.listid,sum(isnull(b.price,0)) as fk_price from SF_FK_EstablishCostFeedback a inner join SF_FK_EstablishCostFeedback_dtl b on a.id = b.masterid group by b.listId)fk on b.id = fk.listId where s.Status=50 and a.EpsId ='0F1D4C6C-67CB-42BE-997E-670E2C30EFA8' order by sequ


select * from PB_Widget where id='16eae063-aa9b-4fdd-b790-da7de904706b'
--/PowerPlat/FormXml/zh-CN/SF_PD/SF_VisaSiteApprovalSheet.htm

select * from PB_Wizard where WizardId='44e8bed7-d429-275e-2a9b-2904f224fc07'

select * from PS_CM_SubContract
select * from SF_PD_VisaSiteApprovalSheet