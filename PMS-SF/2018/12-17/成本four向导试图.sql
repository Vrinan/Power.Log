create view View_SF_Establishfour
as
select a.EpsId,b.*,d.backQuantity,d.backPrice,(b.Quantity-d.backQuantity) as syl,(b.Price-d.backPrice) as syhj from SF_FK_EstablishCostSchedule a left join
PB_DefaultField c on a.Id = c.DefaultFieldId
left join SF_FK_EstablishCostSchedule_dtl b on a.Id = b.MasterId
inner join
(
select b.ListId, sum(b.Quantity) as backQuantity,sum(b.Price) as backPrice from SF_FK_EstablishCostFeedback a left join SF_FK_EstablishCostFeedback_dtl b on a.Id = b.MasterId group by b.ListId
) d
on d.ListId = b.Id

--select * from SF_FK_EstablishCostFeedback_dtl where listid is null
--select * from SF_FK_EstablishCostFeedback where id ='BCD233D0-11FF-424F-A244-5AC1A0C0863E'


