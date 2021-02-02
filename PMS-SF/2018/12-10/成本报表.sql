select * from PB_Widget where id='f06c7dd0-3b5f-44d1-82ea-f3d9817649f5'
--/PowerPlat/FormXml/zh-CN/SF_FK/Win_SF_CostCompared.htm

select * from PLN_project where project_name = '项目部项目'

select * from SF_FK_EquipmentCostSchedule_dtl


select Isnull(d.MatMoney,0) as RealPrice,ISNULL(b.Price,0) as CostPrice,(Isnull(d.MatMoney,0) - ISNULL(b.Price,0)) as RealDiff , d.scheduledtlid, a.Id as MainId,a.Code as MainCode,a.EpsId,a.EpsCode,a.EpsName,a.SceduleType,
b.* from SF_FK_EquipmentCostSchedule a inner join SF_FK_EquipmentCostSchedule_dtl b on a.id = b.masterid
left join(select c.mat_guid,c.MatMoney, b.scheduledtlid from SF_CG_PurchasePlan a inner join SF_CG_PurchasePlanList b on a.id = b.masterid
left join(select b.mat_guid,sum(isnull(MatMoney,0)) as MatMoney from PS_CM_SubContract a inner join
PS_CM_SubContract_MatItem b on a.id = b.masterid where a.status = 50 group by  b.mat_guid)c on b.id = c.mat_guid)d
on b.id = d.scheduledtlid  order by b.sequ


select (isnull(b.price,0) - isnull(d.MatMoney,0)) as ce, d.MatMoney,d.scheduledtlid, b.* from SF_FK_EquipmentCostSchedule a
inner join PB_DefaultField s on a.Id = s.DefaultFieldId
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

where 1=1 and s.Status=50
order by b.sequ

select * from SF_FK_EquipmentCostSchedule

--建筑
--建筑目标
select ISNULL(fk.fk_price,0) as RealPrice, ISNULL(dr.dr_price,0) DrawPrice,ISNULL(b.Price,0) as CostPrice,
--差额（目标-预算）
(ISNULL(b.Price,0)- ISNULL(dr.dr_price,0)) as Diff1,
--差额（预算-实际）
(ISNULL(b.Price,0)-ISNULL(fk.fk_price,0)) as Diff2,
b.* from SF_FK_EstablishCostSchedule a
inner join PB_DefaultField s on a.Id = s.DefaultFieldId
inner join SF_FK_EstablishCostSchedule_dtl b on a.ID = b.masterid
--施工图预算
left join(
   select b.listId,sum(isnull(b.price,0)) as dr_price from SF_DrawingBudget a
   inner join SF_DrawingBudget_dtl b on a.id = b.masterid
   group by b.listId
)dr on b.id = dr.listId
--实际反馈
left join(
   select b.listid,sum(isnull(b.price,0)) as fk_price from SF_FK_EstablishCostFeedback a
   inner join SF_FK_EstablishCostFeedback_dtl b on a.id = b.masterid
   group by b.listId
)fk on b.id = fk.listId
where s.Status=50
order by sequ




select ISNULL(fk.fk_price,0) as RealPrice, ISNULL(dr.dr_price,0) DrawPrice,ISNULL(b.Price,0) as CostPrice,(ISNULL(b.Price,0)- ISNULL(dr.dr_price,0)) as Diff1,(ISNULL(b.Price,0)-ISNULL(fk.fk_price,0)) as Diff2,b.* from SF_FK_EstablishCostSchedule a inner join PB_DefaultField s on a.Id = s.DefaultFieldId inner join SF_FK_EstablishCostSchedule_dtl b on a.ID = b.masterid left join(select b.listId,sum(isnull(b.price,0)) as dr_price from SF_DrawingBudget a inner join SF_DrawingBudget_dtl b on a.id = b.masterid group by b.listId)dr on b.id = dr.listId left join(select b.listid,sum(isnull(b.price,0)) as fk_price from SF_FK_EstablishCostFeedback a inner join SF_FK_EstablishCostFeedback_dtl b on a.id = b.masterid group by b.listId)fk on b.id = fk.listId where s.Status=50 order by sequ

select '['+ code+','+Title+']' from SF_FK_EstablishCostSchedule for xml path('')

select ','+Title from SF_FK_EstablishCostSchedule for xml path('')