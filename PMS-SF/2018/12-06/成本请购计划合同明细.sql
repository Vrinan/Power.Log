select * from PB_Widget where id='f06c7dd0-3b5f-44d1-82ea-f3d9817649f5'
--/PowerPlat/FormXml/zh-CN/SF_FK/Win_SF_CostCompared.htm
--
select a.Id as MainId,a.Code as MainCode,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType,c.* from SF_FK_EquipmentCostSchedule a 
left join PB_DefaultField b on a.Id = b.DefaultFieldId 
left join  SF_FK_EquipmentCostSchedule_dtl c on a.Id=c.MasterId
where b.Status=50 and a.IsNew='1'
--and EpsId=''
order by Sequ


--计划主表
select * from SF_CG_PurchasePlan where ProjId is not null and Status=5
--计划子表
select ScheduleDtlId from SF_CG_PurchasePlanList where ScheduleDtlId is not null
--合同明细
select Mat_Guid,MatMoney from PS_CM_SubContract_MatItem

--select a.Status,a.ProjId,b.ScheduleDtlId,c.MatMoney from SF_CG_PurchasePlan a left join SF_CG_PurchasePlanList b on a.Id = b.MasterId
--where a.ProjId is not null and b.ScheduleDtlId is not null

select d.MatMoney,d.scheduledtlid, a.Id as MainId,a.Code as MainCode,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType, b.* from SF_FK_EquipmentCostSchedule a
inner join SF_FK_EquipmentCostSchedule_dtl b on a.id = b.masterid
left join(
    select c.mat_guid,c.MatMoney, b.scheduledtlid from SF_CG_PurchasePlan a
	inner join SF_CG_PurchasePlanList b on a.id = b.masterid
	left join(
	  select b.mat_guid,sum(isnull(MatMoney,0)) as MatMoney from PS_CM_SubContract a
	  inner join PS_CM_SubContract_MatItem b on a.id = b.masterid
	  where a.status = 50
	  group by  b.mat_guid
	)c on b.id = c.mat_guid
)d on b.id = d.scheduledtlid
where a.EpsId = 'C8A39D6C-1951-4CFB-A5BC-AF638506AA6A'
order by b.sequ



select Isnull(d.MatMoney,0) as MatMoney,d.scheduledtlid, a.Id as MainId,a.Code as MainCode,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType, b.* from SF_FK_EquipmentCostSchedule a inner join SF_FK_EquipmentCostSchedule_dtl b on a.id = b.masterid left join(select c.mat_guid,c.MatMoney, b.scheduledtlid from SF_CG_PurchasePlan a inner join SF_CG_PurchasePlanList b on a.id = b.masterid left join(select b.mat_guid,sum(isnull(MatMoney,0)) as MatMoney from PS_CM_SubContract a inner join PS_CM_SubContract_MatItem b on a.id = b.masterid where a.status = 50 group by  b.mat_guid)c on b.id = c.mat_guid)d on b.id = d.scheduledtlid where a.EpsId = 'C8A39D6C-1951-4CFB-A5BC-AF638506AA6A' order by b.sequ

