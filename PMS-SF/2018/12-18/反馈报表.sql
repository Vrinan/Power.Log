select b.predictionPrice,b.ListId from SF_FK_Establishfour a left join SF_FK_Establishfour_dtl b on a.Id = b.MasterId
where a.Id = (
select top 1 Id from SF_FK_Establishfour where Status=50 and EpsId='73EB864C-C476-4079-B756-08E4D5BF3978' order by RegDate desc
)

select isnull(ys.predictionPrice,0) as predictionPrice,case when b.Name='±ä¸ü' then  '11' when b.Name='Ç©Ö¤' then '33' else ISNULL(fk.fk_price,0) end as RealPrice, 
ISNULL(dr.dr_price,0) DrawPrice,ISNULL(b.Price,0) as CostPrice,(ISNULL(b.Price,0)- ISNULL(dr.dr_price,0)) as Diff1,
(ISNULL(b.Price,0)-ISNULL(fk.fk_price,0)) as Diff2,b.* from SF_FK_EstablishCostSchedule a 
inner join PB_DefaultField s on a.Id = s.DefaultFieldId 
inner join SF_FK_EstablishCostSchedule_dtl b on a.ID = b.masterid 
left join
(select b.listId,sum(isnull(b.price,0)) as dr_price from SF_DrawingBudget a 
inner join SF_DrawingBudget_dtl b on a.id = b.masterid group by b.listId)dr on b.id = dr.listId 
left join(select b.listid,sum(isnull(b.price,0)) as fk_price from SF_FK_EstablishCostFeedback a 
inner join SF_FK_EstablishCostFeedback_dtl b on a.id = b.masterid group by b.listId)fk on b.id = fk.listId


left join (select b.predictionPrice,b.ListId from SF_FK_Establishfour a left join SF_FK_Establishfour_dtl b on a.Id = b.MasterId where a.Id = (select top 1 Id from SF_FK_Establishfour where Status=50 and 1=2 and EpsId='73EB864C-C476-4079-B756-08E4D5BF3978' order by RegDate desc)) ys on b.Id = ys.ListId
where s.Status=50 and a.EpsId='73EB864C-C476-4079-B756-08E4D5BF3978' order by sequ


select * from SF_FK_Establishfour_dtl where MasterId='6E1738A5-8F10-4D47-8F21-82CA3013197F'

update SF_FK_Establishfour_dtl set predictionPrice=3333 where MasterId='6E1738A5-8F10-4D47-8F21-82CA3013197F'